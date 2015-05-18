using System;
using UnityEngine;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	public class TranslateEvent : IEvent
	{
		private float _eventTime;
		private Vector3 _finalPosition;
		
		public float EventTime
		{
			get { return _eventTime; }
			set { _eventTime = value; }
		}
		
		public TranslateEvent (float eventTime, Vector3 finalPosition)
		{
			_eventTime = eventTime;
			_finalPosition = finalPosition;
		}
		
		public void Perform(List<GameObject> objects)
		{
			foreach (GameObject obj in objects)
			{
				Vector3 currentPosition = obj.transform.position;
				Vector3 translation = _finalPosition - currentPosition;

				obj.transform.Translate(translation);
			}
		}
	}
}

