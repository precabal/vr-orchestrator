using UnityEngine;
using System.Collections.Generic;

public class SwarmComponent : MonoBehaviour
{
	public List<GameObject> objectsInSwarm;
	
	private float maximumSpeed = 200f;
	private float maximumForce = 50f;


	void Start ()
	{
		//set initial variables
		
	}
	void FixedUpdate ()
	{

		foreach (GameObject obj in objectsInSwarm) {

			Vector3 separate = Separate (obj, objectsInSwarm);
			Vector3 align = Align (obj, objectsInSwarm);
			Vector3 cohesion = Cohesion (obj, objectsInSwarm);
		
			separate = separate * 2.0f;
			align = align * 0.1f;
			cohesion = cohesion * 0.5f;
			
			Rigidbody rb = obj.GetComponent<Rigidbody> ();


			rb.AddForce (separate);
			rb.AddForce (align);
			rb.AddForce (cohesion);

			//Debug.Log(separate + "/" + align + "/" + cohesion);

		}
		
	}

	private Vector3 Separate(GameObject obj, List<GameObject> objects)
	{
		float desiredSeparation = 1.0f;
		Vector3 steer = new Vector3 (0, 0, 0);
		int count = 0;
		
		foreach (GameObject other in objects)
		{
			float distance =  Vector3.Distance(obj.transform.position, other.transform.position);
			
			if (0 < distance && distance < desiredSeparation)
			{
				Vector3 diff = obj.transform.position - other.transform.position;
				diff.Normalize();
				diff = diff / distance;
				steer = steer + diff;
				count++;
			}
		}
		
		if (count > 0)
		{
			steer = steer / count;
		}
		
		if (steer.magnitude > 0)
		{
			steer.Normalize();
			steer = steer * maximumSpeed;
			steer = steer - obj.GetComponent<Rigidbody>().velocity;
			steer = Vector3.ClampMagnitude(steer, maximumForce);
		}
		
		return steer;
	}
	
	private Vector3 Align(GameObject obj, List<GameObject> objects)
	{
		float neighborDistance = 50;
		Vector3 sum = new Vector3(0, 0, 0);
		int count = 0;
		foreach (GameObject other in objects)
		{
			float distance = Vector3.Distance(obj.transform.position, other.transform.position);
			if (distance > 0 && distance < neighborDistance)
			{
				sum = sum + other.GetComponent<Rigidbody>().velocity;
				count++;
			}
		}
		if (count > 0)
		{
			sum = sum /count;
			sum.Normalize();
			sum = sum * maximumSpeed;
			Vector3 steer = sum - obj.GetComponent<Rigidbody>().velocity;
			steer = Vector3.ClampMagnitude(steer, maximumForce);
			
			return steer;
		} 
		else
		{
			return new Vector3(0, 0, 0);
		}
	}
	
	private Vector3 Cohesion(GameObject obj, List<GameObject> objects)
	{
		float neighborDistance = 50;
		Vector3 sum = new Vector3(0, 0, 0);
		int count = 0;
		foreach (GameObject other in objects)
		{
			float distance = Vector3.Distance(obj.transform.position, other.transform.position);
			if (distance > 0 && distance < neighborDistance)
			{
				sum = sum + other.transform.position;
				count++;
			}
		}
		if (count > 0)
		{
			sum = sum / count;
			return Seek(obj, sum);
		} 
		else
		{
			return new Vector3(0, 0, 0);
		}
	}
	
	private Vector3 Seek(GameObject obj, Vector3 target)
	{
		Vector3 desired = target - obj.transform.position;	
		desired.Normalize();
		desired = desired * maximumSpeed;
		
		Vector3 steer = desired - obj.GetComponent<Rigidbody>().velocity;
		steer = Vector3.ClampMagnitude(steer, maximumForce);
		return steer;
	}

	
	public void StopMovement()
	{
		Destroy(this);
	}
}