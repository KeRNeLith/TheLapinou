using UnityEngine;
using System.Collections;

public class PlayerController : HumanoidController 
{
	// Indique si le jeu est en pause ou non
	private bool pause = false;

	// Nombre de clés possédé
	private int nbKeys = 0;

	// Vecteur de déplacement
	protected Vector3 moveDirection = Vector3.zero;
	// Permet de savoir si on est en face d'une échelle
	private bool inFrontOfLadder = false;
	
	protected CharacterController controller;
	
	// Permet de régler la vitesse de translation horizontale
	public float horizontalMovementSpeed = 35f;
	// Permet de régler la vitesse de translation verticale
	public float verticalMovementSpeed = 30f;
	// Permet de régler la vitesse des mouvements en vol
	public float flyingMoveAttenuation = 15f;
	
	// Energie pour que le joueur puisse voler
	protected float energy;
	protected float energyMax = 100;
	
	// Temps de vol maximum
	protected float maxTimeFlying;
	// Energie à perdre par seconde
	private float updateEnergyPerSecond;

	// Use this for initialization
	protected override void Start () 
	{
		Time.timeScale = 1;
		hpMax = 100;
		maxTimeFlying = 5;	// 5s de temps de vol maximum
		controller = GetComponent<CharacterController>();
		energy = 0;
		updateEnergyPerSecond = energyMax/maxTimeFlying;
		base.Start();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (pause)
			return;

		// Si on a de l'énergie et que l'on demande à voler (espace)
		if (Input.GetButton("Jump") && energy > 0)
		{
			moveDirection = new Vector3(Input.GetAxis("Horizontal") * flyingMoveAttenuation * Time.deltaTime,
			                            0.85f,
			                            0);
			// Applique la gravité
			moveDirection.y -= gravity * Time.deltaTime;
			controller.Move(moveDirection);
			// Fait baisser l'énergie
			energyUpdate(-Time.deltaTime*updateEnergyPerSecond);
		}
		else
		{
			float lateralMove = Input.GetAxis("Horizontal") * horizontalMovementSpeed * Time.deltaTime;
			float verticalMove = 0;
			// Si on est en face d'une echelle, on autorise la translation verticale
			if (inFrontOfLadder)
			{
				verticalMove = Input.GetAxis("Vertical") * verticalMovementSpeed * Time.deltaTime;
			}
			moveDirection = new Vector3(lateralMove, verticalMove, 0);
			// Applique la gravité
			moveDirection.y -= gravity * Time.deltaTime;
			// Applique les mouvements
			controller.Move(moveDirection);
		}
	}

	// Test les Triggers
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Key")
		{
			nbKeys++;
			DestroyObject(other.gameObject);
			return;
		}
		else if (other.gameObject.tag == "Carrot")
		{
			healthUpdate(20);
			DestroyObject(other.gameObject);
			return;
		}
		else if (other.gameObject.tag == "Ladder")
		{
			inFrontOfLadder = true;
			gravity /= 2;
			return;
		}
		else if (other.gameObject.tag == "Battery")
		{
			energyUpdate(updateEnergyPerSecond*2);	// On récupère 2s de vol
			DestroyObject(other.gameObject);
			return;
		}
	}

	void OnTriggerExit(Collider other) 
	{
		if (other.gameObject.tag == "Ladder")
		{
			inFrontOfLadder = false;
			gravity *= 2;
			return;
		}
	}

	// Permet de modifier l'énergie de l'entité
	// Avec vérifications des bornes
	public void energyUpdate(float change)
	{
		energy += change;
		if (energy > energyMax)
			energy = energyMax;
		if (energy < 0)
			energy = 0;
	}

	public void setPause(bool state)
	{
		pause = state;
		if (pause)
			Time.timeScale = 0;
		else
			Time.timeScale = 1;
	}

	public int getNbKeyCollected()
	{
		return nbKeys;
	}
}
