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
			range.Begin = DateTime.Now.AddDays(-1);
			range.End = DateTime.Now;
			
			Event e = new Event();
			e.Actor = "application://gedit.desktop";
			Subject sub = new Subject();
			e.Subjects.Add(sub);
			
			LogClient client = new LogClient();
			List<uint> eventIds = client.FindEventIds(range, new List<Event>(){e}, StorageState.Any, 20, ResultType.MostRecentEvents);
			
			CollectionAssert.IsNotEmpty(eventIds);
		}
	}
}

