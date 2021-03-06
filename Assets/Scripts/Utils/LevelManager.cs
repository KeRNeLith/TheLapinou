﻿using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour 
{
	// Nombre de clés requises pour le niveau en cours
	private int nbRequiredKeys = 0;

	// Message à afficher quand on s'approche de la porte
	public GUIText doorMessage;

	// Joueur
	private PlayerController player;

	// Numéro du level suivant
	private int nextLevel = 1;

	// Musique du niveau
	public AudioClip backgroundSound;

	// Use this for initialization
	void Start () 
	{
		// Détermine le numéro du niveau suivant
		string sceneName = Application.loadedLevelName;
		string[] splitedName = sceneName.Split('_');
		nextLevel += int.Parse(splitedName[1]);

		// Détermine le nombre de clés requises pour terminer le niveau
		GameObject[] keys = GameObject.FindGameObjectsWithTag("Key");
		nbRequiredKeys = keys.Length;

		player = FindObjectOfType(System.Type.GetType("PlayerController")) as PlayerController;

		// Ajoute le niveau en cours au playerPref comme non fini
		if (!PlayerPrefsX.GetBool(Application.loadedLevelName, false))
			PlayerPrefsX.SetBool(Application.loadedLevelName, false);

		doorMessage.enabled = false;

		audio.PlayOneShot(backgroundSound);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (audio.isPlaying)
			audio.PlayOneShot(backgroundSound);
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
					string levelToLoad = "Level_" + nextLevel;
					if (Application.CanStreamedLevelBeLoaded(levelToLoad))
					{
						// Marque le niveau comme terminé et chage le suivant
						PlayerPrefsX.SetBool(Application.loadedLevelName, true);
						Application.LoadLevel(levelToLoad);
					}
					else
						Application.LoadLevel("selectLevel");
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
