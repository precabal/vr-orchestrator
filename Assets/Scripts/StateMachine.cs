using UnityEngine;
using System.Collections;
using AssemblyCSharp;
using System;

public class StateMachine : MonoBehaviour
{
	private ObjectStates state;
	private int enumLength;
	private Camera cameraFacing;
	private float translationStep;

	void Start ()
	{
		state = ObjectStates.unselected;
		enumLength = Enum.GetNames(typeof(ObjectStates)).Length;
		cameraFacing = Camera.allCameras[1];
		translationStep = 0.3f;

	}
	

	void Update ()
	{
		//TODO fix relative position on camera
		if(state.Equals(ObjectStates.positionControl))
		{
			float distanceToCamera = (transform.position - cameraFacing.transform.position).magnitude ; 
			transform.position = cameraFacing.transform.position +
				cameraFacing.transform.rotation * Vector3.forward * distanceToCamera;
		}

		if (MidiInput.GetKeyDown (1) )
		{
			//bring object closer / decrease volume / unmute / solo
			switch(state)
			{
			case ObjectStates.muteControl:
				GetComponentInChildren<AudioSource> ().mute = false;
				GetComponent<Light>().intensity = 6.9f;
				break;
			case ObjectStates.positionControl:
				transform.Translate(cameraFacing.transform.rotation * Vector3.forward * translationStep * -1f);
				break;
			case ObjectStates.volumeControl:
				GetComponentInChildren<AudioSource> ().volume -= 0.05f;//volumeChange
				GetComponent<Light>().range -= 0.05f;
				break;
			case ObjectStates.soloControl:
				//solo
				break;
			}
		}else if (MidiInput.GetKeyDown (3) ) 
		{
			//move object away / increase volume / mute / unsolo
			switch(state)
			{
			case ObjectStates.muteControl:
				GetComponentInChildren<AudioSource> ().mute = true;
				GetComponent<Light>().intensity = 0.5f;

				break;
			case ObjectStates.positionControl:
				transform.Translate(cameraFacing.transform.rotation * Vector3.forward * translationStep);
				break;
			case ObjectStates.volumeControl:
				//TODO: Link these two
				GetComponentInChildren<AudioSource> ().volume += 0.05f;
				GetComponent<Light>().range += 0.05f;
				break;
			case ObjectStates.soloControl:
				//solo
				break;
			}
	
		}
	}


	public void ToggleMute()
	{
		GetComponentInChildren<AudioSource> ().mute = !(GetComponentInChildren<AudioSource> ().mute);

		//TODO Migrate to other function or script
		GetComponent<Light>().intensity = 
			(  (10 * (GetComponent<Light>().intensity  + Definitions.maxLight - Definitions.minLight)) % (20 * (Definitions.maxLight - Definitions.minLight))  )/10f;
	
	}
	public ObjectStates ChangeState()
	{
		int stateNumber = (int)state;
		stateNumber = (stateNumber + 1) % enumLength;
		state = (ObjectStates)stateNumber ; 
		Debug.Log (state);

		/*
		if (state.Equals (ObjectStates.locked)) {
			//TODO store relative position of object on screen
		}*/


		return state;
	}
}

