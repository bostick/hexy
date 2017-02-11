using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionLogger : MonoBehaviour {

//	public GameObject ThisThing;

//	void OnTriggerEnter(Collider other) {
//
//		if (other.gameObject.CompareTag ("Pick Up")) {
//
//			SphereCollider c = other.gameObject.GetComponent<SphereCollider> ();
//			if (c.isTrigger) {
//				Rigidbody pickupRB = other.gameObject.GetComponent<Rigidbody> ();
//				pickupRB.isKinematic = false;
//				c.isTrigger = false;
//
//				//Debug.Log ("Trigger! yes " + ThisThing.tag);
//
//			} else if (ThisThing.CompareTag("Portal")) {
//				// Make Pickup disappear
//				other.gameObject.SetActive (false);
//
//				ParticleSystem sys = ThisThing.GetComponentInChildren<ParticleSystem> ();
//				sys.Stop ();
//
//				//Debug.Log ("Trigger! no " + ThisThing.tag + " " + ThisThing.is);
//			}
//		} else {
//			//Debug.Log ("Trigger! something else " + ThisThing.tag);
//		}
//	
//	}

//	void OnCollisionEnter(Collision collision) {
//
//        ContactPoint p = collision.contacts [0];
//
//        //Debug.Log ("Collision! " + (p.thisCollider.gameObject.tag) + " " + (p.otherCollider.gameObject.tag) + " " + (p.thisCollider.gameObject.transform.position.ToString()) + " " + (p.thisCollider.gameObject.transform.rotation.ToString()));
//
//        if (p.thisCollider.gameObject.CompareTag("Pick Up") &&
//            p.otherCollider.gameObject.CompareTag("Portal"))
//        {
//            p.thisCollider.gameObject.SetActive(false);
//        }
//    }

}
