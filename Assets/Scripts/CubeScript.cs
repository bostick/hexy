using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Rigidbody rb = GetComponent<Rigidbody> ();

		//Vector3 NewPosition2 = rb.transform.TransformPoint(new Vector3(0f, 0f, -1f));
		//rb.AddForceAtPosition(rb.transform.forward * 100f, NewPosition2, ForceMode.Force);

		rb.AddForce (rb.transform.forward * 600f);
	}
}
