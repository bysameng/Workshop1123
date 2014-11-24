using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//This script will move objects based on key inputs
//And it will take a directional vector to move the attached object
public class PositionMover : MonoBehaviour {

	#region class vars

	//motor class vars
	public float acceleration = 200;
	public float maxVelocity = 10;

	public bool usingAxisInput = true;


	private Vector3 currentDirection = Vector3.zero;

	#endregion


	#region default monobehaviour signatures

	// Use this for initialization
	void Start () {
		if (this.rigidbody == null){
			Debug.Log("No rigidbody! Adding one.");
//			System.Console.WriteLine("No rigidbody! Adding one.");
			this.gameObject.AddComponent<Rigidbody>();
			this.rigidbody.useGravity = false;
		}
	}


	// Update is called once per frame
	void Update () {

		//have a movement vector
		Vector3 movement = Vector3.zero;


		//get input
		if (usingAxisInput){
			//inline version
//			movement.x = Input.GetAxisRaw("Horizontal");
//			movement.y = Input.GetAxisRaw("Vertical");
			//function version
//			movement = GetInputVector();
			//reference function version
			GetInputVector(ref movement);
		}
		else{
			movement = currentDirection;
		}

		//clamp the vector to length 1 
//		movement /= movement.magnitude;
//		//same thing
//		movement = movement.normalized;
//		//same thing
		movement.Normalize();

		movement *= acceleration * Time.deltaTime;

		//accelerate the rigidbody
		rigidbody.AddForce(movement);

		//clamp the rigidbody velocity
		rigidbody.velocity = 
			Vector3.ClampMagnitude(rigidbody.velocity,
		                           maxVelocity);
	}

	#endregion

	#region helper functions

	private Vector3 GetInputVector(){
		Vector3 movement = Vector3.zero;
		movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");
		return movement;
	}

	private Vector3 GetInputVector(ref Vector3 refVector){
		refVector.x = Input.GetAxisRaw("Horizontal");
		refVector.y = Input.GetAxisRaw("Vertical");
		return refVector;
	}

	#endregion

	#region public functions

	//pass in a direction 
	//to make the rigidbody move in that direction
	public void Move(Vector3 direction){
		currentDirection = direction;
	}

	#endregion


}