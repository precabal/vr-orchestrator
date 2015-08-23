using System;
using System.IO;
using UnityEngine;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	public class GlobalTimeLine
	{
		private Orchestra _orchestra = new Orchestra();
		//private Scenery _scenery = new Scenery();
		private List<SingleTimeLine> _timeLines = new List<SingleTimeLine>();
		private float _simulationLength = 2000f; 
		private Figure _headFigure, _godFigure, _faceAFigure, _faceBFigure;

		private SingleTimeLine	leadSynth_L_solo_TimeLine,
								leadSynth_L_group_TimeLine,
								
								leadSynth_R_TimeLine, 
								leadSynth_R_solo_TimeLine,
								leadSynth_R_group_TimeLine,
							
								staticSources_TimeLine,
								allObjects_TimeLine;

		
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

			//LoadTextFiles ();
			InitializeNonTrackTimeLines ();
			InitializeTrackTimeLines ();
			PopulateTimelines();
		}

		private void InitializeTrackTimeLines() {

			//TODO: make this automatic according to the tracks that have been placed on the scene			


			leadSynth_L_solo_TimeLine = new SingleTimeLine (_orchestra.GetObjects("leadSynth_L", false));
			_timeLines.Add (leadSynth_L_solo_TimeLine);
			
			leadSynth_L_group_TimeLine = new SingleTimeLine (_orchestra.GetObjects("leadSynth_L_group", false));
			_timeLines.Add (leadSynth_L_group_TimeLine);
			


			leadSynth_R_TimeLine = new SingleTimeLine (_orchestra.GetObjects("leadSynth_R"));
			_timeLines.Add (leadSynth_R_TimeLine);
			
			leadSynth_R_solo_TimeLine = new SingleTimeLine (_orchestra.GetObjects("leadSynth_R", false));
			_timeLines.Add (leadSynth_R_solo_TimeLine);
			
			leadSynth_R_group_TimeLine = new SingleTimeLine (_orchestra.GetObjects("leadSynth_R_group", false));
			_timeLines.Add (leadSynth_R_group_TimeLine);
			
			
			staticSources_TimeLine = new SingleTimeLine (_orchestra.GetObjects("staticObjects"));
			_timeLines.Add (staticSources_TimeLine);

		}
		private void InitializeNonTrackTimeLines ()
		{

			allObjects_TimeLine = new SingleTimeLine(_orchestra.GetObjects("all"));
			_timeLines.Add (allObjects_TimeLine);

		}


		
		private void PopulateTimelines()
		{


			float bpm = 120f / 118f; //beats per minute
			//TODO fix meter definition.
			int meter = 4 / 1; //4 beats in one measure
			float wholeNote = bpm * meter;
			float quarterNote = bpm;

			Vector3 diagonalX = new Vector3 (1, 0, -1);
			Vector3 diagonalY = new Vector3 (1, 0, 1);

			allObjects_TimeLine.AddEvent( new PlayAudioEvent(Definitions.songStart) );

			staticSources_TimeLine.AddEvent (new ShowEvent (3.0f));




          	//leadSynth_R_TimeLine.AddEvent( new GlowEvent (5.0f) );
			//leadSynth_R_group_TimeLine.AddEvent( new TranslateEvent(6.0f, new Vector3(-3f, 1f, 2f), 25f, 70f));

			//leadSynth_R_TimeLine.AddEvent( new LightningEvent(7.0f, _orchestra.GetObjects ("leadSynth_R_group", false), Envelopes.sharpAttackEnvelope) );


			//leadSynth_R_solo_TimeLine.AddEvent( new OrbitEvent(35f,15) );

//			leadSynth_L_group_TimeLine.AddEvent( new GlowEvent (5.0f) );
//			leadSynth_L_solo_TimeLine.AddEvent( new GlowEvent (3.0f) );
//
//			leadSynth_L_group_TimeLine.AddEvent( new TranslateEvent(10.0f, new Vector3(13f, 1f, 10f), 25f, 405f));
//			leadSynth_L_solo_TimeLine.AddEvent( new TranslateEvent(10.0f, new Vector3(13f, 1f, 10f), 25f, 405f));
//
//			leadSynth_L_solo_TimeLine.AddEvent( new OrbitEvent(15.1f,15) );
//
//			leadSynth_L_solo_TimeLine.AddEvent( new StartSwarmEvent(15.5f, _orchestra.GetObjects ("leadSynth_L_group", false) )  );

		
//			allObjects_TimeLine.AddEvent( new HideEvent(200.0f) );

		}
		
		public SingleTimeLine GetSingleTimeLine(int timeLineIndex)
		{
			if (timeLineIndex < 0 || timeLineIndex >= _timeLines.Count)
				throw new System.AccessViolationException("TimeLine index out of range");

			return _timeLines [timeLineIndex];

		}

		private void LoadTextFiles()
		{
			//TODO handle I/O exceptions
			
			//_headFigure = new Figure ();
			//_godFigure = new Figure ();
			_faceAFigure = new Figure ();
			_faceBFigure = new Figure ();
			
			FileInfo theSourceFile = null;
			StreamReader reader = null;
			
//			theSourceFile = new FileInfo (Application.dataPath + "/positionsHead.txt");
//			if ( theSourceFile != null && theSourceFile.Exists )
//				reader = theSourceFile.OpenText();
//			
//			if ( reader == null )
//			{
//				Debug.Log("positionsHead.txt not found or not readable");
//			}
//			else
//			{
//				string txt;
//				// Read each line from the file
//				while ( ( txt = reader.ReadLine()) != null ){
//					//parse the line
//					String[] result = txt.Split(',');
//					_headFigure.AddPoint( new Vector3(Int32.Parse(result[0]), Int32.Parse(result[1]), 20.0f)  );
//				}
//				
//			}
//			
//			
//			theSourceFile = new FileInfo (Application.dataPath + "/positionsGod.txt");
//			if ( theSourceFile != null && theSourceFile.Exists )
//				reader = theSourceFile.OpenText();
//			
//			if ( reader == null )
//			{
//				Debug.Log("positionsGod.txt not found or not readable");
//			}
//			else
//			{
//				string txt;
//				// Read each line from the file
//				while ( ( txt = reader.ReadLine()) != null ){
//					//parse the line
//					String[] result = txt.Split(',');
//					_godFigure.AddPoint( new Vector3(Int32.Parse(result[0]), Int32.Parse(result[1]), 20.0f)  );
//				}
//				
//			}

			//theSourceFile = Resources.Load (caraA) as FileInfo;

			theSourceFile = new FileInfo (Application.dataPath + "/Resources/caraA.txt");
			if ( theSourceFile != null && theSourceFile.Exists )
				reader = theSourceFile.OpenText();
			
			if ( reader == null )
			{
				Debug.Log("caraA.txt not found or not readable");
			}
			else
			{
				string txt;
				// Read each line from the file
				while ( ( txt = reader.ReadLine()) != null ){
					//parse the line
					String[] result = txt.Split(',');
					_faceAFigure.Add2DPoint( float.Parse(result[0]) , float.Parse(result[1]) );
				}
				
			}


			theSourceFile = new FileInfo (Application.dataPath + "/Resources/caraB.txt");
			if ( theSourceFile != null && theSourceFile.Exists )
				reader = theSourceFile.OpenText();
			
			if ( reader == null )
			{
				Debug.Log("caraB.txt not found or not readable");
			}
			else
			{
				string txt;
				// Read each line from the file
				while ( ( txt = reader.ReadLine()) != null ){
					//parse the line
					String[] result = txt.Split(',');
					_faceBFigure.Add2DPoint( float.Parse(result[0]) , float.Parse(result[1]) );
				}
				
			}

			_faceBFigure.SetImageCenter (new Vector3 (90, 100, 120));

			
			reader.Close ();
			
			
		}

		public void DestroyObjects()
		{
			_orchestra.DestroyObjects();

			//TODO Unload loaded assets with Resources.UnloadAsset( gameObject );
		}

	}
}

