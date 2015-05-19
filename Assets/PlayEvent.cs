using System;
using System.Collections.Generic;
using UnityEngine;

namespace AssemblyCSharp
{
	public class PlayEvent : IEvent
	{
		private float _eventTime;
		
		public float EventTime
		{
			get { return _eventTime; }
			set { _eventTime = value; }
		}
		
		public PlayEvent(float eventTime)
		{
			_eventTime = eventTime;
		}
		
		public void Perform(List<GameObject> objects)
		{
			Transform child;

			foreach (GameObject obj in objects)
			{
				if( (child = obj.transform.Find ("OSPAudioSource")) != null )
				{
					child.gameObject.GetComponent<OSPAudioSource> ().Play();
				}
			}

		}
	}
}