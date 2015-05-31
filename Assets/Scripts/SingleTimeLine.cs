using System;
using UnityEngine;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	public class SingleTimeLine
	{
		private List<IEvent> _events = new List<IEvent>();
		private List<GameObject> _objects;
		private int _currentEventIndex = 0;


		public List<GameObject> ObjectReferences
		{
			get { return _objects;}
		}

		public int NumberOfEvents
		{
			get { return _events.Count;}
		}

		public SingleTimeLine(List<GameObject> objects)
		{
			_objects = objects;
		}

		public float GetEventTime(int eventIndex)
		{
			if (eventIndex <= 0 || eventIndex >= _events.Count)
				throw new System.AccessViolationException("Event index out of range");

			return _events[eventIndex].EventTime;
		}

		public void AddEvent(IEvent e)
		{
			_events.Add(e);
			_events.Sort (IEventComparison);

		}
		private int IEventComparison(IEvent x, IEvent y)
		{
			return (int)(x.EventTime - y.EventTime);
				
		}
		

		public float GetNextEventTime()
		{
			if (_currentEventIndex >= _events.Count)
				//throw new System.AccessViolationException("There are no more events");
				return float.MaxValue;

			return _events[_currentEventIndex].EventTime;
		}

		public void PerformNextEvent()
		{
			if (_currentEventIndex >= _events.Count)
				throw new System.AccessViolationException("There are no more events");
			
			_events[_currentEventIndex++].Perform(ObjectReferences);
		}

	}
}

