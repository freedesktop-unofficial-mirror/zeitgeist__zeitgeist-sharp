using System;
using org.freedesktop;
using org.freedesktop.DBus;

namespace Zeitgeist.ZeitgeistSharp.Datamodel
{
	public class DataSource : MarshalByRefObject
	{
		public string UniqueId { get;set; }
		public string Name { get;set; }
		public string Description { get;set; }
		public Event[] Events { get;set; }
		public bool Running { get;set; }
		public UInt64 LastSeen { get;set; }
		public bool Enabled { get;set; }
	}
	
	[NDesk.DBus.Interface ("org.gnome.zeitgeist.DataSourceRegistry")]
	public class DataSources : MarshalByRefObject
	{
		public DataSource[] Sources { get;set; }
	}
}

