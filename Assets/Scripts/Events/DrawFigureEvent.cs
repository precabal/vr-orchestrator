using System;
using System.Collections.Generic;
using UnityEngine;

namespace AssemblyCSharp
{
	public class DrawFigureEvent : IEvent
	{
		private float _eventTime;
		private Figure _figure;
		private float _speed = 25.0f;
		private float _timeToDraw;
		public float EventTime
		{
			get { return _eventTime; }
			set { _eventTime = value; }
		}

		public DrawFigureEvent (float eventTime, Figure figure, float timeToDraw=-1f)
		{
			_timeToDraw = timeToDraw;
			_eventTime = eventTime;
			_figure = figure;
		}
		
		public void Perform(List<GameObject> objects)
		{
			//N objects to be mapped at M points of _figure
			int i = 0;
			float ratio = (float)(_figure.NumberOfPoints () - 1) / (float)(objects.Count - 1);

			MoveComponent testComponent;
			//Debug.Log (objects.Count + " / " + _figure.NumberOfPoints ());
			foreach(GameObject obj in objects)
			{
				int destinationIndex = (int) Math.Round((float)i * ratio) ; 

				//Debug.Log (destinationIndex);

				//calculate distance between the actual and target positions
				Vector3 distanceToTravel = _figure.getPoint(destinationIndex) - obj.transform.position;

				//calculate the time to go there with a fixed velocity
				if (_timeToDraw == -1f) { 
					_timeToDraw = distanceToTravel.magnitude / _speed;
				}

				//search and destroy existing component
				if(testComponent = obj.GetComponent<MoveComponent>())
				{
					testComponent.StopMovement();
				}

				CreateComponent(obj, _figure.getPoint(destinationIndex), _timeToDraw);

				i++;

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

