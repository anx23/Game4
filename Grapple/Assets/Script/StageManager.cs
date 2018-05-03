using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour {
	[SerializeField]
	int stageNum=1;
	[SerializeField]
	GameControll gameManager;
	private bool isClear;
	[SerializeField]
	GameObject menuPanel;
	[SerializeField]
	GameObject cleartPanel;
	bool isOpen=false;

	// Use this for initialization
	void Start () {
		//ゲーム管理オブジェクト取得
		gameManager = GameObject.Find ("GameManager").GetComponent<GameControll>();
	//	menuPanel = GameObject.Find ("MenuPanel");
		//cleartPanel = GameObject.Find ("ClearPanel");
		//Debug.Log ("set");
		//menuPanel.SetActive (false);
		//cleartPanel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void Goal(){
		//ステージ更新
		if (gameManager.currentStageNum<stageNum) {
			gameManager.currentStageNum=stageNum;
			gameManager.Save ();
			isClear = true;

		}
		//SceneManager.LoadScene ("Select");
		cleartPanel.SetActive(true);
	}

	public void ReturnMenu(){
		SceneManager.LoadScene ("Select");
	}

	public void GoNextScene(){
		SceneManager.LoadScene ("Stage"+(stageNum+1).ToString());

	}

	public void OpenMenu(){
		isOpen = !isOpen;
		if (isOpen)
			menuPanel.SetActive (false);
		else
			menuPanel.SetActive (true);
	}

	public void ReverseScene(){
		Scene loadScene = SceneManager.GetActiveScene();
		// Sceneの読み直し
		SceneManager.LoadScene(loadScene.name);

	}

	void OnTriggerEnter(Collider c){

		if (c.gameObject.tag == "Player") {
			c.gameObject.GetComponent<Rigidbody> ().velocity = Vector3.zero;
			Goal ();
		}

	}
}
