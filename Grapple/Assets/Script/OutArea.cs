using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class OutArea : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider c){

		if (c.gameObject.tag == "Player") {
			Scene loadScene = SceneManager.GetActiveScene();
			// Sceneの読み直し
			SceneManager.LoadScene(loadScene.name);
		}

	}


}
