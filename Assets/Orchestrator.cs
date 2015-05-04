using UnityEngine;
using System;
using AssemblyCSharp;

public class Orchestrator : MonoBehaviour
{

	public GlobalTimeLine globalTimeLine;	
	
	private GameObject sphere;
	private float timer;

	private int nextEventIndex;
//	bool firstEventHappened, secondEventHappened;

	// Use this for initialization
	void Start ()
	{
			
		//Create (or get) an isntance of the Global TimeLine class
		globalTimeLine = new GlobalTimeLine();
		timer = 0f;
		timer = timer + 2;
	}
	
	// Update is called once per frame
	void Update ()
	{

		//TODO perhaps we could use Time.deltaTime directly instead of relying on the variable timer. 
		timer += Time.deltaTime; 
		int i = 0;

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


//		for(SingleTimeLine currentTimeLine = globalTimeLine.getSingleTimeLine(i); i < globalTimeLine.getNumberOfTimeLines(); i++)
//		{
//			if ( timer > currentTimeLine.getNextEventTime() ) 
//			{
//				performEvent(currentTimeLine.getNextAction(), currentTimeLine.getObjectReferences());
//				currentTimeLine.updateNextEvent();
//			}
//		
//		}
//
	}

	private void performEvent (EventKind action, GameObject[] objects)
	{
		if (objects != null) {
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
