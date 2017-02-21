using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour {

	public GameObject EastLargeWall;
	public GameObject SouthLargeWall;

	private bool triggered = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {

		if (Input.GetKey (KeyCode.P) ||
			OVRInput.Get (OVRInput.Button.Four)) {
			triggered = true;
		}

		if (triggered) {

			if (SouthLargeWall.transform.position.z > -170.0f) {
				SouthLargeWall.transform.position = SouthLargeWall.transform.position + 0.005f * Vector3.back;
			} else {
//				Rigidbody southRB = SouthLargeWall.GetComponent<Rigidbody> ();
//				southRB.
			}

			if (EastLargeWall.transform.position.x < 170.0f) {
				EastLargeWall.transform.position = EastLargeWall.transform.position + 0.005f * Vector3.right;
			} else {
//				Rigidbody eastRB = EastLargeWall.GetComponent<Rigidbody> ();
			}

		}

	}
}
