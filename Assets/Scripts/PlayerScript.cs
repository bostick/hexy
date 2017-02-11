using UnityEngine;
using System.Collections;

public class PlayerScript : Excavator {

	public AudioSource source;
	public AudioClip idling_clip;
	public AudioClip driving_clip;

	void Start()
	{
		ExcavatorStart ();

		//set the bigarm to a non colliding position
		anim.SetFloat("BigArmSpeed",10f);
		anim.Play("BigOpen", 1, (1f/30f)*5f);
		//anim.SetInteger("BigArmPosition",2);

		rb.centerOfMass = new Vector3(0, 0f, 0);

		source.clip = idling_clip;
		source.Play ();
	}

	private int leftTreadFrameCount = 0;
	private int rightTreadFrameCount = 0;

//	private bool leftTreadForward = false;
//	private bool rightTreadForward = false;
	//private enum Gear {Forward, Reverse, Neither};  

	//private Gear leftTreadGear = Gear.Neither;
	//private Gear rightTreadGear = Gear.Neither;

	private float leftTreadRotSpeed = 0;
	private float rightTreadRotSpeed = 0;

	float sgn(float x) {
		if (Mathf.Approximately (x, 0)) {
			return 0;
		} else if (x > 0) {
			return 1;
		} else {
			return -1;
		}
 	}

	void Update()
	{
		ExcavatorUpdate ();

		if (isDriving && source.clip == idling_clip)
		{
			source.clip = driving_clip;
			source.Play ();

		} else if (!isDriving && source.clip == driving_clip) {
			source.clip = idling_clip;
			source.Play ();
		}
	}

	private bool isDriving = false;

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



		if (leftTreadFrameCount > 5) {
			isDriving = true;
		} else if (leftTreadFrameCount < -5) {
			isDriving = true;
		} else if (rightTreadFrameCount > 5) {
			isDriving = true;
		} else if (rightTreadFrameCount < -5) {
			isDriving = true;
		} else {
			isDriving = false;
		}



		if (isDriving && leftTreadFrameCount > 0) {
			leftTreadRotSpeed = Mathf.Clamp (leftTreadRotSpeed + 0.1f * rotSpeed, 0, rotSpeed);
		} else if (isDriving && leftTreadFrameCount < 0) {
			leftTreadRotSpeed = Mathf.Clamp (leftTreadRotSpeed + 0.1f * -rotRevSpeed, -rotRevSpeed, 0);
		} else {
//			leftTreadRotSpeed = leftTreadRotSpeed + 0.2f * -leftTreadRotSpeed;
//			if (Mathf.Abs(leftTreadRotSpeed) < 0.001f) {
//				leftTreadRotSpeed = 0;
//			}
			leftTreadRotSpeed = 0;
		}


		if (isDriving && rightTreadFrameCount > 0) {
			rightTreadRotSpeed = Mathf.Clamp (rightTreadRotSpeed + 0.1f * rotSpeed, 0, rotSpeed);
		} else if (isDriving && rightTreadFrameCount < 0) {
			rightTreadRotSpeed = Mathf.Clamp (rightTreadRotSpeed + 0.1f * -rotRevSpeed, -rotRevSpeed, 0);
		} else {
//			rightTreadRotSpeed = rightTreadRotSpeed + 0.2f * -rightTreadRotSpeed;
//			if (Mathf.Abs(rightTreadRotSpeed) < 0.001f) {
//				rightTreadRotSpeed = 0;
//			}
			rightTreadRotSpeed = 0;
		}




		// left tread
		{
			// apply torque
			transform.RotateAround(rightTread.transform.position, Vector3.up, Time.deltaTime * leftTreadRotSpeed);

			//Debug.Log (leftTreadRotSpeed);

			// animate
			offsetL = Time.time * sgn(leftTreadRotSpeed) * scrollSpeed % 1;
			WheelFrontLeft.transform.Rotate(-Vector3.forward * Time.deltaTime *leftTreadRotSpeed *4);
			WheelBackLeft.transform.Rotate(-Vector3.forward * Time.deltaTime *leftTreadRotSpeed *4);
		}

		// right tread
		{
			transform.RotateAround(leftTread.transform.position, -Vector3.up, Time.deltaTime * rightTreadRotSpeed);

			offsetR = Time.time * sgn(rightTreadRotSpeed) * scrollSpeed % 1;
			WheelFrontRight.transform.Rotate(Vector3.forward * Time.deltaTime * rightTreadRotSpeed *4);
			WheelBackRight.transform.Rotate(Vector3.forward * Time.deltaTime * rightTreadRotSpeed *4);
		}




		//---------------------------------------------------------ROTATE BODY----------------------------------------------------------
		if (Input.GetKey(KeyCode.A) ||
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

		//-------------------------------------------------BIG ARM-----------------------------------------------------------------
		if (
			(Input.GetKey (KeyCode.W) ||
			OVRInput.Get (OVRInput.Axis2D.PrimaryThumbstick) [1] > 0.5f)
			&& anim.GetInteger ("BigArmPosition") != 2) {
			anim.SetInteger ("BigArmPosition", 1);
			anim.SetFloat ("BigArmSpeed", 1f);
		} else if (
			(Input.GetKey (KeyCode.S) ||
			OVRInput.Get (OVRInput.Axis2D.PrimaryThumbstick) [1] < -0.5f)
			&& anim.GetInteger ("BigArmPosition") != 0) {
			anim.SetInteger ("BigArmPosition", 1);
			anim.SetFloat ("BigArmSpeed", -1f);
		} else {
			anim.SetFloat ("BigArmSpeed", 0);
		}

		//-------------------------------------------------------SMALL ARM-------------------------------------------------------------
		if (
			(Input.GetKey(KeyCode.UpArrow) ||
				OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick)[1] > 0.5f)
			&& anim.GetInteger("SmallArmPosition")!=2)
		{
			anim.SetInteger("SmallArmPosition",1);
			anim.SetFloat("SmallArmSpeed",1f);
		}
		else if (
			(Input.GetKey(KeyCode.DownArrow) ||
				OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick)[1] < -0.5f)
			&& anim.GetInteger("SmallArmPosition")!=0)
		{
			anim.SetInteger("SmallArmPosition",1);
			anim.SetFloat("SmallArmSpeed", -1f);
		}
		else
		{
			anim.SetFloat("SmallArmSpeed", 0);
		}

		//----------------------------------------------------------SHOVEL-----------------------------------------------------------------
		if (
			(Input.GetKey(KeyCode.LeftArrow) ||
				OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick)[0] < -0.5f)
			&& anim.GetInteger("ShovelPosition")!=2)
		{
			anim.SetInteger("ShovelPosition",1);
			anim.SetFloat("ShovelSpeed", 1f);
		}
		else if (
			(Input.GetKey(KeyCode.RightArrow) ||
				OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick)[0] > 0.5f)
			&& anim.GetInteger("ShovelPosition")!=0)
		{
			anim.SetInteger("ShovelPosition",1);
			anim.SetFloat("ShovelSpeed", -1f);
		}
		else
		{
			anim.SetFloat("ShovelSpeed", 0);
		}
	}

	void OnTriggerEnter(Collider other) {

		if (other.gameObject.CompareTag ("Pick Up")) {

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
