using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void Awake() 
	{
		//Récupère la musique si UnityEditor est actuellement enabled AnimatorTransitionInfo d'etre jouée
		GameObject MenuMusic  = GameObject.Find("MusicMenu");
		if (MenuMusic) 
		{
			// Détruit la musique
			Destroy(MenuMusic);
		}
		// Permet de conserver le MusicController dans les différentes scènes
		//DontDestroyOnLoad(gameObject);
	}
}
