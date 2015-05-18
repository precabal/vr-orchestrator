using System;
using UnityEngine;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	public class GlobalTimeLine
	{
		private Orchestra _orchestra = new Orchestra();
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
			SingleTimeLine beaconsTimeLine = new SingleTimeLine(_orchestra.GetObjects("beacons"));
			beaconsTimeLine.AddEvent( new ShowEvent(4.0f) );
			beaconsTimeLine.AddEvent( new HideEvent(8.0f) );
			_timeLines.Add (beaconsTimeLine);

			SingleTimeLine spheresTimeLine = new SingleTimeLine (_orchestra.GetObjects ("spheres"));
			spheresTimeLine.AddEvent( new ShowEvent(4.0f) );
			spheresTimeLine.AddEvent( new AddGravityEvent(5.0f) );
			spheresTimeLine.AddEvent( new TranslateEvent(8.0f, new Vector3(0, 0, 0)));
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

