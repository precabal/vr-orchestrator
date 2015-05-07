using System;
using System.Collections.Generic;
using UnityEngine;

namespace AssemblyCSharp
{
	public interface IEvent
	{
		float EventTime{ get; set; }
		void PerformEvent(List<GameObject> objects);
	}
}

