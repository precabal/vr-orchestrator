using UnityEngine;

namespace AssemblyCSharp
{
	public class Cymbal_2 : Track
	{

		public Cymbal_2 ()
		{
			centerPosition = new Vector3 (14, 4, -32);
			audioPath = "Binaries/audioTracks/CYMBAL DLY_01";
			tag = "cymbal_2";

			AssignTrackParameters();
		}
		
	}
}
