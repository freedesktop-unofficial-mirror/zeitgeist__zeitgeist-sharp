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
		
		/// <summary>
		/// Converts a List of Events to a List of RawEvent
		/// </summary>
		/// <param name="events">
		/// A List of Events <see cref="T:System.Collection.Generic.List{Event}"/>
		/// </param>
		/// <returns>
		/// A List of RawEvents <see cref="T:System.Collection.Generic.List{RawEvent}"/>
		/// </returns>
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
		
		/// <summary>
		/// Converts an Array of RawEvent to a List of Event
		/// </summary>
		/// <param name="rawEvents">
		/// An array of RawEvent <see cref="RawEvent[]"/>
		/// </param>
		/// <returns>
		/// A list of Event <see cref="T:System.Collection.Generic.List{Event}"/>
		/// </returns>
		public static List<Event> FromRawEventList(RawEvent[] rawEvents)
		{
			List<Event> events = new List<Event>();
			
			foreach(RawEvent rawEvent in rawEvents)
			{
				Event evnt = RawEvent.FromRaw(rawEvent);
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
		
		/// <summary>
		/// The actual DBus path for Zeitgeist Engine
		/// </summary>
		public static string DBusPath
		{
			get
			{
				return _dBusPath;
			}
		}
		
		private static string _dBusPath = "org.gnome.zeitgeist.Engine";
		
		#endregion
		
		#region Print Event, RawEvent
		
		public static void PrintEvent(Event e)
		{
			Console.WriteLine("ID: "+e.Id);
			Console.WriteLine("Interpretation: "+e.Interpretation.Name);
			Console.WriteLine("Manifestation: "+e.Manifestation.Name);
			Console.WriteLine("Timestamp: "+e.Timestamp.ToLongTimeString());
			Console.WriteLine("Actor: "+e.Actor);
			foreach(Subject sub in e.Subjects)
			{
				Console.WriteLine("URI: "+sub.Uri);
				Console.WriteLine("Interpretation: "+sub.Interpretation.Name);
				Console.WriteLine("Manifestation: "+sub.Manifestation.Name);
				Console.WriteLine("Mimetype: "+sub.MimeType);
				Console.WriteLine("Text: "+sub.Text);
			}
		}
		
		public static void PrintRawEvent(RawEvent e)
		{
			if(e.metadata == null)
				Console.WriteLine("RawEevent metadata in null");
			if(e.subjects == null)
				Console.WriteLine("RawEevent subjects in null");
			
			Console.WriteLine("ID: "+e.metadata[0]);
			Console.WriteLine("Interpretation: "+e.metadata[1]);
			Console.WriteLine("Manifestation: "+e.metadata[2]);
			Console.WriteLine("Timestamp: "+e.metadata[3]);
			Console.WriteLine("Actor: "+e.metadata[4]);
			foreach(string[] sub in e.subjects)
			{
				Console.WriteLine("URI: "+sub[0]);
				Console.WriteLine("Interpretation: "+sub[1]);
				Console.WriteLine("Manifestation: "+sub[2]);
				Console.WriteLine("Mimetype: "+sub[4]);
				Console.WriteLine("Text: "+sub[5]);
			}
		}
		
		#endregion
		
		/// <summary>
		/// Get an instance of DBus object for the provided objectPath
		/// </summary>
		/// <param name="objectPath">
		/// The object path of the DBus <see cref="System.String"/>
		/// </param>
		/// <returns>
		/// The Generic Interface Type representing the DBus interface for the object path <see cref="T"/>
		/// </returns>
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

