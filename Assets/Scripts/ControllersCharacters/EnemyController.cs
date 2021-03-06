﻿using UnityEngine;
using System.Collections;


public class EnemyController : HumanoidController
{
	// Face de l'ennemy
	Transform frontEnnemy;

	// Sens dans lequel se déplace l'ennemi
	int sens = 1;

	private float timeToChange = 0f;

	// Vitesse de l'ennemy
	float speed = 5f;

	// Booleen pour savoir si on est proche du joueur
	bool nearPlayer = false;

	// Joueur
	private PlayerController target;

	// Temps écoulé entre chaque attaque
	private float timeCountAttack = 0;
	// Temps minimum entre chaque attaque
	private float timeAttack = 1f;

	// Dégats infligés
	private float damage = -15f;

	// Probabilité de toucher
	private float attackProbability = 0.7f;

	// Use this for initialization
	protected override void Start () 
	{
		// Récupère l'objet vide devant l'ennemi
		frontEnnemy = GetComponentInChildren<Transform>().Find("Face");
		target = FindObjectOfType<PlayerController>();
	}

	// Update is called once per frame
	protected override void Update ()
	{
		if (!nearPlayer)
		{
			// On va tester si en avançant on est encore sur la platform
			bool isPlatform = false;
			RaycastHit rayToDownHit;
			Ray rayToDown = new Ray(frontEnnemy.position, Vector3.down);
			if (Physics.Raycast(rayToDown, out rayToDownHit, 1.5f))
			{
				// Si on est sur une platform
				if (rayToDownHit.collider.tag == "Platform")
					isPlatform = true;
			}

			// Si on est pas sur une platform on change de sens
			if (!isPlatform)
				changeSens();

			transform.position = new Vector3(transform.position.x + sens * speed * Time.deltaTime,
			                                 transform.position.y,
			                                 transform.position.z);
		}
		else
		{
			float distance = Vector3.Distance(target.transform.position, transform.position);
			float distanceOnX = target.transform.position.x - transform.position.x;
			sens = (int)(distanceOnX/Mathf.Abs(distanceOnX));
			if (distance <= 0.5f)
			{
				transform.position = new Vector3(transform.position.x + sens * speed * Time.deltaTime,
				                                 transform.position.y,
				                                 transform.position.z);
			}

			if (timeCountAttack >= timeAttack)
			{
				attack();
			}
		}
		timeCountAttack += Time.deltaTime;
		if (timeToChange >= 0)
			timeToChange -= Time.deltaTime;
	}

	void changeSens()
	{
		if (timeToChange > 0)
			return;
		// Change le sens de déplacement
		sens = -sens;
		transform.forward = -transform.forward;
		timeToChange = 0.5f;
	}

	void attack()
	{
		if (timeCountAttack >= timeAttack)
		{
			if (Random.value <= attackProbability)
				target.healthUpdate(damage);
		}
		timeCountAttack = 0;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			nearPlayer = true;
		}
		if (other.gameObject.tag == "Enemy")
		{
			changeSens();
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			nearPlayer = false;
			return;
		}
	}
}