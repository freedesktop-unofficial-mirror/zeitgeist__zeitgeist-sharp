using System;
using System.Collections.Generic;
using Zeitgeist.Client;
using NDesk.DBus;
using Zeitgeist.Datamodel;

namespace Zeitgeist
{
	public class DataSourceClient
	{
		public static List<DataSource> GetDataSources()
		{
			IDataSource srcInterface = GetDBusObject();
			RawDataSource[] srcs = srcInterface.GetDataSources();
			
			List<DataSource> srcList = new List<DataSource>();
			
			foreach(RawDataSource src in srcs)
			{
				DataSource et = DataSource.FromRaw(src);
				srcList.Add(et);
			}
			
			return srcList;
		}
		
		public static bool RegisterDataSources(string uniqueId, string name, string description, List<Event> events)
		{
			IDataSource srcInterface = GetDBusObject();
			
			
			List<RawEvent> rawEventList = new List<RawEvent>();
			foreach(Event src in events)
			{
				RawEvent evnt = src.GetRawEvent();
				rawEventList.Add(evnt);
			}
			
			return srcInterface.RegisterDataSources(uniqueId, name, description, rawEventList.ToArray());
		}
		
		void SetDataSourceEnabled(string uniqueId, bool enabled)
		{
			IDataSource srcInterface = GetDBusObject();
			
			srcInterface.SetDataSourceEnabled(uniqueId, enabled);
		}
		
		private static IDataSource GetDBusObject()
		{
			ObjectPath objPath = new ObjectPath("/org/gnome/zeitgeist/data_source_registry");
			IDataSource log = Bus.Session.GetObject<IDataSource>("org.gnome.zeitgeist.Engine", objPath);
			
			return log;
		}
	}
}

