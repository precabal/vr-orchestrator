using UnityEngine;
using System.Collections;
using AssemblyCSharp;


public class ObjectSelector : MonoBehaviour
{
	public Camera cameraFacing;
	private System.Random randomGenerator;
	// Use this for initialization
	void Start ()
	{
		randomGenerator = new System.Random ();

	}
	
	// Update is called once per frame
	void Update ()
	{

		if (Input.GetButtonDown("A")) {
	
			RaycastHit hitInformation;

			if (Physics.Raycast (cameraFacing.transform.position, cameraFacing.transform.rotation * Vector3.forward, out hitInformation)) {


				ObjectStates state = hitInformation.transform.gameObject.GetComponent<StateMachine> ().ChangeState ();

				//If object has a light compoment, select it and paint it
				if (hitInformation.transform.gameObject.GetComponent<Light> () != null) {
					hitInformation.transform.gameObject.GetComponent<Light> ().color = GetColorFromState (state);
				}
			}

		}

		if (Input.GetButtonDown ("X") ) {
			
			RaycastHit hitInformation;

			if (Physics.Raycast (cameraFacing.transform.position, cameraFacing.transform.rotation * Vector3.forward, out hitInformation)) {
								
				hitInformation.transform.gameObject.GetComponent<StateMachine>().ToggleMute();

			}
		}
		
	}
	//TODO migrate this fnc to State machine
	private Color GetColorFromState(ObjectStates state)
	{
		Color color = Color.black;
		switch (state) {
		case ObjectStates.unselected:
			color = Color.white;
			break;
		case ObjectStates.positionControl:
			color = Color.green;
			break;
		case ObjectStates.muteControl:
			color = Color.cyan;
			break;
			/*
		case ObjectStates.soloControl:
			color = Color.yellow;
			break;
		case ObjectStates.writeAutomation:
			color = Color.red;
			break;
			*/
		case ObjectStates.volumeControl:
			color = Color.magenta;
			break;
		}
		return color;
	}

	private Color RandomColor()
	{
		int randonNumber = randomGenerator.Next (0, 5);
		Color color = Color.white;
		switch (randonNumber) {
		case 0:
			color = Color.yellow;
			break;
		case 1:
			color = Color.red;
			break;
		case 2:
			color = Color.green;
			break;
		case 3:
			color = Color.blue;
			break;
		case 4:
			color = Color.magenta;
			break;
		}
		return color;

	}
}

