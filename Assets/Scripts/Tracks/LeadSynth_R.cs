using UnityEngine;
using System;

namespace AssemblyCSharp
{
	public class LeadSynth_R : Track
	{
		public LeadSynth_R ()
		{

			float speakerHeight = 0.3353f;
			float angle = -45f;
			
			VectorSpherical groundPosition = new VectorSpherical (3.5f, 0, (float)Math.PI*angle/180f);
			centerPosition = Utils.SphericalToCartesian (groundPosition);
			centerPosition.y += speakerHeight;
			
			audioPath = "Binaries/audioTracks/swarmComponent.R";
			tag = "leadSynth_R";

			//associatedObjectsPrefabType = PrefabType.light;
			widthOfAssociatedObjects = 0.025f;

			AssignTrackParameters();

		}
		
		
	}
}
