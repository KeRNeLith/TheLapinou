using UnityEngine;
using System.Collections;

public class videoOptions : MonoBehaviour 
{
	// cursor
	public Texture2D cursorTexture;
	private CursorMode cursorMode = CursorMode.Auto;
	private Vector2 hotSpot = Vector2.zero;
	
	// Textures
	public Texture backButton;

	// Meme ratio sur toute résolutions
	// on peut modifier la scale des boutons et texture via ces variables pour que la taille des boutons ai la meme taille sur n'importe quel résolution
	private int screenWidth;
	private int screnHeight;
	//private int textureHeight;
	private int textureWidth;
	private float xPosition;
	private float yPosition;


	// Use this for initialization
	void Start () 
	{
		screenWidth = Screen.width;
		screnHeight = Screen.height;
		textureWidth = backButton.width;
		//textureHeight = backButton.height;
		xPosition = ( screenWidth / 2 ) - ( textureWidth / 2 );
		yPosition = ( screnHeight / 2 );
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown("escape"))
			Application.LoadLevel("OptionsMenu");
	}

	void OnGUI () 
	{
		GUILayout.BeginHorizontal();
		for (int i = 0; i < Screen.resolutions.Length ; i++ )
		{
			if (GUILayout.Button(Screen.resolutions[i].width + " x " + Screen.resolutions[i].height))
			{
				Screen.SetResolution(Screen.resolutions[i].width,Screen.resolutions[i].height,true);
			}
		}
		GUILayout.EndHorizontal();



		GUI.DrawTexture(new Rect (xPosition,yPosition*2-100,200,80), backButton);
		if (GUI.Button (new Rect (xPosition,yPosition*2-100,200,80), "")) 
		{
			Application.LoadLevel("OptionsMenu");
		}
	}
}
