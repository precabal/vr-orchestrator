using UnityEngine;
using System;
using AssemblyCSharp;
using System.Collections.Generic;

public class Orchestrator : MonoBehaviour
{
	public GlobalTimeLine globalTimeLine;	
	private float timer;

	private int nextEventIndex;
//	bool firstEventHappened, secondEventHappened;

	// Use this for initialization
	void Start ()
	{
			
		//Create (or get) an isntance of the Global TimeLine class
		globalTimeLine = new GlobalTimeLine();
		timer = 0f;

	}
	
	// Update is called once per frame
	void Update ()
	{

		//TODO perhaps we could use Time.deltaTime directly instead of relying on the variable timer. 
		timer += Time.deltaTime; 

		if ( timer > globalTimeLine.getSimulationLength() ) 
		{
			Time.timeScale = 0;

			globalTimeLine.destroyObjects();
			//Application.Quit ();
		}

		foreach (SingleTimeLine singleTimeLine in globalTimeLine.getTimeLines())
		{
			if ( timer > singleTimeLine.getNextEventTime() ) 
			{
				performEvent(singleTimeLine.getNextAction(), singleTimeLine.getObjectReferences());
				singleTimeLine.updateNextEvent();
			}

		}

	}

	private void performEvent (EventKind action, List<GameObject> objects)
	{
		if (objects != null)
		{
			switch (action) {
			case EventKind.invalid:
			//send error message
				break;
			
			case EventKind.show:

				Renderer rend;
			
				foreach (GameObject o in objects){
					rend = o.GetComponent<Renderer>();
					rend.enabled = true;
				}

				//o.SetActive (true);

				break;
			
			case EventKind.hide:
				foreach (GameObject o in objects)
					o.SetActive (false);
				break;

			default:
			//TODO do something?
				break;
			
			}
		} else {
			//warn of null objects.
		}
	}

}
