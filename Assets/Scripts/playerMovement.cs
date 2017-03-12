using UnityEngine;
using System.Collections;

[RequireComponent (typeof(CharacterController))]
//[RequireComponent (typeof(Animation))]
public class playerMovement : MonoBehaviour {
    //static Animator anim;
    public float moveSpeed;
    public float rotateSpeed;
    public float jump;
   
    private CharacterController _controller;
    private Transform mytransform;
 //   private Animation anim;

    void Awake()
    {
        mytransform = transform;
        _controller = GetComponent<CharacterController>();
    }
    void Start()
    {
       // anim = GetComponent<Animator>();
    }
	void Update ()
    {
      turn();
       walk();

      
  	}
    void walk()
    {
        if (Mathf.Abs(Input.GetAxis("Vertical")) > 0)
        {
            mytransform.Rotate(0, Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed, 0);
            _controller.SimpleMove(mytransform.TransformDirection(Vector3.forward) * Input.GetAxis("Vertical") * moveSpeed);
          //  anim.SetBool("iswalking",true);
        }
            else 
            {
           // anim.SetBool("iswalking",false);
        
            }
        
    }
    void turn()
    {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0)
        {
            mytransform.Rotate(0, Input.GetAxis("Horizontal") * Time.deltaTime * rotateSpeed, 0);
            mytransform.rotation = transform.rotation;
        }
    }
  /*  void run()
    {
        if (Mathf.Abs(Input.GetAxis("Vertical")) > 0)
        {
            mytransform.Rotate(0, Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed* moveSpeed, 0);
            _controller.SimpleMove(mytransform.TransformDirection(Vector3.forward) * Input.GetAxis("Vertical") * moveSpeed* moveSpeed);
            anim.SetBool("iswalking", true);
        }
        else
        {
            anim.SetBool("iswalking", false);

        }
    }*/
      
}
