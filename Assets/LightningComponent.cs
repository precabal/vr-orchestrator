using UnityEngine;
using System.Collections;

public class BounceComponent : MonoBehaviour
{
	public float attack, decay, sustain, release;
	private float _timer;
	private float _rotationPeriod;

	void Start ()
	{
	
		Vector3 translation = _finalPosition - this.transform.position;
		float accelerationMagnitude = 4 * translation.magnitude / Mathf.Pow ((float)_translationTime, 2);
		
		_acceleration = translation.normalized * accelerationMagnitude;
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
		else
		{
			rb.velocity = Vector3.zero;
			this.transform.position = _finalPosition;
			Destroy(this);
		}
		_timer += Time.deltaTime;
		
	}
	
	public void StopMovement()
	{
		rb.velocity = Vector3.zero;
		Destroy(this);
	}
}
