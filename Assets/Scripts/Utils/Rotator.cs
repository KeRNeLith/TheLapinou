using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

	private float xRotation = 0;
	private float yRotation = 0;
	private float zRotation = 0;

	// Use this for initialization
	void Start () 
	{
		xRotation = Random.Range(10, 15);
		yRotation = Random.Range(10, 15);
		zRotation = Random.Range(10, 15);
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Rotate(new Vector3(xRotation, yRotation, zRotation) * Time.deltaTime);
	}
}
