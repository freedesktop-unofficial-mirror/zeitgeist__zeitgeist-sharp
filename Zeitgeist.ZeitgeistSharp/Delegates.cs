using System;
using Zeitgeist.ZeitgeistSharp.Datamodel;

namespace Zeitgeist.ZeitgeistSharp
{
	public delegate void DataSourceDisconnectedHandler(DataSource datasource);
		
	public delegate void DataSourceEnabledHandler(string dataSourceValue, bool enabled);
	
	public delegate void DataSourceRegisteredHandler(DataSource datasource);
}

