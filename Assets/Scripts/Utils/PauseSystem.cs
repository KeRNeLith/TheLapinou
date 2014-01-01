using UnityEngine;
using System.Collections;

public class PauseSystem : MonoBehaviour 
{
	// Booleen de pause
	private bool pause;

	// Joueur
	private PlayerController player;
	
	void Start() // le jeu n'est pas en pause au départ
	{
		player = FindObjectOfType(System.Type.GetType("PlayerController")) as PlayerController;
		pause = false;
		player.setPause(pause);
	}
	
	
	void Update()
	{
		// si on appuie sur "Escape" change l'état du jeu
		if(Input.GetButtonDown("Menu"))
		{
			pause = !pause;
			player.setPause(pause);
		}
	}

	void OnGUI()
	{
		if(!pause)
		{
			// désactive le curseur durant le level
			Screen.showCursor = false;
			return;
		}
		// active le curseur durant le menu de pause
		Screen.showCursor = true;

		GUILayout.BeginArea(new Rect(Screen.width/2-50, Screen.height/2-50, 100, 100));
			
		if(GUILayout.Button("Continuer"))
		{
			pause = false;
			player.setPause(pause);
		}

		if(GUILayout.Button("Recommencer"))
			Application.LoadLevel(Application.loadedLevel);
			
		if(GUILayout.Button("Menu"))
			Application.LoadLevel("selectLevel");
			
		GUILayout.EndArea();
	}
}
