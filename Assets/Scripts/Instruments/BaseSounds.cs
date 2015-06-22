using System;
using System.Collections.Generic;
using UnityEngine;

namespace AssemblyCSharp
{
	public class BaseSounds : IInstrument
	{
		private List<GameObject> _objects;
		
		private Vector3 _centerPosition;
		public List<GameObject> Objects
		{
			get { return _objects; }
			set { _objects = value; }
		}
		public BaseSounds ()
		{
			_objects = new List<GameObject> ();
			
			//surrounding objects: none
			
			//main object:
			AudioClip audioClip = Resources.Load("Binaries/audioTracks/base") as AudioClip;
			GameObject mainObject = ObjectFactory.CreateFromPrefab(Resources.Load("OSPAudioSource_prefab") as GameObject);
			mainObject.name = "Base Sounds";
			mainObject.GetComponent<AudioSource> ().clip = audioClip;
			mainObject.GetComponent<AudioSource> ().spatialBlend = 0;
			mainObject.GetComponent<AudioSource> ().volume = 0.1f;
			mainObject.GetComponent<OSPAudioSource> ().Bypass = true;
			_objects.Add (mainObject);		
			
			
			
		}
		
	}
}


