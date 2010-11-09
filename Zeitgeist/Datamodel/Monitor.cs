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
using System.Collections.Generic;
using NDesk.DBus;
using GLib;
using System.Threading;
using System.ComponentModel;

namespace Zeitgeist.Datamodel
{
	[Interface("org.gnome.zeitgeist.Monitor")]
	internal interface IMonitor
	{
		void NotifyInsert(long[] range, RawEvent[] events);
		
		void NotifyDelete(long[] range, UInt32[] evendIds);
	}
	
	internal class RawMonitor : IMonitor
	{
		public RawMonitor(string monitorPath)
		{
			ObjectPath objPath = new ObjectPath (monitorPath);
			Bus.Session.Register (objPath, this);
			
			loop = new MainLoop();
			worker = new BackgroundWorker();
			
			worker.DoWork += delegate(object sender, DoWorkEventArgs e) {
				loop.Run();
			};
			
			worker.RunWorkerAsync();
		}
		
		public void NotifyInsert(long[] range, RawEvent[] events)
		{
			List<Event> eventList = ZsUtils.FromRawEventList(events);
			
			if(Inserted != null)
				Inserted(new TimeRange(range[0], range[1]), eventList);
		}
		
		public void NotifyDelete(long[] range, UInt32[] evendIds)
		{
			List<UInt32> eventIdList = new List<UInt32>(evendIds);
			
			if(Deleted != null)
				Deleted(new TimeRange(range[0], range[1]), eventIdList);
		}
		
		public event NotifyInsertHandler Inserted;
		
		public event NotifyDeleteHandler Deleted;
		
		private BackgroundWorker worker;
		
		private MainLoop loop;
	}
	
	/// <summary>
	/// DBus interface for monitoring the Zeitgeist log for certain types of events.
	/// When using the Python bindings monitors are normally instantiated indirectly by calling ZeitgeistClient.install_monitor
	/// </summary>
	/// <remarks>
	/// It is important to understand that the Monitor instance lives on the client side, and expose a 
	/// DBus service there, and the Zeitgeist engine calls back to the monitor when matching events are registered.
	/// </remarks>
	public class Monitor
	{
		/// <summary>
		/// Create a new instance of Monitor which can be used for notifying the client that some event has been 
		/// inserted or deleted which matches the event template
		/// </summary>
		/// <param name="monitorPath">
		/// The DBus path over which the bus is activated <see cref="System.String"/>
		/// </param>
		public Monitor(string monitorPath)
		{
			_monitor = new RawMonitor( monitorPath);
			
			_monitor.Inserted += delegate(TimeRange event_range, List<Event> events) {
				if(Inserted != null)
					Inserted(event_range, events);
			};
			_monitor.Deleted += delegate(TimeRange event_range, List<uint> eventIds) {
				if(Deleted != null)
					Deleted(event_range, eventIds);
			};
		}
		
		/// <summary>
		/// The event which is fired in the case of an event is inserted which matches the Event Templates
		/// </summary>
		public event NotifyInsertHandler Inserted;
		
		/// <summary>
		/// The event which is fired in the case of an event is deleted which matches the Event Templates
		/// </summary>
		public event NotifyDeleteHandler Deleted;
		
		private RawMonitor _monitor;
	}
}