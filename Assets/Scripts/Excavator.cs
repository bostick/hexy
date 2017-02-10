using UnityEngine;
using System.Collections;

public class Excavator : MonoBehaviour {

	protected Rigidbody rb;

	public Animator anim;
	protected float rotSpeed = 75f;
	protected float rotRevSpeed = 30f;
	protected float driveSpeed = 2f;

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


	public void ExcavatorStart()
	{

		// Materials for the Treads
		matL = TreadsL.GetComponent<Renderer> ().material;
		matR = TreadsR.GetComponent<Renderer> ().material;

		rb = GetComponent<Rigidbody> ();
	}

	void FixedUpdate() {
		
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
