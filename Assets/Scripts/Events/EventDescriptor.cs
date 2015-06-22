using System;

namespace AssemblyCSharp
{
	public enum EventKind { start, show, hide, move, addGravity, invalid };
	//public enum ObjectKind { sphere, cube, beacon};

	public struct EventDescriptor
	{
		public float eventTime;
		//public ObjectKind objectKind;
		//TODO: describir la accion con una clase q implementa de interfaz comun
		public EventKind eventKind;
		public EventDescriptor(float eventTime, EventKind eventKind)
		{
			this.eventTime = eventTime;
			this.eventKind = eventKind;
		}

	}

}

