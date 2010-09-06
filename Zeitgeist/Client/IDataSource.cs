using System;
using Zeitgeist.Datamodel;
using Zeitgeist;

namespace Zeitgeist.Client
{
	[NDesk.DBus.Interface ("org.gnome.zeitgeist.DataSourceRegistry")]
	public interface IDataSource
	{
		RawDataSource[] GetDataSources();
			
		bool RegisterDataSources(string unique_id, string name, string description, RawEvent[] events);
		
		void SetDataSourceEnabled(string unique_id, bool enabled);
		
		event DataSourceDisconnectedHandler DataSourceDisconnected;
		event DataSourceEnabledHandler DataSourceEnabled;
		event DataSourceRegisteredHandler DataSourceRegistered;
	}
}

