using UnityEngine;
using System.Collections;

public class VerticalDeplacements : LateralDeplacements 
{
	// Permet de savoir si on est en face d'une échelle
	private bool inFrontOfLadder = false;

	// Permet de régler la vitesse de translation verticale
	public float verticalMovementSpeed = 30f;

	// Use this for initialization
	protected override void Start () 
	{
		base.Start();
	}
	
	// Update is called once per frame
	protected override void Update () 
	{
		base.Update();
		// Si on est en face d'une echelle, on autorise la translation verticale
		if (inFrontOfLadder)
		{
			moveDirection = new Vector3(0,
			                            Input.GetAxis("Vertical") * verticalMovementSpeed * Time.deltaTime,
			                            0);
			controller.Move(moveDirection);
		}
	}

	// Tests de Triggers, déterminent si on est en face ou non d'une échelle
	protected virtual void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Ladder")
		{
			inFrontOfLadder = true;
			gravity /= 2;
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
}
