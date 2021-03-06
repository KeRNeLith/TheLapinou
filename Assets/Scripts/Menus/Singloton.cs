﻿using UnityEngine;
using System.Collections;

// Permet de gérer un Singleton, classe ne pouvant etre instancier qu'une seule fois
public class Singloton : MonoBehaviour {
	
	private static Singloton instance = null;
	
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	
	public static Singloton Instance 
	{
		get { return instance; }
	}
	void Awake() 
	{
		if (instance != null && instance != this) 
		{
			Destroy(this.gameObject);
			return;
		} else 
		{
			instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
	}
	
}
