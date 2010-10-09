using System;
using System.Collections.Generic;

namespace Zeitgeist.Datamodel
{
	public delegate void NotifyInsertHandler(TimeRange range, List<Event> events);
	
	public delegate void NotifyDeleteHandler(TimeRange range, List<UInt32> eventIds);
}

