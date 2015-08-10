using UnityEngine;
using System.Collections;


public class RayCaster : MonoBehaviour
{
	public Transform forwardDirection;
	private System.Random randomGenerator;
	// Use this for initialization
	void Start ()
	{
		randomGenerator = new System.Random ();
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown ("space")) {

			//TODO: get the vector where the oculus is looking
			Vector3 gazeDirection = this.transform.TransformVector (-this.transform.forward);
			//Debug.Log (gazeDirection);
			RaycastHit hitInformation;

			//TODO: restore last painted object's color, or move this component to each object. It is as if all the rays are coming from my selectable objects.

			if (Physics.Raycast (this.transform.position, forwardDirection.rotation * Vector3.forward, out hitInformation)) {
				//If object has a light compoment, select it and paint it green
				//if(hitInformation.transform.gameObject.GetComponent<Light> () != null)
				{
					hitInformation.transform.gameObject.GetComponent<Light> ().color = RandomColor ();
				}
			}
			//Ray ray = oculusCamera.ScreenPointToRay(Input.mousePosition);
			//Debug.DrawRay(this.transform.position, forwardDirection.rotation * Vector3.forward * 20 * 100, Color.red);
		}
		
	}
	private Color RandomColor()
	{
		int randonNumber = randomGenerator.Next (0, 5);
		Color color = Color.white;
		switch (randonNumber) {
		case 0:
			color = Color.yellow;
			break;
		case 1:
			color = Color.red;
			break;
		case 2:
			color = Color.green;
			break;
		case 3:
			color = Color.blue;
			break;
		case 4:
			color = Color.magenta;
			break;
		}
		return color;

	}
}

