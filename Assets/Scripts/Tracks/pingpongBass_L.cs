using System;

namespace AssemblyCSharp
{
	public class pingpongBass_L : Track
	{
		
		public pingpongBass_L ()
		{
			float speakerHeight = 0.554f;
			float angle = 45f;

			VectorSpherical groundPosition = new VectorSpherical (3.5f, 0, (float)Math.PI*angle/180f);
			centerPosition = Utils.SphericalToCartesian (groundPosition);
			centerPosition.y += speakerHeight;

			audioPath = "Binaries/audioTracks/WURLY_PINGPONG_RR_02.L";
			tag = "pingpongBass_L";

			mainObjectPrefabType = PrefabType.speaker;

			hasAssociatedObjects = false;

			AssignTrackParameters();
			

			
		}
		
		
	}
}

