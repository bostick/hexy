using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionLogger : MonoBehaviour {

		void OnTriggerEnter(Collider other) {
        //Destroy (other.gameObject);

        Debug.Log("Trigger! " + (other.gameObject.tag) );

        if (other.gameObject.CompareTag("Pick Up")) {

            SphereCollider c = other.gameObject.GetComponent<SphereCollider>();
            if (c.isTrigger)
            {
                Rigidbody pickupRB = other.gameObject.GetComponent<Rigidbody>();
                pickupRB.isKinematic = false;

                c.isTrigger = false;
            } else
            {
                other.gameObject.SetActive(false);
            }


                
			}
	
			//
	
		}

	void OnCollisionEnter(Collision collision) {

        ContactPoint p = collision.contacts [0];

        //Debug.Log ("Collision! " + (p.thisCollider.gameObject.tag) + " " + (p.otherCollider.gameObject.tag) + " " + (p.thisCollider.gameObject.transform.position.ToString()) + " " + (p.thisCollider.gameObject.transform.rotation.ToString()));

        if (p.thisCollider.gameObject.CompareTag("Pick Up") &&
            p.otherCollider.gameObject.CompareTag("Portal"))
        {
            p.thisCollider.gameObject.SetActive(false);
        }
    }

}
