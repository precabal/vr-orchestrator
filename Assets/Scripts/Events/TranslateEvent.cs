using System;
using UnityEngine;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	public class TranslateEvent : IEvent
	{
		private float _eventTime;
		private Vector3 _relativeTranslation;
		private float _translationTime;
		private float _groupScaling;

		public float EventTime
		{
			get { return _eventTime; }
			set { _eventTime = value; }
		}
		
		public TranslateEvent (float eventTime, Vector3 relativeTranslation, float translationTime, float groupScaling = 1.0f)
		{
			_eventTime = eventTime;
			_relativeTranslation = relativeTranslation;
			_translationTime = translationTime;
			_groupScaling = groupScaling;
		}
		
		public void Perform(List<GameObject> objects)
		{
			//calculate geometric center
			Vector3 geometricCenter = Vector3.zero;
			foreach (GameObject obj in objects) {
				geometricCenter += obj.transform.position;
			}
			geometricCenter /= objects.Count;

			//calculate each object's final position and send
			foreach (GameObject obj in objects)
			{
				Vector3 currentPosition = obj.transform.position;
				Vector3 finalPosition = geometricCenter + _relativeTranslation + _groupScaling * (currentPosition - geometricCenter);

				//speed inversely proportional to size
				//float particularTime = 1.2f *_translationTime - 0.4f * (obj.transform.localScale.x);

				CreateComponent(obj, finalPosition, _translationTime);
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

