using System;
using Zeitgeist.Datamodel;
using Zeitgeist.Client;
using System.Collections.Generic;

namespace Zeitgeist
{
	internal class ZsUtils
	{
		public static List<RawEvent> ToRawEventList(List<Event> events)
		{
			List<RawEvent> rawEvents = new List<RawEvent>();
			
			foreach(Event eventInst in events)
			{
				RawEvent rawEvnt = eventInst.GetRawEvent();
				rawEvents.Add(rawEvnt);
			}
			
			return rawEvents;
		}
		
		public static List<Event> FromRawEventList(RawEvent[] rawEvents)
		{
			List<Event> events = new List<Event>();
			
			foreach(RawEvent rawEvent in rawEvents)
			{
				Event evnt = Event.FromRaw(rawEvent);
				events.Add(evnt);
			}
			
			return events;
		}
	}
}

