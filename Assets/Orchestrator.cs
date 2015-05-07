using UnityEngine;
using System;
using AssemblyCSharp;
using System.Collections.Generic;

public class Orchestrator : MonoBehaviour
{
	private GlobalTimeLine _globalTimeLine;
	private float _timer;

	// Use this for initialization
	void Start ()
	{
		_globalTimeLine = new GlobalTimeLine();
		_timer = 0f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//TODO perhaps we could use Time.deltaTime directly instead of relying on the variable timer. 
		_timer += Time.deltaTime; 

		if ( _timer > _globalTimeLine.SimulationLength ) 
		{
			Time.timeScale = 0;
			_globalTimeLine.DestroyObjects();
			//Application.Quit ();
		}

		foreach (SingleTimeLine singleTimeLine in _globalTimeLine.TimeLines)
		{
			if ( _timer > singleTimeLine.GetNextEventTime() ) 
			{
				singleTimeLine.PerformNextEvent();
			}
		}

	}

}
