using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCTV_PanelBehaviour : MonoBehaviour
{
    public buttonBehaviour birdsEyeButton;
    public buttonBehaviour tripodButton;
    public buttonBehaviour topLeftButton;
    public buttonBehaviour topRightButton;
    public buttonBehaviour bottomLeftButton;
    public buttonBehaviour bottomRightButton;

    public GameObject birdsEyeCamera;
    public GameObject tripodCamera;
    public GameObject topLeftCamera;
    public GameObject topRightCamera;
    public GameObject bottomLeftCamera;
    public GameObject bottomRightCamera;

    public RenderTexture output;

    private void Start()
    {
        birdsEyeMonitor();
    }
    void turnAllOff()
    {
        birdsEyeButton.setState(false);
        tripodButton.setState(false);
        topLeftButton.setState(false);
        topRightButton.setState(false);
        bottomLeftButton.setState(false);
        bottomRightButton.setState(false);

        //birdsEyeCamera.targetTexture = null;
        //tripodCamera.targetTexture = null;
        //topLeftCamera.targetTexture = null;
        //topRightCamera.targetTexture = null;
        //bottomLeftCamera.targetTexture = null;
        //bottomRightCamera.targetTexture = null;

        birdsEyeCamera.SetActive(false);
        tripodCamera.SetActive(false);
        topLeftCamera.SetActive(false);
        topRightCamera.SetActive(false);
        bottomLeftCamera.SetActive(false);
        bottomRightCamera.SetActive(false);

    }



    public void birdsEyeMonitor()
    {
        turnAllOff();
        birdsEyeButton.setState(true);

        birdsEyeCamera.SetActive(true);
    }

    public void tripodMonitor()
    {
        turnAllOff();
        tripodButton.setState(true);

        tripodCamera.SetActive(true);
    }

    public void topLeftMonitor()
    {
        turnAllOff();
        topLeftButton.setState(true);
        topLeftCamera.SetActive(true);
    }

    public void topRightMonitor()
    {
        turnAllOff();
        topRightButton.setState(true);
        topRightCamera.SetActive(true);
    }

    public void bottomLeftMonitor()
    {
        turnAllOff();
        bottomLeftButton.setState(true);
        bottomLeftCamera.SetActive(true);
    }

    public void bottomRightMonitor()
    {
        turnAllOff();
        bottomRightButton.setState(true);
        bottomRightCamera.SetActive(true);
    }
}
