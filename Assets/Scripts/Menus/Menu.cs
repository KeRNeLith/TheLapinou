using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour 
{
	// cursor
	public Texture2D cursorTexture;
	private CursorMode cursorMode = CursorMode.Auto;
	private Vector2 hotSpot = Vector2.zero;

	// Textures
	public Texture playButton;
	public Texture OptionsButton;
	public Texture AboutButton;
	public Texture QuitButton;

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
		textureWidth = playButton.width;
		//textureHeight = playButton.height;
		xPosition = ( screenWidth / 2 ) - ( textureWidth / 2 );
		yPosition = ( screnHeight / 2 );
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	void OnGUI ()
	{
		GUI.DrawTexture(new Rect (xPosition,yPosition-170,200,80), playButton);
		Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
		if (GUI.Button (new Rect (xPosition,200,200,80), "")) 
		{
			Application.LoadLevel ("Level001");	// ou une intro ou un menu de selection de niveau
		}
		GUI.DrawTexture(new Rect (xPosition,yPosition-70,200,80), OptionsButton);
		if (GUI.Button (new Rect (xPosition,300,200,80), "")) 
		{
			Application.LoadLevel ("OptionsMenu");
		}
		GUI.DrawTexture(new Rect (xPosition,yPosition+30,200,80), AboutButton);
		if (GUI.Button (new Rect (xPosition,400,200,80), "")) 
		{
			Application.LoadLevel ("auteurs");
		}
		GUI.DrawTexture(new Rect (xPosition,yPosition+130,200,80), QuitButton);
		if (GUI.Button (new Rect (xPosition,500,200,80), "")) 
		{
			Application.Quit();
		}
	}

	void Awake() 
	{
		// see if we've got menu music still playing
		GameObject GameMusic  = GameObject.Find("GameMusic");
		if (!GameMusic) 
		{
			// kill menu music
			Destroy(GameMusic);
		}
		// make sure we survive going to different scenes
		//DontDestroyOnLoad(gameObject);
	}

}
