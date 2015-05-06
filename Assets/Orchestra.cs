// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace AssemblyCSharp
{
	public class Orchestra
	{
		private ObjectFactory objectFactory;
		private List<GameObject> gameObjects;

		public GameObject spherePrefab;


		public Orchestra ()
		{
			objectFactory = new ObjectFactory();
			gameObjects = new List<GameObject>();
		}

		public void initialize()
		{
			//call ObjectFactory to instantiate prefabs
			GameObject cube = objectFactory.CreateCube(); 
			cube.AddComponent<Rigidbody>();
			cube.transform.position = new Vector3 (5, 5, 5);
			cube.tag = "beacons";

			Renderer rend;
			rend = cube.GetComponent<Renderer>();
			rend.enabled = false;

			gameObjects.Add (cube); 
			//gameObjects[0].SetActive(false);			

			//gameObjects[0].tag
			spherePrefab = Resources.Load("sphPref") as GameObject;

			//gameObjects[1].transform.position = new Vector3 (5, 5, 5);
			System.Random random = new System.Random();

			for (int i = 0; i < 10; i++)
			{
				GameObject sphere = objectFactory.CreateSphereFromPrefab(spherePrefab);
				sphere.transform.position = new Vector3(random.Next(-5, 5), random.Next(1, 5), random.Next(-5, 5));
				sphere.tag = "spheres";

				gameObjects.Add(sphere);
			}

			Resources.UnloadAsset(spherePrefab);
			
			
		}
		
		public List<GameObject> getObjects(String specifier)
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
				selectedObjects = gameObjects;
				break;
			default:
				//TODO igual que all
				break;
				
			}
			return selectedObjects;	
		}

		public void destroyObjects()
		{
			foreach (object o in gameObjects)
			{
			}
				//destroy object.
		}
	}
}

