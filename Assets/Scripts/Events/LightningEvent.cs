using System;
using UnityEngine;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	public class LightningEvent : IEvent
	{
		private float _eventTime;
		private float[] _envelope;
		private List<GameObject> _objectsToLight;

		public float EventTime
		{
			get { return _eventTime; }
			set { _eventTime = value; }
		}
		
		public LightningEvent (float eventTime, List<GameObject> objectsToLight, float[] envelope)
		{
			_eventTime = eventTime;
			_objectsToLight = objectsToLight;
			_envelope = envelope;
		}
		
		public void Perform(List<GameObject> objects)
		{
			//assign only to parent
			foreach (GameObject obj in objects) {
				CreateComponent (obj, _objectsToLight, _envelope);
			}
		}

		public void CreateComponent(GameObject target, List<GameObject> objectsToLight, float[] envelope)
		{
			LightningComponent lightningComponent = target.AddComponent<LightningComponent> ();
			lightningComponent.objectsToLight = objectsToLight;
			lightningComponent.envelope = envelope;

			
		}

	}
}

