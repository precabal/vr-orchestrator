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

		public Orchestra ()
		{
			Initialize ();
		}

		public void Initialize()
		{
			//InitializeBeacons ();
			InitializeRandomSpheres ();
		}

		public void InitializeBeacons()
		{
			_beacons[0] = Resources.Load("beacon_1_prefab") as GameObject;
			GameObject beacon1 = _objectFactory.CreateFromPrefab(_beacons[0]);
			beacon1.transform.position = new Vector3(10,20,10);
			beacon1.tag = "beacons";
			_gameObjects.Add (beacon1); 

			_beacons[1] = Resources.Load("beacon_2_prefab") as GameObject;
			GameObject beacon2 = _objectFactory.CreateFromPrefab(_beacons[1]);
			beacon2.transform.position = new Vector3(10,20,-10);
			beacon2.tag = "beacons";
			_gameObjects.Add (beacon2);

			_beacons[2] = Resources.Load("beacon_3_prefab") as GameObject;
			GameObject beacon3 = _objectFactory.CreateFromPrefab(_beacons[2]);
			beacon3.transform.position = new Vector3(-10,20,10);
			beacon3.tag = "beacons";
			_gameObjects.Add (beacon3);

			_beacons[3] = Resources.Load("beacon_4_prefab") as GameObject;
			GameObject beacon4 = _objectFactory.CreateFromPrefab(_beacons[3]);
			beacon4.transform.position = new Vector3(-10,20,-10);
			beacon4.tag = "beacons";
			_gameObjects.Add (beacon4);

			//TODO: see if we can unload assets here: Resources.UnloadAsset(_beacons[i]);
		}

		public void InitializeRandomSpheres()
		{
			_spherePrefab = Resources.Load("sphere_prefab") as GameObject;
			
			System.Random random = new System.Random();
			
			for (int i = 0; i < 10; i++)
			{
				GameObject sphere = _objectFactory.CreateFromPrefab(_spherePrefab);
				sphere.transform.position = new Vector3(random.Next(-5, 5), random.Next(1, 5), random.Next(-5, 5));
				sphere.tag = "spheres";
				
				_gameObjects.Add(sphere);
			}

			//TODO: see if we can unload asset here: Resources.UnloadAsset(_spherePrefab);

		}

		public List<GameObject> GetObjects(String specifier)
		{
			//TODO consider the case where a single object wants to be selected. better to use tag? see http://docs.unity3d.com/ScriptReference/GameObject.Find.html
			List<GameObject> selectedObjects = null;

			switch(specifier)
			{
			case "swarm":
				//selectedObjects = GameObject.FindGameObjectsWithTag("swarm");
				break;
			case "room":
				//selectedObjects = GameObject.FindGameObjectsWithTag("room");
				break;
			case "beacons":
				selectedObjects = GameObject.FindGameObjectsWithTag("beacons").ToList();
				break;
			case "spheres":
				selectedObjects = GameObject.FindGameObjectsWithTag("spheres").ToList();
				break;
			case "all":
				selectedObjects = _gameObjects;
				break;
			default:
				//TODO igual que all
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

