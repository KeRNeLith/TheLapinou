using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour 
{
	// Nombre de clés requises pour le niveau en cours
	public int nbRequiredKeys = 1;

	// Message à afficher quand on s'approche de la porte
	public GUIText doorMessage;
	// Message à afficher si on a perdu toute sa vie
	public GUIText gameOver;

	// Joueur
	public PlayerController player;

	// Use this for initialization
	void Start () 
	{
		doorMessage.enabled = false;
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

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			// Charge et affiche le bon message en fonction du nombre de clés rammassées
			if (player.getNbKeyCollected() >= nbRequiredKeys)
				doorMessage.text = "Appuyer sur E pour ouvrir";
			else
				doorMessage.text = "Il vous faut plus de clés !";

			doorMessage.enabled = true;
			return;
		}
	}

	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			if (player.getNbKeyCollected() >= nbRequiredKeys)
			{
				doorMessage.text = "Appuyer sur E pour ouvrir";
				if (Input.GetKey(KeyCode.E))
				{
					// Charge lvl suivant
					Debug.Log("Charge lvl suivant");
				}
			}
			else
				doorMessage.text = "Il vous faut plus de clés !";

			return;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			doorMessage.enabled = false;
			return;
		}
	}
}
