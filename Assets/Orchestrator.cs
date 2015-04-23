using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class Orchestrator : MonoBehaviour {

	private TimeLine timeLine;
	private GameObject cube;
	private float timer;
	bool firstEventHappened, secondEventHappened;
	// Use this for initialization
	void Start () {
	
		//Create (or get) an isntance of the TimeLine class
		timeLine = new TimeLine ();
		timer = 0;
		firstEventHappened = false;
		secondEventHappened = false;
		//Create an instance of Factory

	}
	
	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime; 
		if (timer > timeLine.objectsAppearEventMS/1000)
		{
			//wait objectsAppearEventMS to make objects appear
			//(temp) create a temporary object
			if(!firstEventHappened){ 
				firstEventHappened = true;
				cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
				cube.AddComponent<Rigidbody>();
				cube.transform.position = new Vector3(5, 5, 10);

			}else{
				//wait objectsDisappearEventMS to make objects disappear
				//destroy temporary object
				if(!secondEventHappened && timer > timeLine.objectsDisappearEventMS/1000 )
				{
					secondEventHappened = true;
					Destroy (cube);
				}
			}

		} 

		 
	}
}
