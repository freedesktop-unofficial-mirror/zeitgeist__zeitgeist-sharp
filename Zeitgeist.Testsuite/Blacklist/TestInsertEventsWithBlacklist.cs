/******************************************************************************
 * The MIT/X11/Expat License
 * Copyright (c) 2011 Manish Sinha<manishsinha@ubuntu.com>

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
	public class TestInsertEventsWithBlacklist
	{
		[Test()]
		public void TestInsertEventsWithBlacklistPass ()
		{
			LogClient client = new LogClient();
			BlacklistClient bClient = new BlacklistClient();
			string fooBlacklistId = "block-foo";
			
			// Create the first event
			Event ev1 = new Event();
			ev1.Interpretation = Interpretation.Instance.EventInterpretation.ModifyEvent;
			ev1.Manifestation = Manifestation.Instance.HardDiskPartition;
			ev1.Actor = "application://foo.desktop";
			Subject sub1 = new Subject();
			sub1.MimeType = "text/plain";
			sub1.Interpretation = Interpretation.Instance.Font;
			ev1.Subjects.Add(sub1);
			
			// Create second event
			Event ev2 = new Event();
			ev2.Actor = "application://gedit.desktop";
			Subject sub2 = new Subject();
			ev2.Subjects.Add(sub2);
			
			// Create the blacklist template
			Event evTemplate = new Event();
			evTemplate.Actor = "application://foo.desktop";
			Subject subTemplate = new Subject();
			evTemplate.Subjects.Add(subTemplate);
			
			// Insert the event before the blacklist has been set
			// and check if it actually gets inserted
			List<uint> res = client.InsertEvents(new List<Event>(){ev1});
			Assert.IsNotEmpty(res);
			// Check if it gets inserted. Means event_id > 0
			Assert.Greater(res[0], 0, "Event inserted before setting blacklist");
			// If inserted, clean the database by deleting random events
			client.DeleteEvents(res);
			
			// Handle the Template Added event
			bClient.TemplateAdded += delegate(string blacklistId, Event addedTemplate) {
				Console.Out.WriteLine("Blacklist added for: ", blacklistId);
			};
			// Handle the Template Removed event
			bClient.TemplateRemoved += delegate(string blacklistId, Event removedTemplate) {
				Console.Out.WriteLine("Blacklist removed for: ", blacklistId);
			};
			
			// Add the blacklist template
			bClient.AddTemplate(fooBlacklistId, evTemplate);
			
			// Try to insert the event which should get blocked
			List<uint> res2 = client.InsertEvents(new List<Event>(){ev1});
			Assert.IsNotEmpty(res2);
			Assert.AreEqual(res2[0], 0, "Insert event after setting blacklist which should get blocked");
			
			// Try to insert the event which should get not get blocked
			List<uint> res3 = client.InsertEvents(new List<Event>(){ev2});
			Assert.IsNotEmpty(res3);
			Assert.Greater(res3[0], 0, "Insert event after setting blacklist which should not get blocked");
			// If inserted, clean the database by deleting random events
			client.DeleteEvents(res3);
			
			// Remove the blacklist template
			bClient.RemoveTemplate(fooBlacklistId);
		}
	}
}

