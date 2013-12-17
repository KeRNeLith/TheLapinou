using UnityEngine;
using System.Collections;

public class Interface : MonoBehaviour {

	// Message à afficher si on a perdu toute sa vie
	public GUIText gameOver;

	// Joueur
	public PlayerController player;

	// Use this for initialization
	void Start () 
	{
		gameOver.enabled = false;
		gameOver.text = "Game Over";
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!player.getAlive())
		{
			gameOver.enabled = true;
			Time.timeScale = 0;
		}
	}
}
