using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour
{

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
        matL = TreadsL.GetComponent<Renderer>().material;
        matR = TreadsR.GetComponent<Renderer>().material;


        //		Debug.Log ("begin");
        //		Debug.Log (anim.layerCount);
        //		Debug.Log (anim.parameterCount);
        //		for (int i = 0; i < anim.parameterCount; i++) {
        //			AnimatorControllerParameter p = anim.GetParameter (i);
        //			Debug.Log (p.name);
        //		}
        //		Debug.Log ("end");



        //set the bigarm to a non colliding position
        anim.SetFloat("BigArmSpeed", 10f);
        anim.Play("BigOpen", 1, (1f / 30f) * 30f);

        anim.SetFloat("SmallArmSpeed", 10f);
        anim.Play("SmallOpen", 2, (1f / 30f) * 30f);

        //anim.SetInteger("BigArmPosition",2);


        anim.SetFloat("RotateSpeed", 0.5f);





        






        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0, 2f, 0);


        //bc = GetComponent<BoxCollider> ();

        //bc.bounds

        //rb.AddForce (1000f * Vector3.forward);
        //rb.AddForceAtPosition(1000f * Vector3.forward, new Vector2(0f, 0f, 1f));
        //rb.AddForceAtPosition (Vector3.forward * 1000f, transform.position+new Vector3(2f, 0f, 0f));
    }

    private bool opening = true;

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

    void Update()
    {

        //--------------------------------------------------------------Animate UV's---------------------------------------------------
        if (U && V)
        {
            matL.mainTextureOffset = new Vector2(offsetL, offsetL);
            matR.mainTextureOffset = new Vector2(offsetR, offsetR);
        }
        else if (U)
        {
            matL.mainTextureOffset = new Vector2(offsetL, 0);
            matR.mainTextureOffset = new Vector2(offsetR, 0);
        }
        else if (V)
        {
            matL.mainTextureOffset = new Vector2(0, offsetL);
            matR.mainTextureOffset = new Vector2(0, offsetR);
        }
    }

}
