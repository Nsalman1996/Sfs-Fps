using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {
	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	public CharacterController _Controller = null;
	private Vector3 moveDirection = Vector3.zero;

	void Update() {
		if(_Controller == null)
			return;

		if (_Controller.isGrounded) {
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			if (Input.GetButton("Jump"))
				moveDirection.y = jumpSpeed;
			
		}
		var rotateY = (Input.GetAxis("Mouse X")*200)*Time.deltaTime;

		_Controller.transform.Rotate(0,rotateY,0);

		moveDirection.y -= gravity * Time.deltaTime;

		_Controller.Move(moveDirection * Time.deltaTime);
	}
}