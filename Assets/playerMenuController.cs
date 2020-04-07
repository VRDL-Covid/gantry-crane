using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMenuController : MonoBehaviour
{
    public GameObject VRPlayer;
    public GameObject flatScreenPlayer;

    public Dropdown option;
    
    public void startSimulation()
    {
        if(option.value == 0)
        {
            VRPlayer.SetActive(true);
        }

        if (option.value == 1)
        {
            flatScreenPlayer.SetActive(true);
        }

        gameObject.SetActive(false);
    }
}
