﻿using UnityEngine;
using System;
using AssemblyCSharp;

public class Orchestrator : MonoBehaviour
{
	public GameObject spherePrefab;

	private ObjectFactory objectFactory;
	private TimeLine timeLine;
	private GameObject cube;
	private GameObject sphere;
	private float timer;
	private int nextEventIndex;
//	bool firstEventHappened, secondEventHappened;

	// Use this for initialization
	void Start ()
	{
		//Create an instance of Factory
		objectFactory = new ObjectFactory ();	
		//Create (or get) an isntance of the TimeLine class
		timeLine = new TimeLine ();

		timer = 0;
		nextEventIndex = 1;
//		firstEventHappened = false;
//		secondEventHappened = false;

	}
	
	// Update is called once per frame
	void Update ()
	{

		//TODO perhaps we could use Time.deltaTime directly instead of relying on the variable timer. 
		timer += Time.deltaTime; 

		if (timer > timeLine.getEventTime(nextEventIndex))
		{

			//query evnextEventIndex instructions & perform the instructions (create, destroy, move). call a new function.
			switch (timeLine.getEventKind(nextEventIndex))
			{
			case EventKind.invalid:
				//send error message
				break;

			case EventKind.appears:
				sphere = objectFactory.CreateSphereFromPrefab(spherePrefab);
				sphere.transform.position = new Vector3 (5, 5, 5);
				break;

			case EventKind.disappears:
				Destroy (sphere);
				break;
			default:
				break;

			}

			if (nextEventIndex++ == timeLine.getNumberOfEvents())
			{
				//stop simulation
				Time.timeScale = 0;

				//quit?
				//Application.Quit();
			}
		}


//		if (timer > timeLine.getEventTime (1)) {
//			//wait objectsAppearEventMS to make objects appear
//			//(temp) create a temporary object
//			if (!firstEventHappened) { 
//				firstEventHappened = true;
//
//
//				sphere = objectFactory.CreateSphere();
//				sphere.AddComponent<Rigidbody>();
//				sphere.transform.position = new Vector3 (2, 5, 2);
//
//			} else {
//				//wait objectsDisappearEventMS to make objects disappear
//				//destroy temporary object
//				if (!secondEventHappened && timer > timeLine.getEventTime (2)) {
//					secondEventHappened = true;
//					Destroy (cube);
//				}
//			}
//
//		} 

		 
	}
}
