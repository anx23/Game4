using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour {


	Camera cam;
	Rigidbody rb;

	    RaycastHit grapplePoint;

	[SerializeField]
	bool isGrappling = false;

	float distance;


	public float grappleSpeed = 5f;
	[SerializeField]
	Transform hookpos;
	Vector3 grapplePos;
	LineRenderer wire;
	public GameObject reticle; //表示したい画像をアタッチ
	float wireDistance;


	void Start () {

		// Get Camera and Rigidbody
		cam = Camera.main;
		         rb = GetComponent<Rigidbody>();
		hookpos = GameObject.Find ("hook").transform;
		wire = hookpos.GetComponent<LineRenderer> ();

	}

	void FixedUpdate () {
		
		        Ray ray = cam.ScreenPointToRay(Input.mousePosition);


		if (Physics.Raycast (ray, out grapplePoint,60.0f)) {
		//	reticle.transform.rotation = Quaternion.LookRotation (grapplePoint.normal);
			//照準
			reticle.SetActive (true);
			//reticle.transform.rotation = Quaternion.FromToRotation(reticle.transform.forward,grapplePoint.normal );
			reticle.transform.position = grapplePoint.point+grapplePoint.normal*2.3f ; //hitRayPosition は画像が当たった対象にめり込まない程度に設定する

			if (Input.GetButtonDown ("Fire1")) {
		

				grapplePos = grapplePoint.point;
				isGrappling = true;
				Vector3 grappleDirection = (grapplePoint.point - transform.position);
				wireDistance = Vector3.Distance (transform.position,grapplePoint.point);
				//rb.velocity = grappleDirection.normalized * grappleSpeed*1.6f+rb.angularVelocity;
			}
		} else {

			reticle.SetActive (false);
		}
		 
	
		if (Input.GetButtonUp("Fire1")){
			isGrappling = false;
			wire.SetPosition (1, hookpos.position);
		}

		//アクション
		if (isGrappling) {
			//紐が一定の長さになると切れる
			if (Vector3.Distance (transform.position, grapplePoint.point)-3.0f > wireDistance)
				isGrappling = false;
			
			RenderWire ();
			wire.enabled = true;
			reticle.SetActive (false);

			transform.LookAt (grapplePoint.point);

		
			Vector3 grappleDirection = (grapplePoint.point - transform.position);


			if (distance < grappleDirection.magnitude) {
				float velocity = rb.velocity.magnitude;
				rb.useGravity = false;
				Vector3 newDirection = Vector3.ProjectOnPlane (rb.velocity, grappleDirection);//斜面方向
			
				rb.AddForce (grappleDirection.normalized * grappleSpeed);
				//rb.velocity = newDirection.normalized * velocity;

			} else
				rb.AddForce (grappleDirection.normalized * grappleSpeed);
		
			distance = grappleDirection.magnitude;

		} else {
			//リセットする
			rb.useGravity = true;
			transform.rotation = Quaternion.LookRotation (Vector3.forward, Vector3.up); 
			wire.enabled = false;
			reticle.SetActive (true);
		}
	}





	//ワイヤーセット
	void RenderWire(){

		wire.SetPosition (0, hookpos.position);
		wire.SetPosition (1,grapplePos);

	}





}
