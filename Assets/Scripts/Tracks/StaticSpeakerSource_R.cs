using System;

namespace AssemblyCSharp
{
	public class StaticSpeakerSource_R : Track
	{
		
		public StaticSpeakerSource_R ()
		{

			centerPosition = Definitions.speakerPositionRight;
			
			audioPath = "Binaries/audioTracks/newBase.R";
			internalTag = "staticSpeakerSource_R";
			
			mainObjectPrefabType = PrefabType.speaker;
			
			hasAssociatedObjects = false;
			
			AssignTrackParameters();
			
			
			
		}
		
		
	}
}
