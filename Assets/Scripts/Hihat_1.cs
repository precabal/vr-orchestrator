using System;
using System.Collections.Generic;
using UnityEngine;

namespace AssemblyCSharp
{
	public class Hihat_1 : IInstrument
	{
		private List<GameObject> _objects;

		private Vector3 _centerPosition;
		public List<GameObject> Objects
		{
			get { return _objects; }
			set { _objects = value; }
		}
		public Hihat_1 ()
		{
			GameObject container = new GameObject ("Hihat_1");
			GameObject flareContainer = new GameObject ("Flare");
			flareContainer.transform.parent = container.transform;

			_objects = new List<GameObject> ();

			_centerPosition = new Vector3 (15, 50, 15);

			//surrounding objects:
			_objects.AddRange( ObjectFactory.InitializeRandomSpheresInSphere(_centerPosition) );
			foreach (GameObject obj in _objects) 
			{
				obj.tag = "hihat_1_group";
				obj.transform.parent = flareContainer.transform;
			}

			//main object:
			AudioClip audioClip = Resources.Load("Binaries/audioTracks/HI_HAT_CL_RR_02") as AudioClip;
			GameObject mainObject = ObjectFactory.CreateFromPrefab(Resources.Load("soundSource_prefab") as GameObject, _centerPosition, "hihat_1");
			mainObject.name = "Source";
			mainObject.transform.Find ("OSPAudioSource").gameObject.GetComponent<AudioSource> ().clip = audioClip;
			_objects.Add (mainObject);
			mainObject.transform.parent = container.transform;

		}


	}
}

