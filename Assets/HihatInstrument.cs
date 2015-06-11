using System;
using System.Collections.Generic;
using UnityEngine;

namespace AssemblyCSharp
{
	public class HihatInstrument : IInstrument
	{
		private List<GameObject> _objects;

		private Vector3 _centerPosition;
		public List<GameObject> Objects
		{
			get { return _objects; }
			set { _objects = value; }
		}
		public HihatInstrument ()
		{
			_objects = new List<GameObject> ();

			_centerPosition = new Vector3 (3, 5, -2);

			//surrounding shperes - estela
			_objects.AddRange(ObjectFactory.InitializeRandomSpheres (100, 100, _centerPosition));
			_objects.ForEach (o => o.tag = "hihat1_estela");

			//main object
			AudioClip hihat1 = Resources.Load("Binaries/audioTracks/HI_HAT_CL_RR_02") as AudioClip;
			GameObject hihat1Obj = ObjectFactory.CreateFromPrefab(Resources.Load("soundSource_prefab") as GameObject, _centerPosition, "hihat1");			
			hihat1Obj.transform.Find ("OSPAudioSource").gameObject.GetComponent<AudioSource> ().clip = hihat1;
			_objects.Add (hihat1Obj);



		}

	}
}

