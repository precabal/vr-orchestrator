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

		public GameObject CreateFromPrefab(GameObject objectPrefab, Vector3 atPosition, String withTag, float withScale=0.0f)
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
		
	}
}

