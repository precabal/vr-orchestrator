using System;
using System.Collections.Generic;
using UnityEngine;

namespace AssemblyCSharp
{
	public class Cymbal_2 : IInstrument
	{
		private List<GameObject> _objects;
		
		private Vector3 _centerPosition;
		public List<GameObject> Objects
		{
			get { return _objects; }
			set { _objects = value; }
		}
		public Cymbal_2 ()
		{

			GameObject container = new GameObject ("Cymbal_2");
			GameObject flareContainer = new GameObject ("Flare");
			flareContainer.transform.parent = container.transform;

			_objects = new List<GameObject> ();
			
			_centerPosition = new Vector3 (14, 4, -32);
			
			//surrounding objects:
			_objects.AddRange( ObjectFactory.InitializeRandomSpheresInSphere(_centerPosition, 22, 4.0f, 20.0f, 30.0f) );
			foreach (GameObject obj in _objects) 
			{
				obj.tag = "cymbal_2_group";
				obj.transform.parent = flareContainer.transform;
			}

			//main object:
			AudioClip audioClip = Resources.Load("Binaries/audioTracks/CYMBAL DLY_01") as AudioClip;
			GameObject mainObject = ObjectFactory.CreateFromPrefab(Resources.Load("soundSource_prefab") as GameObject, _centerPosition, "cymbal_2");
			mainObject.name = "Source";
			mainObject.transform.Find ("OSPAudioSource").gameObject.GetComponent<AudioSource> ().clip = audioClip;
			_objects.Add (mainObject);
			mainObject.transform.parent = container.transform;
		}
		
	}
}
