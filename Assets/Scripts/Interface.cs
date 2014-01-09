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

	// Textures barre d'énergie
	public GUITexture energyTextureEmpty;
	public GUITexture energyTexture;

	// Use this for initialization
	void Start () 
	{
		gameOver.enabled = false;
		gameOver.text = "Game Over";

		updateBarsPosition();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!player.getAlive())
		{
			gameOver.enabled = true;
			Time.timeScale = 0;
		}
		updateBarsPosition();
	}

	void LateUpdate()
	{
		// Actualisation de la barre de vie
		// en déterminant l'offset en pixel à appliquer à la texture de remplissage
		int hpBarLenght = (int) (healthTexture.texture.width + 194*((double)player.getHealth()/(double)player.getMaxHealth()));
		healthTexture.border = new RectOffset(hpBarLenght, 0, 0, 0);

		// Actualisation de la barre d'énergie
		// en déterminant l'offset en pixel à appliquer à la texture de remplissage
		int energyBarLenght = (int) (energyTexture.texture.width + 194*((double)player.getEnergy()/(double)player.getMaxEnergy()));
		energyTexture.border = new RectOffset(energyBarLenght, 0, 0, 0);
	}

	void updateBarsPosition()
	{
		// Barre de vie
		// Placement de la barre de vie (remplissage) => en dehors de l'écran pour subir un offset par la suite pour simuler son mouvement
		healthTexture.pixelInset = new Rect(-Screen.width/2 + 0.05f*Screen.width - healthTexture.texture.width,
		                                    Screen.height/2 - 1.5f*healthTexture.texture.height,
		                                    healthTexture.texture.width,
		                                    healthTexture.texture.height);
		
		// Placement de la barre de vie (contour)
		healthTextureEmpty.pixelInset = new Rect(-Screen.width/2 + 0.05f*Screen.width,
		                                         Screen.height/2 - 1.5f*healthTextureEmpty.texture.height,
		                                         healthTextureEmpty.texture.width,
		                                         healthTextureEmpty.texture.height);
		
		// Barre d'énergie
		// Placement de la barre de vie (remplissage) => en dehors de l'écran pour subir un offset par la suite pour simuler son mouvement
		energyTexture.pixelInset = new Rect(-Screen.width/2 + 0.05f*Screen.width - energyTexture.texture.width,
		                                    Screen.height/2 - 3f*energyTexture.texture.height,
		                                    energyTexture.texture.width,
		                                    energyTexture.texture.height);
		
		// Placement de la barre de vie (contour)
		energyTextureEmpty.pixelInset = new Rect(-Screen.width/2 + 0.05f*Screen.width,
		                                         Screen.height/2 - 3f*energyTextureEmpty.texture.height,
		                                         energyTextureEmpty.texture.width,
		                                         energyTextureEmpty.texture.height);
	}
}