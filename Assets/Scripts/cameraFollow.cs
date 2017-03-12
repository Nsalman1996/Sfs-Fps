using UnityEngine;
using System.Collections;

public class cameraFollow :playerMovement {
   
     public float turnSpeed = 4.0f;
     public Transform target;
     public float height = 0.5f;
     public float distance = 0.2f;
     
     private Vector3 offsetX;
     private Vector3 offsetY;
     private Transform mytransform;
     


    void Awake()
    {
        mytransform = this.transform;
    }
	void Start () 
    {

        OffsetPos();
	}
	void Update () 
    {
      
	}
    void LateUpdate()
    {
        SetOffset();
    }
    void OffsetPos()
    {
        offsetX = new Vector3(0, height, distance);
        offsetY = new Vector3(0, 0, distance);

    }
    void SetOffset()
    {
        offsetX = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offsetX;
        offsetY = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * turnSpeed, Vector3.right) * offsetY;
      mytransform.position = target.position + offsetX;
		mytransform.rotation = target.rotation;
		mytransform.LookAt(target.position);
    }
    

    
 }