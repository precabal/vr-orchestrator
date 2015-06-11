using System;
using System.IO;
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
		private Figure _headFigure, _godFigure;

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
			LoadTextFiles ();
			PopulateTimelines();
		}

		private void LoadTextFiles()
		{
			//TODO handle I/O exceptions

			_headFigure = new Figure ();
			_godFigure = new Figure ();

			FileInfo theSourceFile = null;
			StreamReader reader = null;
			
			theSourceFile = new FileInfo (Application.dataPath + "/positionsHead.txt");
			if ( theSourceFile != null && theSourceFile.Exists )
				reader = theSourceFile.OpenText();
			
			if ( reader == null )
			{
				Debug.Log("positionsHead.txt not found or not readable");
			}
			else
			{
				string txt;
				// Read each line from the file
				while ( ( txt = reader.ReadLine()) != null ){
					//parse the line
					String[] result = txt.Split(',');
					_headFigure.AddPoint( new Vector3(Int32.Parse(result[0]), Int32.Parse(result[1]), 20.0f)  );
				}
			
			}


			theSourceFile = new FileInfo (Application.dataPath + "/positionsGod.txt");
			if ( theSourceFile != null && theSourceFile.Exists )
				reader = theSourceFile.OpenText();
			
			if ( reader == null )
			{
				Debug.Log("positionsGod.txt not found or not readable");
			}
			else
			{
				string txt;
				// Read each line from the file
				while ( ( txt = reader.ReadLine()) != null ){
					//parse the line
					String[] result = txt.Split(',');
					_godFigure.AddPoint( new Vector3(Int32.Parse(result[0]), Int32.Parse(result[1]), 20.0f)  );
				}
				
			}


			reader.Close ();


		}
		
		private void PopulateTimelines()
		{

//			SingleTimeLine tilesATimeLine = new SingleTimeLine (_scenery.GetObjects ("tilesA"));
//			tilesATimeLine.AddEvent (new ShowEvent (2.0f));
//			tilesATimeLine.AddEvent (new RotateEvent (6.0f, new Vector3 (1, 0, 0), 180, 0.4f, 2*120f/118f));
//
//			_timeLines.Add (tilesATimeLine);
//
//			SingleTimeLine tilesBTimeLine = new SingleTimeLine (_scenery.GetObjects ("tilesB"));
//			tilesBTimeLine.AddEvent (new ShowEvent (2.0f));
//			tilesBTimeLine.AddEvent (new RotateEvent (6.0f, new Vector3 (0, 0, 1), 180, 0.4f, 2*120f/118f));
//			tilesBTimeLine.AddEvent (new RotateEvent (6.0f, new Vector3 (0, 0, 1), 180, 0.4f, 4*120f/118f, 0.125f));
//			_timeLines.Add (tilesBTimeLine);
//
//			SingleTimeLine tiles3_2TimeLine = new SingleTimeLine (_scenery.GetObjects ("tiles3_2"));
//			tiles3_2TimeLine.AddEvent (new ShowEvent (2.0f));
//			tiles3_2TimeLine.AddEvent (new RotateEvent (6.0f, new Vector3 (1, 0, 1), 180, 0.4f, 120f/118f));
//			tiles3_2TimeLine.AddEvent (new RotateEvent (6.0f, new Vector3 (1, 0, 1), 180, 0.4f, 4*120f/118f, 0.875f));
//			_timeLines.Add (tiles3_2TimeLine);
//
//			SingleTimeLine swarmTimeLine = new SingleTimeLine(_orchestra.GetObjects("swarm"));
//
//			swarmTimeLine.AddEvent( new MoveEvent(7.0f, new Vector3(5f, 3f, 2f), 5f));
//			swarmTimeLine.AddEvent( new OrbitEvent(12.0f,45) );
//			swarmTimeLine.AddEvent( new ShowEvent(4.0f) );
//
//			_timeLines.Add (swarmTimeLine);
//
//			SingleTimeLine spheresTimeLine = new SingleTimeLine (_orchestra.GetObjects ("spheres"));
//			spheresTimeLine.AddEvent( new ShowEvent(3.0f) );
//			spheresTimeLine.AddEvent( new GlowEvent(6.0f) );
//			//spheresTimeLine.AddEvent( new HideEvent(9.0f) );
//			//spheresTimeLine.AddEvent (new DrawFigureEvent (8.0f, _headFigure));
//			//spheresTimeLine.AddEvent (new DrawFigureEvent (17.0f, _godFigure));
//			_timeLines.Add (spheresTimeLine);
//
//			SingleTimeLine allObjectsTimeLine = new SingleTimeLine(_orchestra.GetObjects("all"));
//			allObjectsTimeLine.AddEvent( new PlayAudioEvent(6.0f) );
//			allObjectsTimeLine.AddEvent( new HideEvent(200.0f) );
//			_timeLines.Add (allObjectsTimeLine);

			float[] envelope = new float[32];
			for (int i  = 0; i< 16; i++) 
			{
				envelope[i] = (float)2f*i/31f;
			}
			for (int i  = 31; i >= 16; i--) 
			{
				envelope[i] = (float)2f*(32 - i - 1)/31f;
			}



			SingleTimeLine lightningTestGroup = new SingleTimeLine (_orchestra.GetObjects ("lightningMaster"));
			lightningTestGroup.AddEvent (new LightningEvent (5.0f, _orchestra.GetObjects ("lightning1"), envelope));
			_timeLines.Add (lightningTestGroup);

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

