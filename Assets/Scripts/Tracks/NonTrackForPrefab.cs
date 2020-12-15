using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public class NonTrackForPrefab : MonoBehaviour
	{

		protected Vector3 centerPosition;

		// TODO: this is redundant. Remove
		protected string internalTag;
		protected float widthOfAssociatedObjects;


		public PrefabType mainObjectPrefabType;
		public bool hasAssociatedObjects;
		public PrefabType associatedObjectsPrefabType;


		public float WidthOfAssociatedObjects {
			get { return widthOfAssociatedObjects; }
		}



		public int numberOfSurroundingObjects;


		public Vector3 CenterPosition
		{
			get { return centerPosition; }
			set { centerPosition = value; }
		}
		//TODO: this never gets called because the inheritance from MonoBehaviour. Put in Start() if necessar (so remove from orchestra). 
		//STart function should also handle prefab selection/creation
		public NonTrackForPrefab ()
		{
			centerPosition = new Vector3 (0, -10, 0);
			hasAssociatedObjects = true;
			mainObjectPrefabType = PrefabType.sphere;
			associatedObjectsPrefabType = PrefabType.sphere;
			widthOfAssociatedObjects = 2;

			//internalTag = this.transform.tag;
		}

		public string GetTag ()
		{
			return this.transform.tag;

		}

		public Transform GetTransform ()
		{
			return this.transform;
		}

		protected void AssignTrackParameters()
		{
		}


	}
}


