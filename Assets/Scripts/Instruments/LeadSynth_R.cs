using System;
using System.Collections.Generic;
using UnityEngine;

namespace AssemblyCSharp
{
	public class LeadSynth_R : IInstrument
	{
		private List<GameObject> _objects;
		
		private Vector3 _centerPosition;
		public List<GameObject> Objects
		{
			get { return _objects; }
			set { _objects = value; }
		}
		public LeadSynth_R ()
		{
			GameObject container = new GameObject ("LeadSynth_R");
			GameObject flareContainer = new GameObject ("Flare");
			flareContainer.transform.parent = container.transform;
			
			_objects = new List<GameObject> ();
			
			_centerPosition = new Vector3 (10, 5, -5);
			
			//surrounding objects:
			_objects.AddRange( ObjectFactory.InitializeRandomPrefabsInSphere(ObjectFactory.sphere, _centerPosition, 8, 1.0f, 5.0f, 5.0f) );
			
			foreach (GameObject obj in _objects) 
			{
				obj.tag = "leadSynth_R_group";
				obj.transform.parent = flareContainer.transform;
			}
			
			//main object:
			AudioClip audioClip = Resources.Load("Binaries/audioTracks/16b - REPTILIANREGIONS_TRACKnoBASS.R") as AudioClip;
			GameObject mainObject = ObjectFactory.CreateFromPrefab(ObjectFactory.soundSource, _centerPosition, "leadSynth_R");
			mainObject.name = "Source";
			mainObject.transform.Find ("OSPAudioSource").gameObject.GetComponent<AudioSource> ().clip = audioClip;
			_objects.Add (mainObject);
			mainObject.transform.parent = container.transform;

		}
		
		
	}
}
