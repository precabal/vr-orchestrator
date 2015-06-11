using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace AssemblyCSharp
{
	public class Orchestra
	{
		private ObjectFactory _objectFactory = new ObjectFactory();
		private List<GameObject> _gameObjects = new List<GameObject>();
		private GameObject _spherePrefab;
		private GameObject[] _beacons = new GameObject[4];
		private int _numberOfSpheres = 100;
		private int _spaceDimension = 12;
		private int offsetX = 40;
		private int offsetY = 20;
		private int offsetZ = 40;

		public Orchestra ()
		{
			Initialize ();
		}
		public void AddGroup(IInstrument instrument)
		{
			_gameObjects.AddRange (instrument.Objects);

		}

		public void Initialize()
		{

			//InitializeSoundSources ();

			//InitializeBeacons ();

			InitializeRandomSpheres ();

		}

		public void InitializeSoundSources()
		{
//			AudioClip leadSynth_R = Resources.Load("Binaries/audioTracks/16b - REPTILIANREGIONS_TRACKnoBASS.L") as AudioClip;
//			AudioClip leadSynth_L = Resources.Load("Binaries/audioTracks/16b - REPTILIANREGIONS_TRACKnoBASS.R") as AudioClip;
//			AudioClip baseSoundsClip = Resources.Load("Binaries/audioTracks/base") as AudioClip;
//			AudioClip hihat1 = Resources.Load("Binaries/audioTracks/HI_HAT_CL_RR_02") as AudioClip;
//			AudioClip hihat2 = Resources.Load("Binaries/audioTracks/HI_HAT_OPEN_RR_02") as AudioClip;
//			AudioClip cymbal1 = Resources.Load("Binaries/audioTracks/CYMBALS_03") as AudioClip;
//			AudioClip cymbal2 = Resources.Load("Binaries/audioTracks/CYMBAL DLY_01") as AudioClip;
//			AudioClip snare1 = Resources.Load("Binaries/audioTracks/SNARE_1_RR_02") as AudioClip;
//			AudioClip snare2 = Resources.Load("Binaries/audioTracks/SNARE_2_RR_02") as AudioClip;
			//AudioClip snare3 = Resources.Load("Binaries/audioTracks/SNARE1_VERB_02") as AudioClip;

//			//Source #0 - Base (Stereo, 2D)
//			GameObject baseSounds = _objectFactory.CreateFromPrefab(Resources.Load("OSPAudioSource_prefab") as GameObject);
//			baseSounds.GetComponent<AudioSource> ().clip = baseSoundsClip;
//			baseSounds.GetComponent<AudioSource> ().spatialBlend = 0;
//			baseSounds.GetComponent<AudioSource> ().volume = 0.1f;
//			baseSounds.GetComponent<OSPAudioSource> ().Bypass = true;
//			_gameObjects.Add (baseSounds);				
//					
//			//Source #1 -Lead Synth L
//			GameObject sphereSwarmL = _objectFactory.CreateFromPrefab(Resources.Load("soundSource_prefab") as GameObject, new Vector3(15,3,-6), "swarm");			
//			sphereSwarmL.transform.Find ("OSPAudioSource").gameObject.GetComponent<AudioSource> ().clip = leadSynth_L;
//			_gameObjects.Add (sphereSwarmL);
//
//			//Source #2 - Lead Synth R
//			GameObject sphereSwarmR = _objectFactory.CreateFromPrefab(Resources.Load("soundSource_prefab") as GameObject, new Vector3(15,3,6), "swarm");			
//			sphereSwarmR.transform.Find ("OSPAudioSource").gameObject.GetComponent<AudioSource> ().clip = leadSynth_R;
//			_gameObjects.Add (sphereSwarmR);
//
//			//Source #3 - Hihat 1
//			GameObject hihat1Obj = _objectFactory.CreateFromPrefab(Resources.Load("soundSource_prefab") as GameObject, new Vector3(3,5,-2), "spheres");			
//			hihat1Obj.transform.Find ("OSPAudioSource").gameObject.GetComponent<AudioSource> ().clip = hihat1;
//			_gameObjects.Add (hihat1Obj);
//
//			//Source #4 - Hihat 2
//			GameObject hihat2Obj = _objectFactory.CreateFromPrefab(Resources.Load("soundSource_prefab") as GameObject, new Vector3(3,5,-2), "spheres");			
//			hihat2Obj.transform.Find ("OSPAudioSource").gameObject.GetComponent<AudioSource> ().clip = hihat2;
//			_gameObjects.Add (hihat2Obj);
//
//			//Source #5 - Cymbal 1
//			GameObject cymbal1Obj = _objectFactory.CreateFromPrefab(Resources.Load("soundSource_prefab") as GameObject, new Vector3(-3,4,-2), "spheres");			
//			cymbal1Obj.transform.Find ("OSPAudioSource").gameObject.GetComponent<AudioSource> ().clip = cymbal1;
//			_gameObjects.Add (cymbal1Obj);
//			
//			//Source #6 - Cymbal 2
//			GameObject cymbal2Obj = _objectFactory.CreateFromPrefab(Resources.Load("soundSource_prefab") as GameObject, new Vector3(-3,4,2), "spheres");			
//			cymbal2Obj.transform.Find ("OSPAudioSource").gameObject.GetComponent<AudioSource> ().clip = cymbal2;
//			_gameObjects.Add (cymbal2Obj);
//				
//			//Source #7 - Snare 1
//			GameObject snare1Obj = _objectFactory.CreateFromPrefab(Resources.Load("soundSource_prefab") as GameObject, new Vector3(-3,8,-2), "spheres");			
//			snare1Obj.transform.Find ("OSPAudioSource").gameObject.GetComponent<AudioSource> ().clip = snare1;
//			_gameObjects.Add (snare1Obj);
//			
//			//Source #8 - Cymbal 2
//			GameObject snare2Obj = _objectFactory.CreateFromPrefab(Resources.Load("soundSource_prefab") as GameObject, new Vector3(-3,8,2), "spheres");			
//			snare2Obj.transform.Find ("OSPAudioSource").gameObject.GetComponent<AudioSource> ().clip = snare2;
//			_gameObjects.Add (snare2Obj);
//
//			
			
		}
		
		public void InitializeBeacons()
		{

//			_beacons[0] = Resources.Load("beacon_1_prefab") as GameObject;
//			GameObject beacon1 = _objectFactory.CreateFromPrefab(_beacons[0], new Vector3(10,20,10), "beacons");
//			_gameObjects.Add (beacon1); 
//
//			_beacons[1] = Resources.Load("beacon_2_prefab") as GameObject;
//			GameObject beacon2 = _objectFactory.CreateFromPrefab(_beacons[1], new Vector3(10,20,-10), "beacons");
//			_gameObjects.Add (beacon2);
//
//			_beacons[2] = Resources.Load("beacon_3_prefab") as GameObject;
//			GameObject beacon3 = _objectFactory.CreateFromPrefab(_beacons[2], new Vector3(-10,20,10), "beacons");
//			_gameObjects.Add (beacon3);
//
//			_beacons[3] = Resources.Load("beacon_4_prefab") as GameObject;
//			GameObject beacon4 = _objectFactory.CreateFromPrefab(_beacons[3], new Vector3(-10,20,-10), "beacons");
//			_gameObjects.Add (beacon4);

			//TODO: see if we can unload assets here: Resources.UnloadAsset(_beacons[i]);
		}

		//TODO: pass the number of spheres as a parameter
		public void InitializeRandomSpheres()
		{
//			_spherePrefab = Resources.Load("sphere_prefab") as GameObject;
//			
//			System.Random random = new System.Random();
//
//			Vector3 position;
//			for (int i = 0; i < _numberOfSpheres; i++)
//			{
//				position = new Vector3(random.Next(-_spaceDimension+offsetX, _spaceDimension+offsetX), random.Next(1, _spaceDimension+offsetY), random.Next(-_spaceDimension+offsetZ, _spaceDimension+offsetZ));
//
//				//scale goes between [-0.25, -.25) 
//				float scale = 0.9f*((float)random.NextDouble() - 0.3f);
//
//				GameObject sphere = _objectFactory.CreateFromPrefab(_spherePrefab, position, "lightning1", scale);
//				_gameObjects.Add(sphere);
//			}
//
//			GameObject masterSphere = _objectFactory.CreateFromPrefab(_spherePrefab, new Vector3(offsetX, offsetY, offsetZ), "lightningMaster", 0.5f);
//			_gameObjects.Add(masterSphere);

			//TODO: see if we can unload asset here: Resources.UnloadAsset(_spherePrefab);

		}

		public List<GameObject> GetObjects(String specifier)
		{
			//TODO consider the case where a single object wants to be selected. better to use tag? see http://docs.unity3d.com/ScriptReference/GameObject.Find.html
			List<GameObject> selectedObjects = null;

			switch(specifier)
			{
			case "all":
				selectedObjects = _gameObjects;
				break;
			default:
				selectedObjects = GameObject.FindGameObjectsWithTag(specifier).ToList();
				break;
				
			}
			return selectedObjects;	
		}


		public void DestroyObjects()
		{
			foreach (GameObject obj in _gameObjects)
			{
				MonoBehaviour.Destroy(obj);
			}
		}
	}
}

