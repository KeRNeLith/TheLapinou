﻿using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour 
{
	// Nombre de clés requises pour le niveau en cours
	public int nbRequiredKeys = 1;
	private int nbKeyCollected = 0;

	// Message à afficher quand on s'approche de la porte
	public GUIText doorMessage;

	// Use this for initialization
	void Start () 
	{
		doorMessage.enabled = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			// Charge et affiche le bon message en fonction du nombre de clés rammassées
			nbKeyCollected = other.gameObject.GetComponent<PlayerController>().getNbKeyCollected();

			if (nbKeyCollected >= nbRequiredKeys)
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
			if (nbKeyCollected >= nbRequiredKeys)
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