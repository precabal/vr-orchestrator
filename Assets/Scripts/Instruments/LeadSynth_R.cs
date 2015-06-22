using System;
using System.Collections.Generic;
using UnityEngine;

namespace AssemblyCSharp
{
	public class LeadSynth_R : Track
	{
		public LeadSynth_R ()
		{

			centerPosition = new Vector3 (10, 5, -5);

			audioPath = "Binaries/audioTracks/16b - REPTILIANREGIONS_TRACKnoBASS.R";
			tag = "leadSynth_R";
			
			AssignTrackParameters();



		}
		
		
	}
}
