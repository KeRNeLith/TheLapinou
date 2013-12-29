using UnityEngine;
using System.Collections;

public class LightOscillateur : MonoBehaviour 
{
	// Lumière
	private Light pointLight;

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
		// Récupère la référence sur le point lumineux
		pointLight = GetComponent<Light>();
		pointLight.intensity = 0;

		// Fixe l'intensité cible au max
		newIntensity = intensityMax;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Mathf.Abs(pointLight.intensity - intensityMax) < changingTreshold)
			changeIntensity();
		else if (Mathf.Abs(pointLight.intensity - intensityMin) < changingTreshold)
			changeIntensity();
		
		pointLight.intensity = Mathf.Lerp(pointLight.intensity, newIntensity, smooth * Time.deltaTime);
	}
	
	void changeIntensity()
	{
		if (newIntensity == intensityMax)
			newIntensity = intensityMin;
		else
			newIntensity = intensityMax;
	}
}
