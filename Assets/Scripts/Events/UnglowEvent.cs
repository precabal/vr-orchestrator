using System;
using System.Collections.Generic;
using UnityEngine;

namespace AssemblyCSharp
{
	public class UnglowEvent : IEvent
	{
		private float _eventTime;
		
		public float EventTime
		{
			get { return _eventTime; }
			set { _eventTime = value; }
		}
		
		public UnglowEvent(float eventTime)
		{
			_eventTime = eventTime;
		}
		
		public void Perform(List<GameObject> objects)
		{
			objects.ForEach (o => (o.GetComponent("Halo") as Behaviour).enabled = false);
		}
	}
}

