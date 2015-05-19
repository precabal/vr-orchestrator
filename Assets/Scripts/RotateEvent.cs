using System;
using System.Collections.Generic;
using UnityEngine;

namespace AssemblyCSharp
{
	public class RotateEvent : IEvent
	{
		private float _eventTime;
		private Vector3 _rotationAngle;
		private float _rotationTime;

		public float EventTime
		{
			get { return _eventTime; }
			set { _eventTime = value; }
		}
		public RotateEvent (float eventTime, Vector3 rotationAngle, float rotationTime)
		{
			_eventTime = eventTime;
			_rotationAngle = rotationAngle;
			_rotationTime = rotationTime;
		}

		public void Perform(List<GameObject> objects)
		{
			foreach (GameObject obj in objects)
			{
				RotateComponent rc = RotateComponent.CreateComponent(obj, _rotationAngle, _rotationTime);
			}
		}
	}
}

