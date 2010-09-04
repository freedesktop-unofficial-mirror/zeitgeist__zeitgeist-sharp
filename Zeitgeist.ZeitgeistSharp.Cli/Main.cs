using System;
using NDesk.DBus;
using Zeitgeist.ZeitgeistSharp.Datamodel;

namespace Zeitgeist.ZeitgeistSharp.Cli
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			BusG.Init();
			NDesk.DBus.ObjectPath objPath = new NDesk.DBus.ObjectPath("/org/gnome/zeitgeist/data_source_registry");
			try
			{
				DataSources zeitgeist = Bus.Session.GetObject<DataSources>("org.gnome.zeitgeist.DataSourceRegistry", objPath);
				
				DataSource src = zeitgeist.Sources[0];
				if(zeitgeist == null)
				{
					
				}
				
				
			}
			catch(Exception e)
			{
				
			}
		}
	}
}

