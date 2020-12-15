using System;
using System.Collections.Generic;
using UnityEngine;

namespace AssemblyCSharp
{
	public class StartSwarmEvent : IEvent
	{
		private float _eventTime;

		private List<GameObject> _objectsToMove;
			
		public float EventTime
		{
			get { return _eventTime; }
			set { _eventTime = value; }
		}
		
		public StartSwarmEvent(float eventTime, List<GameObject> objectsToMove)
		{
			_eventTime = eventTime;
			_objectsToMove = objectsToMove;
		}
		
		public void Perform(List<GameObject> objects)
		{
			//MoveComponent testComponent;
			foreach (GameObject obj in objects)
			{

	//			//if exists, destroy moving component
	//			if(testComponent = obj.GetComponent<MoveComponent>())
	//			{
	//				testComponent.StopMovement();
	//			}
				CreateComponent (obj, _objectsToMove);
			}
		}

		private void CreateComponent(GameObject target, List<GameObject> objectsToMove)
		{
			SwarmComponent swarmComponent = target.AddComponent<SwarmComponent> ();
			swarmComponent.objectsInSwarm = objectsToMove;
		}
	}
}

