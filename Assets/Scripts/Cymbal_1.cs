using System;
using System.Collections.Generic;
using UnityEngine;

namespace AssemblyCSharp
{
	public class Cymbal_1 : IInstrument
	{
		private List<GameObject> _objects;
		
		private Vector3 _centerPosition;
		public List<GameObject> Objects
		{
			get { return _objects; }
			set { _objects = value; }
		}
		public Cymbal_1 ()
		{

			GameObject container = new GameObject ("Cymbal_1");
			GameObject flareContainer = new GameObject ("Flare");
			flareContainer.transform.parent = container.transform;

			_objects = new List<GameObject> ();
			
			_centerPosition = new Vector3 (-30, 4, 12);
			
			//surrounding objects:
			_objects.AddRange( ObjectFactory.InitializeRandomSpheresInSphere(_centerPosition, 22, 4.0f, 20.0f, 30.0f) );
			foreach (GameObject obj in _objects) 
			{
				obj.tag = "cymbal_1_group";
				obj.transform.parent = flareContainer.transform;
			}
			
			//main object:
			AudioClip audioClip = Resources.Load("Binaries/audioTracks/CYMBALS_03") as AudioClip;
			GameObject mainObject = ObjectFactory.CreateFromPrefab(Resources.Load("soundSource_prefab") as GameObject, _centerPosition, "cymbal_1");
			mainObject.name = "Source";
			mainObject.transform.Find ("OSPAudioSource").gameObject.GetComponent<AudioSource> ().clip = audioClip;
			_objects.Add (mainObject);
			mainObject.transform.parent = container.transform;


		}
		
	}
}
