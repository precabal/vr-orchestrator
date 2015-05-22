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

			SingleTimeLine tilesATimeLine = new SingleTimeLine (_scenery.GetObjects ("tilesA"));
			tilesATimeLine.AddEvent (new ShowEvent (2.0f));
			tilesATimeLine.AddEvent (new RotateEvent (6.0f, new Vector3 (180, 0, 0), 0.4f, 2*120f/118f));
			tilesATimeLine.AddEvent (new RotateEvent (6.0f, new Vector3 (180, 0, 0), 0.4f, 4*120f/118f, 0.25f));
			_timeLines.Add (tilesATimeLine);

			SingleTimeLine tilesBTimeLine = new SingleTimeLine (_scenery.GetObjects ("tilesB"));
			tilesBTimeLine.AddEvent (new ShowEvent (2.0f));
			//tilesBTimeLine.AddEvent (new RotateEvent (6.0f, new Vector3 (0, 0, 180), 1f, 240/118f));
			_timeLines.Add (tilesBTimeLine);

			SingleTimeLine swarmTimeLine = new SingleTimeLine(_orchestra.GetObjects("swarm"));
			swarmTimeLine.AddEvent( new MoveEvent(7.0f, new Vector3(5f, 3f, 2f), 20f));
			swarmTimeLine.AddEvent( new ShowEvent(4.0f) );
			_timeLines.Add (swarmTimeLine);

			SingleTimeLine spheresTimeLine = new SingleTimeLine (_orchestra.GetObjects ("spheres"));
			spheresTimeLine.AddEvent( new ShowEvent(3.0f) );
			spheresTimeLine.AddEvent( new HideEvent(9.0f) );
			_timeLines.Add (spheresTimeLine);

			SingleTimeLine allObjectsTimeLine = new SingleTimeLine(_orchestra.GetObjects("all"));
			allObjectsTimeLine.AddEvent( new PlayEvent(6.0f) );
			allObjectsTimeLine.AddEvent( new HideEvent(200.0f) );
			_timeLines.Add (allObjectsTimeLine);

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

