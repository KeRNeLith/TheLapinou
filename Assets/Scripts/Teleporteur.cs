using UnityEngine;
using System.Collections;

public class Teleporteur : MonoBehaviour 
{

	// Téléporteur lié à celui-ci
	public Teleporteur otherTeleporteur;
	// Etat activé ou non du téléporteur
	bool isActive = true;

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	void OnTriggerEnter(Collider other)
	{
		// Si le player emprunte le téléporteur
		// On le téléporte sur le téléporteur lié
		if (other.gameObject.tag == "Player")
		{
			teleport(other.gameObject);
			return;
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		// On réactive le téléporteur 1s après que le joueur l'ai emprunté
		if (other.gameObject.tag == "Player")
		{
			Invoke("activate", 1);
			return;
		}
	}

	void teleport(GameObject obj)
	{
		// Si le téléporteur est actif on téléporte le joueur sur le téléporteur lié
		// On désactive l'autre téléporteur (sinon on aurait des téléportations infinies)
		if (isActive)
		{
			otherTeleporteur.setActive(false);
			Vector3 positionToTeleport = new Vector3(otherTeleporteur.transform.position.x,
			                                 		 otherTeleporteur.transform.position.y + obj.collider.bounds.size.y/2,
			                                 		 otherTeleporteur.transform.position.z);
			obj.transform.position = positionToTeleport;
		}
	}

	private void activate()
	{
		isActive = true;
	}

	public void setActive(bool state)
	{
		isActive = state;
	}
}
