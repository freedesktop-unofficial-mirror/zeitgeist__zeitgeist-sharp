using System;
using System.Collections.Generic;

namespace Zeitgeist.Datamodel
{
	/// <summary>
	/// The delegate for an event which is called by the Daemon when a matching event is inserted
	/// </summary>
	/// <remarks>
	/// Using Monitor a client can recieve events from the daemon when some event is inserted which
	/// matches the Event template provided. This delegeate defined the event for the same
	/// </remarks>
	public delegate void NotifyInsertHandler(TimeRange range, List<Event> events);
	
	/// <summary>
	/// The delegate for an event which is called by the Daemon when a matching event is deleted
	/// </summary>
	/// <remarks>
	/// Using Monitor a client can recieve events from the daemon when some event is deleted which
	/// matches the Event template provided. This delegeate defined the event for the same
	/// </remarks>
	public delegate void NotifyDeleteHandler(TimeRange range, List<UInt32> eventIds);
}

