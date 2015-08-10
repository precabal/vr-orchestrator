using UnityEngine;
using System;

namespace AssemblyCSharp
{
	public class LeadSynth_L : Track
	{

		public LeadSynth_L ()
		{

			centerPosition = Definitions.speakerPositionLeft;

			audioPath = "Binaries/audioTracks/swarmComponent.L";
			internalTag = "leadSynth_L";

			//associatedObjectsPrefabType = PrefabType.light;
			
			AssignTrackParameters();


			
			
		}
		
		
	}
}
