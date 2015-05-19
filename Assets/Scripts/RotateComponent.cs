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

	public static RotateComponent CreateComponent(GameObject target, Vector3 rotationAngle, float rotationTime)
	{
		RotateComponent mc = target.AddComponent<RotateComponent> ();
		
		_rotationAngle = rotationAngle;
		_rotationTime = rotationTime;

		return mc;
	}

	void Start ()
	{
		_numberOfSteps = (int)Math.Floor(_rotationTime / Time.fixedDeltaTime);
		_rotationStep = _rotationAngle / _numberOfSteps;
	}
	
	void FixedUpdate ()
	{
		if (_rotationCount < _numberOfSteps)
		{
			this.transform.Rotate (_rotationStep);
			_rotationCount++;
		}
	}
}

