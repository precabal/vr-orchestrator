using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public class Track
	{
		protected GameObject soundSource;
		protected Vector3 centerPosition;
		protected AudioClip audioClip;
		protected string audioPath;
		protected string tag;
		protected float widthOfAssociatedObjects;

		public PrefabType associatedObjectsPrefabType;
		public PrefabType mainObjectPrefabType;

		public float WidthOfAssociatedObjects {
			get { return widthOfAssociatedObjects; }
		}

		public bool hasAssociatedObjects;

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
		public Track ()
		{
			centerPosition = new Vector3 (0, -10, 0);
			hasAssociatedObjects = true;
			mainObjectPrefabType = PrefabType.soundSource;
			associatedObjectsPrefabType = PrefabType.sphere;
			widthOfAssociatedObjects = 2;
		}

		public string GetTag ()
		{
			return tag;
		}

		public Transform GetTransform ()
		{
			return soundSource.transform;
		}

		protected void AssignTrackParameters()
		{
			soundSource = ObjectFactory.CreateFromPrefab(mainObjectPrefabType, centerPosition, tag);
			soundSource.name = char.ToUpper(tag[0]) + tag.Substring(1);

			audioClip = Resources.Load(audioPath) as AudioClip;
			soundSource.transform.Find ("OSPAudioSource").gameObject.GetComponent<AudioSource> ().clip = audioClip;

		}

	}
	
}


