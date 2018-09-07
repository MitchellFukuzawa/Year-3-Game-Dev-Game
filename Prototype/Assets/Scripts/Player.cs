using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	private float xVel;
	private float yVel;
	private float xFire;
	private float yFire;
	private Vector3 inputVector;

	public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		xVel = Input.GetAxis("H_LStick");
		yVel = Input.GetAxis("V_LStick");

		inputVector = new Vector3(xVel, 0, yVel);

		print("X_Vel: "+ xVel);
		print("z_Vel: "+ yVel);

		if (xVel != 0 || yVel != 0)
		{
			GetComponent<Rigidbody>().AddForce(inputVector.normalized * speed);
		}

		GetComponent<Rigidbody>().velocity = new Vector3 (speed * xVel, 0f, speed * yVel);

		Vector3 playerDirection = Vector3.right * Input.GetAxisRaw("H_RStick") + Vector3.forward * -Input.GetAxisRaw("V_RStick");
		if(playerDirection.sqrMagnitude > 0.0f)
		{
			transform.rotation = Quaternion.LookRotation(playerDirection, Vector3.up);
		}


	}
}
