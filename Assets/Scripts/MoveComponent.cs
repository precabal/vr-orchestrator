using UnityEngine;
using System.Collections;

public class MoveComponent : MonoBehaviour
{
	private Vector3 _finalPosition;
	private float _velocity;

	public void CreateComponent(GameObject target, Vector3 finalPosition, float velocity)
	{
		target.AddComponent<MoveComponent> ();

		_finalPosition = finalPosition;
		_velocity = velocity;
	}

	void Start ()
	{
	}

	void FixUpdate ()
	{
	}
}
