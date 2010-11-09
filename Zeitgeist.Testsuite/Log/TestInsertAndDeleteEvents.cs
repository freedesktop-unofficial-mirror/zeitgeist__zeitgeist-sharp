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

