using System;
using UnityEngine;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	public class GlobalTimeLine
	{
		private Orchestra _orchestra = new Orchestra();
		private Scenery _scenery = new Scenery();
		private List<SingleTimeLine> _timeLines = new List<SingleTimeLine>();
		private float _simulationLength = 60f; 

		public List<SingleTimeLine> TimeLines
		{
			get { return _timeLines;}
		}

		public int NumberOfTimeLines
		{
			get {return _timeLines.Count;}
		}

		public float SimulationLength
		{
			get { return _simulationLength;}
		}

		public GlobalTimeLine ()
		{
			PopulateTimelines();
		}
		
		private void PopulateTimelines()
		{

			SingleTimeLine tilesTimeLine = new SingleTimeLine (_scenery.GetObjects ("tiles"));
			tilesTimeLine.AddEvent (new ShowEvent (2.0f));
			tilesTimeLine.AddEvent (new RotateEvent (3.0f, new Vector3 (180, 0, 0), 1f));

			_timeLines.Add (tilesTimeLine);

			SingleTimeLine beaconsTimeLine = new SingleTimeLine(_orchestra.GetObjects("swarm"));
			beaconsTimeLine.AddEvent( new ShowEvent(4.0f) );
			//beaconsTimeLine.AddEvent( new HideEvent(8.0f) );
			_timeLines.Add (beaconsTimeLine);

			SingleTimeLine spheresTimeLine = new SingleTimeLine (_orchestra.GetObjects ("spheres"));
			spheresTimeLine.AddEvent( new ShowEvent(4.0f) );
			//spheresTimeLine.AddEvent( new AddGravityEvent(5.0f) );
			spheresTimeLine.AddEvent( new MoveEvent(8.0f, new Vector3(0f, 3f, 0f), 1f));
			spheresTimeLine.AddEvent( new HideEvent(20.0f) );
			_timeLines.Add (spheresTimeLine);

			SingleTimeLine allTimeLine = new SingleTimeLine(_orchestra.GetObjects("all"));
			allTimeLine.AddEvent( new HideEvent(200.0f) );
			_timeLines.Add (allTimeLine);

		}
		
		public SingleTimeLine GetSingleTimeLine(int timeLineIndex)
		{
			if (timeLineIndex < 0 || timeLineIndex >= _timeLines.Count)
				throw new System.AccessViolationException("TimeLine index out of range");

			return _timeLines [timeLineIndex];

		}

		public void DestroyObjects()
		{
			_orchestra.DestroyObjects();
		}

	}
}

