using UnityEngine;
using System;

namespace AssemblyCSharp
{
	public class LeadSynth_R : Track
	{
		public LeadSynth_R ()
		{

			centerPosition = Definitions.speakerPositionRight;
			
			audioPath = "Binaries/audioTracks/swarmComponent.R";
			internalTag = "leadSynth_R";

			//associatedObjectsPrefabType = PrefabType.light;
			widthOfAssociatedObjects = 0.025f;

			AssignTrackParameters();

		}
		
		
	}
}
