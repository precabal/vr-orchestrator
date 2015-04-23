using UnityEngine;
using System;
using AssemblyCSharp;

public class Orchestrator : MonoBehaviour
{

	private ObjectFactory objectFactory;
	private TimeLine timeLine;
	private GameObject cube;
	private GameObject sphere;
	private float timer;
	bool firstEventHappened, secondEventHappened;

	// Use this for initialization
	void Start ()
	{
		//Create an instance of Factory
		objectFactory = new ObjectFactory ();	
		//Create (or get) an isntance of the TimeLine class
		timeLine = new TimeLine ();

		timer = 0;
		firstEventHappened = false;
		secondEventHappened = false;

	}
	
	// Update is called once per frame
	void Update ()
	{

		timer += Time.deltaTime; 
		if (timer > timeLine.objectsAppearEventMS / 1000) {
			//wait objectsAppearEventMS to make objects appear
			//(temp) create a temporary object
			if (!firstEventHappened) { 
				firstEventHappened = true;

				cube = objectFactory.CreateCube();
				cube.AddComponent<Rigidbody>();
				cube.transform.position = new Vector3 (5, 5, 5);

				sphere = objectFactory.CreateSphere();
				sphere.AddComponent<Rigidbody>();
				sphere.transform.position = new Vector3 (2, 5, 2);

			} else {
				//wait objectsDisappearEventMS to make objects disappear
				//destroy temporary object
				if (!secondEventHappened && timer > timeLine.objectsDisappearEventMS / 1000) {
					secondEventHappened = true;
					Destroy (cube);
				}
			}

		} 

		 
	}
}
