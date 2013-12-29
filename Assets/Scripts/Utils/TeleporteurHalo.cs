using UnityEngine;
using System.Collections;

public class TeleporteurHalo : MonoBehaviour 
{
	// Lumière
	private Light spot;

	// Atténuation
	public float smooth = 1.8f;
	// Seuil de changement d'intensité
	public float changingTreshold = 0.1f;

	// Plage de variation d'intensité
	public float intensityMin = 0f;
	public float intensityMax = 1f;

	// Intensité vers laquelle converge le spot
	private float newIntensity;

	// Use this for initialization
	void Start () 
	{
		// Récupère la référence sur le spot
		spot = GetComponent<Light>();
		spot.intensity = 0;

		// Fixe l'intensité cible au max
		newIntensity = intensityMax;

		// Affecte la couleur au spot (celle du material du téléporteur)
		spot.color = transform.parent.FindChild("TPMaterial").renderer.material.color;
	}
	
	// Update is called once per frame
	void Update () 
	{ 
		if (Mathf.Abs(spot.intensity - intensityMax) < changingTreshold)
			changeIntensity();
		else if (Mathf.Abs(spot.intensity - intensityMin) < changingTreshold)
			changeIntensity();

		spot.intensity = Mathf.Lerp(spot.intensity, newIntensity, smooth * Time.deltaTime);
	}

	void changeIntensity()
	{
		if (newIntensity == intensityMax)
			newIntensity = intensityMin;
		else
			newIntensity = intensityMax;
	}
}
