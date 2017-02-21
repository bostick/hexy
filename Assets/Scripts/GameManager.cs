using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
		
	public AudioSource source;
	public AudioClip normalMusic;
	public AudioClip endingMusic;

	public GameObject player;
	public GameObject enemy;

	public GameObject bluePickup;
	public GameObject redPickup;

	public GameObject bluePortal;
	public GameObject redPortal;

	private bool BlueUnlocked = false;
	private bool RedUnlocked = false;

	public Transform spawnPoint;

	public void unlockBlue() {
		//Debug.Log ("unlocking blue");
		BlueUnlocked = true;
	}

	public void unlockRed() {
		RedUnlocked = true;
	}

	//Awake is always called before any Start functions
	void Awake()
	{
		//Check if instance already exists
		if (instance == null)

			//if not, set instance to this
			instance = this;

		//If instance already exists and it's not this:
		else if (instance != this)

			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
			Destroy(gameObject);    

		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(gameObject);


		source.clip = normalMusic;
	}

	// Use this for initialization
	void Start () {
		source.Play ();
	}
	
	// Update is called once per frame
	void Update () {

		//Debug.Log (instance.BlueUnlocked + " " + instance.RedUnlocked + " " + (source.clip != endingMusic));



		if (BlueUnlocked && RedUnlocked &&
			source.clip != endingMusic) {


			source.Stop ();

			source.clip = endingMusic;
			source.PlayDelayed (3.0f);

			//GameObject[] objects = new GameObject[20];
			//SceneManager.GetActiveScene ().GetRootGameObjects (objects);
			Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);

		}

	}

	public void GoingToMainMenu() {

		// stop music
		source.Stop ();

	}
}
