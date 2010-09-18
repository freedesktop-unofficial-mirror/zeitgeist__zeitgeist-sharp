using System;
using NDesk.DBus;
using Zeitgeist.Datamodel;
using Zeitgeist.Client;
using System.Collections.Generic;
using Zeitgeist;

namespace Zeitgeist.ZeitgeistSharp.Cli
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			BusG.Init();
			
			KeyValuePair<string,string> res= Interpretation.Instance.Search("http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Software");
			KeyValuePair<string, string> res2 = Manifestation.Instance.Search("http://www.zeitgeist-project.com/ontologies/2010/01/27/zg#UserActivity");
			
			
			
			//List<DataSource> srcs = DataSourceClient.GetDataSources();
			
			//List<Event> blacklistEvents = BlacklistClient.GetBlacklist();
			
			
			
			List<uint> listOfEvents = new List<uint>();
			listOfEvents.Add(23);listOfEvents.Add(24);listOfEvents.Add(25);
			
			
			LogClient client = new LogClient();
			List<Event> eventInst = client.GetEvents(listOfEvents);
			Console.WriteLine(eventInst[0].Interpretation);
			Console.WriteLine(eventInst[0].Manifestation);
			Console.WriteLine(eventInst[0].Timestamp.ToLongTimeString());
			
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

