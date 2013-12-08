using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void Awake() 
	{
		// see if we've got menu music still playing
		GameObject MenuMusic  = GameObject.Find("MusicMenu");
		if (MenuMusic) 
		{
			// kill menu music
			Destroy(MenuMusic);
		}
		// make sure we survive going to different scenes
		//DontDestroyOnLoad(gameObject);
	}
}
