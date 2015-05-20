using UnityEngine;
using System.Collections;
using System;

public class RotateComponent : MonoBehaviour
{
	private static Vector3 _rotationAngle;
	private static float _rotationTime;
	private Vector3 _rotationStep;
	private int _rotationCount;
	private int _numberOfSteps;
	private static float _rotationPeriod;
	private float _timer;

	public static RotateComponent CreateComponent(GameObject target, Vector3 rotationAngle, float rotationTime, float rotationPeriod)
	{
		RotateComponent mc = target.AddComponent<RotateComponent> ();
		
		_rotationAngle = rotationAngle;
		_rotationTime = rotationTime;
		_rotationPeriod = rotationPeriod;

		return mc;
	}

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

