using System;
using System.Collections.Generic;
using Zeitgeist.Datamodel;
using Zeitgeist.Client;
using NDesk.DBus;

namespace Zeitgeist
{
	public class BlacklistClient
	{
		public static List<Event> GetBlacklist()
		{
			IBlacklist srcInterface = GetDBusObject();
			RawEvent[] rawBlackLists = srcInterface.GetBlacklist();
			
			List<Event> events = new List<Event>();
			
			foreach(RawEvent rawEvent in rawBlackLists)
			{
				Event evnt = Event.FromRaw(rawEvent);
				events.Add(evnt);
			}
			
			return events;
		}
		
		public static void SetBlacklist(List<Event> eventTemplates)
		{
			List<RawEvent> events = new List<RawEvent>();
			
			foreach(Event eventInst in eventTemplates)
			{
				RawEvent rawEvnt = eventInst.GetRawEvent();
				events.Add(rawEvnt);
			}
			
			IBlacklist srcInterface = GetDBusObject();
			srcInterface.SetBlacklist(events.ToArray());
		}
		
		private static IBlacklist GetDBusObject()
		{
			ObjectPath objPath = new ObjectPath("/org/gnome/zeitgeist/blacklist");
			IBlacklist log = Bus.Session.GetObject<IBlacklist>("org.gnome.zeitgeist.Engine", objPath);
			
			return log;
		}
	}
}

