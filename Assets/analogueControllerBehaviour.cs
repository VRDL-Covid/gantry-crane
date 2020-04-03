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
    // Start is called before the first frame update
    void Start()
    {
        defaultRotation = bone.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        handleFlatScreen();
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

        Debug.Log("outputY = " + outputY);
    }
}
