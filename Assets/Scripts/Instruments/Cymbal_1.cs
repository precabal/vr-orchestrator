using System;
using System.Collections.Generic;
using UnityEngine;

namespace AssemblyCSharp
{
	public class Cymbal_1 : Track
	{

		public Cymbal_1 ()
		{
			centerPosition = new Vector3 (-30, 4, 12);
			audioPath = "Binaries/audioTracks/CYMBALS_03";
			tag = "cymbal_1";


			AssignTrackParameters();

		}
		
	}
}
