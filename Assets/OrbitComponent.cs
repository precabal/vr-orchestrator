using UnityEngine;
using System.Collections;

public class OrbitComponent : MonoBehaviour
{

	public float angularVelocity;

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		//Get object's position

	
		//Calculate angular velocity
		this.transform.RotateAround (Vector3.zero, Vector3.up, angularVelocity * Time.deltaTime);

		//rotate over center with that velociy delta
	}
}

