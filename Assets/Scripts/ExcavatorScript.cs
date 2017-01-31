using UnityEngine;
using System.Collections;

public class ExcavatorScript : MonoBehaviour {

//	public float maxMotorTorque;
//	public WheelCollider frontLeft;
//	public WheelCollider frontRight;
//	public WheelCollider rearLeft;
//	public WheelCollider rearRight;


	private Rigidbody rb;
	//private BoxCollider bc;

	//private bool added = false;

	//Animator
	public Animator anim;
	float rotSpeed = 50f;
	float rotRevSpeed = 30f;
	public float driveSpeed = 2f;
	//Door
	//bool opened = false;

	//public bool InDriveMode = true;
	//Animate UV'S
	public float scrollSpeed = 0.5f;

	float offsetL;
	float offsetR;

	public bool U = false;
	public bool V = true;

	private Material matL;
	private Material matR;

	//Treads
	public GameObject TreadsL;
	public GameObject TreadsR;

	//Weight Points - determines the rotation and movement axis of the Excavator
	public GameObject leftTread;
	public GameObject rightTread;

	//Big Wheels
	public GameObject WheelFrontLeft;
	public GameObject WheelFrontRight;

	public GameObject WheelBackLeft;
	public GameObject WheelBackRight;


	void Start()
	{
		// Materials for the Treads
		matL = TreadsL.GetComponent<Renderer> ().material;
		matR = TreadsR.GetComponent<Renderer> ().material;


//		Debug.Log ("begin");
//		Debug.Log (anim.layerCount);
//		Debug.Log (anim.parameterCount);
//		for (int i = 0; i < anim.parameterCount; i++) {
//			AnimatorControllerParameter p = anim.GetParameter (i);
//			Debug.Log (p.name);
//		}
//		Debug.Log ("end");



		//set the bigarm to a non colliding position
		anim.SetFloat("BigArmSpeed",10f);
		anim.Play("BigOpen", 1, (1f/30f)*5f);
		//anim.SetInteger("BigArmPosition",2);




		rb = GetComponent<Rigidbody> ();
		rb.centerOfMass = new Vector3(0, 0f, 0);


		//bc = GetComponent<BoxCollider> ();

		//bc.bounds

		//rb.AddForce (1000f * Vector3.forward);
		//rb.AddForceAtPosition(1000f * Vector3.forward, new Vector2(0f, 0f, 1f));
		//rb.AddForceAtPosition (Vector3.forward * 1000f, transform.position+new Vector3(2f, 0f, 0f));
	}

	void FixedUpdate() {
		//anim.SetFloat("RotateSpeed", 0.5f);

		//rb.AddForce (100000f * Vector3.forward);

		//Vector3 NewPosition2 = rb.transform.TransformPoint(new Vector3(0f, -0.25f, 0f));
		//rb.AddForceAtPosition (rb.transform.TransformPoint(Vector3.forward * 100000f), NewPosition2);


		//rb.AddForceAtPosition(Vector3.up, Vector3.right);

		//Vector3 NewPosition = rb.transform.TransformPoint(leftTread.transform.position);
		//rb.AddForceAtPosition(200000f * Vector3.forward, NewPosition);

//		if (!added) {
//			added = true;
//			Vector3 NewPosition = rb.transform.TransformPoint(new Vector3(5f, 0f, -10f));
//			rb.AddForceAtPosition (100f * Vector3.forward, NewPosition, ForceMode.Force);
//		}


//		frontLeft.motorTorque = maxMotorTorque;
//		frontRight.motorTorque = maxMotorTorque;
//		rearLeft.motorTorque = maxMotorTorque;
//		rearRight.motorTorque = maxMotorTorque;


//		float moveHorizontal = Input.GetAxis ("Horizontal");
//		float moveVertical = Input.GetAxis ("Vertical");
//
//		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
//
//		rb.AddForce (movement * speed);

		//ANIMATE LEFT TREAD
		//if (Input.GetKey(KeyCode.Q) && !Input.GetKey(KeyCode.A))
		if (Input.GetKey(KeyCode.Q) ||
			OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) > 0.5f )
		{
			// apply torque
			transform.RotateAround(rightTread.transform.position, Vector3.up, Time.deltaTime * rotSpeed);
			//rb.AddForceAtPosition(Vector3.forward, leftTread.transform.position);
			//Vector3 NewPosition = rb.transform.TransformPoint(new Vector3(5f, 0f, 0f));
			//rb.AddForceAtPosition (10f * Vector3.forward, NewPosition, ForceMode.Force);

			// animate
			offsetL = Time.time * scrollSpeed % 1;
			WheelFrontLeft.transform.Rotate(-Vector3.forward * Time.deltaTime *rotSpeed *4);
			WheelBackLeft.transform.Rotate(-Vector3.forward * Time.deltaTime *rotSpeed *4);

		}

		if (Input.GetKey(KeyCode.Z) ||
			OVRInput.Get(OVRInput.Button.PrimaryShoulder))
		{
			// apply torque
			transform.RotateAround(rightTread.transform.position, -Vector3.up, Time.deltaTime * rotRevSpeed);
			//rb.AddForceAtPosition(-Vector3.forward, leftTread.transform.position);
			//Vector3 NewPosition = rb.transform.TransformPoint(new Vector3(5f, 0f, -10f));
			//rb.AddForceAtPosition (-100f * Vector3.forward, NewPosition, ForceMode.Force);

			// animate
			offsetL = Time.time * -scrollSpeed % 1;
			WheelFrontLeft.transform.Rotate(Vector3.forward * Time.deltaTime *rotRevSpeed *4);
			WheelBackLeft.transform.Rotate(Vector3.forward * Time.deltaTime *rotRevSpeed *4);

		}

		//ANIMATE RIGHT TREAD
		//if (Input.GetKey(KeyCode.E) && !Input.GetKey(KeyCode.D))
		if (Input.GetKey(KeyCode.E) ||
			OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0.5f )
		{
			transform.RotateAround(leftTread.transform.position, -Vector3.up, Time.deltaTime * rotSpeed);
			//rb.AddForceAtPosition(Vector3.forward, rightTread.transform.position);
			//Vector3 NewPosition = rb.transform.TransformPoint(new Vector3(-5f, 0f, -10f));
			//rb.AddForceAtPosition (100f * Vector3.forward, NewPosition, ForceMode.Force);

			offsetR = Time.time * scrollSpeed % 1;
			WheelFrontRight.transform.Rotate(Vector3.forward * Time.deltaTime *rotSpeed *4);
			WheelBackRight.transform.Rotate(Vector3.forward * Time.deltaTime *rotSpeed *4);
		}

		//if (!Input.GetKey(KeyCode.E) && Input.GetKey(KeyCode.D))
		if (Input.GetKey(KeyCode.C) ||
			OVRInput.Get(OVRInput.Button.SecondaryShoulder))
		{
			transform.RotateAround(leftTread.transform.position, Vector3.up, Time.deltaTime * rotRevSpeed);
			//rb.AddForceAtPosition(-Vector3.forward, rightTread.transform.position);
			//Vector3 NewPosition = rb.transform.TransformPoint(new Vector3(-5f, 0f, -10f));
			//rb.AddForceAtPosition (-100f * Vector3.forward, NewPosition, ForceMode.Force);

			offsetR = Time.time * -scrollSpeed % 1;
			WheelFrontRight.transform.Rotate(-Vector3.forward * Time.deltaTime *rotRevSpeed *4);
			WheelBackRight.transform.Rotate(-Vector3.forward * Time.deltaTime *rotRevSpeed *4);
		}




		//---------------------------------------------------------ROTATE BODY----------------------------------------------------------
		//if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
		if (Input.GetKey(KeyCode.A) ||
			//OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick)[0] < -0.5f ||
			OVRInput.Get(OVRInput.Button.DpadLeft)
			)
		{
			anim.SetFloat("RotateSpeed", 0.5f);
		}
		else if (
			Input.GetKey(KeyCode.D) ||
			//!Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)
			//OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick)[0] > 0.5f
			OVRInput.Get(OVRInput.Button.DpadRight)
		)
		{
			anim.SetFloat("RotateSpeed", -0.5f);
		}
		else
		{
			anim.SetFloat("RotateSpeed", 0f);
		}

//		if (Input.GetKey(KeyCode.P)) {
//			anim.Play("TurnAround", 4, (1f/60f)*20f);
//		}



		//-------------------------------------------------BIG ARM-----------------------------------------------------------------
		if (
			(Input.GetKey(KeyCode.W) ||
			//Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S)
				OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick)[1] > 0.5f)
			&& anim.GetInteger("BigArmPosition")!=2)
		{
			anim.SetInteger("BigArmPosition",1);
			anim.SetFloat("BigArmSpeed",1f);
		}
		else if (
			(Input.GetKey(KeyCode.S) ||
			//!Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S)
				OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick)[1] < -0.5f)
			&& anim.GetInteger("BigArmPosition")!=0)
		{
			anim.SetInteger("BigArmPosition",1);
			anim.SetFloat("BigArmSpeed", -1f);
		}
		else
		{
			anim.SetFloat("BigArmSpeed", 0);
		}





		//-------------------------------------------------------SMALL ARM-------------------------------------------------------------
		if (
			(Input.GetKey(KeyCode.UpArrow) ||
			//Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow)
				OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick)[1] > 0.5f)
			&& anim.GetInteger("SmallArmPosition")!=2)
		{
			anim.SetInteger("SmallArmPosition",1);
			anim.SetFloat("SmallArmSpeed",1f);
		}
		else if (
			(Input.GetKey(KeyCode.DownArrow) ||
			//!Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.DownArrow)
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
			//Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow)
				OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick)[0] < -0.5f)
			&& anim.GetInteger("ShovelPosition")!=2)
		{
			anim.SetInteger("ShovelPosition",1);
			anim.SetFloat("ShovelSpeed", 1f);
		}
		else if (
			(Input.GetKey(KeyCode.RightArrow) ||
			//!Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow)
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

	void Update() 
	{
		




		

//		//ANIMATE LEFT TREAD
//		//if (Input.GetKey(KeyCode.Q) && !Input.GetKey(KeyCode.A))
//	if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0.5f )
//		{
//			// apply torque
//			transform.RotateAround(leftTread.transform.position, -Vector3.up, Time.deltaTime * rotSpeed);
//
//			// animate
//			offsetR = Time.time * scrollSpeed % 1;
//			WheelFrontRight.transform.Rotate(Vector3.forward * Time.deltaTime *rotSpeed *4);
//			WheelBackRight.transform.Rotate(Vector3.forward * Time.deltaTime *rotSpeed *4);
//
//		}
//
//		if (OVRInput.Get(OVRInput.Button.SecondaryShoulder))
//		{
//			// apply torque
//			transform.RotateAround(leftTread.transform.position, Vector3.up, Time.deltaTime * rotSpeed);
//
//			// animate
//			offsetR = Time.time * -scrollSpeed % 1;
//			WheelFrontRight.transform.Rotate(-Vector3.forward * Time.deltaTime *rotSpeed *4);
//			WheelBackRight.transform.Rotate(-Vector3.forward * Time.deltaTime *rotSpeed *4);
//		}
//
//		//ANIMATE RIGHT TREAD
//		//if (Input.GetKey(KeyCode.E) && !Input.GetKey(KeyCode.D))
//		if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) > 0.5f )
//		{
//			transform.RotateAround(rightTread.transform.position, Vector3.up, Time.deltaTime * rotSpeed);
//			offsetL = Time.time * scrollSpeed % 1;
//			WheelFrontLeft.transform.Rotate(-Vector3.forward * Time.deltaTime *rotSpeed *4);
//			WheelBackLeft.transform.Rotate(-Vector3.forward * Time.deltaTime *rotSpeed *4);
//		}
//
//		//if (!Input.GetKey(KeyCode.E) && Input.GetKey(KeyCode.D))
//		if (OVRInput.Get(OVRInput.Button.PrimaryShoulder))
//		{
//			transform.RotateAround(rightTread.transform.position, -Vector3.up, Time.deltaTime * rotSpeed);
//			offsetL = Time.time * -scrollSpeed % 1;
//			WheelFrontLeft.transform.Rotate(Vector3.forward * Time.deltaTime *rotSpeed *4);
//			WheelBackLeft.transform.Rotate(Vector3.forward * Time.deltaTime *rotSpeed *4);
//		}

		//------------------------------------------------------DOOR OPEN / CLOSE-----------------------------------------------------
		//if (Input.GetKeyDown(KeyCode.F))
//		if (OVRInput.Get(OVRInput.Button.One)
//			&& !opened)
//		{
//			opened = true;
//			//Debug.Log ("BKB Hit A Button. Door is now: " + opened.ToString());
//
//			//anim.
//
//			anim.SetBool("DoorOpen", opened);
//		}

		//--------------------------------------------------------------Animate UV's---------------------------------------------------
		if(U && V)
		{
			matL.mainTextureOffset = new Vector2(offsetL,offsetL);
			matR.mainTextureOffset = new Vector2(offsetR,offsetR);
		}
		else if(U)
		{
			matL.mainTextureOffset = new Vector2(offsetL,0);
			matR.mainTextureOffset = new Vector2(offsetR,0);
		}
		else if(V)
		{
			matL.mainTextureOffset = new Vector2(0,offsetL);
			matR.mainTextureOffset = new Vector2(0,offsetR);
		}
	}

//	void OnTriggerEnter(Collider other) {
//		//Destroy (other.gameObject);
//
////		if (other.gameObject.CompareTag("Pick Up")) {
////			other.gameObject.SetActive (false);
////			count = count + 1;
////			SetCountText ();
////		}
//
//		Debug.Log ("Collision!");
//
//	}
}
