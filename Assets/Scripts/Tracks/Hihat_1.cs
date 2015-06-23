using UnityEngine;

namespace AssemblyCSharp
{
	public class Hihat_1 : Track
	{

		public Hihat_1 ()
		{

			centerPosition = new Vector3 (15, 50, 15);
			audioPath = "Binaries/audioTracks/HI_HAT_CL_RR_02";
			tag = "hihat_1";
			
			AssignTrackParameters();


		}

	}
}

