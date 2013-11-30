using UnityEngine;
using System.Collections;

public class LateralDeplacements : HumanoidController 
{
	// Vecteur de déplacement
	protected Vector3 moveDirection = Vector3.zero;

	protected CharacterController controller;

	// Permet de régler la vitesse de translation horizontale
	public float horizontalMovementSpeed = 35f;

	// Use this for initialization
	protected override void Start () 
	{
		controller = GetComponent<CharacterController>();
		base.Start();
	}
	
	// Update is called once per frame
	protected override void Update ()
	{
		base.Update();
		// Fait translater le joueur
		moveDirection = new Vector3(Input.GetAxis("Horizontal") * horizontalMovementSpeed * Time.deltaTime,
		                            0,
		                            0);
		// Applique la gravité
		moveDirection.y -= gravity * Time.deltaTime;
		// Applique la translation
		controller.Move(moveDirection);
	}

}
