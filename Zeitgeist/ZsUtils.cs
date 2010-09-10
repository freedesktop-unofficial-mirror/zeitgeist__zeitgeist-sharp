using System;
using Zeitgeist.Datamodel;
using Zeitgeist.Client;
using System.Collections.Generic;
using NDesk.DBus;

namespace Zeitgeist
{
	internal class ZsUtils
	{
		#region Event <--> RawEvent Conversions
		
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
		
		#endregion
		
		#region DBus Path
		
		public static string DBusPath
		{
			get
			{
				return _dBusPath;
			}
		}
		
		private static string _dBusPath = "org.gnome.zeitgeist.Engine";
		
		#endregion
		
		public static T GetDBusObject<T>(string objectPath)
		{
			// Create the ObjectPath from the path provided
			ObjectPath objPath = new ObjectPath(objectPath);
			T interfaceInst = Bus.Session.GetObject<T>(ZsUtils.DBusPath, objPath);
			
			return interfaceInst;
		}
	}
	
	
}

