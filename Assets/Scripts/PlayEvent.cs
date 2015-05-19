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
				//if the audiosource is attached to a rigidbody the OSPAudioSource object will be a child of it
				if( (child = obj.transform.Find ("OSPAudioSource")) != null )
				{
					child.gameObject.GetComponent<OSPAudioSource> ().Play();
				
				}
				//if the audiosource is not attached to a rigidbody (i.e. 2D sound), we access the component directly
				else if(obj.GetComponent<OSPAudioSource>()!=null)
				{
					obj.GetComponent<OSPAudioSource>().Play ();
				}

				//TODO: evaluate the case where this is a normal AudioSource?
			}

		}
	}
}