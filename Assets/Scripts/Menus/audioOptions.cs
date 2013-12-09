using UnityEngine;
using System.Collections;

public class audioOptions : MonoBehaviour 
{
	// curseur
	public Texture2D cursorTexture;
	private CursorMode cursorMode = CursorMode.Auto;
	private Vector2 hotSpot = Vector2.zero;
	
	// Textures
	public Texture backButton;

	// Meme ratio sur toute résolutions
	// on peut modifier la scale des boutons et texture via ces variables pour que la taille des boutons ai la meme taille sur n'importe quel résolution
	private int screenWidth;
	private int screnHeight;
	private int textureHeight;
	private int textureWidth;
	private float xPosition;
	private float yPosition;

	// Volume
	private float musicMenuValue;
	private bool musicMenuEnabled;


	// Use this for initialization
	void Start () 
	{
		screenWidth = Screen.width;
		screnHeight = Screen.height;
		textureWidth = backButton.width;
		textureHeight = backButton.height;
		xPosition = ( screenWidth / 2 ) - ( textureWidth / 2 );
		yPosition = ( screnHeight / 2 ) - ( textureHeight / 2 );

		musicMenuValue = PlayerPrefs.GetFloat("menuMusicVolume");
		musicMenuEnabled = PlayerPrefsX.GetBool("menuMusicVolumeEnabled");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown("escape"))
			Application.LoadLevel("OptionsMenu");
	}

	void OnGUI () 
	{
		musicMenuEnabled = GUI.Toggle(new Rect(820, 134, 110, 30), musicMenuEnabled, " : Menu Volume");
		musicMenuValue = GUI.HorizontalSlider(new Rect(700, 140, 100, 30), musicMenuValue, 0.0F, 1.0F);
		PlayerPrefs.SetFloat("menuMusicVolume" , musicMenuValue);
		PlayerPrefsX.SetBool("menuMusicVolumeEnabled", musicMenuEnabled);


		GUI.DrawTexture(new Rect (xPosition,yPosition*2-100,textureWidth,textureHeight), backButton);
		if (GUI.Button (new Rect (xPosition,yPosition*2-100,textureWidth,textureHeight), "")) 
		{
			Application.LoadLevel("OptionsMenu");
		}
	}
}
