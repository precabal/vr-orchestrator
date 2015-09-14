using UnityEngine;
using System.Collections;
using System;
using AssemblyCSharp;
using UnityEngine.UI;

public class Transport : MonoBehaviour {

	public float rewindTime;
	public float forwardTime;

	void Start () {
		rewindTime = 5f;
		forwardTime = 5f;
	}

	void Update () {
		//rewind
		if(Input.GetButtonDown("Back"))
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


		if(Input.GetButtonDown("BigCircle"))
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

		if(Input.GetButtonDown("Forward"))
		{
			GameObject[] audioSources =  GameObject.FindGameObjectsWithTag("audioSource");
			
			float currentSongTime = audioSources[0].GetComponent<AudioSource>().time;
			
			float targetTime = Math.Max(0f, currentSongTime + forwardTime);
			
			foreach(GameObject obj in audioSources)
			{
				obj.GetComponent<AudioSource>().time = targetTime;
			}
			
		}


	}
}
