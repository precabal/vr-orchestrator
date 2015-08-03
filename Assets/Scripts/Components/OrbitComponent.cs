using UnityEngine;
using System.Collections;

public class OrbitComponent : MonoBehaviour
{

	public float angularVelocity;
	
	void Start ()
	{
	}

	void FixedUpdate ()
	{

		//rotate over center with that velociy delta
		this.transform.RotateAround (Vector3.zero, Vector3.up, angularVelocity * Time.deltaTime);

	}
}

