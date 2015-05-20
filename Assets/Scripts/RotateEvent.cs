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
		private float _rotationPeriod;

		public float EventTime
		{
			get { return _eventTime; }
			set { _eventTime = value; }
		}
		public RotateEvent (float eventTime, Vector3 rotationAngle, float rotationTime, float rotationPeriod)
		{
			_eventTime = eventTime;
			_rotationAngle = rotationAngle;
			_rotationTime = rotationTime;
			_rotationPeriod = rotationPeriod;
		}

		public void Perform(List<GameObject> objects)
		{
			foreach (GameObject obj in objects)
			{
				CreateComponent(obj, _rotationAngle, _rotationTime, _rotationPeriod);
			}
		}

		private void CreateComponent(GameObject target, Vector3 rotationAngle, float rotationTime, float rotationPeriod)
		{
			RotateComponent rotateComponent = target.AddComponent<RotateComponent> ();
			rotateComponent._rotationAngle = rotationAngle;
			rotateComponent._rotationTime = rotationTime;
			rotateComponent._rotationPeriod = rotationPeriod;

		}
	}
}

