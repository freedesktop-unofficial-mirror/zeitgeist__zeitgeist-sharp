using System;
using org.freedesktop;
using org.freedesktop.DBus;

namespace Zeitgeist.Datamodel
{
	public struct DataSource 
	{
		public string UniqueId { get;set; }
		public string Name { get;set; }
		public string Description { get;set; }
		public RawEvent[] RawEvents { get;set; }
		public bool Running { get;set; }
		public UInt64 LastSeen { get;set; }
		public bool Enabled { get;set; }
		
		public DataSource ( string uid, string name, string desc, RawEvent[] events, bool running, UInt64 Lastseen, bool enabled)
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

