using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public class TrackForPrefab : MonoBehaviour
	{
		//deprecated TODO: remove and fix for manual tracks
		protected GameObject soundSource;
		protected AudioClip audioClip;
		protected string audioPath;


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

		public GameObject SoundSource
		{
			get { return soundSource; }
			set { soundSource = value; }
		}

		public Vector3 CenterPosition
		{
			get { return centerPosition; }
			set { centerPosition = value; }
		}
		//TODO: this never gets called because the inheritance from MonoBehaviour. Put in Start() if necessar (so remove from orchestra). 
		//STart function should also handle prefab selection/creation
		public TrackForPrefab ()
		{
			centerPosition = new Vector3 (0, -10, 0);
			hasAssociatedObjects = true;
			mainObjectPrefabType = PrefabType.soundSource;
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
			soundSource = ObjectFactory.CreateFromPrefab(mainObjectPrefabType, centerPosition, internalTag);
			soundSource.name = char.ToUpper(internalTag[0]) + internalTag.Substring(1);

			audioClip = Resources.Load(audioPath) as AudioClip;
			soundSource.transform.Find ("OSPAudioSource").gameObject.GetComponent<AudioSource> ().clip = audioClip;

		}


	}
	//TODO create custom editor to display associated objects option only if checkbox is selected	
	
}


