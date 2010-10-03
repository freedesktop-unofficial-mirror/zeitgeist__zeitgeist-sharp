using System;
using NUnit.Framework;
using Zeitgeist;
using Zeitgeist.Datamodel;
using System.Collections.Generic;

namespace Zeitgeist.Testsuite
{
	[TestFixture()]
	public class TestInsertEvents
	{
		[Test()]
		public void TestInsertEventsPass()
		{
			Event ev = new Event();
			ev.Interpretation = Interpretation.Instance.EventInterpretation.AccessEvent;
			ev.Manifestation = Manifestation.Instance.EventManifestation.UserActivity;
			ev.Actor = "application://tomboy.desktop";
			
			Subject sub11 = new Subject();
			sub11.Uri = "/home/manish/.local/share/tomboy/bf7112c1-28dd-4079-b566-c135b19c4e01.note";
			sub11.Interpretation = Interpretation.Instance.EventInterpretation.AccessEvent;
			sub11.Manifestation = Manifestation.Instance.EventManifestation.UserActivity;
			sub11.Origin = "file:///home/manish/.local/share/tomboy/";
			sub11.MimeType = "text/x-note";
			sub11.Text = "Ubuntu One";
			
			ev.Subjects.Add(sub11);
			
			LogClient client = new LogClient();
			List<uint> eventIds = client.InsertEvents(new List<Event>() { ev });
			
			Assert.IsNotNull(eventIds);
			CollectionAssert.IsNotEmpty(eventIds);
		}
	}
}

