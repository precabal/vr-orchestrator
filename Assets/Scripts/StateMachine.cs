using UnityEngine;
using System.Collections;
using AssemblyCSharp;
using System;

public class StateMachine : MonoBehaviour
{
	private ObjectStates state;
	private int enumLength;

	void Start ()
	{
		state = ObjectStates.unselected;
		enumLength = Enum.GetNames(typeof(ObjectStates)).Length;
	}
	

	void Update ()
	{
	
	}
	public ObjectStates ChangeState()
	{
		int stateNumber = (int)state;
		stateNumber = (stateNumber + 1) % enumLength;
		state = (ObjectStates)stateNumber ; 
		Debug.Log (state);
		return state;
	}
}

