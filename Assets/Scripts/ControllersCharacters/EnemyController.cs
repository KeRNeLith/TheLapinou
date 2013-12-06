using UnityEngine;
using System.Collections;


public class EnemyController : HumanoidController
{
	// Face de l'ennemy
	Transform frontEnnemy;

	// Sens dans lequel se déplace l'ennemi
	int sens = 1;

	// Vitesse de l'ennemy
	float speed = 5f;

	// Use this for initialization
	protected override void Start () 
	{
		// Récupère l'objet vide devant l'ennemi
		frontEnnemy = GetComponentInChildren<Transform>().Find("Face");
	}

	// Update is called once per frame
	protected override void Update ()
	{
		// On va tester si en avançant on est encore sur la platform
		bool isPlatform = false;
		RaycastHit rayToDownHit;
		Ray rayToDown = new Ray(frontEnnemy.position, Vector3.down);
		
		if (Physics.Raycast(rayToDown, out rayToDownHit, 1))
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

	void changeSens()
	{
		// Change le sens de déplacement
		sens = -sens;
		transform.forward = -transform.forward;
	}
}