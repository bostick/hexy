using UnityEngine;
using System.Collections;

public class EnemyScript : Excavator {

	private bool opening = true;

    void Start()
    {
		ExcavatorStart ();

        //set the bigarm to a non colliding position
        anim.SetFloat("BigArmSpeed", 10f);
        anim.Play("BigOpen", 1, (1f / 30f) * 30f);

        anim.SetFloat("SmallArmSpeed", 10f);
        anim.Play("SmallOpen", 2, (1f / 30f) * 30f);

        //anim.SetInteger("BigArmPosition",2);


		anim.SetFloat ("RotateSpeed", 0.5f);



        rb.centerOfMass = new Vector3(0, 2f, 0);
    }

	void Update() 
	{
		ExcavatorUpdate ();
	}

    void FixedUpdate()
    {
        if (opening)
        {
            if (anim.GetInteger("BigArmPosition") != 2)
            {
                anim.SetInteger("BigArmPosition", 1);
                anim.SetFloat("BigArmSpeed", 1f);
            } else
            {
                opening = false;
            }
        }
        else
        {
            if (anim.GetInteger("BigArmPosition") != 0)
            {
                anim.SetInteger("BigArmPosition", 1);
                anim.SetFloat("BigArmSpeed", -1f);
            } else
            {
                opening = true;
            }
            
        }
    }
}
