
using UnityEngine;
using Valve.VR;

public class VRControllerAPI : MonoBehaviour
{

	public SteamVR_Input_Sources handType;
	public bool getGripUp()
	{
		return SteamVR_Actions.default_GrabGrip.GetStateUp(handType);
	}
	
	public bool getGripDown()
	{
		return SteamVR_Actions.default_GrabGrip.GetStateDown(handType);
	}
	
	public bool getGrip()
	{
		return SteamVR_Actions.default_GrabGrip.GetState(handType);
	}

}
