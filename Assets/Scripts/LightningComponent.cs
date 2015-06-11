using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using AssemblyCSharp;

public class LightningComponent : MonoBehaviour
{
	public float[] envelope;
	public List<GameObject> objectsToLight;
	
	private float _lightningPeriod = 1f;
	private float _binsToStepsRatio;

	private int _lastBallOn, _updateStep, _numberOfStepsInPeriod;
	private int numberOfBinsInEnvelope = 32;	

	System.Random randomGenerator = new System.Random();
	

	void Start ()
	{
		//set initial variables
		_updateStep = 0;
		_lastBallOn = -1;
		_numberOfStepsInPeriod = (int)Math.Floor (_lightningPeriod / Time.fixedDeltaTime);
		_binsToStepsRatio = (float)(numberOfBinsInEnvelope - 1) / (float)(_numberOfStepsInPeriod - 1);

		//shuffle list
		//objectsToLight = objectsToLight.OrderBy(a => randomGenerator.Next()) as List<GameObject>;
		 
	}
	void FixedUpdate ()
	{
		int targetBin = (int)Math.Floor ((float)_updateStep * _binsToStepsRatio); 

		int ballsToLight = (int)Math.Round (envelope [targetBin] * objectsToLight.Count);

		for (int i = _lastBallOn + 1; i < ballsToLight; i++) 
		{	
			(objectsToLight[i].GetComponent("Halo") as Behaviour).enabled = true;
			_lastBallOn = i;
		}

		for (int i = _lastBallOn; i > ballsToLight; i--) 
		{			
			(objectsToLight[i].GetComponent("Halo") as Behaviour).enabled = false;
			_lastBallOn = i - 1;
		}

		if (_updateStep++ >= _numberOfStepsInPeriod) {
			_updateStep = 0;
			//shuffle list
			Shuffle(objectsToLight);
		}
		
	}
	
	public void StopMovement()
	{
		Destroy(this);
	}

	public void Shuffle<T>(IList<T> list)  
	{  
		
		int n = list.Count;  
		while (n > 1) {  
			n--;  
			int randomIndex = randomGenerator.Next(n + 1);  
			T value = list[randomIndex];  
			list[randomIndex] = list[n];  
			list[n] = value;  
		}  
	}
}
