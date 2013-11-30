using UnityEngine;
using System.Collections;

public class PlayerController : FlyingDeplacements 
{
	// Indique si le jeu est en pause ou non
	private bool pause = false;

	// Nombre de clés possédé
	private int nbKeys = 0;

	// Use this for initialization
	protected override void Start () 
	{
		Time.timeScale = 1;
		hpMax = 100;
		maxTimeFlying = 5;	// 5s de temps de vol maximum
		base.Start();
	}
	
	// Update is called once per frame
	protected override void Update () 
	{
		if (pause)
			return;

		base.Update();
	}

	// Test le Trigger avec un objet Key
	protected override void OnTriggerEnter(Collider other)
	{
		base.OnTriggerEnter(other);
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
