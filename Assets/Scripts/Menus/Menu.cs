using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour 
{
	// curseur
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
	private int textureHeight;
	private int textureWidth;
	private float xPosition;
	private float yPosition;

	// Use this for initialization
	void Start () 
	{
		screenWidth = Screen.width;
		screnHeight = Screen.height;
		textureWidth = playButton.width;
		textureHeight = playButton.height;
		xPosition = ( screenWidth / 2 ) - ( textureWidth / 2 );
		yPosition = ( screnHeight / 2 ) - (textureHeight / 2 );

		print (textureWidth);
		print (textureHeight);
		PlayerPrefs.SetInt("nbLevels",9);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	void OnGUI ()
	{
		GUI.DrawTexture(new Rect (xPosition,yPosition-170,textureWidth,textureHeight), playButton);
		Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
		if (GUI.Button (new Rect (xPosition,yPosition-170,textureWidth,textureHeight), "")) 
		{
			Application.LoadLevel ("selectLevel");	// ou une intro ou un menu de selection de niveau
		}
		GUI.DrawTexture(new Rect (xPosition,yPosition-70,textureWidth,textureHeight), OptionsButton);
		if (GUI.Button (new Rect (xPosition,yPosition-70,textureWidth,textureHeight), "")) 
		{
			Application.LoadLevel ("OptionsMenu");
		}
		GUI.DrawTexture(new Rect (xPosition,yPosition+30,textureWidth,textureHeight), AboutButton);
		if (GUI.Button (new Rect (xPosition,yPosition+30,textureWidth,textureHeight), "")) 
		{
			Application.LoadLevel ("auteurs");
		}
		GUI.DrawTexture(new Rect (xPosition,yPosition+130,textureWidth,textureHeight), QuitButton);
		if (GUI.Button (new Rect (xPosition,yPosition+130,textureWidth,textureHeight), "")) 
		{
			Application.Quit();
		}
	}

	void Awake() 
	{
		// Vérifie si une musique est déjà en train d'etre jouée
		GameObject GameMusic  = GameObject.Find("GameMusic");
		if (!GameMusic) 
		{
			// Détruit la musique
			Destroy(GameMusic);
		}
		// Permet de conserver le Menu dans les différentes scènes
		//DontDestroyOnLoad(gameObject);
	}

}
