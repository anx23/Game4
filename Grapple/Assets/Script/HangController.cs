using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangController : MonoBehaviour {

	RaycastHit hit;
	GameObject target;
	public GameObject reticle; //表示したい画像をアタッチ
	Vector3 defaultPos;
	Quaternion defaultRotation;

	Vector3 handPos;
	// Use this for initialization
	void Start () {
		//Rayの初期化設定
		defaultPos=transform.position;

	}
	
	// Update is called once per frame
	void Update () {

		if (Physics.Raycast (transform.position, transform.forward, out hit, 2.0f)) {
			//hit.collider.gameObject.GetComponent<MeshRenderer>().material.color=Color
			if (target != hit.collider.gameObject) {
				target = hit.collider.gameObject;
				hit.collider.gameObject.GetComponent<MeshRenderer> ().material.color = Color.red;
				reticle.SetActive (true);

			} 
			handPos = hit.point+(hit.normal*0.2f);
			reticle.transform.rotation = Quaternion.LookRotation(hit.normal);
			reticle.transform.position = hit.point + (hit.normal ); //hitRayPosition は画像が当たった対象にめり込まない程度に設定する





		} else {
			reticle.SetActive (false);
			target = null;

		}



		if (target != null) {

			if (Input.GetMouseButton (0)) {
				transform.position = Vector3.Lerp (transform.position,handPos,Time.deltaTime*1.5f);
			}

			if(Input.GetMouseButtonUp(0))
				transform.position = Vector3.Lerp (transform.position,defaultPos,Time.deltaTime*1.5f);


			if (Input.GetMouseButtonDown (1))
				target.transform.parent = transform;
			transform.position = Vector3.Lerp (transform.position,transform.forward*-3.5f,Time.deltaTime*1.5f);

		}


	}



}
