using System;
using NUnit.Framework;
using Zeitgeist;
using Zeitgeist.Datamodel;
using System.Collections.Generic;

namespace Zeitgeist.Testsuite
{
	[TestFixture()]
	public class TestGetEvents
	{
		[Test()]
		public void TestEventIds()
		{
			LogClient client = new LogClient();
			
			List<uint> eventIdList = new List<uint>(){ 1, 2, 3 };
			List<Event> events = client.GetEvents(eventIdList);
			
			Assert.IsNotNull(events);
			
			foreach(Event ev in events)
			{
				Assert.IsNotNull(ev);
				Assert.IsNotNull(ev.Interpretation);
				Assert.IsNotNull(ev.Manifestation);
				Assert.IsNotEmpty(ev.Interpretation.Uri);
				Assert.IsNotEmpty(ev.Manifestation.Uri);
				
				Assert.IsNotNull(ev.Timestamp);
				
				Assert.IsNotNull(ev.Actor);
				
				CollectionAssert.AllItemsAreNotNull(ev.Subjects);
				CollectionAssert.AllItemsAreUnique(ev.Subjects);
			}
		}
		
		[Test()]
		public void TestNonExistingEventIds()
		{
			LogClient client = new LogClient();
			
			List<uint> eventIdList = new List<uint>(){ 100000, 200000, 300000 };
			List<Event> events = client.GetEvents(eventIdList);
			
			foreach(Event ev in events)
			{
				Assert.IsNull(ev);
			}
		}
	}
}

