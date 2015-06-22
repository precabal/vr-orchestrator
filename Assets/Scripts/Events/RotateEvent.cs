using System;
using System.Collections.Generic;
using UnityEngine;

namespace AssemblyCSharp
{
	public class RotateEvent : IEvent
	{
		private float _eventTime;
		private Vector3 _rotationAxis;
		private float _rotationAngle;
		private float _rotationTime;
		private float _rotationPeriod;
		private float _percentageOffset;

		public float EventTime
		{
			get { return _eventTime; }
			set { _eventTime = value; }
		}
		public RotateEvent (float eventTime, Vector3 rotationAxis, float rotationAngle, float rotationTime, float rotationPeriod, float percentageOffset = 0f)
		{
			_eventTime = eventTime;
			_rotationAxis = rotationAxis;
			_rotationTime = rotationTime;
			_rotationPeriod = rotationPeriod;
			_percentageOffset = percentageOffset;
			_rotationAngle = rotationAngle;
		}

		public void Perform(List<GameObject> objects)
		{
			foreach (GameObject obj in objects)
			{
				CreateComponent(obj, _rotationAxis, _rotationAngle, _rotationTime, _rotationPeriod, _percentageOffset);
			}
		}

		private void CreateComponent(GameObject target, Vector3 rotationAxis, float rotationAngle, float rotationTime, float rotationPeriod, float percentageOffset)
		{
			RotateComponent rotateComponent = target.AddComponent<RotateComponent> ();
			rotateComponent._rotationAxis = rotationAxis;
			rotateComponent._rotationAngle = rotationAngle;
			rotateComponent._rotationTime = rotationTime;
			rotateComponent._rotationPeriod = rotationPeriod;
			rotateComponent._percentageOffset = percentageOffset;

		}
	}
}

