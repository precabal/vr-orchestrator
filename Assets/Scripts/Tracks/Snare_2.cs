using UnityEngine;

namespace AssemblyCSharp
{
	public class Snare_2 : Track
	{
		
		public Snare_2 ()
		{
			
			centerPosition = new Vector3 (-35, 50, -35);
			audioPath = "Binaries/audioTracks/SNARE_2_RR_02";
			internalTag = "snare_2";
			
			AssignTrackParameters();
			
			
		}
		
	}
}

