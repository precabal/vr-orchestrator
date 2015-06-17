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

		private IInstrument hihat_1, hihat_2, baseSounds, leadSynth_R, leadSynth_L, cymbal_1, cymbal_2, snare_1, snare_2;
		private SingleTimeLine 	hihat_1_TimeLine, 
								hihat_2_TimeLine, 
								cymbal_1_TimeLine, 
								cymbal_2_TimeLine, 
								leadSynth_L_TimeLine,
								leadSynth_R_TimeLine, 
								tiles_TimeLine,
								tiles_A_TimeLine, 
								tiles_B_TimeLine, 
								tiles_C_TimeLine,
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
			LoadTextFiles ();
			InitializeInstruments ();
			InitializeTimeLines ();
			PopulateTimelines();
		}

		private void InitializeInstruments()
		{
			baseSounds = new BaseSounds ();
			_orchestra.AddGroup (baseSounds);

			cymbal_1 = new Cymbal_1 ();
			_orchestra.AddGroup (cymbal_1);

			cymbal_2 = new Cymbal_2 ();
			_orchestra.AddGroup (cymbal_2);

			hihat_1 = new Hihat_1 ();
			_orchestra.AddGroup (hihat_1);
			
			hihat_2 = new Hihat_2 ();
			_orchestra.AddGroup (hihat_2);

			leadSynth_L = new LeadSynth_L ();
			_orchestra.AddGroup (leadSynth_L);

			leadSynth_R = new LeadSynth_R ();
			_orchestra.AddGroup (leadSynth_R);

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

			hihat_1_TimeLine = new SingleTimeLine (hihat_1.Objects);
			_timeLines.Add (hihat_1_TimeLine);

			hihat_2_TimeLine = new SingleTimeLine (hihat_2.Objects);
			_timeLines.Add (hihat_2_TimeLine);

			cymbal_1_TimeLine = new SingleTimeLine (cymbal_1.Objects);
			_timeLines.Add (cymbal_1_TimeLine);
			
			cymbal_2_TimeLine = new SingleTimeLine (cymbal_2.Objects);
			_timeLines.Add (cymbal_2_TimeLine);

			leadSynth_L_TimeLine = new SingleTimeLine (leadSynth_L.Objects);
			_timeLines.Add (leadSynth_L_TimeLine);

			leadSynth_R_TimeLine = new SingleTimeLine (leadSynth_R.Objects);
			_timeLines.Add (leadSynth_R_TimeLine);
		}

		
		private void PopulateTimelines()
		{

			tiles_TimeLine.AddEvent (new ShowEvent (2.0f));

			tiles_A_TimeLine.AddEvent (new RotateEvent (6.0f, new Vector3 (1, 0, 0), 180, 0.4f, 2*120f/118f));

			tiles_B_TimeLine.AddEvent (new RotateEvent (6.0f, new Vector3 (0, 0, 1), 180, 0.4f, 2*120f/118f));
			tiles_B_TimeLine.AddEvent (new RotateEvent (6.0f, new Vector3 (0, 0, 1), 180, 0.4f, 4*120f/118f, 0.125f));

			tiles_C_TimeLine.AddEvent (new RotateEvent (6.0f, new Vector3 (1, 0, 1), 180, 0.4f, 120f/118f));
			tiles_C_TimeLine.AddEvent (new RotateEvent (6.0f, new Vector3 (1, 0, 1), 180, 0.4f, 4*120f/118f, 0.875f));


			leadSynth_L_TimeLine.AddEvent (new GlowEvent (4.8f));
          	leadSynth_R_TimeLine.AddEvent (new GlowEvent (4.8f));

			leadSynth_R_TimeLine.AddEvent( new MoveEvent(7.0f, new Vector3(-35f, 3f, -22f), 5f));
			leadSynth_L_TimeLine.AddEvent( new OrbitEvent(12.0f,45) );

			cymbal_1_TimeLine.AddEvent (new GlowEvent (4.0f));
			cymbal_2_TimeLine.AddEvent (new GlowEvent (4.0f));

			hihat_1_TimeLine.AddEvent (new LightningEvent (8.0f, _orchestra.GetObjects ("hihat_1_group"), Envelopes.sharpAttackEnvelope));

			hihat_2_TimeLine.AddEvent (new LightningEvent (7.3f, _orchestra.GetObjects ("hihat_2_group"), Envelopes.sharpAttackEnvelope));
			hihat_2_TimeLine.AddEvent (new DrawFigureEvent (16.0f, _headFigure));

			allObjects_TimeLine.AddEvent( new PlayAudioEvent(6.0f) );

			hihat_2_TimeLine.AddEvent (new DrawFigureEvent (27.0f, _godFigure));

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

		public void DestroyObjects()
		{
			_orchestra.DestroyObjects();

			//TODO Unload loaded assets with Resources.UnloadAsset( gameObject );
		}

	}
}

