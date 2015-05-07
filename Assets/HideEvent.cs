using System;
using System.Collections.Generic;
using UnityEngine;

namespace AssemblyCSharp
{
	public class HideEvent : IEvent
	{
		private float _eventTime;
		
		public float EventTime
		{
			get { return _eventTime; }
			set { _eventTime = value; }
		}
		
		public HideEvent(float eventTime)
		{
			_eventTime = eventTime;
		}

		public void PerformEvent(List<GameObject> objects)
		{
			foreach (GameObject obj in objects)
				obj.SetActive(false);
		}
	}
}

