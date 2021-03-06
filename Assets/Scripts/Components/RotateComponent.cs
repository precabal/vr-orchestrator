using UnityEngine;
using System.Collections;
using System;

public class RotateComponent : MonoBehaviour
{
	public Vector3 _rotationAxis;
	public float _rotationAngle;
	public float _rotationTime;
	public float _rotationPeriod;
	public float _percentageOffset;

	private float _rotationStep;
	private int _rotationCount;
	private int _numberOfStepsToRotate;
	private float _numberOfStepsInPeriod;
	private int _offsetInSteps;

	private float _timer;
	//private float _epsilon = float.Epsilon;


	
	void Start ()
	{
		//TODO: force that _rotationTime to be a multiple of Time.fixedDeltaTime
		//if (Math.IEEERemainder(_rotationTime,Time.fixedDeltaTime) > 0)

		_numberOfStepsToRotate = (int)Math.Floor(_rotationTime / Time.fixedDeltaTime);
		_numberOfStepsInPeriod = (int)Math.Floor(_rotationPeriod / Time.fixedDeltaTime);
		_offsetInSteps = (int)Math.Floor (_percentageOffset * (float)_numberOfStepsInPeriod);
		//Debug.Log (_offsetInSteps);
		_rotationStep = _rotationAngle / _numberOfStepsToRotate;
		_timer = 0f;
	}
	
	void FixedUpdate ()
	{

		if (_timer >= _rotationPeriod - 2*float.Epsilon) {
			_rotationCount = 0;
			_timer = 0;
		}
		if ( (0 <= _rotationCount - _offsetInSteps) && (_rotationCount - _offsetInSteps < _numberOfStepsToRotate) )
		{
			//this.transform.Rotate (_rotationStep);
			this.transform.RotateAround(this.transform.position, this._rotationAxis, _rotationStep);

		}
		_rotationCount++;
		_timer += Time.deltaTime;
	}
}

