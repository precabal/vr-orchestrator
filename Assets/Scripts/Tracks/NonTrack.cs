using System;
using UnityEngine;


namespace AssemblyCSharp
{
	public class NonTrack
	{
		//deprecated TODO: remove and fix for manual tracks


		protected Vector3 centerPosition;
		protected GameObject source;

		// TODO: this is redundant. Remove
		protected string internalTag;
		protected float widthOfAssociatedObjects;


		public PrefabType mainObjectPrefabType;
		public bool hasAssociatedObjects;
		public PrefabType associatedObjectsPrefabType;


		public float WidthOfAssociatedObjects {
			get { return widthOfAssociatedObjects; }
		}

		public GameObject Source
		{
			get { return source; }
			set { source = value; }
		}

		public int numberOfSurroundingObjects;

		public Vector3 CenterPosition
		{
			get { return centerPosition; }
			set { centerPosition = value; }
		}
		public NonTrack ()
		{
			centerPosition = new Vector3 (0, -10, 0);
			hasAssociatedObjects = true;
			mainObjectPrefabType = PrefabType.sphere;
			associatedObjectsPrefabType = PrefabType.sphere;
			widthOfAssociatedObjects = 20;

			//internalTag = this.transform.tag;
		}

		public string GetTag ()
		{
			return this.internalTag;

		}

		public Transform GetTransform ()
		{
			return source.transform;
		}

		protected void AssignTrackParameters()
		{
			source = ObjectFactory.CreateFromPrefab(mainObjectPrefabType, centerPosition, internalTag);
			source.name = char.ToUpper(internalTag[0]) + internalTag.Substring(1);
		}


	}
	//TODO create custom editor to display associated objects option only if checkbox is selected	

}

