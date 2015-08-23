using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class SaveState : MonoBehaviour {

	List<GameObject> audioTracks;

	void Start () {
		audioTracks = new List<GameObject>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetButton("Fire1"))
		{
			//recorrer lista de objetos y guardar posicion
			audioTracks = GameObject.FindGameObjectsWithTag("audioTrack").ToList();

			foreach(GameObject obj in audioTracks)
			{
				Debug.Log("OBJETOS: " + obj.name + " " + obj.transform.position);

			}
		}
	}
}
