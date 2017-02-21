using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropped : MonoBehaviour {

//	public GameObject ThisThing;
//	public AudioSource source;
//	public AudioClip dropped_clip;
//
//	void OnTriggerEnter(Collider other) {
//		if (other.gameObject.CompareTag ("BluePickup")) {
//			SphereCollider c = other.gameObject.GetComponent<SphereCollider> ();
//			if (c.isTrigger) {
//				Rigidbody pickupRB = other.gameObject.GetComponent<Rigidbody> ();
//				pickupRB.isKinematic = false;
//				c.isTrigger = false;
//			} else if (ThisThing.CompareTag("BluePortal")) {
//				MakePickupDisappear (other);
//				GameManager.instance.unlockBlue ();
//			}
//		} else if (other.gameObject.CompareTag ("RedPickup")) {
//			SphereCollider c = other.gameObject.GetComponent<SphereCollider> ();
//			if (c.isTrigger) {
//				Rigidbody pickupRB = other.gameObject.GetComponent<Rigidbody> ();
//				pickupRB.isKinematic = false;
//				c.isTrigger = false;
//			} else if (ThisThing.CompareTag("RedPortal")) {
//				MakePickupDisappear (other);
//				GameManager.instance.unlockRed ();
//			}
//		}
//	}
//
//	void MakePickupDisappear(Collider other) {
//		other.gameObject.SetActive (false);
//		ParticleSystem sys = ThisThing.GetComponentInChildren<ParticleSystem> ();
//		sys.Stop ();
//		source.clip = dropped_clip;
//		source.Play ();
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
