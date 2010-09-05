using System;
using NDesk.DBus;
using org.freedesktop;
using org.freedesktop.DBus;
using Zeitgeist.ZeitgeistSharp.Datamodel;

namespace Zeitgeist.ZeitgeistSharp.DBusInterface
{
	[NDesk.DBus.Interface ("org.gnome.zeitgeist.DataSourceRegistry")]
	public interface DataSourceRegistry
	{
		DataSource[] GetDataSources();
		bool RegisterDataSources(string unique_id, string name, string description, Event[] events);
		void SetDataSourceEnabled(string unique_id, bool enabled);
		event DataSourceDisconnectedHandler DataSourceDisconnected;
		event DataSourceEnabledHandler DataSourceEnabled;
		event DataSourceRegisteredHandler DataSourceRegistered;
	}
}

