using System;
using Zeitgeist.Datamodel;

namespace Zeitgeist
{
	/// <summary>
	/// This signal is emitted whenever the last running instance of a data-source disconnects.
	/// </summary>
	/// <param name="datasource">
	/// The disconnected data-source of type <see cref="Zeitgeist.Datamodel.DataSource"/>
	/// </param>
	public delegate void DataSourceDisconnectedHandler(DataSource datasource);
		
	/// <summary>
	/// This signal is emitted whenever a data-source is enabled or disabled.
	/// </summary>
	/// <param name="dataSourceValue">
	/// Unique string identifier of a data-source<see cref="System.String"/>
	/// </param>
	/// <param name="dataSourceValue">
	/// true if it was enabled false if it was disabled. <see cref="System.Boolean"/>
	/// </param>
	public delegate void DataSourceEnabledHandler(string dataSourceValue, bool enabled);
	
	/// <summary>
	/// This signal is emitted whenever a data-source registers itself.
	/// </summary>
	/// <param name="datasource">
	/// The registered data-source of type <see cref="Zeitgeist.Datamodel.DataSource"/>
	/// </param>
	public delegate void DataSourceRegisteredHandler(DataSource datasource);
}

