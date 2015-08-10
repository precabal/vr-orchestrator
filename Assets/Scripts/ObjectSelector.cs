using UnityEngine;
using System.Collections;
using AssemblyCSharp;


public class ObjectSelector : MonoBehaviour
{
	private Camera cameraFacing;
	private System.Random randomGenerator;
	// Use this for initialization
	void Start ()
	{
		randomGenerator = new System.Random ();
		cameraFacing = Camera.allCameras[0];
		Debug.Log (cameraFacing);
	}
	
	// Update is called once per frame
	void Update ()
	{
		int number = 0;
		if (MidiInput.GetKeyDown (number) ) {

			//TODO: get the vector where the oculus is looking
			//Vector3 gazeDirection = this.transform.TransformVector (-this.transform.forward);
			//Debug.Log ("got note 0");
			RaycastHit hitInformation;

			//TODO: restore last painted object's color, or move this component to each object. It is as if all the rays are coming from my selectable objects.

			if (Physics.Raycast (cameraFacing.transform.position, cameraFacing.transform.rotation * Vector3.forward, out hitInformation)) {
				//if we caught an object, we mark it as:
					//selected-locked = green
					//volume change = red
					//solo = yellow
					//mute = light blue

				ObjectStates state = hitInformation.transform.gameObject.GetComponent<StateMachine>().ChangeState();

				//If object has a light compoment, select it and paint it green
				if(hitInformation.transform.gameObject.GetComponent<Light> () != null)
				{
					hitInformation.transform.gameObject.GetComponent<Light> ().color = GetColorFromState (state);
				}
			}
			//Ray ray = oculusCamera.ScreenPointToRay(Input.mousePosition);
			//Debug.DrawRay(this.transform.position, forwardDirection.rotation * Vector3.forward * 20 * 100, Color.red);
		}
		
	}
	private Color GetColorFromState(ObjectStates state)
	{
		Color color = Color.black;
		switch (state) {
		case ObjectStates.unselected:
			color = Color.white;
			break;
		case ObjectStates.locked:
			color = Color.green;
			break;
		case ObjectStates.muted:
			color = Color.cyan;
			break;
		case ObjectStates.soloed:
			color = Color.yellow;
			break;
		case ObjectStates.volumeChange:
			color = Color.red;
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

