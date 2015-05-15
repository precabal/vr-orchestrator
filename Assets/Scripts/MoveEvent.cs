using System;
using UnityEngine;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	public class MoveEvent : MonoBehaviour, IEvent
	{
		private float _eventTime;
		private Vector3 _finalPosition;
		private float _velocity;

		public float EventTime
		{
			get { return _eventTime; }
			set { _eventTime = value; }
		}

		public MoveEvent (float eventTime, Vector3 finalPosition, float velocity)
		{
			_eventTime = eventTime;
			_finalPosition = finalPosition;
			_velocity = velocity;
		}

		public void Perform(List<GameObject> objects)
		{
			foreach (GameObject obj in objects)
			{
				obj.transform.Translate(_finalPosition);
			}
		}
	}
}

