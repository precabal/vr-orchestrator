using System;
using System.Collections.Generic;
using UnityEngine;

namespace AssemblyCSharp
{
	public class StartSwarmEvent : IEvent
	{
		private float _eventTime;

		private float maximumSpeed = 200f;
		private float maximumForce = 50f;

		public float EventTime
		{
			get { return _eventTime; }
			set { _eventTime = value; }
		}
		
		public StartSwarmEvent(float eventTime)
		{
			_eventTime = eventTime;
		}
		
		public void Perform(List<GameObject> objects)
		{
			foreach (GameObject obj in objects)
			{
				Vector3 separate = Separate (obj, objects);
				Vector3 align = Align (obj, objects);
				Vector3 cohesion = Cohesion (obj, objects);
				
				separate = separate * 1.0f;
				align = align * 1.0f;
				cohesion = cohesion * 1.0f;

				Rigidbody rb = obj.GetComponent<Rigidbody>();
				rb.AddForce(separate);
				rb.AddForce(align);
				rb.AddForce(cohesion);
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

				if (distance > 0 && distance < desiredSeparation)
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

	}
}

