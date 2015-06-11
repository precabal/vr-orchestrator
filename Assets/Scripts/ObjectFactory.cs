using System;
using System.Collections.Generic;
using UnityEngine;

namespace AssemblyCSharp
{
	public class ObjectFactory
	{
		public GameObject CreateCube()
		{
			return GameObject.CreatePrimitive(PrimitiveType.Cube);
		}

		public GameObject CreateSphere()
		{
			return GameObject.CreatePrimitive(PrimitiveType.Sphere);
		}

		public static GameObject CreateFromPrefab(GameObject objectPrefab, Vector3 atPosition, String withTag, float withScale=0.0f)
		{
			GameObject result = MonoBehaviour.Instantiate (objectPrefab, atPosition, Quaternion.identity) as GameObject;
			result.transform.localScale += new Vector3(withScale, withScale, withScale);
			result.tag = withTag;
			return result;
		}

		public GameObject CreateFromPrefab(GameObject objectPrefab)
		{
			return MonoBehaviour.Instantiate (objectPrefab, new Vector3(0,0,0), Quaternion.identity) as GameObject;
		}
		public static List<GameObject> InitializeRandomSpheres(int numberOfSpheres=100, float length=100f, Vector3 center = default(Vector3))
		{
			List<GameObject> shperes = new List<GameObject> ();
		
			GameObject _spherePrefab = Resources.Load("sphere_prefab") as GameObject;
			
			System.Random random = new System.Random();
			
			Vector3 position;
			for (int i = 0; i < numberOfSpheres; i++)
			{
				position = new Vector3(0.5f * ((float)random.NextDouble()  - 0.5f) , (float)random.NextDouble(), 0.5f * ((float)random.NextDouble()  - 0.5f));
				position *= length;
				position += center;

				//scale goes between [-0.27, 0.63) 
				float scale = 0.9f*((float)random.NextDouble() - 0.3f);
				
				GameObject sphere = CreateFromPrefab(_spherePrefab, position, "spheres", scale);
				shperes.Add(sphere);
			}

			return shperes;
			
			//TODO: see if we can unload asset here: Resources.UnloadAsset(_spherePrefab);
			
		}
	}
}

