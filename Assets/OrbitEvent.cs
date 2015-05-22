using System;
using System.Collections.Generic;
using UnityEngine;

namespace AssemblyCSharp
{
	public class OrbitEvent : IEvent
	{
		private float _angularVelocity;
		private float _eventTime;

		public float EventTime
		{
			get { return _eventTime; }
			set { _eventTime = value; }
		}

		public OrbitEvent (float eventTime, float angularVelocity)
		{
				_eventTime = eventTime;
				_angularVelocity = angularVelocity;
		}

		public void Perform(List<GameObject> objects)
		{
			foreach (GameObject obj in objects)
			{
				CreateComponent(obj, _angularVelocity);
			}
		}
		
		private void CreateComponent(GameObject target, float angularVelocity)
		{
			OrbitComponent orbitComponent = target.AddComponent<OrbitComponent> ();
			orbitComponent.angularVelocity = angularVelocity;

		}
	}

}

