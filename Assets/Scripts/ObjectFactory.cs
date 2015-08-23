using System;
using System.Collections.Generic;
using UnityEngine;

namespace AssemblyCSharp
{
	public class ObjectFactory
	{
		private static GameObject sphere = Resources.Load("OwnPrefabs/sphere_prefab") as GameObject;
		private static GameObject light = Resources.Load("OwnPrefabs/light_prefab") as GameObject;

		//TODO: merge these two
		private static GameObject soundSource = Resources.Load("OwnPrefabs/soundSource_prefab") as GameObject;
		private static GameObject looseSoundSource = Resources.Load ("OwnPrefabs/OSPAudioSource_prefab") as GameObject;
		private static GameObject speaker = Resources.Load("OwnPrefabs/speaker_prefab") as GameObject;
		private static GameObject tilePrefab = Resources.Load("OwnPrefabs/tile_prefab") as GameObject;
		private static GameObject swarmObject = Resources.Load("OwnPrefabs/swarm_prefab") as GameObject;

		public GameObject CreateCube()
		{
			return GameObject.CreatePrimitive(PrimitiveType.Cube);
		}

		public GameObject CreateSphere()
		{
			return GameObject.CreatePrimitive(PrimitiveType.Sphere);
		}

		public static GameObject CreateFromPrefab(PrefabType prefabType, Vector3 atPosition = default(Vector3), String withTag ="Untagged", float withScale=0.0f)
		{
			GameObject prefab = null;
			float rotationYdegrees = 0f;
			switch(prefabType)
			{
			case PrefabType.sphere:
				prefab = sphere;
				break;
			case PrefabType.light:
				prefab = light;
				break;
			case PrefabType.soundSource:
				prefab = soundSource;
				break;
			case PrefabType.swarmObject:
				prefab = swarmObject;
				break;
			case PrefabType.speaker:
				prefab = speaker;
				rotationYdegrees = 180f * (float) ((Utils.CartesianToSpherical(atPosition).phi + Math.PI ) / Math.PI) ;
				break;
			case PrefabType.tile:
				prefab = tilePrefab;
				break;
			case PrefabType.looseSoundSource:
				prefab = looseSoundSource;
				break;

			}


			GameObject result = MonoBehaviour.Instantiate (prefab, atPosition, Quaternion.identity) as GameObject;

			result.transform.RotateAround(atPosition, Vector3.up, rotationYdegrees);
			result.transform.localScale *= (1 + withScale);
			result.tag = withTag;

			return result;
		}

		public static List<GameObject> InitializeRandomSpheres(int numberOfSpheres=100, float length=100f, Vector3 center = default(Vector3))
		{
			List<GameObject> shperes = new List<GameObject> ();
			
			System.Random random = new System.Random();

			Vector3 position;
			for (int i = 0; i < numberOfSpheres; i++)
			{
				position = new Vector3(0.5f * ((float)random.NextDouble()  - 0.5f) , (float)random.NextDouble(), 0.5f * ((float)random.NextDouble()  - 0.5f));
				position *= length;
				position += center;

				//scale goes between [-0.27, 0.63) 
				float scale = 0.9f*((float)random.NextDouble() - 0.3f);
				
				GameObject sphereInstance = CreateFromPrefab(PrefabType.sphere, position, "Untagged", scale);
				shperes.Add(sphereInstance);
			}

			return shperes;
			
		}

		public static List<GameObject> InitializeRandomPrefabsInSphere(PrefabType type, Vector3 centerPoint = default(Vector3),
		                                                               int numberOfSpheres=100, 
		                                                               float thickness = 2f,
		                                                               float azimuthWidthDegrees = 20f,
		                                                               float elevationWidthDegrees = 80f
		                                                               )
		{
			List<GameObject> prefabCollection = new List<GameObject> ();

			//TODO: these random should be global?		
			System.Random random = new System.Random();

			Vector3 positionCartesian;
			VectorSpherical tempVector;

			for (int i = 0; i < numberOfSpheres; i++)
			{

				tempVector.r =  thickness*((float)random.NextDouble()  - 0.5f);
				tempVector.theta =  (float)Math.PI*elevationWidthDegrees*((float)random.NextDouble()  - 0.5f)/180f;
				tempVector.phi = (float)Math.PI*azimuthWidthDegrees*((float)random.NextDouble()  - 0.5f)/180f;

				positionCartesian = Utils.SphericalToCartesian(tempVector) + centerPoint;

				//scale goes between [-0.27, 0.63) 
				float scale = 0.9f*((float)random.NextDouble() - 0.3f);
				
				GameObject prefabInstance = CreateFromPrefab(type, positionCartesian, "Untagged", scale);

				prefabCollection.Add(prefabInstance);
			}

			return prefabCollection;

		}

	}
}

