using UnityEngine;
using System;
using AssemblyCSharp;
using System.Collections.Generic;

public class Orchestrator : MonoBehaviour
{
	private GlobalTimeLine _globalTimeLine;

	// Use this for initialization
	void Start ()
	{
		_globalTimeLine = new GlobalTimeLine();
	}
	
	// Update is called once per frame
	void Update ()
	{

		if ( Time.time > _globalTimeLine.SimulationLength ) 
		{
			//Time.timeScale = 0;
			_globalTimeLine.DestroyObjects();
			//Application.Quit ();
		}

		foreach (SingleTimeLine singleTimeLine in _globalTimeLine.TimeLines)
		{
			if ( Time.time > singleTimeLine.GetNextEventTime() ) 
			{
				singleTimeLine.PerformNextEvent();
			}
		}

	}

}
