using UnityEngine;
using System.Collections;
using System;

public class RotateComponent : MonoBehaviour
{
	public Vector3 _rotationAngle;
	public  float _rotationTime;
	public float _rotationPeriod;

	private Vector3 _rotationStep;
	private int _rotationCount;
	private int _numberOfSteps;

	private float _timer;

	
	void Start ()
	{
		//TODO: force that _rotationTime to be a multiple of Time.fixedDeltaTime
		_numberOfSteps = (int)Math.Floor(_rotationTime / Time.fixedDeltaTime);
		_rotationStep = _rotationAngle / _numberOfSteps;
		_timer = 0f;
	}
	
	void FixedUpdate ()
	{
		if (_timer > _rotationPeriod) {
			_rotationCount = 0;
			_timer = 0;
		}
		if (_rotationCount < _numberOfSteps)
		{
			this.transform.Rotate (_rotationStep);
			_rotationCount++;
		}
		_timer += Time.deltaTime;
	}
}

