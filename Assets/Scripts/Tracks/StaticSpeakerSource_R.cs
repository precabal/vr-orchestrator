using System;

namespace AssemblyCSharp
{
	public class StaticSpeakerSource_R : Track
	{
		
		public StaticSpeakerSource_R ()
		{
			float speakerHeight = 0.554f;
			float angle = -45f;
			
			VectorSpherical groundPosition = new VectorSpherical (3.5f, 0, (float)Math.PI*angle/180f);
			centerPosition = Utils.SphericalToCartesian (groundPosition);
			centerPosition.y += speakerHeight;
			
			audioPath = "Binaries/audioTracks/allButSwarm.R";
			tag = "staticSpeakerSource_R";
			
			mainObjectPrefabType = PrefabType.speaker;
			
			hasAssociatedObjects = false;
			
			AssignTrackParameters();
			
			
			
		}
		
		
	}
}
