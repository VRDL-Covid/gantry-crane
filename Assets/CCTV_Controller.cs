using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCTV_Controller : MonoBehaviour
{
    public analogueControllerBehaviour controller;

    public float zoomRate = 1.0f;
    public float panRate = 1.0f;

    public bool invertY;
    Camera camera;

    private void Start()
    {
        camera = gameObject.GetComponent<Camera>();
    }



    private void Update()
    {

        transform.Rotate(0, controller.outputX * panRate * Time.deltaTime, 0, Space.Self);

        transform.Rotate(-controller.outputY * panRate * Time.deltaTime, 0, 0, Space.Self);

        //Todo - gwc impliment VR Zoom
        /*
        if(controller.controller != null)
        {
            if (controller.controller.GetComponent<VRControllerAPI>.getTrigger())
            {

            }
        }
        camera.fieldOfView -=
        */
    }






}
