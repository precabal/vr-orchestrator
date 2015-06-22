using System;
using System.Collections.Generic;
using UnityEngine;

namespace AssemblyCSharp
{
	public class Hihat_2 : Track
	{

		public Hihat_2 ()
		{

			centerPosition = new Vector3 (-15, 30, 15);
			audioPath = "Binaries/audioTracks/HI_HAT_OPEN_RR_02";
			tag = "hihat_2";
			prefabType = PrefabType.light;

			AssignTrackParameters();


		}
		
	}
}

