using System;
using System.Collections.Generic;
using UnityEngine;

namespace AssemblyCSharp
{
	public class StopSwarmEvent : IEvent
	{
		private float _eventTime;
		
		public float EventTime
		{
			get { return _eventTime; }
			set { _eventTime = value; }
		}
		
		public StopSwarmEvent(float eventTime)
		{
			_eventTime = eventTime;
		}


		
		public void Perform(List<GameObject> objects)
		{
			SwarmComponent testComponent;
			foreach (GameObject obj in objects) {
				if (testComponent = obj.GetComponent<SwarmComponent> ()) {
					testComponent.StopMovement ();
				}
			}
		}

	}
}

