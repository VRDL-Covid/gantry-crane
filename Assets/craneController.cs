using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class craneController : MonoBehaviour
{

    public float craneSpeed = 0.5f;
    public float truckSpeed = 0.5f;
    public float hookSpeed = 0.5f;

    public analogueControllerBehaviour controller;
    public analogueControllerBehaviour hookController;
    public GameObject truck;
 //   public GameObject Hook;
    public GameObject Chain;
    public ChainSpawn ChainSpawn;
    private void Start()
    {
        ChainSpawn = Chain.GetComponent(typeof(ChainSpawn)) as ChainSpawn;
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
        //Hook.transform.position +=  Vector3.up * hookSpeed * hookController.outputY * Time.deltaTime;
        print(hookController.outputY);

        if (hookController.outputY > 0f)
        {
            hookUp();
        }
        else if(hookController.outputY < 0f)
        {
            hookDown();
        }
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
        transform.position = transform.position + Vector3.forward * craneSpeed * Time.deltaTime;
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
        ChainSpawn.RaiseChain();
        
    }

    public void hookDown()
    {
        ChainSpawn.LowerChain();
    }
}
