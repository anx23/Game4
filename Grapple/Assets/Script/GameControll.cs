using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameControll : MonoBehaviour {
	
	static public GameControll instance;
	public int currentStageNum=0;
	int maxStageNum;
	[SerializeField]
	List<GameObject> stages=new List<GameObject>();
	const string STAGELEVEl = "stagelevel";
	// Use this for initialization
	[SerializeField]
	GameObject uiPanel; 
	[SerializeField]
	Button[] buttons;

	void Awake ()
	{
		//Singleton
		if (instance == null) {

			instance = this;
			DontDestroyOnLoad (gameObject);
			SetUi ();
		}
		else {

			Destroy (gameObject);
		//	SetUi ();
		}


	}




	void Start () {
	//	DontDestroyOnLoad (this.gameObject);

	

		SceneManager.activeSceneChanged += OnActiveSceneChanged;
		SceneManager.sceneLoaded              += OnSceneLoaded;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SetStage(){

		for(int i=currentStageNum+1;i<buttons.Length;i++){

			buttons[i].interactable = false;

		}
	}

	public void GoGame(string stageName){
		SceneManager.LoadScene (stageName);

	}

	public void Save(){
		PlayerPrefs.SetInt (STAGELEVEl,currentStageNum);
	}


	void Load(){

		currentStageNum = PlayerPrefs.GetInt (STAGELEVEl);

	}


	void OnActiveSceneChanged( Scene scene, Scene nextScene )
	{
		Debug.Log ( scene.buildIndex.ToString()+ " scene loaded");

		if (scene.buildIndex == 1) {//戦闘シーンであれば
			
			uiPanel=GameObject.Find("ButtonPanel");
			buttons=uiPanel.GetComponentsInChildren<Button>();
			maxStageNum = 10;
			Load ();
			SetStage ();
		}






	}



	void OnSceneLoaded( Scene scene, LoadSceneMode mode )
	{
		Debug.Log ( scene.buildIndex.ToString() + " scene loaded");
		
		
		if (scene.buildIndex == 1) {//戦闘シーンであれば


			uiPanel=GameObject.Find("ButtonPanel");
			buttons=uiPanel.GetComponentsInChildren<Button>();
			maxStageNum = 10;
			Load ();
			SetStage ();
		}

	}



	void SetUi(){

		uiPanel=GameObject.Find("ButtonPanel");
		buttons=uiPanel.GetComponentsInChildren<Button>();
		maxStageNum = 10;
		Load ();
		SetStage ();
	}







}
