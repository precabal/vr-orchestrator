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
		private float _simulationLength = 300f; 
		private Figure _headFigure, _godFigure, _faceAFigure, _faceBFigure;

		private SingleTimeLine	leadSynth_L_solo_TimeLine,
								leadSynth_L_group_TimeLine,
								
								leadSynth_R_TimeLine, 
								leadSynth_R_solo_TimeLine,
								leadSynth_R_group_TimeLine,
								
								tiles_TimeLine,
								tiles_A_TimeLine, 
								tiles_B_TimeLine, 
								tiles_C_TimeLine,
								
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
			InitializeTimeLines ();
			PopulateTimelines();
		}


		private void InitializeTimeLines ()
		{
			tiles_A_TimeLine = new SingleTimeLine (_scenery.GetObjects ("tiles_A"));
			_timeLines.Add (tiles_A_TimeLine);

			tiles_B_TimeLine = new SingleTimeLine (_scenery.GetObjects ("tiles_B"));
			_timeLines.Add (tiles_B_TimeLine);

			tiles_C_TimeLine = new SingleTimeLine (_scenery.GetObjects ("tiles_C"));
			_timeLines.Add (tiles_C_TimeLine);

			tiles_TimeLine = new SingleTimeLine(_scenery.GetObjects("tiles"));
			_timeLines.Add (tiles_TimeLine);


			allObjects_TimeLine = new SingleTimeLine(_orchestra.GetObjects("all"));
			_timeLines.Add (allObjects_TimeLine);




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

		
		private void PopulateTimelines()
		{

			float songStart = 6.0f;
			float bpm = 120f / 118f; //beats per minute
			int meter = 4 / 1; //4 beats in one measure
			float measureLength = bpm * meter;

			Vector3 diagonalX = new Vector3 (1, 0, -1);
			Vector3 diagonalY = new Vector3 (1, 0, 1);


			tiles_TimeLine.AddEvent (new ShowEvent (2.0f));

			allObjects_TimeLine.AddEvent( new PlayAudioEvent(songStart) );

			staticSources_TimeLine.AddEvent (new ShowEvent (3.0f));



			//TODO introduce more randomness in rotation. add rotation for hihat not included yet. 
			tiles_A_TimeLine.AddEvent (new RotateEvent (songStart, Vector3.forward, 180, 0.4f, measureLength/2));

			tiles_C_TimeLine.AddEvent (new RotateEvent (songStart + measureLength, diagonalX, 180, 0.2f, bpm));
			tiles_C_TimeLine.AddEvent (new RotateEvent (songStart, diagonalY, 90, 0.1f, measureLength, 0.8175f));
			tiles_C_TimeLine.AddEvent (new RotateEvent (songStart, diagonalY, 90, 0.2f, measureLength, 0.875f));

			tiles_B_TimeLine.AddEvent (new RotateEvent (songStart + 2 * measureLength, Vector3.left, 180, 0.4f, measureLength/2));
			tiles_B_TimeLine.AddEvent (new RotateEvent (songStart + 2 * measureLength, Vector3.left, 180, 0.4f, measureLength, 0.125f));




          	leadSynth_R_TimeLine.AddEvent( new GlowEvent (5.0f) );
			leadSynth_R_group_TimeLine.AddEvent( new TranslateEvent(6.0f, new Vector3(-3f, 1f, 2f), 25f, 70f));

			float[] envelope = new float[32];

			for(int i =0; i<32; i++)
			{
				envelope[i] = (float)i/32.0f;
			}


			leadSynth_R_TimeLine.AddEvent( new LightningEvent(7.0f, _orchestra.GetObjects ("leadSynth_R_group", false), envelope) );
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




			allObjects_TimeLine.AddEvent( new HideEvent(200.0f) );

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

