using UnityEngine;
using System.Collections;

public class PlayerController : FlyingDeplacements 
{
	// Indique si le jeu est en pause ou non
	private bool pause = false;

	// Use this for initialization
	void Start () 
	{
		Time.timeScale = 1;
		hpMax = 100;
		maxTimeFlying = 5;	// 5s de temps de vol maximum
		base.Start();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (pause)
			return;

		base.Update();
	}

	public void setPause(bool state)
	{
		pause = state;
		if (pause)
			Time.timeScale = 0;
		else
			Time.timeScale = 1;
	}
}
