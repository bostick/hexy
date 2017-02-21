using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class PlayerScript : Excavator {

	private AudioSource engineSource;
	private AudioSource boomSource;
	private AudioSource stickSource;
	private AudioSource bucketSource;

	public AudioClip idling_clip;
	public AudioClip driving_clip;
	public AudioClip hydraulic_clip;
	public AudioMixer mixer;

	void Start()
	{
		rotSpeed = 75;
		rotRevSpeed = 30;

		ExcavatorStart ();

		//set the bigarm to a non colliding position
		anim.SetFloat("BigArmSpeed",10f);
		anim.Play("BigOpen", 1, (1f/30f)*5f);
		//anim.SetInteger("BigArmPosition",2);

		rb.centerOfMass = new Vector3(0, 0f, 0);




		//AudioMixer mainMix = Resources.Load("MainMix") as AudioMixer;

		engineSource = gameObject.AddComponent( typeof(AudioSource) ) as AudioSource;
		engineSource.loop = true;
		engineSource.outputAudioMixerGroup = mixer.FindMatchingGroups("Driving")[0];
		engineSource.clip = idling_clip;
		engineSource.Play ();


		boomSource = gameObject.AddComponent( typeof(AudioSource) ) as AudioSource;
		boomSource.loop = true;
		boomSource.outputAudioMixerGroup = mixer.FindMatchingGroups("Hydraulic")[0];
		boomSource.clip = hydraulic_clip;
		boomSource.pitch = 1.0f;
		//boomSource.Play ();


		stickSource = gameObject.AddComponent( typeof(AudioSource) ) as AudioSource;
		stickSource.loop = true;
		stickSource.outputAudioMixerGroup = mixer.FindMatchingGroups("Hydraulic")[0];
		stickSource.clip = hydraulic_clip;
		stickSource.pitch = 1.5f;
		//stickSource.Play ();


		bucketSource = gameObject.AddComponent( typeof(AudioSource) ) as AudioSource;
		bucketSource.loop = true;
		bucketSource.outputAudioMixerGroup = mixer.FindMatchingGroups("Hydraulic")[0];
		bucketSource.clip = hydraulic_clip;
		bucketSource.pitch = 2.0f;
		//bucketSource.Play ();


	}



//	private bool leftTreadForward = false;
//	private bool rightTreadForward = false;
	//private enum Gear {Forward, Reverse, Neither};  

	//private Gear leftTreadGear = Gear.Neither;
	//private Gear rightTreadGear = Gear.Neither;





	void Update()
	{
		ExcavatorUpdate ();

		if (isDriving && engineSource.clip == idling_clip)
		{
			engineSource.clip = driving_clip;
			engineSource.Play ();

		} else if (!isDriving && engineSource.clip == driving_clip) {
			engineSource.clip = idling_clip;
			engineSource.Play ();
		}
	}

	void FixedUpdate() {

		//Debug.Log ("frame counts: " + (leftTreadFrameCount) + " " +  (rightTreadFrameCount));

//		leftTreadForward = false;
//		rightTreadForward = false;
		//bool driving = false;

		//ANIMATE LEFT TREAD
		if (Input.GetKey (KeyCode.Q) ||
		    OVRInput.Get (OVRInput.Axis1D.PrimaryIndexTrigger) > 0.5f) {
			leftTreadFrameCount++;
			if (leftTreadFrameCount > 20) {
				leftTreadFrameCount = 20;
			}
		} else if (Input.GetKey (KeyCode.Z) ||
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
		if (Input.GetKey (KeyCode.E) ||
		    OVRInput.Get (OVRInput.Axis1D.SecondaryIndexTrigger) > 0.5f) {
			rightTreadFrameCount++;
			if (rightTreadFrameCount > 20) {
				rightTreadFrameCount = 20;
			}
		} else if (Input.GetKey (KeyCode.C) ||
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


		ExcavatorFixedUpdate ();





		//---------------------------------------------------------ROTATE BODY----------------------------------------------------------
		
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

		//-------------------------------------------------BIG ARM-----------------------------------------------------------------
		if (
			(Input.GetKey (KeyCode.W) ||
			OVRInput.Get (OVRInput.Axis2D.PrimaryThumbstick) [1] > 0.5f)
			&& anim.GetInteger ("BigArmPosition") != 2) {

			anim.SetInteger ("BigArmPosition", 1);
			anim.SetFloat ("BigArmSpeed", 1f);

			if (!boomSource.isPlaying) {
				boomSource.Play ();
			}

		} else if (
			(Input.GetKey (KeyCode.S) ||
			OVRInput.Get (OVRInput.Axis2D.PrimaryThumbstick) [1] < -0.5f)
			&& anim.GetInteger ("BigArmPosition") != 0) {

			anim.SetInteger ("BigArmPosition", 1);
			anim.SetFloat ("BigArmSpeed", -1f);

			if (!boomSource.isPlaying) {
				boomSource.Play ();
			}

		} else {
			anim.SetFloat ("BigArmSpeed", 0);

			if (boomSource.isPlaying) {
				boomSource.Stop ();
			}
		}

		//-------------------------------------------------------SMALL ARM-------------------------------------------------------------
		if (
			(Input.GetKey(KeyCode.UpArrow) ||
				OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick)[1] > 0.5f)
			&& anim.GetInteger("SmallArmPosition")!=2)
		{
			anim.SetInteger("SmallArmPosition",1);
			anim.SetFloat("SmallArmSpeed",1f);

			if (!stickSource.isPlaying) {
				stickSource.Play ();
			}

		}
		else if (
			(Input.GetKey(KeyCode.DownArrow) ||
				OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick)[1] < -0.5f)
			&& anim.GetInteger("SmallArmPosition")!=0)
		{
			anim.SetInteger("SmallArmPosition",1);
			anim.SetFloat("SmallArmSpeed", -1f);

			if (!stickSource.isPlaying) {
				stickSource.Play ();
			}
		}
		else
		{
			anim.SetFloat("SmallArmSpeed", 0);

			if (stickSource.isPlaying) {
				stickSource.Stop ();
			}
		}

		//----------------------------------------------------------SHOVEL-----------------------------------------------------------------
		if (
			(Input.GetKey(KeyCode.LeftArrow) ||
				OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick)[0] < -0.5f)
			&& anim.GetInteger("ShovelPosition")!=2)
		{
			anim.SetInteger("ShovelPosition",1);
			anim.SetFloat("ShovelSpeed", 1f);

			if (!bucketSource.isPlaying) {
				bucketSource.Play ();
			}
		}
		else if (
			(Input.GetKey(KeyCode.RightArrow) ||
				OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick)[0] > 0.5f)
			&& anim.GetInteger("ShovelPosition")!=0)
		{
			anim.SetInteger("ShovelPosition",1);
			anim.SetFloat("ShovelSpeed", -1f);

			if (!bucketSource.isPlaying) {
				bucketSource.Play ();
			}
		}
		else
		{
			anim.SetFloat("ShovelSpeed", 0);

			if (bucketSource.isPlaying) {
				bucketSource.Stop ();
			}
		}
	}

	void OnTriggerEnter(Collider other) {

		if (other.gameObject.CompareTag ("BluePickup") ||
			other.gameObject.CompareTag ("RedPickup")) {

			SphereCollider c = other.gameObject.GetComponent<SphereCollider> ();
			if (c.isTrigger) {
				Rigidbody pickupRB = other.gameObject.GetComponent<Rigidbody> ();
				pickupRB.isKinematic = false;
				c.isTrigger = false;

				//Debug.Log ("Trigger! yes " + ThisThing.tag);

			}
		}
	}
}
