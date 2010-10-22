using System;
using NUnit.Framework;
using Zeitgeist;
using Zeitgeist.Datamodel;
using System.Collections.Generic;

namespace Zeitgeist.Testsuite
{
	[TestFixture()]
	public class TestInsertAndDeleteEvents
	{
		[Test()]
		public void TestDeleteEventsPass()
		{
			Event ev1 = new Event();
			Subject sub11 = new Subject();
			Subject sub12 = new Subject();
			ev1.Subjects.Add(sub11);
			ev1.Subjects.Add(sub12);
			
			Event ev2 = new Event();
			Subject sub21 = new Subject();
			Subject sub22 = new Subject();
			ev2.Subjects.Add(sub21);
			ev2.Subjects.Add(sub22);
			
			LogClient client = new LogClient();
			List<uint> eventIds = client.InsertEvents(new List<Event>() { ev1, ev2 });
			
			CollectionAssert.IsNotEmpty(eventIds);
			Assert.AreEqual(eventIds.Count, 2);
			
			TimeRange range = client.DeleteEvents(eventIds);
			
			Assert.IsNotNull(range.Begin);
			Assert.IsNotNull(range.End);
		}
		
		[Test()]
		public void TestDeleteEventsFail()
		{
			LogClient client = new LogClient();
			
			TimeRange range = client.DeleteEvents(new List<uint>(){ 30000 });
			
			Assert.IsNull(range);
		}
	}
}

