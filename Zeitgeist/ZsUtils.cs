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
		
		#region DateTime <--> UNIX Timestamp conversion
		
		/// <summary>
		/// Create an instance of System.DateTime from unsigned 64-bit integer representing UNIX Timestamp
		/// </summary>
		/// <param name="timestamp">
		/// The UNIX Timestamp as Unsigned 64-bit integer  <see cref="UInt64"/>
		/// </param>
		/// <returns>
		/// The instance of  <see cref="DateTime"/>
		/// </returns>
		public static DateTime ToDateTime(UInt64 timestamp)
		{
			DateTime time = Epoch.AddMilliseconds(timestamp);
			
			return time;
		}
		
		/// <summary>
		/// Create UNIX Timestamp from System.DateTime
		/// </summary>
		/// <param name="time">
		/// The instance of <see cref="DateTime"/>
		/// </param>
		/// <returns>
		/// The UNIX Timestamp as a unsigned 64-bit integer. Type: <see cref="UInt64"/>
		/// </returns>
		public static UInt64 ToTimestamp(DateTime time)
		{
			TimeSpan now = time - Epoch;
			
			// Ticks is 100 nanoseconds. i.e. 1/10000 of a millisec
			UInt64 timestamp = (UInt64)(now.Ticks / 10000);
			
			return timestamp;
		}
		
		/// <summary>
		/// The DateTime of UNIX Epoch
		/// </summary>
		/// <remarks>
		/// UNIX Epoch is January 01, 1970 00:00:00 UTC
		/// </remarks>
		public static DateTime Epoch
		{
			get
			{
				return _epoch;
			}
		}
		
		private static DateTime _epoch = new DateTime(1970, 1,1, 0,0,0, DateTimeKind.Utc);
		
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
			BusG.Init();
			
			// Create the ObjectPath from the path provided
			ObjectPath objPath = new ObjectPath(objectPath);
			T interfaceInst = Bus.Session.GetObject<T>(ZsUtils.DBusPath, objPath);
			
			return interfaceInst;
		}
	}
	
	
}

