using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public static GameObject _camera;
    public float cameraSpeed = 0.5f;

    public bool canFly = false;

    Vector3 relFwd;
    Vector3 relRight;

 
    public Transform defaultTarget;

    public Transform target;
    // Start is called before the first frame update

    private void Awake()
    {
        _camera = gameObject;
    }
    void Start()
    {
        target = defaultTarget;
    }

    // Update is called once per frame
    void Update()
    {
        handleKeyboardInput();
    }

    public void handleKeyboardInput()
    {
        if (canFly)
        {
            transform.LookAt(target);
            relFwd = (target.position - transform.position).normalized;
            relRight = Vector3.Cross(Vector3.up, relFwd).normalized;

            if (Input.GetKey(KeyCode.Keypad8))
            {
                transform.position += relFwd * cameraSpeed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.Keypad5))
            {
                transform.position += relFwd * -cameraSpeed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.Keypad4))
            {
                transform.position += relRight * -cameraSpeed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.Keypad6))
            {
                transform.position += relRight * cameraSpeed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.Keypad9))
            {
                transform.position += Vector3.up * cameraSpeed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.Keypad7))
            {
                transform.position += Vector3.up * -cameraSpeed * Time.deltaTime;
            }
        }

    }

    
}
