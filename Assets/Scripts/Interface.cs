using UnityEngine;
using System.Collections;

public class Interface : MonoBehaviour {

	// Message à afficher si on a perdu toute sa vie
	public GUIText gameOver;

	// Joueur
	public PlayerController player;

	// Textures barre de vie
	public GUITexture healthTextureEmpty;
	public GUITexture healthTexture;

	// Use this for initialization
	void Start () 
	{
		gameOver.enabled = false;
		gameOver.text = "Game Over";

		// Placement de la barre de vie (remplissage) => en dehors de l'écran pour subir un offset par la suite pour simuler son mouvement
		healthTexture.pixelInset = new Rect(-Screen.width/2 + 0.05f*Screen.width - healthTextureEmpty.texture.width,
		                                    Screen.height/2 - 1.5f*healthTextureEmpty.texture.height,
		                                    healthTexture.texture.width,
		                                    healthTexture.texture.height);

		// Placement de la barre de vie (contour)
		healthTextureEmpty.pixelInset = new Rect(-Screen.width/2 + 0.05f*Screen.width,
		                                         Screen.height/2 - 1.5f*healthTextureEmpty.texture.height,
		                                         healthTextureEmpty.texture.width,
		                                         healthTextureEmpty.texture.height);
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

	void LateUpdate()
	{
		// Actualisation de la barre de vie
		// en déterminant l'offset en pixel à appliquer à la texture de remplissage
		int hpBarLenght = (int) (healthTexture.texture.width + 194*((double)player.getHealth()/(double)player.getMaxHealth()));

		healthTexture.border = new RectOffset(hpBarLenght, 0, 0, 0);
	}
}