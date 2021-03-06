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

