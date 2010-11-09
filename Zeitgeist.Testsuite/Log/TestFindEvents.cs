/******************************************************************************
 * The MIT/X11/Expat License
 * Copyright (c) 2010 Manish Sinha<mail@manishsinha.net>

 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:

 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.

 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE. 
********************************************************************************/


using System;
using NUnit.Framework;
using Zeitgeist;
using Zeitgeist.Datamodel;
using System.Collections.Generic;

namespace Zeitgeist.Testsuite
{
	[TestFixture()]
	public class TestFindEvents
	{
		[Test()]
		public void TestFindEventsPass()
		{
			TimeRange range = new TimeRange();
			range.Begin = DateTime.Now.AddDays(-30);
			range.End = DateTime.Now;
			
			Event e = new Event();
			e.Actor = "application:///usr/share/applications/gedit.desktop";
			Subject sub = new Subject();
			e.Subjects.Add(sub);
			
			Event e2 = new Event();
			e2.Actor = "application://gedit.desktop";
			Subject sub2 = new Subject();
			e2.Subjects.Add(sub2);
			
			LogClient client = new LogClient();
			List<Event> events = client.FindEvents(range, new List<Event>(){e,e2}, StorageState.Any, 20, ResultType.MostRecentEvents);
			
			CollectionAssert.IsNotEmpty(events);
			
			foreach(Event ev in events)
			{
				Assert.Greater(ev.Id, 0);
				Assert.IsNotEmpty(ev.Actor);
				Assert.IsNotNull(ev.Interpretation);
			}
		}
	}
}

