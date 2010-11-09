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
using Zeitgeist.Datamodel;
using Zeitgeist.Client;
using NDesk.DBus;
using System.Linq;

namespace Zeitgeist
{
	/// <summary>
	/// Primary interface to the Zeitgeist engine. 
	/// </summary>
	/// <remarks>
	/// Used to update and query the log. 
	/// It also provides means to listen for events matching certain criteria. 
	/// All querying is heavily based around an “event template”-concept.
	/// </remarks>
	public class LogClient
	{
		/// <summary>
		/// The constructor for LogClient
		/// </summary>
		/// <remarks>
		/// This constructor gets the DBus object for LogClient which the object's methods use
		/// </remarks>
		public LogClient()
		{
			srcInterface = ZsUtils.GetDBusObject<ILog>(objectPath);
		}
		
		#region Fetch, Insert and Delete Events
		
		/// <summary>
		/// Get full event data for a set of event IDs
		/// Each event which is not found in the event log is represented by the null in the resulting List.
		/// </summary>
		/// <param name="eventIds">
		/// An array of event IDs <see cref="T:System.Collection.Generic.List{System.UInt32}"/>
		/// </param>
		/// <returns>
		/// Full event data for all the requested IDs of type <see cref="T:System.Collection.Generic.List{Zeitgeist.Datamodel.Event}"/>
		/// </returns>
		public List<Event> GetEvents(List<uint> eventIds)
		{
			RawEvent[] rawEvents = srcInterface.GetEvents(eventIds.ToArray());
			
			return ZsUtils.FromRawEventList(rawEvents);
		}
		
		/// <summary>
		/// Inserts events into the log. Returns an array containing the IDs of the inserted events
		/// </summary>
		/// <remarks>
		/// Each event which failed to be inserted into the log (either by being blocked or because of an error) will be represented by 0 in the resulting array.
		/// One way events may end up being blocked is if they match any of the blacklist templates.
		/// Any monitors with matching templates will get notified about the insertion. 
		/// Note that the monitors are notified after the events have been inserted.
		/// </remarks>
		/// <param name="events">
		/// List of <see cref="T:System.Collection.Generic.List{Zeitgeist.Datamodel.Event}"/> events to be inserted in the log 
		/// </param>
		/// <returns>
		/// An array containing the event IDs (type <see cref="T:System.Collection.Generic.List{System.UInt32}"/> ) of the inserted events. 0 as ID means failed to insert 
		/// </returns>
		public List<uint> InsertEvents(List<Event> events)
		{
			List<RawEvent> rawEvents = ZsUtils.ToRawEventList(events);
			
			UInt32[] eventIds = srcInterface.InsertEvents(rawEvents.ToArray());
			
			return new List<uint>(eventIds);
		}
		
		/// <summary>
		/// Delete a set of events from the log given their IDs
		/// If all the Event ID provided does not exist, then null is returned
		/// </summary>
		/// <param name="eventIds">
		/// The eventId (of type <see cref="T:System.Collection.Generic.List{System.UInt32}"/> ) of the Events to be deleted 
		/// </param>
		/// <returns>
		/// The TimeRange <see cref="T:Zeitgeist.Datamodel.TimeRange"/>
		/// </returns>
		public TimeRange DeleteEvents(List<uint> eventIds)
		{
			RawTimeRange rawRange = srcInterface.DeleteEvents(eventIds.ToArray());
			
			if(rawRange.Begin < 0 &&  rawRange.End < 0)
				return null;
			else
				return new TimeRange(rawRange.Begin, rawRange.End);
		}
		
		#endregion
		
		#region Search
		
		/// <summary>
		/// Search for events matching a given set of templates and return the IDs of matching events.
		/// Use GetEvents() passing in the returned IDs to look up the full event data.
		/// The matching is done where unset fields in the templates are treated as wildcards. 
		/// If a template has more than one subject then events will match the template if any one of their subjects match any one of the subject templates.
		/// The fields uri, interpretation, manifestation, origin, and mimetype can be prepended with an exclamation mark ‘!’ in order to negate the matching.
		/// The fields uri, origin, and mimetype can be prepended with an asterisk ‘*’ in order to do truncated matching.
		/// </summary>
		/// <remarks>
		/// This method is intended for queries potentially returning a large result set. 
		/// It is especially useful in cases where only a portion of the results are to be displayed at the same time 
		/// (eg., by using paging or dynamic scrollbars), as by holding a list of IDs you keep a stable ordering 
		/// and you can ask for the details associated to them in batches, when you need them. 
		/// For queries yielding a small amount of results, or where you need the information about all results at once no matter how many of them there are, see FindEvents().
		/// </remarks>
		/// <param name="range">
		/// The TimeRange <see cref="T:Zeitgeist.Datamodel.TimeRange"/> for the query 
		/// </param>
		/// <param name="eventTemplates">
		/// An List of event templates <see cref="T:System.Collection.Generic.List{Zeitgeist.Datamodel.Event}"/> which the returned events should match at least one of. 
		/// </param>
		/// <param name="state">
		/// Value of type <see cref="T:Zeitgeist.Datamodel.StorageState"/> whether the item is currently known to be available 
		/// </param>
		/// <param name="maxEvents">
		/// Maximal amount of returned events <see cref="T:Zeitgeist.Datamodel.System.UInt32"/>
		/// </param>
		/// <param name="resType">
		/// The Order in which the result should be made available <see cref="T:Zeitgeist.Datamodel.ResultType"/>
		/// </param>
		/// <returns>
		/// An array of type <see cref="T:System.Collection.Generic.List{System.UInt32}"/> containing the IDs of all matching events, up to a maximum of num_events events. 
		/// Sorted and grouped as defined by the result_type parameter. 
		/// </returns>
		public List<uint> FindEventIds(TimeRange range, List<Event> eventTemplates, StorageState state, uint maxEvents, ResultType resType)
		{
			RawEvent[] rawEventTemplates = ZsUtils.ToRawEventList(eventTemplates).ToArray();
			
			RawTimeRange rawRange = new RawTimeRange();
			rawRange.Begin = (long)ZsUtils.ToTimestamp(range.Begin);
			rawRange.End = (long)ZsUtils.ToTimestamp(range.End);
			
			UInt32[] eventIds = srcInterface.FindEventIds(rawRange, rawEventTemplates, (uint)state, maxEvents, (uint) resType);
			
			return new List<uint>(eventIds);
		}
		
		/// <summary>
		/// Get events matching a given set of templates.
		/// The matching is done where unset fields in the templates are treated as wildcards. 
		/// If a template has more than one subject then events will match the template if any one of their subjects match any one of the subject templates.
		/// </summary>
		/// <remarks>
		/// The fields uri, interpretation, manifestation, origin, and mimetype can be prepended with an exclamation mark ‘!’ in order to negate the matching.
		/// The fields uri, origin, and mimetype can be prepended with an asterisk ‘*’ in order to do truncated matching.
		/// In case you need to do a query yielding a large (or unpredictable) result set and you only want to show some of the results at the same time (eg., by paging them), use FindEventIds().
		/// </remarks>
		/// <param name="range">
		/// The TimeRange <see cref="T:Zeitgeist.Datamodel.TimeRange"/> for the query 
		/// </param>
		/// <param name="eventTemplates">
		/// An array of event templates of type <see cref="T:System.Collection.Generic.List{Zeitgeist.Datamodel.Event}"/> which the returned events should match at least one of 
		/// </param>
		/// <param name="state">
		/// Value of type <see cref="T:Zeitgeist.Datamodel.StorageState"/> whether the item is currently known to be available 
		/// </param>
		/// <param name="maxEvents">
		/// Maximal amount of returned events <see cref="System.UInt32"/>
		/// </param>
		/// <param name="resType">
		/// The Order in which the result should be made available <see cref="T:Zeitgeist.Datamodel.ResultType"/>
		/// </param>
		/// <returns>
		/// Full event data of type <see cref="T:System.Collection.Generic.List{Zeitgeist.Datamodel.Event}"/> for all the requested IDs, up to a maximum of num_events events, sorted and grouped as defined by the result_type parameter. 
		/// </returns>
		public List<Event> FindEvents(TimeRange range, List<Event> eventTemplates, StorageState state, uint maxEvents, ResultType resType)
		{
			RawEvent[] rawEventTemplates = ZsUtils.ToRawEventList(eventTemplates).ToArray();
			
			RawTimeRange rawRange = new RawTimeRange();
			rawRange.Begin = (long)ZsUtils.ToTimestamp(range.Begin);
			rawRange.End = (long)ZsUtils.ToTimestamp(range.End);
			
			RawEvent[] events = srcInterface.FindEvents(rawRange, rawEventTemplates, (uint)state, maxEvents, (uint) resType);
			
			return ZsUtils.FromRawEventList(events);
		}
		
		/// <summary>
		/// Get a list of URIs of subjects which frequently occur together with events matching event_templates within time_range. 
		/// The resulting URIs must occur as subjects of events matching result_event_templates and have storage state storage_state.
		/// </summary>
		/// <remarks>
		/// Warning: This API is EXPERIMENTAL and is not fully supported yet.
		/// </remarks>
		/// <param name="range">
		/// The TimeRange <see cref="T:Zeitgeist.Datamodel.TimeRange"/> for the query  
		/// </param>
		/// <param name="eventTemplates">
		/// An List of event templates <see cref="T:System.Collection.Generic.List{Zeitgeist.Datamodel.Event}"/> which you want URIs that relate to. 
		/// </param>
		/// <param name="resultEventTemplates">
		/// An array of event templates <see cref="T:System.Collection.Generic.List{Zeitgeist.Datamodel.Event}"/> which the returned URIs must occur as subjects of. 
		/// </param>
		/// <param name="state">
		/// Value of type <see cref="T:Zeitgeist.Datamodel.StorageState"/> whether the item is currently known to be available 
		/// </param>
		/// <param name="maxEvents">
		/// Maximal amount of returned events <see cref="System.UInt32"/>
		/// </param>
		/// <param name="resType">
		/// The Order in which the result should be made available <see cref="T:Zeitgeist.Datamodel.ResultType"/>
		/// </param>
		/// <returns>
		/// A list of URIs <see cref="T:System.Collection.Generic.List{System.String}"/> matching the described criteria 
		/// </returns>
		public List<string> FindRelatedUris(TimeRange range, List<Event> eventTemplates, List<Event> resultEventTemplates, StorageState state, uint maxEvents, ResultType resType)
		{
			RawEvent[] rawEvents = ZsUtils.ToRawEventList(eventTemplates).ToArray();
			RawEvent[] rawEventTemplates = ZsUtils.ToRawEventList(resultEventTemplates).ToArray();
			
			RawTimeRange rawRange = new RawTimeRange();
			rawRange.Begin = (long)ZsUtils.ToTimestamp(range.Begin);
			rawRange.End = (long)ZsUtils.ToTimestamp(range.End);
			
			string[] uris = srcInterface.FindRelatedUris(rawRange, rawEvents, rawEventTemplates, (uint)state, maxEvents, (uint) resType);
			
			return new List<string>(uris);
		}
		
		#endregion
		
		#region Monitors
		
		/// <summary>
		/// Register a client side monitor object to receive callbacks when events matching time_range and event_templates are inserted or deleted.
		/// </summary>
		/// <param name="monitorPath">
		/// The path to be monitored <see cref="System.String"/>
		/// </param>
		/// <param name="range">
		/// The time range <see cref="T:Zeitgeist.Datamodel.TimeRange"/> under which Monitored events must fall within 
		/// </param>
		/// <param name="eventTemplates">
		/// Event templates <see cref="T:System.Collection.Generic.List{Zeitgeist.Datamodel.Event}"/> that events must match in order to trigger the monitor 
		/// </param>
		public void InstallMonitor(string monitorPath, TimeRange range, List<Event> eventTemplates)
		{
			srcInterface = ZsUtils.GetDBusObject<ILog>(objectPath);
			
			RawTimeRange rawRange = new RawTimeRange();
			rawRange.Begin = (long)ZsUtils.ToTimestamp(range.Begin);
			rawRange.End = (long)ZsUtils.ToTimestamp(range.End);
			
			ObjectPath path = new ObjectPath(monitorPath);
			List<RawEvent> rawEvents = ZsUtils.ToRawEventList(eventTemplates);
			srcInterface.InstallMonitor(path, rawRange, rawEvents.ToArray());
		}
		
		/// <summary>
		/// Remove a monitor installed with InstallMonitor()
		/// </summary>
		/// <param name="monitorPath">
		/// The path of the monitor to be removed <see cref="System.String"/>
		/// </param>
		public void RemoveMonitor(string monitorPath)
		{
			ObjectPath path = new ObjectPath(monitorPath);
			srcInterface.RemoveMonitor(path);
		}
		
		#endregion
		
		/// <summary>
		/// Delete the log file and all its content
		/// </summary>
		/// <remarks>
		/// This method is used to delete the entire log file and all its content in one go. 
		/// To delete specific subsets use FindEventIds() combined with DeleteEvents().
		/// </remarks>
		public void DeleteLog()
		{
			srcInterface.DeleteLog();
		}
		
		/// <summary>
		/// Terminate the running Zeitgeist engine process
		/// </summary>
		/// <remarks>
		/// Use with caution, this action must only be triggered with the user’s explicit consent, 
		/// as it will affect all applications using Zeitgeist
		/// </remarks>
		public void Quit()
		{
			srcInterface.Quit();
		}
		
		private ILog srcInterface;
		
		private static string objectPath = "/org/gnome/zeitgeist/log/activity";
	}
}

