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
using Zeitgeist.Datamodel;
using Zeitgeist;

namespace Zeitgeist.Client
{
	/// <summary>
	/// The Zeitgeist engine maintains a list of event templates that is known as the blacklist. 
	/// When inserting events via LogClient.InsertEvents they will be checked against the blacklist templates 
	/// and if they match they will not be inserted in the log, and any matching monitors will not be signalled.
	/// </summary>
	[DBus.Interface ("org.gnome.zeitgeist.Blacklist")]
	internal interface IBlacklist
	{
		/// <summary>
		/// Get the current blacklist templates.
		/// </summary>
		/// <returns>
		/// A list of Blacklist RawEvent <see cref="T:System.Collection.Generic.List{Zeitgeist.Datamodel.RawEvent>"/> templates 
		/// </returns>
		RawEvent[] GetBlacklist();
		
		/// <summary>
		/// Set the blacklist to event_templates. 
		/// </summary>
		/// <remarks>
		/// Events matching any these templates will be blocked from insertion into the log. 
		/// It is still possible to find and look up events matching the blacklist which was inserted before the blacklist banned them.
		/// </remarks>
		/// <param name="event_templates">
		/// A List of RawEvent <see cref="T:System.Collection.Generic.List{Zeitgeist.Datamodel.RawEvent>"/> templates 
		/// </param>
		void SetBlacklist(RawEvent[] event_templates);
	}
}

