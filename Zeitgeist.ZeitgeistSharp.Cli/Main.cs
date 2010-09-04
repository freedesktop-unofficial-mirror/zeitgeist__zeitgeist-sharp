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
			DataSources zeitgeist = Bus.Session.GetObject<DataSources>("org.gnome.zeitgeist.Engine", objPath);
			DataSource[] sources = zeitgeist.GetDataSources();
			Console.WriteLine(sources.Length);
		}
	}
}

