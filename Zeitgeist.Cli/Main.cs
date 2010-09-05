using System;
using NDesk.DBus;
using Zeitgeist.Datamodel;
using Zeitgeist.Client;

namespace Zeitgeist.ZeitgeistSharp.Cli
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			BusG.Init();
			
			NDesk.DBus.ObjectPath objPath = new NDesk.DBus.ObjectPath("/org/gnome/zeitgeist/blacklist");
			IBlacklist zeitgeist = Bus.Session.GetObject<IBlacklist>("org.gnome.zeitgeist.Engine", objPath);
			RawEvent[] sources = zeitgeist.GetBlacklist();
			
			RawEvent evnt = sources[0];
			Event ev = Event.FromRaw(evnt);
			RawEvent rw = ev.GetRawEvent();
		}
	}
}

