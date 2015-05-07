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

		public Orchestra ()
		{
		}

		public void Initialize()
		{
			//call ObjectFactory to instantiate prefabs
			GameObject cube = _objectFactory.CreateCube(); 
			cube.AddComponent<Rigidbody>();
			cube.transform.position = new Vector3 (5, 5, 5);
			cube.tag = "beacons";

			Renderer rend;
			rend = cube.GetComponent<Renderer>();
			rend.enabled = false;

			_gameObjects.Add (cube); 
			//gameObjects[0].SetActive(false);			

			//gameObjects[0].tag
			_spherePrefab = Resources.Load("sphPref") as GameObject;

			//gameObjects[1].transform.position = new Vector3 (5, 5, 5);
			System.Random random = new System.Random();

			for (int i = 0; i < 10; i++)
			{
				GameObject sphere = _objectFactory.CreateSphereFromPrefab(_spherePrefab);
				sphere.transform.position = new Vector3(random.Next(-5, 5), random.Next(1, 5), random.Next(-5, 5));
				sphere.tag = "spheres";

				_gameObjects.Add(sphere);
			}

//			Resources.UnloadAsset(_spherePrefab);
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
			foreach (object obj in _gameObjects)
			{
			}
		}
	}
}

