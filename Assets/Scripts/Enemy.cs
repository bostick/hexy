using UnityEngine;
using System.Collections;

public class Enemy : Excavator {

//	private bool opening = true;

    void Start()
    {
		ExcavatorStart ();

		rotSpeed = 60;
		rotRevSpeed = 20;

        //set the bigarm to a non colliding position
        anim.SetFloat("BigArmSpeed", 10f);
        anim.Play("BigOpen", 1, (1f / 30f) * 30f);




//        anim.SetFloat("SmallArmSpeed", 10f);
//		anim.Play ("SmallOpen", 2, (1f / 30f) * 30f);
//		anim.SetFloat ("RotateSpeed", 0.5f);



        rb.centerOfMass = new Vector3(0, 0f, 0);
    }

	void Update() 
	{
		ExcavatorUpdate ();
	}

    void FixedUpdate()
    {
//        if (opening)
//        {
//            if (anim.GetInteger("BigArmPosition") != 2)
//            {
//                anim.SetInteger("BigArmPosition", 1);
//                anim.SetFloat("BigArmSpeed", 1f);
//            } else
//            {
//                opening = false;
//            }
//        }
//        else
//        {
//            if (anim.GetInteger("BigArmPosition") != 0)
//            {
//                anim.SetInteger("BigArmPosition", 1);
//                anim.SetFloat("BigArmSpeed", -1f);
//            } else
//            {
//                opening = true;
//            }
//            
//        }

		//ExcavatorFixedUpdate ();

		//Vector3 targetDir = target.position - transform.position;
		//float angle = Vector3.Angle( transform.position, GameManager.instance.player.transform.position );


//		float angle = Vector2.Angle (new Vector2(transform.position.x, transform.position.z),
//			new Vector2(GameManager.instance.player.transform.position.x,
//				GameManager.instance.player.transform.position.z));


		GameObject player = GameObject.Find("Player");
		Vector3 relative = transform.InverseTransformPoint(player.transform.position);
		float angle = Mathf.Atan2(relative.x, relative.z) * Mathf.Rad2Deg;

		//Debug.Log (angle);

		float fieldOfView = 30.0f;

		if (angle > (180.0f - fieldOfView) || angle < (-180.0f + fieldOfView)) {
			leftTreadFrameCount = 10;
			rightTreadFrameCount = 10;
		} else if (angle < 0.0f) {
			// turn right
			leftTreadFrameCount = 10;
			rightTreadFrameCount = 0;
		} else {
			// turn left
			leftTreadFrameCount = 0;
			rightTreadFrameCount = 10;
		}

//		if( angle < 5.0f )
//			print( "close" );


		ExcavatorFixedUpdate ();

    }
}
