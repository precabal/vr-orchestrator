using System;
using System.Collections.Generic;
using UnityEngine;

namespace AssemblyCSharp
{
	public class ObjectFactory
	{
		public static GameObject sphere = Resources.Load("sphere_prefab") as GameObject;
		public static GameObject light = Resources.Load("light_prefab") as GameObject;
		public static GameObject soundSource = Resources.Load("soundSource_prefab") as GameObject;


		public GameObject CreateCube()
		{
			return GameObject.CreatePrimitive(PrimitiveType.Cube);
		}

		public GameObject CreateSphere()
		{
			return GameObject.CreatePrimitive(PrimitiveType.Sphere);
		}

		public static GameObject CreateFromPrefab(GameObject prefab, Vector3 atPosition = default(Vector3), String withTag ="Untagged", float withScale=0.0f)
		{
			GameObject result = MonoBehaviour.Instantiate (prefab, atPosition, Quaternion.identity) as GameObject;
			result.transform.localScale += new Vector3(withScale, withScale, withScale);
			result.tag = withTag;
			return result;
		}

		public static List<GameObject> InitializeRandomSpheres(int numberOfSpheres=100, float length=100f, Vector3 center = default(Vector3))
		{
			List<GameObject> shperes = new List<GameObject> ();
		
			//GameObject _spherePrefab = Resources.Load("sphere_prefab") as GameObject;
			
			System.Random random = new System.Random();

			Vector3 position;
			for (int i = 0; i < numberOfSpheres; i++)
			{
				position = new Vector3(0.5f * ((float)random.NextDouble()  - 0.5f) , (float)random.NextDouble(), 0.5f * ((float)random.NextDouble()  - 0.5f));
				position *= length;
				position += center;

				//scale goes between [-0.27, 0.63) 
				float scale = 0.9f*((float)random.NextDouble() - 0.3f);
				
				GameObject sphereInstance = CreateFromPrefab(sphere, position, "Untagged", scale);
				shperes.Add(sphereInstance);
			}

			return shperes;
			
			//TODO: see if we can unload asset here: Resources.UnloadAsset(_spherePrefab);
			
		}

		public static List<GameObject> InitializeRandomPrefabsInSphere(GameObject prefab, Vector3 centerPoint = default(Vector3),
		                                                               int numberOfSpheres=100, 
		                                                               float thickness = 2f,
		                                                               float azimuthWidthDegrees = 20f,
		                                                               float elevationWidthDegrees = 80f
		                                                               )
		{
			List<GameObject> shperes = new List<GameObject> ();

			
			System.Random random = new System.Random();

			Vector3 positionCartesian;
			VectorSpherical positionSpherical = Utils.CartesianToSpherical (centerPoint);
			VectorSpherical tempVector;

			for (int i = 0; i < numberOfSpheres; i++)
			{

				tempVector.r =  thickness*((float)random.NextDouble()  - 0.5f);
				tempVector.theta =  (float)Math.PI*elevationWidthDegrees*((float)random.NextDouble()  - 0.5f)/180f;
				tempVector.phi = (float)Math.PI*azimuthWidthDegrees*((float)random.NextDouble()  - 0.5f)/180f;

				tempVector.r += positionSpherical.r;
				tempVector.theta += positionSpherical.theta;
				tempVector.phi += positionSpherical.phi;

				positionCartesian = Utils.SphericalToCartesian(tempVector);

				//scale goes between [-0.27, 0.63) 
				float scale = 0.9f*((float)random.NextDouble() - 0.3f);
				
				GameObject sphereInstance = CreateFromPrefab(prefab, positionCartesian, "Untagged", scale);
				shperes.Add(sphereInstance);
			}

			return shperes;

		}

	}
}

