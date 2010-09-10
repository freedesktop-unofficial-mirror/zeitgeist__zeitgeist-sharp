using System;
using System.Collections.Generic;
using Zeitgeist.Client;
using NDesk.DBus;
using Zeitgeist.Datamodel;

namespace Zeitgeist
{
	/// <summary>
	/// The Zeitgeist engine maintains a publicly available list of recognized data-sources 
	/// (components inserting information into Zeitgeist). An option to disable such data-providers is also provided.
	/// </summary>
	public class DataSourceClient
	{
		/// <summary>
		/// The constructor for DataSourceClient
		/// </summary>
		/// <remarks>
		/// This constructor gets the DBus object for DataSource which the object's methods use.
	    /// Additionally it chains the events from IDataSource to DataSourceClient
		/// </remarks>
		public DataSourceClient()
		{
			srcInterface = ZsUtils.GetDBusObject<IDataSource>(objectPath);
			
			// Data Source Registered
			srcInterface.DataSourceRegistered += delegate(DataSource datasource) {
				if(this.DataSourceRegistered != null)
				{
					this.DataSourceRegistered(datasource);
				}
			};
			
			// Data Source Enabled
			srcInterface.DataSourceEnabled += delegate(string dataSourceValue, bool enabled) {
				if(this.DataSourceEnabled != null)
				{
					this.DataSourceEnabled(dataSourceValue, enabled);
				}
			};
			
			// Data Source Disconnected
			srcInterface.DataSourceDisconnected += delegate(DataSource datasource) {
				if(this.DataSourceDisconnected != null)
				{
					this.DataSourceDisconnected(datasource);
				}
			}; 
			
		}

		
		/// <summary>
		/// Get the list of known data-sources.
		/// </summary>
		/// <returns>
		/// A list of DataSource of type <see cref="T:System.Collection.Generic.List{Zeitgeist.Datamodel.Event}"/>
		/// </returns>
		public List<DataSource> GetDataSources()
		{
			RawDataSource[] srcs = srcInterface.GetDataSources();
			
			List<DataSource> srcList = new List<DataSource>();
			
			foreach(RawDataSource src in srcs)
			{
				DataSource et = DataSource.FromRaw(src);
				srcList.Add(et);
			}
			
			return srcList;
		}
		
		/// <summary>
		/// Register a data-source as currently running. 
		/// If the data-source was already in the database, its metadata (name, description and event_templates) are updated.
		/// </summary>
		/// <param name="uniqueId">
		/// The uniqueId DataSource of type <see cref="System.String"/>
		/// </param>
		/// <param name="name">
		/// The name of the DataSource of type <see cref="System.String"/>
		/// </param>
		/// <param name="description">
		/// Description of DataSource of type <see cref="System.String"/>
		/// </param>
		/// <param name="events">
		/// A list of Event templates of type <see cref="T:System.Collection.Generic.List{Zeitgeist.Datamodel.Event}"/>
		/// </param>
		/// <returns>
		/// true is successful, false otherwise <see cref="System.Boolean"/>
		/// </returns>
		public bool RegisterDataSources(string uniqueId, string name, string description, List<Event> events)
		{
			List<RawEvent> rawEventList = new List<RawEvent>();
			foreach(Event src in events)
			{
				RawEvent evnt = src.GetRawEvent();
				rawEventList.Add(evnt);
			}
			
			return srcInterface.RegisterDataSources(uniqueId, name, description, rawEventList.ToArray());
		}
		
		/// <summary>
		/// Enables/Disables the DataSource identified by a uniqueId
		/// </summary>
		/// <param name="uniqueId">
		/// The uniqueId of the DataSource of type <see cref="System.String"/>
		/// </param>
		/// <param name="enabled">
		/// Is the DataSource to be enabled(true) or disabled(false) <see cref="System.Boolean"/>
		/// </param>
		void SetDataSourceEnabled(string uniqueId, bool enabled)
		{
			srcInterface.SetDataSourceEnabled(uniqueId, enabled);
		}
		
		/// <summary>
		/// This signal is emitted whenever the last running instance of a data-source disconnects.
		/// </summary>
		public event DataSourceDisconnectedHandler DataSourceDisconnected;
		
		/// <summary>
		/// This signal is emitted whenever a data-source is enabled or disabled.
		/// </summary>
		public event DataSourceEnabledHandler DataSourceEnabled;
		
		/// <summary>
		/// This signal is emitted whenever a data-source registers itself.
		/// </summary>
		public event DataSourceRegisteredHandler DataSourceRegistered;
		
		private IDataSource srcInterface;
		
		private static string objectPath = "/org/gnome/zeitgeist/log/activity";
	}
}

