using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchGameObject : MonoBehaviour {



	[SerializeField] GameObject targetCamera, mainCamera; 
	void OnTriggerEnter(Collider other) 
		{ 
		if(other.gameObject.tag=="Player"){
				targetCamera.SetActive(true); 
				mainCamera.SetActive(false); 
		}
			} 


	 	void OnTriggerExit(Collider other) 
	 	{ 
				targetCamera.SetActive(false); 
		 		mainCamera.SetActive(true); 
			} 
	







}
