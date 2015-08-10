using UnityEngine;
using System.Collections;
using AssemblyCSharp;
using System;

public class StateMachine : MonoBehaviour
{
	private ObjectStates state;
	private int enumLength;
	private Camera cameraFacing;

	void Start ()
	{
		state = ObjectStates.unselected;
		enumLength = Enum.GetNames(typeof(ObjectStates)).Length;
		cameraFacing = Camera.allCameras[1];
	}
	

	void Update ()
	{
		//TODO fix relative position on camera
		if (state.Equals (ObjectStates.locked)) {
		
			float distanceToCamera = (transform.position - cameraFacing.transform.position).magnitude ; 
			transform.position = cameraFacing.transform.position +
				cameraFacing.transform.rotation * Vector3.forward * distanceToCamera;
		}



	
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

