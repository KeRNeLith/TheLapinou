using UnityEngine;
using System.Collections;

public class mainScene : MonoBehaviour 
{
	// cursor
	public Texture2D cursorTexture;
	private CursorMode cursorMode = CursorMode.Auto;
	private Vector2 hotSpot = Vector2.zero;

	// Textures
	public Texture startButton;

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
		textureWidth = startButton.width;
		//textureHeight = startButton.height;
		xPosition = ( screenWidth / 2 ) - ( textureWidth / 2 );
		yPosition = ( screnHeight / 2 );
	}
	
	// Update is called once per frame
	void Update () 
	{
		// if espace , enter , echap pressed changer la scene
		if(Input.GetKeyDown(KeyCode.Escape) ||
		   Input.GetKeyDown(KeyCode.Space) ||
		   Input.GetKeyDown(KeyCode.KeypadEnter) ||
		   Input.GetKeyDown(KeyCode.Return) ||
		   Input.GetKeyDown(KeyCode.E) ||
		   Input.GetKeyDown(KeyCode.F) )
		   loadMenu();
	}


	void OnGUI () 
	{
		GUI.DrawTexture(new Rect (xPosition,yPosition,200,80), startButton);
		Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
		if (GUI.Button (new Rect (xPosition,yPosition,200,80), "")) 
		{
			loadMenu();
		}
	}

	void loadMenu()
	{
		Application.LoadLevel ("Menu");
	}


}
