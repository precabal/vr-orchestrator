using UnityEngine;

namespace AssemblyCSharp
{
	public class LeadSynth_L : Track
	{

		public LeadSynth_L ()
		{

			centerPosition = new Vector3 (10, 5, 5);
			

			//_objects.AddRange( ObjectFactory.InitializeRandomPrefabsInSphere(ObjectFactory.sphere, _centerPosition, 8, 1.0f, 5.0f, 5.0f) );
			
			audioPath = "Binaries/audioTracks/16b - REPTILIANREGIONS_TRACKnoBASS.L";
			tag = "leadSynth_L";
			
			AssignTrackParameters();


			
			
		}
		
		
	}
}
