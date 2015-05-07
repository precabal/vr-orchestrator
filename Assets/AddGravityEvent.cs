using System;
using System.Collections.Generic;
using UnityEngine;

namespace AssemblyCSharp
{
	public class AddGravityEvent : IEvent
	{
		private float _eventTime;
		
		public float EventTime
		{
			get { return _eventTime; }
			set { _eventTime = value; }
		}
		
		public AddGravityEvent(float eventTime)
		{
			_eventTime = eventTime;
		}
		
		public void PerformEvent(List<GameObject> objects)
		{
			foreach (GameObject obj in objects)
			{
				Rigidbody rb = obj.GetComponent<Rigidbody>();
				if (rb != null)
					rb.useGravity = true;
			}
		}
	}
}

