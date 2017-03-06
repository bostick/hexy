using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {

	public static Pickup redInstance = null;
	public static Pickup blueInstance = null;

	private Rigidbody rb;

	private float minimum = 0.5f;
	private float maximum = 2.0f;
	private float startTime;
	private float startPhase;

	private bool _active = true;

	void Awake() {
		if (gameObject.CompareTag ("BluePickup")) {
			if (blueInstance == null) {
				blueInstance = this;

				DontDestroyOnLoad (gameObject);

			} else if (blueInstance != this) {

				Destroy (gameObject);

				// game is resuming
				if (blueInstance._active) {
					blueInstance.gameObject.SetActive (true);
				}
			} else {
				throw new System.Exception ("how did this happen...");
			}
		}

		if (gameObject.CompareTag ("RedPickup")) {
			if (redInstance == null) {
				redInstance = this;

				DontDestroyOnLoad (gameObject);

			} else if (redInstance != this) {

				Destroy (gameObject);

				// game is resuming
				if (redInstance._active) {
					redInstance.gameObject.SetActive (true);
				}
			} else {
				throw new System.Exception ("how did this happen...");
			}
		}
	}

	void Start() {
		rb = GetComponent<Rigidbody>();

		startPhase = 5.0f * Random.value;

		startTime = Time.time + startPhase;
	}

	void Update () {
		if (rb.isKinematic) {
			// pickup has not yet been touched
			// make pickup float
			float t = (Time.time - startTime);
			float y =  minimum + (maximum - minimum) * (0.5f * (1.0f + Mathf.Sin (t)));
			transform.position = new Vector3(transform.position.x, y, transform.position.z);
		}
	}

	public void GoingToMainMenu() {
		// disable pickup while in main menu
		if (_active) {
			gameObject.SetActive (false);
		}
	}

	// pickup dropped into portal
	public void Unlock() {
		gameObject.SetActive (false);
		_active = false;
	}
}
