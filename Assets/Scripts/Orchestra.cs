using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
//using TBE_3DCore;

namespace AssemblyCSharp
{
	public class Orchestra
	{
		private ObjectFactory _objectFactory = new ObjectFactory();
		private List<GameObject> _gameObjects = new List<GameObject>();
		private GameObject _spherePrefab;
		private GameObject[] _beacons = new GameObject[4];

		public Orchestra ()
		{
			Initialize ();
		}

		public void Initialize()
		{

			InitializeSoundSources ();

			//InitializeBeacons ();

			//InitializeRandomSpheres ();

		}

		public void InitializeSoundSources()
		{
			AudioClip trackNoBassClip_L = Resources.Load("Binaries/audioTracks/16b - REPTILIANREGIONS_TRACKnoBASS.L") as AudioClip;
			AudioClip trackNoBassClip_R = Resources.Load("Binaries/audioTracks/16b - REPTILIANREGIONS_TRACKnoBASS.R") as AudioClip;
			AudioClip baseSoundsClip = Resources.Load("Binaries/audioTracks/base") as AudioClip;

			//Source #1 - L
			GameObject sphereSwarmL = _objectFactory.CreateFromPrefab(Resources.Load("soundSource_prefab") as GameObject, new Vector3(5,3,2), "swarm");			
			sphereSwarmL.transform.Find ("OSPAudioSource").gameObject.GetComponent<AudioSource> ().clip = trackNoBassClip_L;
			_gameObjects.Add (sphereSwarmL);

			//Source #1 - R
			GameObject sphereSwarmR = _objectFactory.CreateFromPrefab(Resources.Load("soundSource_prefab") as GameObject, new Vector3(5,3,-2), "swarm");			
			sphereSwarmR.transform.Find ("OSPAudioSource").gameObject.GetComponent<AudioSource> ().clip = trackNoBassClip_R;
			_gameObjects.Add (sphereSwarmR);


			//Source #2 (Stereo, 2D)
			GameObject baseSounds = _objectFactory.CreateFromPrefab(Resources.Load("OSPAudioSource_prefab") as GameObject);
			baseSounds.GetComponent<AudioSource> ().clip = baseSoundsClip;
			baseSounds.GetComponent<AudioSource> ().spatialBlend = 0;
			baseSounds.GetComponent<OSPAudioSource> ().Bypass = true;
			_gameObjects.Add (baseSounds);

			//Source #3 - L
			//Source #3 - R
				
		}

		public void InitializeBeacons()
		{

			_beacons[0] = Resources.Load("beacon_1_prefab") as GameObject;
			GameObject beacon1 = _objectFactory.CreateFromPrefab(_beacons[0], new Vector3(10,20,10), "beacons");
			_gameObjects.Add (beacon1); 

			_beacons[1] = Resources.Load("beacon_2_prefab") as GameObject;
			GameObject beacon2 = _objectFactory.CreateFromPrefab(_beacons[1], new Vector3(10,20,-10), "beacons");
			_gameObjects.Add (beacon2);

			_beacons[2] = Resources.Load("beacon_3_prefab") as GameObject;
			GameObject beacon3 = _objectFactory.CreateFromPrefab(_beacons[2], new Vector3(-10,20,10), "beacons");
			_gameObjects.Add (beacon3);

			_beacons[3] = Resources.Load("beacon_4_prefab") as GameObject;
			GameObject beacon4 = _objectFactory.CreateFromPrefab(_beacons[3], new Vector3(-10,20,-10), "beacons");
			_gameObjects.Add (beacon4);

			//TODO: see if we can unload assets here: Resources.UnloadAsset(_beacons[i]);
		}

		//TODO: pass the number of spheres as a parameter
		public void InitializeRandomSpheres()
		{
			_spherePrefab = Resources.Load("sphere_prefab") as GameObject;
			
			System.Random random = new System.Random();

			Vector3 position;
			for (int i = 0; i < 1; i++)
			{
				position = new Vector3(random.Next(-5, 5), random.Next(1, 5), random.Next(-5, 5));
				GameObject sphere = _objectFactory.CreateFromPrefab(_spherePrefab, position, "spheres");
				_gameObjects.Add(sphere);
			}

			//TODO: see if we can unload asset here: Resources.UnloadAsset(_spherePrefab);

		}


		//TODO: maybe implement the GetObjects function as a static one, in order to make a subfilter of the returned group?
		/* for example: groupOfObjects = GetObjects("swarm") and then:
		/ subGroupOfObject = GetObjects("soundSources",groupOfObjects), or GetObjects("soundSources","swarm") */

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

