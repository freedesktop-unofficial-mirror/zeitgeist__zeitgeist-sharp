using System;
using NUnit.Framework;
using Zeitgeist;
using Zeitgeist.Datamodel;
using System.Collections.Generic;

namespace Zeitgeist.Testsuite
{
	[TestFixture()]
	public class TestMonitor
	{
		[Test()]
		public void TestMonitorPass ()
		{
			Event ev1 = new Event();
			ev1.Interpretation = Interpretation.Instance.EventInterpretation.ModifyEvent;
			ev1.Manifestation = Manifestation.Instance.HardDiskPartition;
			ev1.Actor = "application://tomboy.desktop";
			Subject sub11 = new Subject();
			sub11.MimeType = "text/plain";
			sub11.Interpretation = Interpretation.Instance.Font;
			Subject sub12 = new Subject();
			sub12.MimeType = "text/plain";
			ev1.Subjects.Add(sub11);
			ev1.Subjects.Add(sub12);
			
			Event ev2 = new Event();
			ev2.Interpretation = Interpretation.Instance.EventInterpretation.ModifyEvent;
			ev2.Manifestation = Manifestation.Instance.SoftwareItem;
			ev2.Actor = "application://tomboy.desktop";
			Subject sub21 = new Subject();
			Subject sub22 = new Subject();
			ev2.Subjects.Add(sub21);
			ev2.Subjects.Add(sub22);
			
			Monitor mn = new Monitor("/org/gnome/zeitgeist/unittest");
			mn.Inserted += delegate(TimeRange range, List<Event> events) {
				Console.WriteLine("Inserted");
				};
			mn.Deleted += delegate(TimeRange range, List<uint> eventIds) {
					Console.WriteLine("Deleted");
				};	
			
			LogClient cl = new LogClient();
			TimeRange rng = new TimeRange();
			rng.Begin = DateTime.Now.AddDays(-1);
			rng.End = DateTime.Now.AddDays(1);
			
			Event ev = new Event();
			ev.Actor = "application://tomboy.desktop";
			Subject sub1 = new Subject();
			Subject sub2 = new Subject();
			ev.Subjects.Add(sub1);
			ev.Subjects.Add(sub2);
			
			cl.InstallMonitor("/org/gnome/zeitgeist/unittest", rng, new List<Event>() {ev});
			
			List<uint> eventidList = cl.InsertEvents(new List<Event>() { ev1, ev2 });
			Assert.AreEqual(eventidList.Count, 2);
			cl.DeleteEvents(new List<uint>(){eventidList[0], eventidList[1]});
			
			cl.RemoveMonitor("/org/gnome/zeitgeist/unittest");
		}
	}
}

