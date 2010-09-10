using System;

namespace Zeitgeist.Datamodel
{
	/// <summary>
	/// An enumeration class used to define how query results should be returned from the Zeitgeist engine.
	/// </summary>
	public enum ResultType
	{
		/// <summary>
		/// All events with the most recent events first. (Integer value: 0)
		/// </summary>
		MostRecentEvents = 0,
		
		/// <summary>
		/// All events with the oldest ones first. (Integer value: 1)
		/// </summary>
		LeastRecentEvents = 1,
		
		/// <summary>
		/// One event for each subject only, ordered with the most recent events first. (Integer value: 2)
		/// </summary>
		MostRecentSubjects = 2,
		
		/// <summary>
		/// One event for each subject only, ordered with oldest events first. (Integer value: 3)
		/// </summary>
		LeastRecentSubjects = 3,
		
		/// <summary>
		/// One event for each subject only, ordered by the popularity of the subject. (Integer value: 4)
		/// </summary>
		MostPopularSubjects = 4,
		
		/// <summary>
		/// One event for each subject only, ordered ascendently by popularity. (Integer value: 5)
		/// </summary>
		LeastPopularSubjects = 5,
		
		/// <summary>
		/// The last event of each different actor,ordered by the popularity of the actor. (Integer value: 6)
		/// </summary>
		MostPopularActor = 6,
		
		/// <summary>
		/// The last event of each different actor,ordered ascendently by the popularity of the actor. (Integer value: 7)
		/// </summary>
		LeastPopularActor = 7,
		
		/// <summary>
		/// The last event of each different actor. (Integer value: 8)
		/// </summary>
		MostRecentActor = 8,
		
		/// <summary>
		/// The first event of each different actor. (Integer value: 9)
		/// </summary>
		LeastRecentActor = 9
	}
}

