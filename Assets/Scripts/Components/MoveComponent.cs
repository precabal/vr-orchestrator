using UnityEngine;
using System.Collections;

public class MoveComponent : MonoBehaviour
{
	public Vector3 _finalPosition;
	public float _translationTime;
	private float _timer;
	private Vector3 _acceleration;
	Rigidbody rb;

	void Start ()
	{
		rb = this.GetComponent<Rigidbody> ();
		//rb.velocity = Vector3.zero;

		Vector3 translation = _finalPosition - this.transform.position;
		float accelerationMagnitude = 4 * translation.magnitude / Mathf.Pow ((float)_translationTime, 2);

		_acceleration = translation.normalized * accelerationMagnitude;
		_timer = 0f;

	}

	void FixedUpdate ()
	{

		//TODO: change for steps as in rotateComponent or LightingComponent
		if (_timer <= _translationTime/2)
		{
			rb.velocity = rb.velocity + _acceleration * Time.deltaTime;
		}
		else if (_timer <= _translationTime)
		{
			rb.velocity = rb.velocity - _acceleration * Time.deltaTime;
		}
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
