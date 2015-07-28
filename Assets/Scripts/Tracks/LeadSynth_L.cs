using UnityEngine;
using System;

namespace AssemblyCSharp
{
	public class LeadSynth_L : Track
	{

		public LeadSynth_L ()
		{

			float speakerHeight = 0.3353f;
			float angle = 45f;
			
			VectorSpherical groundPosition = new VectorSpherical (3.5f, 0, (float)Math.PI*angle/180f);
			centerPosition = Utils.SphericalToCartesian (groundPosition);
			centerPosition.y += speakerHeight;

			audioPath = "Binaries/audioTracks/swarmComponent.L";
			tag = "leadSynth_L";

			//associatedObjectsPrefabType = PrefabType.light;
			
			AssignTrackParameters();


			
			
		}
		
		
	}
}
