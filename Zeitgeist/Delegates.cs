using System;
using Zeitgeist.Datamodel;

namespace Zeitgeist
{
	public delegate void DataSourceDisconnectedHandler(DataSource datasource);
		
	public delegate void DataSourceEnabledHandler(string dataSourceValue, bool enabled);
	
	public delegate void DataSourceRegisteredHandler(DataSource datasource);
}

