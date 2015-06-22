using System;
using System.Collections.Generic;
using UnityEngine;

namespace AssemblyCSharp
{
	public class Snare_1 : Track
	{
		
		public Snare_1 ()
		{
			
			centerPosition = new Vector3 (35, 50, 35);
			audioPath = "Binaries/audioTracks/SNARE_1_RR_02";
			tag = "snare_1";
			
			AssignTrackParameters();
			
			
		}
		
	}
}

