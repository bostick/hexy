using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionLogger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		

	}

		void OnCollisionEnter(Collision collision) {
			Debug.Log ("collide: " + collision.collider.gameObject.tag);
		}
}
