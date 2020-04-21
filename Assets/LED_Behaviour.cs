using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LED_Behaviour : MonoBehaviour
{
    public bool state;
    public Material mat;
    public float strength = 4.0f;
    public Color color;
    private void Awake()
    {
        mat = gameObject.GetComponent<Renderer>().material;
        mat.color = color;
    }


    public void turnOn()
    {
        mat.SetColor("_EmissiveColor", color * strength);
        state = true;
    }

    public void turnOff()
    {
        mat.SetColor("_EmissiveColor", color * 0f);
        state = false;
    }

    public void setState(bool inp)
    {
        if (inp)
        {
            turnOn();
        } else
        {
            turnOff();
        }
    }
}
