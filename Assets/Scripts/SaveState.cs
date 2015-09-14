using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SaveState : MonoBehaviour {

	List<GameObject> audioTracks;

	private GUIMenu menu;

	void Start () {
		audioTracks = new List<GameObject>();
		menu = FindObjectOfType<GUIMenu>();
	}
	
	// Update is called once per frame
	void Update () {
	
		if(( Input.GetButton("BumperL") && Input.GetButtonDown("BumperR") )||( Input.GetButtonDown("BumperL") && Input.GetButton("BumperR") ) )
		{
			//TODO display message on GUI saved state
			menu.savedStateMessage = true;
			StartCoroutine(GuiDisplayTimer());

			//recorrer lista de objetos y guardar posicion
			audioTracks = GameObject.FindGameObjectsWithTag("audioTrack").ToList();

			foreach(GameObject obj in audioTracks)
			{
				Debug.Log("OBJETOS: " + obj.name + " " + obj.transform.position);

			}
		}
	}

	IEnumerator GuiDisplayTimer()
	{
		// Waits an amount of time
		yield return new WaitForSeconds(2.5f);
		// Deactivate GUI objects;
		menu.savedStateMessage = false;
	}
}
