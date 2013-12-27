using UnityEngine;
using System.Collections;

public class selectMenu : MonoBehaviour 
{
	private int levelsFinished;	// Nombre de niveaux fini
	private Vector3 mainCameraPos;
	private int turningAngleCam;
	private int objectBySide;

	private bool estHaut;
	private bool estMilieu;
	private bool estBas;
	private bool peutTourner;

	public GameObject platform; 
	private GameObject level;
	public GameObject Gui3DText;
	private GameObject levelText;

	// souris
	private RaycastHit hitInfo;

	// Use this for initialization
	void Start ()
	{
		peutTourner = true;
		estHaut = false ;
		estBas = false ;
		estMilieu = true;
		//PlayerPrefs.DeleteAll();
		// Calcule le nombre de niveau débloqué
		int i = 1;
		while (PlayerPrefsX.GetBool("Level_" + i, false) && i < PlayerPrefs.GetInt("nbLevels"))
			i++;

		levelsFinished = i;	// Nombre de niveaux débloqués
		mainCameraPos = Camera.main.transform.position;	// position de la camera dans l'espace
		Camera.main.transform.Rotate (new Vector3(0,0,0) );
		objectBySide = 9;
		turningAngleCam = 360 / objectBySide;
		createLevels();

	}
	
	// Update is called once per frame
	void Update () 
	{

		if( Physics.Raycast( Camera.main.ScreenPointToRay( Input.mousePosition ), out hitInfo ) )
		{
			Debug.Log( "mouse is over object " + hitInfo.collider.name );
			string levelName = hitInfo.collider.name;
			if(Input.GetMouseButtonDown(0))
				Application.LoadLevel(levelName);
		} 

		// Eviter d'avoir une vue de travers
		if(!estMilieu)
			peutTourner=false;
		else
			peutTourner=true;

		// Se deplacer dans une forme 3D
		if(peutTourner && Input.GetKeyDown(KeyCode.LeftArrow))	// tourne dans le sens horaire
		{
			Camera.main.transform.Rotate (new Vector3(0,-turningAngleCam,0) );
			// code
		}
		if(peutTourner && Input.GetKeyDown(KeyCode.RightArrow))	// tourne dans le sens trigo
		{
			Camera.main.transform.Rotate (new Vector3(0,turningAngleCam,0) );
			// code
		}
		if(Input.GetKeyDown(KeyCode.UpArrow))	// la caméra doit regarder en haut
		{
			// on peut imaginer une cinematique d'intro
			if(estHaut)
				return;
			if(estMilieu)
			{
				//Camera.main.transform.Rotate (new Vector3(-90,0,0) );
				estHaut = true;
				estMilieu = false;
			}
			if (estBas)
			{
				//Camera.main.transform.Rotate (new Vector3(-90,0,0) );
				estHaut = false;
				estMilieu = true;
				estBas =false;
			}
			Camera.main.transform.Rotate (new Vector3(-90,0,0) );
		}
		if(Input.GetKeyDown(KeyCode.DownArrow))	// la caméra doit regarder en bas
		{
			// on peut imaginer le level final
			if(estBas)
				return;
			if(estMilieu)
			{
				estHaut=false;
				estMilieu=false;
				estBas=true;
			}
			if(estHaut)
			{
				//Camera.main.transform.Rotate (new Vector3(90,0,0) );
				estMilieu=true;
				estHaut=false;
				estBas = false;
			}

			Camera.main.transform.Rotate (new Vector3(90,0,0) );
		}
	}


	void createLevels() 
	{
		string numLevel;
		for(int i = 0 ; i < levelsFinished ; i++)	// on positionne un objet en tournant autour de la caméra
		{
			int y =-2;
			if ( i >= objectBySide)// on baisse d'un cranc
			{
				y +=2;
				if(i >= objectBySide*2)// on obtient un troisième rang
				{
					y+=2;
					// code
					level = Instantiate(platform, new Vector3(mainCameraPos.x , mainCameraPos.y+(y), mainCameraPos.z+10) , Quaternion.identity) as GameObject;
					level.transform.RotateAround(Camera.main.transform.position,new Vector3(0,i*turningAngleCam,0),i*turningAngleCam);

					levelText = Instantiate(Gui3DText, new Vector3(mainCameraPos.x-3 , mainCameraPos.y+(y)+1.5f, mainCameraPos.z+14) , Quaternion.identity) as GameObject;
					levelText.transform.RotateAround(Camera.main.transform.position,new Vector3(0,i*turningAngleCam,0),i*turningAngleCam);
				}
				if(i < objectBySide*2)
				{
				// code
				level = Instantiate(platform, new Vector3(mainCameraPos.x , mainCameraPos.y+(y), mainCameraPos.z+10) , Quaternion.identity) as GameObject;
				level.transform.RotateAround(Camera.main.transform.position,new Vector3(0,i*turningAngleCam,0),i*turningAngleCam);
				
				levelText = Instantiate(Gui3DText, new Vector3(mainCameraPos.x-3 , mainCameraPos.y+(y)+0.5f, mainCameraPos.z+14) , Quaternion.identity) as GameObject;
				levelText.transform.RotateAround(Camera.main.transform.position,new Vector3(0,i*turningAngleCam,0),i*turningAngleCam);
				}
			}
			else
			{
				if ( i < objectBySide)
				level = Instantiate(platform, new Vector3(mainCameraPos.x , mainCameraPos.y+(y), mainCameraPos.z+10) , Quaternion.identity) as GameObject;
				level.transform.RotateAround(Camera.main.transform.position,new Vector3(0,i*turningAngleCam,0),i*turningAngleCam);

				levelText = Instantiate(Gui3DText, new Vector3(mainCameraPos.x-3 , mainCameraPos.y+(y)-0.5f, mainCameraPos.z+14) , Quaternion.identity) as GameObject;
				levelText.transform.RotateAround(Camera.main.transform.position,new Vector3(0,i*turningAngleCam,0),i*turningAngleCam);
			}
			level.name = "Level_"+(i+1);
			numLevel = "Level "+(i+1);
			levelText.GetComponent<TextMesh>().text = numLevel;
		}
	}






}
