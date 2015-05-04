using System;
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

		public GameObject CreateSphereFromPrefab(GameObject spherePrefab)
		{
			GameObject sphere = MonoBehaviour.Instantiate(spherePrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
			return sphere;

		}
	}
}

