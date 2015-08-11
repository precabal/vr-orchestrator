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
		if (state.Equals (ObjectStates.locked)) {
		
			float distanceToCamera = (transform.position - cameraFacing.transform.position).magnitude ; 
			transform.position = cameraFacing.transform.position +
				cameraFacing.transform.rotation * Vector3.forward * distanceToCamera;


			if (MidiInput.GetKeyDown (1) )
			{
				//bring object closer / increase volume / unmute / solo
				transform.Translate(cameraFacing.transform.rotation * Vector3.forward * translationStep * -1f);
			}

			if (MidiInput.GetKeyDown (3) ) 
			{
				//move object away / decrease volume / mute / unsolo
				transform.Translate(cameraFacing.transform.rotation * Vector3.forward * translationStep);

			}
		}





	
	}
	public ObjectStates ToggleMute()
	{
		if (state.Equals (ObjectStates.muted)) 
		{
			state = ObjectStates.unselected;
			this.GetComponentInChildren<AudioSource> ().mute = false;
		} else {
			state = ObjectStates.muted;
			this.GetComponentInChildren<AudioSource> ().mute = true;
		}
		return state;
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

		if (state.Equals (ObjectStates.muted)) {
			this.GetComponentInChildren<AudioSource> ().mute = true;
		} else {
			this.GetComponentInChildren<AudioSource> ().mute = false;
		}

		return state;
	}
}

