using UnityEngine;

namespace AssemblyCSharp
{
	public class Snare_3 : Track
	{
		
		public Snare_3 ()
		{
			
			centerPosition = new Vector3 (25, 50, -35);
			audioPath = "Binaries/audioTracks/SNARE1_VERB_02";
			tag = "snare_3";
			
			AssignTrackParameters();
			
			
		}
		
	}
}

