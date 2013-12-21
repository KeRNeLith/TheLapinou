using UnityEngine;
using System.Collections;

public class HumanoidController : MonoBehaviour 
{
	// Vie de l'entité
	protected float hp;
	protected float hpMax;

	// Gravité
	protected float gravity = 40f;

	// Use this for initialization
	protected virtual void Start () 
	{
		hp = hpMax;
	}
	
	// Update is called once per frame
	protected virtual void Update () 
	{
	}

	// Permet de modifier la vie de l'entité
	// Avec vérifications des bornes
	public virtual void healthUpdate(float change)
	{
		hp += change;
		if (hp > hpMax)
			hp = hpMax;
		if (hp < 0)
			hp = 0;
	}

	public float getHealth()
	{
		return hp;
	}

	public float getMaxHealth()
	{
		return hpMax;
	}
}
