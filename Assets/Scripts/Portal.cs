using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {

	public static Portal redInstance = null;
	public static Portal blueInstance = null;

	public AudioSource source;
	public AudioClip dropped_clip;

	private bool _unlocked = false;

	void Awake() {
		if (gameObject.CompareTag ("BluePortal")) {
			if (blueInstance == null) {
				blueInstance = this;

				DontDestroyOnLoad (gameObject);

			} else if (blueInstance != this) {

				Destroy (gameObject);

				// game is resuming
				blueInstance.gameObject.SetActive (true);
			} else {
				throw new System.Exception ("how did this happen...");
			}
		}

		if (gameObject.CompareTag ("RedPortal")) {
			if (redInstance == null) {
				redInstance = this;

				DontDestroyOnLoad (gameObject);

			} else if (redInstance != this) {

				Destroy (gameObject);

				// game is resuming
				redInstance.gameObject.SetActive (true);
			} else {
				throw new System.Exception ("how did this happen...");
			}
		}
	}

	void OnTriggerEnter(Collider pickup) {
		if (pickup.gameObject.CompareTag ("BluePickup") && gameObject.CompareTag ("BluePortal")) {

			Unlock ();
			Pickup.blueInstance.Unlock ();
		} else if (pickup.gameObject.CompareTag ("RedPickup") && gameObject.CompareTag ("RedPortal")) {

			Unlock ();
			Pickup.redInstance.Unlock ();
		}
	}

	// pickup dropped into portal
	public void Unlock() {
		// stop the particle fountain
		ParticleSystem sys = gameObject.GetComponentInChildren<ParticleSystem> ();
		sys.Stop ();

		// play chime sound
		source.clip = dropped_clip;
		source.Play ();

		_unlocked = true;
	}

	public bool isUnlocked() {
		return _unlocked;
	}

	public void GoingToMainMenu() {
		// disable portal while in main menu
		gameObject.SetActive (false);
	}
}
