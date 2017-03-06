using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour {

	public static Walls instance = null;

	public GameObject EastLargeWall;
	public GameObject SouthLargeWall;

	private bool triggered = false;

	void Awake() {
		if (instance == null) {
			instance = this;

			DontDestroyOnLoad (gameObject);

		} else if (instance != this) {

			Destroy (gameObject);

			// game is resuming
			instance.gameObject.SetActive (true);
		} else {
			throw new System.Exception ("how did this happen...");
		}
	}

	void Start () {
		
	}

	void Update () {
		
	}

	void FixedUpdate() {

		switch (GameManager.instance.origin) {
		case GameManager.Origin.Start:
		case GameManager.Origin.Resume:
			if (Application.isEditor && Input.GetKey (KeyCode.P) ||
				OVRInput.Get (OVRInput.Button.Four)) {
				triggered = true;
			}

			if (triggered) {

				if (SouthLargeWall.transform.position.z > -170.0f) {
					SouthLargeWall.transform.position = SouthLargeWall.transform.position + 0.005f * Vector3.back;
				}

				if (EastLargeWall.transform.position.x < 170.0f) {
					EastLargeWall.transform.position = EastLargeWall.transform.position + 0.005f * Vector3.right;
				}

			}
			break;
		case GameManager.Origin.Leaving:
			// Update may still be called after GoingToMainMenu() has been called...
			break;
		default:
			throw new System.Exception ("how did this happen...");
		}
	}

	public void GoingToMainMenu() {
		gameObject.SetActive (false);
	}
}
