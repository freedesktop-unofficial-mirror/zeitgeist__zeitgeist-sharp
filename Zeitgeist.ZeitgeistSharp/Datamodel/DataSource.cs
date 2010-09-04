using System;
using org.freedesktop;
using org.freedesktop.DBus;
using Zeitgeist.ZeitgeistSharp;

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
	public interface DataSources
	{
		DataSource[] GetDataSources();
		bool RegisterDataSources(string unique_id, string name, string description, Event[] events);
		void SetDataSourceEnabled(string unique_id, bool enabled);
		
		event DataSourceDisconnectedHandler DataSourceDisconnected;
		
		event DataSourceEnabledHandler DataSourceEnabled;
		
		event DataSourceRegisteredHandler DataSourceRegistered;
	}
}

