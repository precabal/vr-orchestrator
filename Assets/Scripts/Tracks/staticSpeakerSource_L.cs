using System;

namespace AssemblyCSharp
{
	public class StaticSpeakerSource_L : Track
	{
		
		public StaticSpeakerSource_L ()
		{

			centerPosition = Definitions.speakerPositionLeft;

			audioPath = "Binaries/audioTracks/newBase.L";
			internalTag = "staticSpeakerSource_L";

			mainObjectPrefabType = PrefabType.speaker;

			hasAssociatedObjects = false;

			AssignTrackParameters();
			

			
		}
		
		
	}
}

