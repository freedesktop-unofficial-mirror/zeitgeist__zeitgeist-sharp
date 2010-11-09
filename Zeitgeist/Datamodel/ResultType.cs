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

