using UnityEngine;
using System.Collections;

public class selectMenu : MonoBehaviour 
{
	private int levelsFinished;	// Nombre de niveaux fini
	private Vector3 mainCameraPos;	// position de la camera (x,y,z) dans la scene
	private int turningAngleCam;	// angle de 360 divisé par le nombre de niveaux total
	private int objectBySide;	// Nombre de niveaux par étage ( 3 etages max de prévu, etage = voir CreateLevels() )

	// Gestion des positions et droits de la caméra
	private bool estHaut;
	private bool estMilieu;
	private bool estBas;
	private bool peutTourner;

	// Affichage des "panneaux" Level_...
	public GameObject platform; 
	private GameObject level;
	public GameObject Gui3DText;
	private GameObject levelText;

	// Gestion de la colision de la souris avec un objet
	private RaycastHit hitInfo;

	// Use this for initialization
	void Start ()
	{
		// La caméra a un angle de (0,0,0) elle est donc au milieu
		peutTourner = true;
		estHaut = false ;
		estBas = false ;
		estMilieu = true;

		// Calcule le nombre de niveau débloqué
		int i = 1;
		while (PlayerPrefsX.GetBool("Level_" + i, false) && i < PlayerPrefs.GetInt("nbLevels"))
			i++;

		levelsFinished = i;	// Nombre de niveaux débloqués

		mainCameraPos = Camera.main.transform.position;	// position de la camera dans l'espace

		Camera.main.transform.Rotate (new Vector3(0,0,0) );	// pour obliger la caméra à etre en angle (0,0,0)

		objectBySide = PlayerPrefs.GetInt("nbLevels");	// on récupère la valeur initialisé dans la scene Menu

		turningAngleCam = 360 / objectBySide;	// on découpe notre angle de 360

		createLevels();	// Creer la scene dynamiquement
	}
	
	// Update is called once per frame
	void Update () 
	{
		// touche echap permet un retour à la scene Menu
		if (Input.GetKeyDown("escape"))
			Application.LoadLevel("Menu");

		// Permet de savoir l'objet qui est en colision avec le curseur et si un clic se fait, charge la scene du meme nom
		if( Physics.Raycast( Camera.main.ScreenPointToRay( Input.mousePosition ), out hitInfo ) )
		{
			string levelName = hitInfo.collider.name;
			if(Input.GetMouseButtonDown(0))
				Application.LoadLevel(levelName);
		} 


		////////////////////////////////////
		/// 
		/// GESTION DE LA ROTATION CAMERA
		/// 
		/// ////////////////////////////////

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
				estHaut = true;
				estMilieu = false;
				Camera.main.transform.position = (new Vector3(0,-90,0) );
			}
			if (estBas)
			{
				estHaut = false;
				estMilieu = true;
				estBas =false;
				Camera.main.transform.position = (new Vector3(0,0,0) );
			}

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
				Camera.main.transform.position = (new Vector3(0,0,0) );
			}
			if(estHaut)
			{
				estMilieu=true;
				estHaut=false;
				estBas = false;
				Camera.main.transform.position = (new Vector3(0,0,0) );
			}
		}
	}


	void createLevels() 
	{
		string numLevel;
		for(int i = 0 ; i < levelsFinished ; i++)	// on positionne un objet en tournant autour de la caméra
		{
			int y =-2;
			if ( i >= objectBySide)	// on baisse d'un cranc (2e etage)
			{
				y +=2;
				if(i >= objectBySide*2)	// on baisse encore (3e etage)
				{
					y+=2;
					// instancie un gameobject avec un prefab en se centrant autour(rotation) de la camera
					level = Instantiate(platform, new Vector3(mainCameraPos.x , mainCameraPos.y+(y), mainCameraPos.z+10) , Quaternion.identity) as GameObject;
					level.transform.RotateAround(Camera.main.transform.position,new Vector3(0,i*turningAngleCam,0),i*turningAngleCam);
					// fait la meme chose avec un Gui3DText vide
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
			// on donne au gameobject son nom (qui sera utilisé lors du clic/position souris pour charger un level)
			// et on applique le texte au Gui3DText
			level.name = "Level_"+(i+1);
			numLevel = "Level "+(i+1);
			levelText.GetComponent<TextMesh>().text = numLevel;
			levelText.GetComponent<TextMesh>().color = Color.yellow;
		}
	}






}
