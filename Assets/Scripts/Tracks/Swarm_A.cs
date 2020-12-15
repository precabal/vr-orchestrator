using UnityEngine;
using System;

namespace AssemblyCSharp
{
	public class Swarm_A : NonTrack
	{

		public Swarm_A ()
		{

			centerPosition = Definitions.speakerPositionLeft;

			internalTag = "swarm_A";

			//associatedObjectsPrefabType = PrefabType.light;
			numberOfSurroundingObjects = 5;
			AssignTrackParameters();




		}


	}
}
