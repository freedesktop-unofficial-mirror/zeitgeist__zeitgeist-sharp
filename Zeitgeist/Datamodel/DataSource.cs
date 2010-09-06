using System;
using org.freedesktop;
using org.freedesktop.DBus;
using System.Collections.Generic;

namespace Zeitgeist.Datamodel
{
	public class DataSource 
	{
		public string UniqueId
		{
			get;set;
		}
		
		public string Name
		{
			get;set;
		}
		
		public string Description
		{
			get;set;
		}
		
		public List<Event> Events
		{
			get;set;
		}
		
		public bool Running
		{
			get;set;
		}
		
		public long LastSeen
		{
			get;set;
		}
		
		public bool Enabled
		{
			get;set;
		}
		
		public static DataSource FromRaw(RawDataSource  raw)
		{
			DataSource src = new DataSource();
			
			src.UniqueId = raw.UniqueId;
			src.Name = raw.Name;
			src.Description = raw.Description;
			src.Running = raw.Running;
			src.LastSeen = long.Parse(raw.LastSeen.ToString());
			src.Enabled = raw.Enabled;
			
			if(raw.RawEvents != null)
			{
				src.Events = new List<Event>();
				foreach(RawEvent evn in raw.RawEvents)
				{
					Event ev = Event.FromRaw(evn);
					src.Events.Add(ev);
				}
			}
			
			return src;
		}
		
		public static RawDataSource ToRaw(DataSource  src)
		{
			RawDataSource raw = new RawDataSource();
			
			raw.UniqueId = src.UniqueId;
			raw.Name = src.Name;
			raw.Description = src.Description;
			raw.Running = src.Running;
			raw.LastSeen = UInt64.Parse(src.LastSeen.ToString());
			raw.Enabled = src.Enabled;
			
			if(raw.RawEvents != null)
			{
				List<RawEvent> events = new List<RawEvent>();
				foreach(Event evn in src.Events)
				{
					RawEvent ev = evn.GetRawEvent();
					events.Add(ev);
				}
			}
			
			return raw;
		}
	}
	
	public struct RawDataSource 
	{
		public string UniqueId;
		public string Name;
		public string Description;
		public RawEvent[] RawEvents;
		public bool Running;
		public UInt64 LastSeen;
		public bool Enabled;
		
		public RawDataSource(string uid, string name, string desc, RawEvent[] events, bool running, UInt64 Lastseen, bool enabled)
		{
			UniqueId = uid;
			Name = name;
			Description = desc;
			RawEvents = events;
			Running = running;
			LastSeen = Lastseen;
			Enabled = enabled;
		}
	}
}

