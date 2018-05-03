using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour {




	public float speed = 10.0f; 

	public GameObject target;    // ターゲットへの参照
	public Vector3 offset;     // 相対座標
	GameObject myCamera;
	float maxClosed;


	Quaternion camerarot;
	//GameObject playerdirection;

	public float rotSpeed = 10.0f; 
	//[SerializeField]
	float maxAngle = 20; // 最大回転角度
	//[SerializeField]
	float minAngle = -30; // 最小回転角度
	float rotspeed = 0.5f; // 回転スピード(お好みで調整してください)
	//[SerializeField]
	bool hitWall=false;

	void Start ()
	{
		//自分自身とtargetとの相対距離を求める
		//
		target=GameObject.FindWithTag("Player");
		offset = transform.position - target.transform.position;
		myCamera = GameObject.FindWithTag ("MainCamera");
		//maxClosed = Vector3.Distance (target.transform.position, camerapos2.transform.position);

		camerarot = transform.rotation;
	//	playerdirection = GameObject.Find ("PlayerDirection");
		SetTarget();
	}




	void Update ()
	{
		






	}







	void FixedUpdate ()
	{

		// 自分自身の座標に、targetの座標に相対座標を足した値を設定する
		//	transform.position =Vector3.Lerp(transform.position, target.position + offset,Time.deltaTime);

	//	AvoidWall ();
		//WallCloseStop ();
		transform.position = target.transform.position+offset;
	
	

	}

	public void SetTarget(){

		target = GameObject.FindWithTag ("Player");
	}





}
