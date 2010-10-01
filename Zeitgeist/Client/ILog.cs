using System;
using Zeitgeist.Datamodel;
using Zeitgeist;
using NDesk.DBus;

namespace Zeitgeist.Client
{
	/// <summary>
	/// Primary interface to the Zeitgeist engine. 
	/// Used to update and query the log. 
	/// It also provides means to listen for events matching certain criteria. 
	/// All querying is heavily based around an “event template”-concept.
	/// </summary>
	[NDesk.DBus.Interface ("org.gnome.zeitgeist.Log")]
	internal interface ILog
	{
		/// <summary>
		/// Get full event data for a set of event IDs
		/// Each event which is not found in the event log is represented by the null in the resulting List.
		/// </summary>
		/// <param name="eventIds">
		/// An array of event IDs. <see cref="T:System.UInt32[]"/>
		/// </param>
		/// <returns>
		/// Full event data for all the requested IDs <see cref="T:Zeitgeist.Datamodel.RawEvent[]"/>
		/// </returns>
		RawEvent[] GetEvents(UInt32[] eventIds);
		
		/// <summary>
		/// Search for events matching a given set of templates and return the IDs of matching events.
		/// Use GetEvents() passing in the returned IDs to look up the full event data.
		/// The matching is done where unset fields in the templates are treated as wildcards. 
		/// If a template has more than one subject then events will match the template if any one of their subjects match any one of the subject templates.
		/// The fields uri, interpretation, manifestation, origin, and mimetype can be prepended with an exclamation mark ‘!’ in order to negate the matching.
		/// The fields uri, origin, and mimetype can be prepended with an asterisk ‘*’ in order to do truncated matching.
		/// NOTE:
		/// This method is intended for queries potentially returning a large result set. 
		/// It is especially useful in cases where only a portion of the results are to be displayed at the same time 
		/// (eg., by using paging or dynamic scrollbars), as by holding a list of IDs you keep a stable ordering 
		/// and you can ask for the details associated to them in batches, when you need them. 
		/// For queries yielding a small amount of results, or where you need the information about all results at once no matter how many of them there are, see FindEvents().
		/// </summary>
		/// <param name="range">
		/// The TimeRange for the query <see cref="T:Zeitgeist.Datamodel.TimeRange"/>
		/// </param>
		/// <param name="eventTemplates">
		/// An array of event templates which the returned events should match at least one of. <see cref="T:Zeitgeist.Datamodel.RawEvent[]"/>
		/// </param>
		/// <param name="state">
		/// Whether the item is currently known to be available <see cref="T:Zeitgeist.Datamodel.StorageState"/>
		/// </param>
		/// <param name="maxEvents">
		/// Maximal amount of returned events <see cref="T:Zeitgeist.Datamodel.System.UInt32"/>
		/// </param>
		/// <param name="resType">
		/// The Order in which the result should be made available <see cref="T:Zeitgeist.Datamodel.ResultType"/>
		/// </param>
		/// <returns>
		/// An array containing the IDs of all matching events, up to a maximum of num_events events. 
		/// Sorted and grouped as defined by the result_type parameter. <see cref="T:System.UInt32[]"/>
		/// </returns>
		UInt32[] FindEventIds(TimeRange range, RawEvent[] eventTemplates, UInt32 state, UInt32 maxEvents, UInt32 resType);
		
		/// <summary>
		/// Get events matching a given set of templates.
		/// The matching is done where unset fields in the templates are treated as wildcards. 
		/// If a template has more than one subject then events will match the template if any one of their subjects match any one of the subject templates.
		/// The fields uri, interpretation, manifestation, origin, and mimetype can be prepended with an exclamation mark ‘!’ in order to negate the matching.
		/// The fields uri, origin, and mimetype can be prepended with an asterisk ‘*’ in order to do truncated matching.
		/// In case you need to do a query yielding a large (or unpredictable) result set and you only want to show some of the results at the same time (eg., by paging them), use FindEventIds().
		/// </summary>
		/// <param name="range">
		/// The TimeRange for the query <see cref="T:Zeitgeist.Datamodel.TimeRange"/>
		/// </param>
		/// <param name="eventTemplates">
		/// An array of event templates which the returned events should match at least one of <see cref="T:Zeitgeist.Datamodel.RawEvent[]"/>
		/// </param>
		/// <param name="state">
		/// Whether the item is currently known to be available <see cref="T:Zeitgeist.Datamodel.StorageState"/>
		/// </param>
		/// <param name="maxEvents">
		/// Maximal amount of returned events <see cref="System.UInt32"/>
		/// </param>
		/// <param name="resType">
		/// The Order in which the result should be made available  <see cref="T:Zeitgeist.Datamodel.ResultType"/>
		/// </param>
		/// <returns>
		/// Full event data for all the requested IDs, up to a maximum of num_events events, sorted and grouped as defined by the result_type parameter. <see cref="T:Zeitgeist.Datamodel.RawEvent[]"/>
		/// </returns>
		RawEvent[] FindEvents(TimeRange range, RawEvent[] eventTemplates, UInt32 state, UInt32 maxEvents, UInt32 resType);
		
		/// <summary>
		/// Warning: This API is EXPERIMENTAL and is not fully supported yet.
		/// Get a list of URIs of subjects which frequently occur together with events matching event_templates within time_range. 
		/// The resulting URIs must occur as subjects of events matching result_event_templates and have storage state storage_state.
		/// </summary>
		/// <param name="range">
		/// The TimeRange for the query  <see cref="T:Zeitgeist.Datamodel.TimeRange"/>
		/// </param>
		/// <param name="eventTemplates">
		/// An array of event templates which you want URIs that relate to. <see cref="T:Zeitgeist.Datamodel.RawEvent[]"/>
		/// </param>
		/// <param name="resultEventTemplates">
		/// An array of event templates which the returned URIs must occur as subjects of. <see cref="T:Zeitgeist.Datamodel.RawEvent[]"/>
		/// </param>
		/// <param name="state">
		/// Whether the item is currently known to be available <see cref="T:Zeitgeist.Datamodel.StorageState"/>
		/// </param>
		/// <param name="maxEvents">
		/// Maximal amount of returned events <see cref="System.UInt32"/>
		/// </param>
		/// <param name="resType">
		/// The Order in which the result should be made available <see cref="T:Zeitgeist.Datamodel.ResultType"/>
		/// </param>
		/// <returns>
		/// A list of URIs matching the described criteria <see cref="T:System.String[]"/>
		/// </returns>
		string[] FindRelatedUris(TimeRange range, RawEvent[] eventTemplates, RawEvent[] resultEventTemplates, UInt32 state, UInt32 maxEvents, UInt32 resType);
		
		/// <summary>
		/// Inserts events into the log. Returns an array containing the IDs of the inserted events
		/// Each event which failed to be inserted into the log (either by being blocked or because of an error) will be represented by 0 in the resulting array.
		/// One way events may end up being blocked is if they match any of the blacklist templates.
		/// Any monitors with matching templates will get notified about the insertion. 
		/// Note that the monitors are notified after the events have been inserted.
		/// </summary>
		/// <param name="events">
		/// List of events to be inserted in the log <see cref="T:Zeitgeist.Datamodel.RawEvent[]"/>
		/// </param>
		/// <returns>
		/// An array containing the event IDs of the inserted events. 0 as ID means failed to insert <see cref="T:System.UInt32[]"/>
		/// </returns>
		UInt32[] InsertEvents(RawEvent[] events);
		
		/// <summary>
		/// Register a client side monitor object to receive callbacks when events matching time_range and event_templates are inserted or deleted.
		/// </summary>
		/// <param name="monitorPath">
		/// The path to be monitored <see cref="NDesk.DBus.ObjectPath"/>
		/// </param>
		/// <param name="range">
		/// The time range under which Monitored events must fall within <see cref="TimeRange"/>
		/// </param>
		/// <param name="eventTemplates">
		/// RawEvent templates that events must match in order to trigger the monitor <see cref="T:Zeitgeist.Datamodel.RawEvent[]"/>
		/// </param>
		void InstallMonitor(ObjectPath monitorPath, TimeRange range, RawEvent[] eventTemplates);
		
		/// <summary>
		/// Remove a monitor installed with InstallMonitor()
		/// </summary>
		/// <param name="monitorPath">
		/// The path of the monitor to be removed <see cref="NDesk.DBus.ObjectPath"/>
		/// </param>
		void RemoveMonitor(ObjectPath monitorPath);
		
		/// <summary>
		/// Delete a set of events from the log given their IDs
		/// </summary>
		/// <param name="eventIds">
		/// The eventId of the Events to be deleted <see cref="T:System.UInt32[]"/>
		/// </param>
		/// <returns>
		/// The TimeRange <see cref="T:Zeitgeist.Datamodel.TimeRange"/>
		/// </returns>
		TimeRange DeleteEvents(UInt32[] eventIds);
		
		/// <summary>
		/// Delete the log file and all its content
		/// This method is used to delete the entire log file and all its content in one go. 
		/// To delete specific subsets use FindEventIds() combined with DeleteEvents().
		/// </summary>
		void DeleteLog();
		
		/// <summary>
		/// Terminate the running Zeitgeist engine process; 
		/// use with caution, this action must only be triggered with the user’s explicit consent, 
		/// as it will affect all applications using Zeitgeist
		/// </summary>
		void Quit();
	}
}

