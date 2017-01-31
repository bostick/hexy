using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionLogger : MonoBehaviour {

		void OnTriggerEnter(Collider other) {
			//Destroy (other.gameObject);
	
	//		if (other.gameObject.CompareTag("Pick Up")) {
	//			other.gameObject.SetActive (false);
	//			count = count + 1;
	//			SetCountText ();
	//		}
	
			//Debug.Log ("Trigger!");
	
		}

	void OnCollisionEnter(Collision collision) {
		
		//ContactPoint p = collision.contacts [0];

		//Debug.Log ("Collision! " + (p.thisCollider.gameObject.tag) + " " + (p.otherCollider.gameObject.tag) + " " + (p.thisCollider.gameObject.transform.position.ToString()) + " " + (p.thisCollider.gameObject.transform.rotation.ToString()));
	}

}
