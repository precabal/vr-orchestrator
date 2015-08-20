using UnityEngine;
using System.Collections;
using System;
using AssemblyCSharp;
using UnityEngine.UI;

public class Transport : MonoBehaviour {

	public float rewindTime;

	void Start () {
		rewindTime = 5f;

	}

	void Update () {
		//rewind
		if(MidiInput.GetKeyDown(24))
		{

			GameObject[] audioSources =  GameObject.FindGameObjectsWithTag("audioSource");

			float currentSongTime = audioSources[0].GetComponent<AudioSource>().time;

			float targetTime = Math.Max(0f, currentSongTime - rewindTime);

			foreach(GameObject obj in audioSources)
			{
				obj.GetComponent<AudioSource>().time = targetTime;
			}

		}

		//pause //resume


		if(Input.GetKeyDown("space"))
		{
			GameObject[] audioSources =  GameObject.FindGameObjectsWithTag("audioSource");
			if(audioSources[0].GetComponent<AudioSource>().isPlaying)
			{
				foreach(GameObject obj in audioSources)
				{
						obj.GetComponent<AudioSource>().Pause();
				}
			}else
			{
				foreach(GameObject obj in audioSources)
				{
					obj.GetComponent<AudioSource>().UnPause();
				}
			}
		
		}


	}
}
