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
		/// Get the list of known data-sources.
		/// </summary>
		/// <returns>
		/// A list of DataSource <see cref="List<DataSource>"/>
		/// </returns>
		public static List<DataSource> GetDataSources()
		{
			// Get the DBus interface for DataSource
			IDataSource srcInterface = ZsUtils.GetDBusObject<IDataSource>(objectPath);
			
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
		/// The uniqueId DataSource <see cref="System.String"/>
		/// </param>
		/// <param name="name">
		/// The name of the DataSource <see cref="System.String"/>
		/// </param>
		/// <param name="description">
		/// Description of DataSource <see cref="System.String"/>
		/// </param>
		/// <param name="events">
		/// A list of Event templates <see cref="List<Event>"/>
		/// </param>
		/// <returns>
		/// true is successful, false otherwise <see cref="System.Boolean"/>
		/// </returns>
		public static bool RegisterDataSources(string uniqueId, string name, string description, List<Event> events)
		{
			// Get the DBus interface for DataSource
			IDataSource srcInterface = ZsUtils.GetDBusObject<IDataSource>(objectPath);
			
			
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
		/// The uniqueId of the DataSource <see cref="System.String"/>
		/// </param>
		/// <param name="enabled">
		/// Is the DataSource to be enabled(true) or disabled(false) <see cref="System.Boolean"/>
		/// </param>
		void SetDataSourceEnabled(string uniqueId, bool enabled)
		{
			// Get the DBus interface for DataSource
			IDataSource srcInterface = ZsUtils.GetDBusObject<IDataSource>(objectPath);
			
			srcInterface.SetDataSourceEnabled(uniqueId, enabled);
		}
		
		private static string objectPath = "/org/gnome/zeitgeist/log/activity";
	}
}

