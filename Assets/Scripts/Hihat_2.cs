using System;
using System.Collections.Generic;
using UnityEngine;

namespace AssemblyCSharp
{
	public class Hihat_2 : IInstrument
	{
		private List<GameObject> _objects;
		
		private Vector3 _centerPosition;
		public List<GameObject> Objects
		{
			get { return _objects; }
			set { _objects = value; }
		}
		public Hihat_2 ()
		{
			GameObject hihatContainer = new GameObject ("Hihat_2");
			GameObject hihatFlareContainer = new GameObject ("Flare");
			hihatFlareContainer.transform.parent = hihatContainer.transform;

			_objects = new List<GameObject> ();
			
			_centerPosition = new Vector3 (-15, 30, 15);
			
			//surrounding objects:
			_objects.AddRange( ObjectFactory.InitializeRandomSpheresInSphere(_centerPosition) );
			foreach (GameObject obj in _objects) 
			{
				obj.tag = "hihat_2_group";
				obj.transform.parent = hihatFlareContainer.transform;
			}

			//main object
			AudioClip audioClip = Resources.Load("Binaries/audioTracks/HI_HAT_OPEN_RR_02") as AudioClip;
			GameObject mainObject = ObjectFactory.CreateFromPrefab(Resources.Load("soundSource_prefab") as GameObject, _centerPosition, "hihat_2");	
			mainObject.name = "Source";
			mainObject.transform.Find ("OSPAudioSource").gameObject.GetComponent<AudioSource> ().clip = audioClip;
			_objects.Add (mainObject);
			mainObject.transform.parent = hihatContainer.transform;
			
		}
		
	}
}

