using UnityEngine;
using System.Collections;

public class MoveComponent : MonoBehaviour
{
	private static Vector3 _finalPosition;
	private static float _translationTime;
	private float _timer;
	private Vector3 _acceleration;

	public static MoveComponent CreateComponent(GameObject target, Vector3 finalPosition, float translationTime)
	{
		MoveComponent mc = target.AddComponent<MoveComponent> ();

		_finalPosition = finalPosition;
		_translationTime = translationTime;

		return mc;
	}

	void Start ()
	{
		Vector3 translation = _finalPosition - this.transform.position;
		float accelerationMagnitude = 4 * translation.magnitude / Mathf.Pow ((float)_translationTime, 2);

		_acceleration = translation.normalized * accelerationMagnitude;
		_timer = 0f;

	}

	void FixedUpdate ()
	{
		Rigidbody rb = this.GetComponent<Rigidbody> ();

	

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
		}
		_timer += Time.deltaTime;

	}
}
