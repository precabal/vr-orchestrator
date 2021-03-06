using System;
using System.Collections.Generic;
using UnityEngine;

namespace AssemblyCSharp
{
	public class ShowEvent : IEvent
	{
		private float _eventTime;

		public float EventTime
		{
			get { return _eventTime; }
			set { _eventTime = value; }
		}

		public ShowEvent(float eventTime)
		{
			_eventTime = eventTime;
		}

		public void Perform(List<GameObject> objects)
		{
			//TODO iterate through children and show all that have mesh renderer
			//objects.ForEach (o => o.GetComponent<Renderer>().enabled = true);


			foreach (GameObject obj in objects) {
				Renderer[] a = obj.GetComponentsInChildren<Renderer> ();
				foreach(Renderer rend in a)
				{
					rend.enabled = true;
				}
			}

		}
	}
}

