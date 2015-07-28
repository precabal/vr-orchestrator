using System;

namespace AssemblyCSharp
{
	public class StaticSpeakerSource_L : Track
	{
		
		public StaticSpeakerSource_L ()
		{
			float speakerHeight = 0.554f;
			float angle = 45f;

			VectorSpherical groundPosition = new VectorSpherical (3.5f, 0, (float)Math.PI*angle/180f);
			centerPosition = Utils.SphericalToCartesian (groundPosition);
			centerPosition.y += speakerHeight;

			audioPath = "Binaries/audioTracks/allButSwarm.L";
			tag = "staticSpeakerSource_L";

			mainObjectPrefabType = PrefabType.speaker;

			hasAssociatedObjects = false;

			AssignTrackParameters();
			

			
		}
		
		
	}
}

