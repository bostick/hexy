using UnityEngine;
using System.Collections;

public class Excavator : MonoBehaviour {

	protected Rigidbody rb;

	public Animator anim;
	protected float rotSpeed = 0;
	protected float rotRevSpeed = 0;
	//protected float driveSpeed = 2f;

	protected float scrollSpeed = 0.5f;

	protected float offsetL = 0f;
	protected float offsetR = 0f;

	protected bool U = false;
	protected bool V = true;

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


	protected int leftTreadFrameCount = 0;
	protected int rightTreadFrameCount = 0;
	protected bool isDriving = false;
	protected float leftTreadRotSpeed = 0;
	protected float rightTreadRotSpeed = 0;

	public void ExcavatorStart()
	{

		// Materials for the Treads
		matL = TreadsL.GetComponent<Renderer> ().material;
		matR = TreadsR.GetComponent<Renderer> ().material;

		rb = GetComponent<Rigidbody> ();
	}

	float sgn(float x) {
		if (Mathf.Approximately (x, 0)) {
			return 0;
		} else if (x > 0) {
			return 1;
		} else {
			return -1;
		}
	}

	public void ExcavatorFixedUpdate() {

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

	}

	public void ExcavatorUpdate() 
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
