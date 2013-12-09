using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Camera playerCamera;
	public Camera fixedLevelCamera;

	// Use this for initialization
	void Start () 
	{
		fixedLevelCamera.enabled = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyUp(KeyCode.Tab))
		{
			switchCamera();
		}
	}

	void switchCamera()
	{
		fixedLevelCamera.enabled = !fixedLevelCamera.enabled;
		playerCamera.enabled = !playerCamera.enabled;
	}
}
