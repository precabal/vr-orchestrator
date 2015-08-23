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
		//cameraFacing = Camera.allCameras[0];
		//Debug.Log (cameraFacing);
	}
	
	// Update is called once per frame
	void Update ()
	{

		int number = 0;
		if (MidiInput.GetKeyDown (number)) {

			RaycastHit hitInformation;

			//TODO: restore last painted object's color, or move this component to each object. It is as if all the rays are coming from my selectable objects.

			if (Physics.Raycast (cameraFacing.transform.position, cameraFacing.transform.rotation * Vector3.forward, out hitInformation)) {


				ObjectStates state = hitInformation.transform.gameObject.GetComponent<StateMachine> ().ChangeState ();

				//If object has a light compoment, select it and paint it
				if (hitInformation.transform.gameObject.GetComponent<Light> () != null) {
					hitInformation.transform.gameObject.GetComponent<Light> ().color = GetColorFromState (state);
				}
			}
			//Ray ray = oculusCamera.ScreenPointToRay(Input.mousePosition);
			//Debug.DrawRay(this.transform.position, forwardDirection.rotation * Vector3.forward * 20 * 100, Color.red);
		}

		if (MidiInput.GetKeyDown (6) ) {
			
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

