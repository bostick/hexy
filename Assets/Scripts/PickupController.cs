using UnityEngine;
using System.Collections;

public class PickupController : MonoBehaviour {

	private Rigidbody rb;

	private float minimum = 0.5f;
	private float maximum = 2.0f;
	//private float duration = 5.0f;
	private float startTime;
	private float startPhase;

	void Start()
	{
		rb = GetComponent<Rigidbody>();


		startPhase = 5.0f * Random.value;

		startTime = Time.time + startPhase;
		//Debug.Log (startPhase);
	}

	// Update is called once per frame
	void Update () {

		if (rb.isKinematic)
		{



			//transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
			float t = (Time.time - startTime);

			//float y = minimum + (maximum - minimum) * (0.5f * (1.0f + Mathf.Sin (t)));
			float y =  minimum + (maximum - minimum) * (0.5f * (1.0f + Mathf.Sin (t)));

			//Debug.Log ((maximum) + " " + (minimum) + " " + (maximum - minimum) + " " + ( y));

			transform.position = new Vector3(transform.position.x, y, transform.position.z);
		}
	}
}
