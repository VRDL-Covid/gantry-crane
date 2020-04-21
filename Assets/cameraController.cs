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
    Quaternion defaultRotation;

    float width;
    float height;

 
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
        width = Screen.width;
        height = Screen.height;
        defaultRotation = gameObject.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        handleKeyboardInput();
        handleLook();
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

    public void handleLook()
    {
        float horizontalRotation = 0;
        float verticalRotation = 0;
        Vector2 mp;
        mp = Input.mousePosition;
        if (!Input.GetMouseButton(0))
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(defaultRotation.eulerAngles + new Vector3(Mathf.Lerp(30, -10, mp.y / height), Mathf.Lerp(-90, 90, mp.x / width), 0)),5f*Time.deltaTime);
        }
        

    }
}
