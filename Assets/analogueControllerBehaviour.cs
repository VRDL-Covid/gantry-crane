using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class analogueControllerBehaviour : MonoBehaviour
{
    public bool X_motion = true;
    public bool Y_motion = true;
    public GameObject bone;
    public float rotateRate = 1.0f;

    public float rangeLimit = 45f;

    public float outputX = 0.0f;
    public float outputY = 0.0f;

    Quaternion defaultRotation;
    bool mouseOver;
    bool heldMouse;

    [HideInInspector]
    public GameObject controller;
    bool isHeld;
    Vector3 heldPos, heldOffset;
    public float handRange = 0.1f;
    
    // Start is called before the first frame update
    void Start()
    {
        defaultRotation = bone.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        handleFlatScreen();
        handleVRBehabiour();
    }

    private void OnMouseOver()
    {
        mouseOver = true;
    }

    private void OnMouseExit()
    {
        mouseOver = false;
    }

    void handleFlatScreen()
    {
        if (mouseOver)
        {
            if (Input.GetMouseButtonDown(0))
            {
                heldMouse = true;
            }
        }
        

        if (Input.GetMouseButtonUp(0)){
            heldMouse = false;
            bone.transform.rotation = defaultRotation;
            outputX = 0;
            outputY = 0;
        }

        if (heldMouse){
            if (X_motion){
                if(outputX<1.0f && outputX > -1.0f)
                {
                    outputX += rotateRate * Input.GetAxis("Mouse X") / rangeLimit;
                    bone.transform.Rotate(0, 0, -rotateRate * Input.GetAxis("Mouse X"));
                }

                if(outputX >= 1.0f && Input.GetAxis("Mouse X") < 0)
                {
                    outputX += rotateRate * Input.GetAxis("Mouse X") / rangeLimit;
                    bone.transform.Rotate(0, 0, -rotateRate * Input.GetAxis("Mouse X"));
                }

                if (outputX <= -1.0f && Input.GetAxis("Mouse X") > 0)
                {
                    outputX += rotateRate * Input.GetAxis("Mouse X") / rangeLimit;
                    bone.transform.Rotate(0, 0, -rotateRate * Input.GetAxis("Mouse X"));
                }
            }

            if (Y_motion)
            {
                if (outputY < 1.0f && outputY > -1.0f)
                {
                    outputY += rotateRate * Input.GetAxis("Mouse Y") / rangeLimit;
                    bone.transform.Rotate(rotateRate * Input.GetAxis("Mouse Y"), 0, 0);
                }

                if (outputY >= 1.0f && Input.GetAxis("Mouse Y") < 0)
                {
                    outputY += rotateRate * Input.GetAxis("Mouse Y") / rangeLimit;
                    bone.transform.Rotate(rotateRate * Input.GetAxis("Mouse Y"), 0, 0);
                }

                if (outputY <= -1.0f && Input.GetAxis("Mouse Y") > 0)
                {
                    outputY += rotateRate * Input.GetAxis("Mouse Y") / rangeLimit;
                    bone.transform.Rotate(rotateRate * Input.GetAxis("Mouse Y"), 0, 0);
                }
            }

            if(outputX > 1.0f)
            {
                outputX = 1.0f;
            }

            if (outputY > 1.0f)
            {
                outputY = 1.0f;
            }

            if (outputX < -1.0f)
            {
                outputX = -1.0f;
            }

            if (outputY < -1.0f)
            {
                outputY = -1.0f;
            }

        }

    }

    #region VR behaviour

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "controller" && !isHeld)
        {
            controller = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == controller && !isHeld)
        {
            controller = null;
        }
    }

    void handleVRBehabiour()
    {
        if(controller != null)
        {
            if (controller.GetComponent<VRControllerAPI>().getGripDown())
            {

                
                heldOffset = controller.transform.position - transform.position ;
                isHeld = true;
                Debug.Log(gameObject.name + " is held by: " + controller.name);
            }

            if (controller.GetComponent<VRControllerAPI>().getGripUp())
            {
                isHeld = false;
                bone.transform.rotation = defaultRotation;
                controller = null;
                outputX = 0f;
                outputY = 0f;
            }
        }

        if (isHeld)
        {
            heldPos = transform.position + heldOffset;
            float yInput = controller.transform.position.z - heldPos.z;
            float xInput = controller.transform.position.x - heldPos.x;

            if(yInput > handRange)
            {
                yInput = handRange;
            }

            if (yInput < -handRange)
            {
                yInput = -handRange;
            }


            if (xInput > handRange)
            {
                xInput = handRange;
            }

            if (xInput < -handRange)
            {
                xInput = -handRange;
            }

            bone.transform.rotation = Quaternion.Euler(defaultRotation.eulerAngles + Quaternion.Euler(yInput * 45f / handRange, 0, -xInput * 45f / handRange).eulerAngles);

            outputX = xInput / handRange;
            outputY = yInput / handRange;
        }

    }
    #endregion
}
