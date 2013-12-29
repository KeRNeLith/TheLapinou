using UnityEngine;
using System.Collections;

public class ShowHelp : MonoBehaviour 
{
	private GUIText message;
	public TextMesh info;

	// Use this for initialization
	void Start () 
	{
		message = transform.FindChild("Message").guiText;
		message.enabled = false;
		info.renderer.enabled = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			message.enabled = true;
			info.renderer.enabled = false;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			message.enabled = false;
			info.renderer.enabled = true;
		}
	}
}
