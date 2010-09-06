using System;
using Zeitgeist.Datamodel;
using Zeitgeist;
using NDesk.DBus;

namespace Zeitgeist.Client
{
	[NDesk.DBus.Interface ("org.gnome.zeitgeist.Log")]
	public interface ILog
	{
		// Works
		RawEvent[] GetEvents(UInt32[] eventIds);
		
		
		UInt32[] FindEventIds(TimeRange range, RawEvent[] eventTemplates, UInt32 state, UInt32 maxEvents, UInt32 resType);
		
		UInt32[] FindEvents(TimeRange range, RawEvent[] eventTemplates, UInt32 state, UInt32 maxEvents, UInt32 resType);
		
		string[] FindRelatedUris(TimeRange range, RawEvent[] eventTemplates, RawEvent[] resultEventTemplates, UInt32 state, UInt32 maxEvents, UInt32 resType);
		
		// Works
		UInt32[] InsertEvents(RawEvent[] events);
		
		void InstallMonitor(ObjectPath monitorPath, TimeRange range, RawEvent[] eventTemplates);
		
		void RemoveMonitor(ObjectPath monitorPath);
		
		// Works
		TimeRange DeleteEvents(UInt32[] eventIds);
		
		// Didn't try but should work. Cant invoke. Will delete everything
		void DeleteLog();
		
		// Works
		void Quit();
	}
}

