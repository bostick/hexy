using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class Player : Excavator {

	//public static Player instance = null;

	void Awake() {
//		if (instance == null) {
//			instance = this;
//
//			DontDestroyOnLoad (gameObject);
//
//		} else if (instance != this) {
//			Destroy (gameObject);
//
//			// game is resuming
//			instance.gameObject.SetActive (true);
//
//			//Debug.Log ("restored: " + instance.gameObject.transform.position.ToString("G4") + " " + instance.gameObject.transform.rotation.ToString("G4"));
//
//		} else {
//			throw new System.Exception ("how did this happen...");
//		}
	}

	void Start()
	{
		switch (GameManager.instance.origin) {
		case GameManager.Origin.Start:
			ExcavatorStart ();

			rotSpeed = 75;
			rotRevSpeed = 30;

			//set the bigarm to a non colliding position
			anim.SetFloat("BigArmSpeed",10f);
			anim.Play("BigOpen", 1, (1f/30f)*5f);

			rb.centerOfMass = new Vector3(0, 0f, 0);
			break;
		case GameManager.Origin.Resume:

			ExcavatorStart ();

			rotSpeed = 75;
			rotRevSpeed = 30;

			gameObject.transform.position = GameManager.instance.playerPosition;
			gameObject.transform.rotation = GameManager.instance.playerRotation;

			//set the bigarm to a non colliding position
			anim.SetFloat("BigArmSpeed",10f);
			anim.Play("BigOpen", 1, (1f/30f)*5f);

			rb.centerOfMass = new Vector3(0, 0f, 0);

			break;
		case GameManager.Origin.Leaving:
			throw new System.Exception ("not allowed to happen");
		default:
			throw new System.Exception ("how did this happen...");
		}
	}

	void Update()
	{
		switch (GameManager.instance.origin) {
		case GameManager.Origin.Start:
			ExcavatorUpdate ();
			break;
		case GameManager.Origin.Resume:
			ExcavatorUpdate ();
			break;
		case GameManager.Origin.Leaving:
			// Update may still be called after GoingToMainMenu() has been called...
			break;
		default:
			throw new System.Exception ("how did this happen...");
		}
	}

	void FixedUpdate() {

		switch (GameManager.instance.origin) {
		case GameManager.Origin.Start:
		case GameManager.Origin.Resume:
			//if (!rebinded) {
				//				anim.SetInteger ("BigArmPosition", 0);
				//				anim.SetInteger ("SmallArmPosition", 0);
				//				anim.SetInteger ("ShovelPosition", 0);
				//anim.Play("BigOpen", 1, (1f/30f)*30f);
				//gameObject.transform.position = gameObject.transform.position + 5.0f * Vector3.up;

				//anim.Rebind ();
//				anim.SetFloat("BigArmSpeed",-1f);
//				anim.SetFloat("SmallArmSpeed",-1f);
//				anim.SetFloat("ShovelSpeed",-1f);
//
//				anim.SetInteger("BigArmPosition", 1);
//				anim.SetInteger("SmallArmPosition", 1);
//				anim.SetInteger("ShovelPosition", 1);

//				anim.Play("BigOpen", 1, (1f/30f)*30f);
//				anim.Play("SmallOpen", 2, (1f/30f)*30f);
//				anim.Play("ShovelOpen", 3, (1f/30f)*30f);

				//rebinded = true;
				//Debug.Log ("rebound");
			//}

			//ANIMATE LEFT TREAD
			if (Application.isEditor && Input.GetKey (KeyCode.Q) ||
				OVRInput.Get (OVRInput.Axis1D.PrimaryIndexTrigger) > 0.5f) {
				leftTreadFrameCount++;
				if (leftTreadFrameCount > 20) {
					leftTreadFrameCount = 20;
				}
			} else if (Application.isEditor && Input.GetKey (KeyCode.Z) ||
				OVRInput.Get (OVRInput.Button.PrimaryShoulder)) {
				leftTreadFrameCount--;
				if (leftTreadFrameCount < -20) {
					leftTreadFrameCount = -20;
				}
			} else if (leftTreadFrameCount > 1) {
				leftTreadFrameCount -= 2;
			} else if (leftTreadFrameCount < -1) {
				leftTreadFrameCount += 2;
			} else {
				leftTreadFrameCount = 0;
			}

			//ANIMATE RIGHT TREAD
			if (Application.isEditor && Input.GetKey (KeyCode.E) ||
				OVRInput.Get (OVRInput.Axis1D.SecondaryIndexTrigger) > 0.5f) {
				rightTreadFrameCount++;
				if (rightTreadFrameCount > 20) {
					rightTreadFrameCount = 20;
				}
			} else if (Application.isEditor && Input.GetKey (KeyCode.C) ||
				OVRInput.Get (OVRInput.Button.SecondaryShoulder)) {
				rightTreadFrameCount--;
				if (rightTreadFrameCount < -20) {
					rightTreadFrameCount = -20;
				}
			} else if (rightTreadFrameCount > 1) {
				rightTreadFrameCount -= 2;
			} else if (rightTreadFrameCount < -1) {
				rightTreadFrameCount += 2;
			} else {
				rightTreadFrameCount = 0;
			}

			// ROTATE BODY
			// Disable body rotation for now...
			/*if (Input.GetKey(KeyCode.A) ||
			OVRInput.Get(OVRInput.Button.DpadLeft)
			)
			{
				anim.SetFloat("RotateSpeed", 0.5f);
			}
			else if (
				Input.GetKey(KeyCode.D) ||
				OVRInput.Get(OVRInput.Button.DpadRight)
			)
			{
				anim.SetFloat("RotateSpeed", -0.5f);
			}
			else
			{
				anim.SetFloat("RotateSpeed", 0f);
			}
	        */

			// BOOM
			if (Application.isEditor && Input.GetKey (KeyCode.W) ||
				OVRInput.Get (OVRInput.Axis2D.PrimaryThumbstick) [1] > 0.5f) {

				if (anim.GetInteger ("BigArmPosition") != 2) {
					anim.SetInteger ("BigArmPosition", 1);
					anim.SetFloat ("BigArmSpeed", 1f);
				}
				if (!boomSource.isPlaying) {
					boomSource.Play ();
				}

			} else if (Application.isEditor && Input.GetKey (KeyCode.S) ||
				OVRInput.Get (OVRInput.Axis2D.PrimaryThumbstick) [1] < -0.5f) {

				if (anim.GetInteger ("BigArmPosition") != 0) {
					anim.SetInteger ("BigArmPosition", 1);
					anim.SetFloat ("BigArmSpeed", -1f);
				}
				if (!boomSource.isPlaying) {
					boomSource.Play ();
				}

			} else {
				anim.SetFloat ("BigArmSpeed", 0);

				if (boomSource.isPlaying) {
					boomSource.Stop ();
				}
			}

			// STICK
			if (Application.isEditor && Input.GetKey(KeyCode.UpArrow) ||
				OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick)[1] > 0.5f) {
				if (anim.GetInteger("SmallArmPosition") != 2) {
					anim.SetInteger("SmallArmPosition", 1);
					anim.SetFloat("SmallArmSpeed", 1f);
				}
				if (!stickSource.isPlaying) {
					stickSource.Play ();
				}

			} else if (Application.isEditor && Input.GetKey(KeyCode.DownArrow) ||
				OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick)[1] < -0.5f) {
				if (anim.GetInteger("SmallArmPosition") != 0) {
					anim.SetInteger("SmallArmPosition", 1);
					anim.SetFloat("SmallArmSpeed", -1f);
				}
				if (!stickSource.isPlaying) {
					stickSource.Play ();
				}
			} else {
				anim.SetFloat("SmallArmSpeed", 0);

				if (stickSource.isPlaying) {
					stickSource.Stop ();
				}
			}

			// BUCKET
			if (Application.isEditor && Input.GetKey(KeyCode.LeftArrow) ||
				OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick)[0] < -0.5f) {
				if (anim.GetInteger("ShovelPosition") != 2) {
					anim.SetInteger("ShovelPosition", 1);
					anim.SetFloat("ShovelSpeed", 1f);
				}
				if (!bucketSource.isPlaying) {
					bucketSource.Play ();
				}
			} else if (Application.isEditor && Input.GetKey(KeyCode.RightArrow) ||
				OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick)[0] > 0.5f) {
				if (anim.GetInteger("ShovelPosition") != 0) {
					anim.SetInteger("ShovelPosition", 1);
					anim.SetFloat("ShovelSpeed", -1f);
				}
				if (!bucketSource.isPlaying) {
					bucketSource.Play ();
				}
			} else {
				anim.SetFloat("ShovelSpeed", 0);

				if (bucketSource.isPlaying) {
					bucketSource.Stop ();
				}
			}

			ExcavatorFixedUpdate ();
			break;
		case GameManager.Origin.Leaving:
			// Update may still be called after GoingToMainMenu() has been called...
			break;
		default:
			throw new System.Exception ("how did this happen...");
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("BluePickup") ||
			other.gameObject.CompareTag ("RedPickup")) {

			// hit a pickup
			SphereCollider c = other.gameObject.GetComponent<SphereCollider> ();
			if (c.isTrigger) {
				// still a trigger, has not been hit before
				Rigidbody pickupRB = other.gameObject.GetComponent<Rigidbody> ();
				pickupRB.isKinematic = false;
				c.isTrigger = false;
			}
		}
	}

	public void GoingToMainMenu() {

//		PreserveAnimatorOnDisable preserveScript = (PreserveAnimatorOnDisable) gameObject.GetComponent(typeof(PreserveAnimatorOnDisable));
//		preserveScript.OnAnimDisable ();

		//rebinded = false;

		GameManager.instance.playerPosition = gameObject.transform.position;
		GameManager.instance.playerRotation = gameObject.transform.rotation;

		//Debug.Log ("disabling: " + instance.gameObject.transform.position.ToString("G4") + " " + instance.gameObject.transform.rotation.ToString("G4"));

		// disable player while in main menu
		gameObject.SetActive (false);
	}

	void OnCollisionEnter(Collision collision) {
		Debug.Log ("collide: " + collision.collider.gameObject.tag);
	}
}
