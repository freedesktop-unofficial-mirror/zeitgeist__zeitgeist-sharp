using System;
using Zeitgeist.Datamodel;
using Zeitgeist;

namespace Zeitgeist.Client
{
	/// <summary>
	/// The Zeitgeist engine maintains a publicly available list of recognized data-sources 
	/// (components inserting information into Zeitgeist). An option to disable such data-providers is also provided.
	/// </summary>
	[NDesk.DBus.Interface ("org.gnome.zeitgeist.DataSourceRegistry")]
	public interface IDataSource
	{
		/// <summary>
		/// Get the list of known data-sources.
		/// </summary>
		/// <returns>
		/// A list of RawDataSource <see cref="RawDataSource[]"/>
		/// </returns>
		RawDataSource[] GetDataSources();
		
		/// <summary>
		/// Register a data-source as currently running. 
		/// If the data-source was already in the database, its metadata (name, description and event_templates) are updated.
		/// </summary>
		/// <param name="unique_id">
		/// The uniqueId DataSource <see cref="System.String"/>
		/// </param>
		/// <param name="name">
		/// The name of the DataSource <see cref="System.String"/>
		/// </param>
		/// <param name="description">
		/// Description of DataSource <see cref="System.String"/>
		/// </param>
		/// <param name="events">
		/// A list of RawEvent templates <see cref="RawEvent[]"/>
		/// </param>
		/// <returns>
		/// true is successful, false otherwise <see cref="System.Boolean"/>
		/// </returns>
		bool RegisterDataSources(string unique_id, string name, string description, RawEvent[] events);
		
		/// <summary>
		/// Enables/Disables the DataSource identified by a uniqueId
		/// </summary>
		/// <param name="unique_id">
		/// The uniqueId of the DataSource <see cref="System.String"/>
		/// </param>
		/// <param name="enabled">
		/// Is the DataSource to be enabled(true) or disabled(false)  <see cref="System.Boolean"/>
		/// </param>
		void SetDataSourceEnabled(string unique_id, bool enabled);
		
		/// <summary>
		/// This signal is emitted whenever the last running instance of a data-source disconnects.
		/// </summary>
		event DataSourceDisconnectedHandler DataSourceDisconnected;
		
		/// <summary>
		/// This signal is emitted whenever a data-source is enabled or disabled.
		/// </summary>
		event DataSourceEnabledHandler DataSourceEnabled;
		
		/// <summary>
		/// This signal is emitted whenever a data-source registers itself.
		/// </summary>
		event DataSourceRegisteredHandler DataSourceRegistered;
	}
}

