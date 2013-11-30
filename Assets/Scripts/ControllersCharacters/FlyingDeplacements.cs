using UnityEngine;
using System.Collections;

public class FlyingDeplacements : VerticalDeplacements 
{
	// Energie pour que le joueur puisse voler
	protected float energy;
	protected float energyMax = 100;

	// Temps de vol maximum
	protected float maxTimeFlying;
	// Energie à perdre par seconde
	private float updateEnergyPerSecond;

	// Permet de régler la vitesse des mouvements en vol
	public float flyingMoveAttenuation = 15f;

	// Use this for initialization
	protected override void Start () 
	{
		energy = 0;
		updateEnergyPerSecond = energyMax/maxTimeFlying;
		base.Start();
	}
	
	// Update is called once per frame
	protected override void Update () 
	{
		base.Update();
		// Si on a de l'énergie et que l'on demande à voler (espace)
		if (Input.GetButton("Jump") && energy > 0)
		{
			moveDirection = new Vector3(moveDirection.x * flyingMoveAttenuation * Time.deltaTime,
			                            1.0f,
			                            0);
			controller.Move(moveDirection);
			// Fait baisser l'énergie
			energyUpdate(-Time.deltaTime*updateEnergyPerSecond);
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

	// Test le Trigger avec un objet Battery (pour recharger l'énergie)
	protected override void OnTriggerEnter(Collider other)
	{
		base.OnTriggerEnter(other);
		if (other.gameObject.tag == "Battery")
		{
			energyUpdate(updateEnergyPerSecond*2);	// On récupère 2s de vol
			DestroyObject(other.gameObject);
			return;
		}
	}
}
