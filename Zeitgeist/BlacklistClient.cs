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
			
			return ZsUtils.FromRawEventList(rawBlackLists);
		}
		
		public static void SetBlacklist(List<Event> eventTemplates)
		{
			List<RawEvent> events = ZsUtils.ToRawEventList(eventTemplates);
			
			IBlacklist srcInterface = GetDBusObject();
			srcInterface.SetBlacklist(events.ToArray());
		}
		
		private static IBlacklist GetDBusObject()
		{
			ObjectPath objPath = new ObjectPath("/org/gnome/zeitgeist/blacklist");
			IBlacklist blacklist = Bus.Session.GetObject<IBlacklist>("org.gnome.zeitgeist.Engine", objPath);
			
			return blacklist;
		}
	}
}

