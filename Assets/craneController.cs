using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class craneController : MonoBehaviour
{

    public float craneSpeed = 0.5f;
    public float truckSpeed = 0.5f;
    public float hookSpeed = 0.5f;

    public analogueControllerBehaviour controller;
    public GameObject hook;
    public GameObject truck;
    Transform camera;
    private void Start()
    {
        camera = cameraController._camera.transform;
    }

    // Update is called once per frame
    void Update()
    {
        handleKeyboardInput();

        handleControllerConnection();
    }

    void handleControllerConnection()
    {
        transform.position += controller.outputY * Vector3.forward * craneSpeed * Time.deltaTime;
        truck.transform.position += controller.outputX * Vector3.right * craneSpeed * Time.deltaTime;
    }

    private void handleKeyboardInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            moveForward();
        }

        if (Input.GetKey(KeyCode.S))
        {
            moveBackward();
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveRight();
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveLeft();
        }

        if (Input.GetKey(KeyCode.Q))
        {
            hookDown();
        }

        if (Input.GetKey(KeyCode.E))
        {
            hookUp();
        }
    }

    public void moveForward()
    {
        transform.position = transform.position + Vector3.forward * craneSpeed * Time.deltaTime ;
    }

    public void moveBackward()
    {
        transform.position = transform.position + Vector3.forward * -craneSpeed * Time.deltaTime;
    }

    public void moveRight()
    {
        truck.transform.position = truck.transform.position + Vector3.right * truckSpeed * Time.deltaTime;
    }

    public void moveLeft()
    {
        truck.transform.position = truck.transform.position + Vector3.right * -truckSpeed * Time.deltaTime;
    }

    public void hookUp()
    {
        //hook.transform.position = hook.transform.position + Vector3.up * hookSpeed * Time.deltaTime;
        if (camera.GetComponent<cameraController>().canFly)
        {
            camera.position += Vector3.up * hookSpeed * Time.deltaTime;
        }
        
    }

    public void hookDown()
    {
        //hook.transform.position = hook.transform.position + Vector3.up * -hookSpeed * Time.deltaTime;
        if (camera.GetComponent<cameraController>().canFly)
        {
            camera.position += Vector3.up * -hookSpeed * Time.deltaTime;
        }
    }
}

