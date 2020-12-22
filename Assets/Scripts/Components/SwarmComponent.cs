using UnityEngine;
using System.Collections.Generic;

public class SwarmComponent : MonoBehaviour
{
	public List<GameObject> objectsInSwarm;
	private List<GameObject> objectsAndLeader;

	public float maximumSpeed = 12f;
	public float maximumForce = 10f;

	public float separation = 1f;
	public float alignment = 0.05f;
	public float cohesiveness = 0.4f;


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


			Dictionary<GameObject, float> distances = new Dictionary<GameObject, float>();
			foreach (GameObject other in objectsAndLeader) {
				distances.Add(other, Vector3.Distance (obj.transform.position, other.transform.position));
			}

			//pasar objeto distances a los metodos siguientes y sacarlo

			Vector3 separate = Separate (obj, objectsAndLeader, distances);
			Vector3 align = Align (obj, objectsAndLeader, distances);
			Vector3 cohesion = Cohesion (obj, objectsAndLeader, distances);
		
			separate = separate * separation;
			align = align * alignment;
			cohesion = cohesion * cohesiveness;
			
			Rigidbody rb = obj.GetComponent<Rigidbody> ();

			rb.AddForce (separate);
			rb.AddForce (align);
			rb.AddForce (cohesion);

			//float inverseForce = -1f / (maxRadius * (maxRadius - this.transform.position.magnitude));
			//rb.AddForce(this.transform.position*inverseForce);


		}
		
	}

	private Vector3 Separate(GameObject obj, List<GameObject> objects, Dictionary<GameObject,float> distances)
	{
		float desiredSeparation = 0.5f;
		Vector3 steer = new Vector3 (0, 0, 0);
		int count = 0;
		
		foreach (GameObject other in objects)
		{
			float distance = distances[other];
			//float distance =  Vector3.Distance(obj.transform.position, other.transform.position);

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
	
	private Vector3 Align(GameObject obj, List<GameObject> objects, Dictionary<GameObject,float> distances)
	{
		float neighborDistance = 6f;
		Vector3 sum = new Vector3(0, 0, 0);
		int count = 0;
		foreach (GameObject other in objects)
		{
			float distance = distances [other];
			//float distance = Vector3.Distance(obj.transform.position, other.transform.position);
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
	
	private Vector3 Cohesion(GameObject obj, List<GameObject> objects, Dictionary<GameObject,float> distances)
	{
		float neighborDistance = 25f;
		Vector3 sum = new Vector3(0, 0, 0);
		int count = 0;
		foreach (GameObject other in objects)
		{
			//float distance = Vector3.Distance(obj.transform.position, other.transform.position);
			float distance = distances[other];
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

		foreach (GameObject obj in objectsInSwarm) {

			Rigidbody rb = obj.GetComponent<Rigidbody> ();
			rb.velocity = Vector3.zero;

		}
		Destroy(this);
	}
}