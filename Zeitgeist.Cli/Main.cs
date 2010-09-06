using System;
using NDesk.DBus;
using Zeitgeist.Datamodel;
using Zeitgeist.Client;
using System.Collections.Generic;

namespace Zeitgeist.ZeitgeistSharp.Cli
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			BusG.Init();
			
			NDesk.DBus.ObjectPath objPath = new NDesk.DBus.ObjectPath("/org/gnome/zeitgeist/data_source_registry");
			IDataSource zeitgeist = Bus.Session.GetObject<IDataSource>("org.gnome.zeitgeist.Engine", objPath);
			
			RawDataSource[] src= zeitgeist.GetDataSources();
			
			List<DataSource> srcs = DataSourceClient.GetDataSources();
			
			/*Event ev = new Event();
			ev.Interpretation = "http://www.zeitgeist-project.com/ontologies/2010/01/27/zg#AccessEvent";
			ev.Manifestation = "http://www.zeitgeist-project.com/ontologies/2010/01/27/zg#UserActivity";
			ev.Actor = "application://gvim.desktop";
			
			ev.Subjects = new List<Subject>();
			Subject sub = new Subject();
			
			sub.Uri="file:///home/manish/Dropbox/braintree/users/models.py";
			sub.Interpretation = "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#SourceCode";
			sub.Manifestation = "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#FileDataObject";
			sub.Origin = "file:///home/manish/Dropbox/braintree/users";
			sub.MimeType = "text/x-python";
			sub.Text = "models.py";
			sub.Storage = "";
			
			ev.Subjects.Add(sub);
			
			ev.Payload = new byte[]{};
			
			RawEvent evn = RawEvent.FromEvent(ev);
			RawEvent[] evnList = new RawEvent[]{evn};
			
			UInt32[] eventIds = zeitgeist.InsertEvents(evnList);*/
			
			//Event ev = Event.FromRaw(events[0]);
		}
	}
}

