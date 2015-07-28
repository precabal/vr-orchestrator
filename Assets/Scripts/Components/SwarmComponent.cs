using UnityEngine;
using System.Collections.Generic;

public class SwarmComponent : MonoBehaviour
{
	public List<GameObject> objectsInSwarm;
	private List<GameObject> objectsAndLeader;

	private float maximumSpeed = 12f;
	private float maximumForce = 10f;

	//private float maxRadius = 20f;


	void Start ()
	{
		//set initial variables
		objectsAndLeader = new List<GameObject>(objectsInSwarm);
		objectsAndLeader.Add (this.gameObject);
		
	}
	void FixedUpdate ()
	{

		foreach (GameObject obj in objectsInSwarm) {

			Vector3 separate = Separate (obj, objectsAndLeader);
			Vector3 align = Align (obj, objectsAndLeader);
			Vector3 cohesion = Cohesion (obj, objectsAndLeader);
		
			separate = separate * 1f;
			align = align * 0.01f;
			cohesion = cohesion * 1f;
			
			Rigidbody rb = obj.GetComponent<Rigidbody> ();

			rb.AddForce (separate);
			rb.AddForce (align);
			rb.AddForce (cohesion);

			//float inverseForce = -1f / (maxRadius * (maxRadius - this.transform.position.magnitude));
			//rb.AddForce(this.transform.position*inverseForce);


		}
		
	}

	private Vector3 Separate(GameObject obj, List<GameObject> objects)
	{
		float desiredSeparation = 0.5f;
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
		float neighborDistance = 6f;
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
		float neighborDistance = 25f;
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