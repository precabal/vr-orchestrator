using System;

namespace AssemblyCSharp
{
	public class pingpongBass_R : Track
	{
		
		public pingpongBass_R ()
		{
			float speakerHeight = 0.554f;
			float angle = -45f;
			
			VectorSpherical groundPosition = new VectorSpherical (3.5f, 0, (float)Math.PI*angle/180f);
			centerPosition = Utils.SphericalToCartesian (groundPosition);
			centerPosition.y += speakerHeight;
			
			audioPath = "Binaries/audioTracks/WURLY_PINGPONG_RR_02.R";
			tag = "pingpongBass_R";
			
			mainObjectPrefabType = PrefabType.speaker;
			
			hasAssociatedObjects = false;
			
			AssignTrackParameters();
			
			
			
		}
		
		
	}
}
