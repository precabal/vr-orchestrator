using System;
using System.Collections.Generic;
using UnityEngine;

namespace AssemblyCSharp
{
	public class PlayAudioEvent : IEvent
	{
		private float _eventTime;
		
		public float EventTime
		{
			get { return _eventTime; }
			set { _eventTime = value; }
		}
		
		public PlayAudioEvent(float eventTime)
		{
			_eventTime = eventTime;
		}
		
		public void Perform(List<GameObject> objects)
		{
			Transform child;

			foreach (GameObject obj in objects)
			{

				if(obj.GetComponentInChildren<OSPAudioSource>()!=null)
				{
					obj.GetComponentInChildren<OSPAudioSource>().Play ();
				}


				//TODO: evaluate the case where this is a normal AudioSource?
			}

		}
	}
}