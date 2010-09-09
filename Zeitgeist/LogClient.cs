using System;
using System.Collections.Generic;
using Zeitgeist.Datamodel;
using Zeitgeist.Client;
using NDesk.DBus;
using System.Linq;

namespace Zeitgeist
{
	public class LogClient
	{
		#region Fetch, Insert and Delete Events
		
		public static List<Event> GetEvents(List<uint> eventIds)
		{
			ILog srcInterface = GetDBusObject();
			
			RawEvent[] rawEvents = srcInterface.GetEvents(eventIds.ToArray());
			
			return ZsUtils.FromRawEventList(rawEvents);
		}
		
		public static List<uint> InsertEvents(List<Event> events)
		{
			ILog srcInterface = GetDBusObject();
			
			List<RawEvent> rawEvents = ZsUtils.ToRawEventList(events);
			
			UInt32[] eventIds = srcInterface.InsertEvents(rawEvents.ToArray());
			
			return new List<uint>(eventIds);
		}
		
		public static TimeRange DeleteEvents(List<uint> eventIds)
		{
			ILog srcInterface = GetDBusObject();
			
			return srcInterface.DeleteEvents(eventIds.ToArray());
		}
		
		#endregion
		
		#region Search
		
		public static List<uint> FindEventIds(TimeRange range, List<Event> eventTemplates, StorageState state, uint maxEvents, ResultType resType)
		{
			ILog srcInterface = GetDBusObject();
			
			RawEvent[] rawEventTemplates = ZsUtils.ToRawEventList(eventTemplates).ToArray();
			
			UInt32[] eventIds = srcInterface.FindEventIds(range, rawEventTemplates, (uint)state, maxEvents, (uint) resType);
			
			return new List<uint>(eventIds);
		}
		
		public static List<Event> FindEvents(TimeRange range, List<Event> eventTemplates, StorageState state, uint maxEvents, ResultType resType)
		{
			ILog srcInterface = GetDBusObject();
			
			RawEvent[] rawEventTemplates = ZsUtils.ToRawEventList(eventTemplates).ToArray();
			
			RawEvent[] events = srcInterface.FindEvents(range, rawEventTemplates, (uint)state, maxEvents, (uint) resType);
			
			return ZsUtils.FromRawEventList(events);
		}
		
		public static List<string> FindRelatedUris(TimeRange range, List<Event> eventTemplates, List<Event> resultEventTemplates, StorageState state, uint maxEvents, ResultType resType)
		{
			ILog srcInterface = GetDBusObject();
			
			RawEvent[] rawEvents = ZsUtils.ToRawEventList(eventTemplates).ToArray();
			RawEvent[] rawEventTemplates = ZsUtils.ToRawEventList(resultEventTemplates).ToArray();
			
			string[] uris = srcInterface.FindRelatedUris(range, rawEvents, rawEventTemplates, (uint)state, maxEvents, (uint) resType);
			
			return new List<string>(uris);
		}
		
		#endregion
		
		#region Monitors
		
		public static void InstallMonitor(string monitorPath, TimeRange range, List<Event> eventTemplates)
		{
			ObjectPath path = new ObjectPath(monitorPath);
			
			List<RawEvent> rawEvents = ZsUtils.ToRawEventList(eventTemplates);
			
			ILog srcInterface = GetDBusObject();
			srcInterface.InstallMonitor(path, range, rawEvents.ToArray());
		}
		
		public static void RemoveMonitor(string monitorPath)
		{
			ObjectPath path = new ObjectPath(monitorPath);
			
			ILog srcInterface = GetDBusObject();
			srcInterface.RemoveMonitor(path);
		}
		
		#endregion
		
		public static void DeleteLog()
		{
			ILog srcInterface = GetDBusObject();
			srcInterface.DeleteLog();
		}
		
		public static void Quit()
		{
			ILog srcInterface = GetDBusObject();
			srcInterface.Quit();
		}
		
		private static ILog GetDBusObject()
		{
			ObjectPath objPath = new ObjectPath("/org/gnome/zeitgeist/log/activity");
			ILog log = Bus.Session.GetObject<ILog>("org.gnome.zeitgeist.Engine", objPath);
			
			return log;
		}
	}
}

