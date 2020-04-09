using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class buttonBehaviour : MonoBehaviour
{
    public LED_Behaviour LED;
    public bool state;
    public UnityEvent monitorActivator;

    // Start is called before the first frame update
    void Start()
    {
        if (LED != null)
        {
            setState(state);
        }
    }

    public void turnOn()
    {
        state = true;
        LED.setState(state);
    }

    public void turnOff()
    {
        state = false;
        LED.setState(state);
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

    #region flatScreen Controlls


    private void OnMouseUp()
    {
        monitorActivator.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "controller")
        {
            monitorActivator.Invoke();
        }
    }
    #endregion
}
