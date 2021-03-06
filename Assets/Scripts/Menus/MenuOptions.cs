﻿using UnityEngine;
using System.Collections;

public class MenuOptions : MonoBehaviour 
{
	// curseur
	public Texture2D cursorTexture;
	private CursorMode cursorMode = CursorMode.Auto;
	private Vector2 hotSpot = Vector2.zero;

	// Textures
	public Texture backButton;
	public Texture videoButton;
	public Texture audioButton;
	public Texture gameButton;

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
		textureWidth = backButton.width;
		textureHeight = backButton.height;
		xPosition = ( screenWidth / 2 ) - ( textureWidth / 2 );
		yPosition = ( screnHeight / 2 ) - ( textureHeight / 2 );
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown("escape"))
			Application.LoadLevel("Menu");
	}

	void OnGUI () 
	{
		GUI.DrawTexture(new Rect (xPosition,yPosition-170,textureWidth,textureHeight), gameButton);	// Options jeu
		Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
		if (GUI.Button (new Rect (xPosition,yPosition-170,textureWidth,textureHeight), "")) 
		{
			Application.LoadLevel ("gameOptions");	// ou une intro ou un menu de selection de niveau
		}
		GUI.DrawTexture(new Rect (xPosition,yPosition-70,textureWidth,textureHeight), audioButton);	// Options audio
		if (GUI.Button (new Rect (xPosition,yPosition-70,textureWidth,textureHeight), "")) 
		{
			Application.LoadLevel ("audioOptions");
		}
		GUI.DrawTexture(new Rect (xPosition,yPosition+30,textureWidth,textureHeight), videoButton);	// Options video
		if (GUI.Button (new Rect (xPosition,yPosition+30,textureWidth,textureHeight), "")) 
		{
			Application.LoadLevel ("videoOptions");
		}


		GUI.DrawTexture(new Rect (xPosition,yPosition+130,textureWidth,textureHeight), backButton);
		if (GUI.Button (new Rect (xPosition,yPosition+130,textureWidth,textureHeight), "")) 
		{
			Application.LoadLevel("Menu");
		}
	}

}
