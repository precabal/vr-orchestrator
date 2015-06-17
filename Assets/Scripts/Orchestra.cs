using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace AssemblyCSharp
{
	public class Orchestra
	{
		private List<GameObject> _members = new List<GameObject>();

		public Orchestra ()
		{
			Initialize ();
		}
		public void AddGroup(IInstrument instrument)
		{
			_members.AddRange (instrument.Objects);

		}

		public void Initialize()
		{

			//InitializeSoundSources ();
			//InitializeBeacons ();

		}

		public void InitializeSoundSources()
		{

			AudioClip snare1 = Resources.Load("Binaries/audioTracks/SNARE_1_RR_02") as AudioClip;
			AudioClip snare2 = Resources.Load("Binaries/audioTracks/SNARE_2_RR_02") as AudioClip;
			//AudioClip snare3 = Resources.Load("Binaries/audioTracks/SNARE1_VERB_02") as AudioClip;
				
			//Source #7 - Snare 1
			GameObject snare1Obj = ObjectFactory.CreateFromPrefab(Resources.Load("soundSource_prefab") as GameObject, new Vector3(-3,8,-2), "spheres");			
			snare1Obj.transform.Find ("OSPAudioSource").gameObject.GetComponent<AudioSource> ().clip = snare1;
			_members.Add (snare1Obj);
			
			//Source #8 - Snare 2
			GameObject snare2Obj = ObjectFactory.CreateFromPrefab(Resources.Load("soundSource_prefab") as GameObject, new Vector3(-3,8,2), "spheres");			
			snare2Obj.transform.Find ("OSPAudioSource").gameObject.GetComponent<AudioSource> ().clip = snare2;
			_members.Add (snare2Obj);

			
			
		}
		
		public void InitializeBeacons()
		{

			GameObject beacon1 = ObjectFactory.CreateFromPrefab(Resources.Load("beacon_1_prefab") as GameObject, new Vector3(10,20,10));
			_members.Add (beacon1); 

			GameObject beacon2 = ObjectFactory.CreateFromPrefab(Resources.Load("beacon_2_prefab") as GameObject, new Vector3(10,20,-10));
			_members.Add (beacon2);

			GameObject beacon3 = ObjectFactory.CreateFromPrefab(Resources.Load("beacon_3_prefab") as GameObject, new Vector3(-10,20,10), "Untagged");
			_members.Add (beacon3);

			GameObject beacon4 = ObjectFactory.CreateFromPrefab(Resources.Load("beacon_4_prefab") as GameObject, new Vector3(-10,20,-10), "Untagged");
			_members.Add (beacon4);

		}

		public List<GameObject> GetObjects(String specifier)
		{
			//TODO consider the case where a single object wants to be selected. better to use tag? see http://docs.unity3d.com/ScriptReference/GameObject.Find.html
			List<GameObject> selectedObjects = null;

			switch(specifier)
			{
			case "all":
				selectedObjects = _members;
				break;
			default:
				selectedObjects = GameObject.FindGameObjectsWithTag(specifier).ToList();
				break;
				
			}
			return selectedObjects;	
		}


		public void DestroyObjects()
		{
			foreach (GameObject obj in _members)
			{
				MonoBehaviour.Destroy(obj);
			}
		}
	}
}

