using System;
using NUnit.Framework;
using Zeitgeist;
using Zeitgeist.Datamodel;
using System.Collections.Generic;

namespace Zeitgeist.Testsuite
{
	[TestFixture()]
	public class TestFindEventIds
	{
		[Test()]
		public void TestFindEventIdsPass()
		{
			TimeRange range = new TimeRange();
			range.Begin = DateTime.Now.AddDays(-30);
			range.End = DateTime.Now;
			
			Event e = new Event();
			e.Actor = "application:///usr/share/applications/eog.desktop";
			Subject sub = new Subject();
			e.Subjects.Add(sub);
			
			Event e2 = new Event();
			e2.Actor = "application://eog.desktop";
			Subject sub2 = new Subject();
			e2.Subjects.Add(sub2);
			
			LogClient client = new LogClient();
			List<uint> eventIds = client.FindEventIds(range, new List<Event>(){e,e2}, StorageState.Any, 20, ResultType.MostRecentEvents);
			
			CollectionAssert.IsNotEmpty(eventIds);
		}
	}
}

