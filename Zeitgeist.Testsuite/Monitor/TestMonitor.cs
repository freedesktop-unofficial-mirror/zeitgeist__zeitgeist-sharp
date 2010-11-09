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

