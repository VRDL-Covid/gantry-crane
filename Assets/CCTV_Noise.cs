using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCTV_Noise : MonoBehaviour
{

    Material mat;
    public analogueControllerBehaviour controller;

    // Start is called before the first frame update
    void Start()
    {
        mat = gameObject.GetComponent<Renderer>().material;
    }

   
    // Update is called once per frame
    void Update()
    {
        mat.SetFloat("strength", Mathf.Abs(Mathf.Max(controller.outputX, controller.outputY)));
    }
}
