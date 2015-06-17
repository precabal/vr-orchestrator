using System;
using System.Collections.Generic;
using UnityEngine;

namespace AssemblyCSharp
{
	public class LeadSynth_L : IInstrument
	{
		private List<GameObject> _objects;
		
		private Vector3 _centerPosition;
		public List<GameObject> Objects
		{
			get { return _objects; }
			set { _objects = value; }
		}
		public LeadSynth_L ()
		{
			GameObject container = new GameObject ("LeadSynth_L");
			GameObject flareContainer = new GameObject ("Flare");
			flareContainer.transform.parent = container.transform;
			
			_objects = new List<GameObject> ();
			
			_centerPosition = new Vector3 (10, 5, 5);
			
			//surrounding objects:
			_objects.AddRange( ObjectFactory.InitializeRandomSpheresInSphere(_centerPosition, 8, 1.0f, 5.0f, 5.0f) );
			
			foreach (GameObject obj in _objects) 
			{
				obj.tag = "leadSynth_L_group";
				obj.transform.parent = flareContainer.transform;
			}
			
			//main object:
			AudioClip audioClip = Resources.Load("Binaries/audioTracks/16b - REPTILIANREGIONS_TRACKnoBASS.L") as AudioClip;
			GameObject mainObject = ObjectFactory.CreateFromPrefab(Resources.Load("soundSource_prefab") as GameObject, _centerPosition, "leadSynth_L");
			mainObject.name = "Source";
			mainObject.transform.Find ("OSPAudioSource").gameObject.GetComponent<AudioSource> ().clip = audioClip;
			_objects.Add (mainObject);
			mainObject.transform.parent = container.transform;
			
			
		}
		
		
	}
}
