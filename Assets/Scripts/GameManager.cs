using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;

	public Vector3 playerPosition;
	public Quaternion playerRotation;
	//private bool playerRebinded;

	public AudioSource source;
	public AudioClip normalMusic;
	public AudioClip endingMusic;

	public AudioClip idling_clip;
	public AudioClip driving_clip;
	public AudioClip hydraulic_clip;

	public Transform spawnPoint;

	// how did the level start?
	// Start - Game started normally
	// Resume - Game is resuming from the main menu
	// Leaving - Game is leaving to the main menu
	public enum Origin {
		Start,
		Resume,
		Leaving
	}

	public Origin origin;

	//Awake is always called before any Start functions
	void Awake()
	{
		if (instance == null) {
			instance = this;

			DontDestroyOnLoad (gameObject);

			// setup GameManager
			instance.source.clip = normalMusic;
			instance.origin = Origin.Start;
		} else if (instance != this) {
			
			Destroy (gameObject);

			instance.origin = Origin.Resume;
		} else {
			throw new System.Exception ("how did this happen...");
		}
	}

	void Start () {
		switch (origin) {
		case Origin.Start:
			// start playing music
			source.Play ();
			break;
		case Origin.Resume:
			throw new System.Exception ("not allowed to happen");
		case Origin.Leaving:
			throw new System.Exception ("not allowed to happen");
		default:
			throw new System.Exception ("how did this happen...");
		}
	}

	void Update () {
		
		switch (origin) {
		case Origin.Start:
			if (Portal.blueInstance.isUnlocked() && Portal.redInstance.isUnlocked() &&
				source.clip != endingMusic) {
				// start boss battle
				//instance.source.Stop ();
				//instance.source.clip = instance.endingMusic;
				//instance.source.PlayDelayed (3.0f);
				//Instantiate(instance.enemy, instance.spawnPoint.position, instance.spawnPoint.rotation);
			}
			break;
		case Origin.Resume:
			// unmute music
			if (source.mute) {
				source.mute = false;
			}
			if (Portal.blueInstance.isUnlocked() && Portal.redInstance.isUnlocked() &&
				source.clip != endingMusic) {
				// start boss battle
				//instance.source.Stop ();
				//instance.source.clip = instance.endingMusic;
				//instance.source.PlayDelayed (3.0f);
				//Instantiate(instance.enemy, instance.spawnPoint.position, instance.spawnPoint.rotation);
			}
			break;
		case Origin.Leaving:
			// Update may still be called after GoingToMainMenu() has been called...
			break;
		default:
			throw new System.Exception ("how did this happen...");
		}
	}

	public void GoingToMainMenu() {

		origin = Origin.Leaving;

		// mute the music
		source.mute = true;

		// dispatch to all other stateful gameobjects
		GameObject player = GameObject.Find("Player");
		Player playerScript = (Player) player.GetComponent(typeof(Player));
		playerScript.GoingToMainMenu();

		Pickup.blueInstance.GoingToMainMenu ();
		Pickup.redInstance.GoingToMainMenu ();
		Portal.blueInstance.GoingToMainMenu ();
		Portal.redInstance.GoingToMainMenu ();
		Walls.instance.GoingToMainMenu ();
	}
}
