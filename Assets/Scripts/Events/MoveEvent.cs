using System;
using UnityEngine;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	public class MoveEvent : IEvent
	{
		private float _eventTime;
		private Vector3 _finalPosition;
		private float _translationTime;

		public float EventTime
		{
			get { return _eventTime; }
			set { _eventTime = value; }
		}

		public MoveEvent (float eventTime, Vector3 finalPosition, float translationTime)
		{
			_eventTime = eventTime;
			_finalPosition = finalPosition;
			_translationTime = translationTime;
		}

		public void Perform(List<GameObject> objects)
		{
			foreach (GameObject obj in objects)
			{
				CreateComponent(obj, _finalPosition, _translationTime);
			}
		}
		public void CreateComponent(GameObject target, Vector3 finalPosition, float translationTime)
		{
			MoveComponent moveComponent = target.AddComponent<MoveComponent> ();
			moveComponent._finalPosition = finalPosition;
			moveComponent._translationTime = translationTime;

		}
	}
}

