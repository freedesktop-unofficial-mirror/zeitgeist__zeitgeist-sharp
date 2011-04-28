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
using DBus;

namespace Zeitgeist
{
	/// <summary>
	/// The Zeitgeist engine maintains a list of event templates that is known as the blacklist. 
	/// </summary>
	/// <remarks>
	/// When inserting events via LogClient.InsertEvents they will be checked against the blacklist templates 
	/// and if they match they will not be inserted in the log, and any matching monitors will not be signalled.
	/// </remarks>
	public class BlacklistClient
	{
		/// <summary>
		/// The constructor for BlacklistClient
		/// </summary>
		/// <remarks>
		/// This constructor gets the DBus object for BlacklistClient which the object's methods use
		/// </remarks>
		public BlacklistClient()
		{
			srcInterface = ZsUtils.GetDBusObject<IBlacklist>(objectPath);
			
			// Connect the Template Added event
			srcInterface.TemplateAdded += delegate(string blacklistId, RawEvent addedTemplate) {
				Console.Out.WriteLine("Blacklist added for: "+blacklistId);
				if(this.TemplateAdded != null)
					this.TemplateAdded(blacklistId, RawEvent.FromRaw(addedTemplate));
			};
			
			// Connect the Template Removed event
			srcInterface.TemplateRemoved += delegate(string blacklistId, RawEvent removedTemplate) {
				Console.Out.WriteLine("Blacklist removed for: "+blacklistId);
				if(this.TemplateRemoved != null)
					this.TemplateRemoved(blacklistId, RawEvent.FromRaw(removedTemplate));
			};
		}
		
		/// <summary>
		/// Get the current blacklist templates.
		/// </summary>
		/// <returns>
		/// A dictionary of string as key and <see cref="T:System.Collection.Generic.List{Zeitgeist.Datamodel.Event>"/> as the Blacklist template
		/// </returns>
		public Dictionary<string, Event> GetTemplates()
		{
			Dictionary<string, RawEvent> rawBlackLists = srcInterface.GetTemplates();
			Dictionary<string, Event> eventList = new Dictionary<string, Event>();
			
			foreach(KeyValuePair<string, RawEvent> pair in rawBlackLists)
			{
				eventList.Add(pair.Key, RawEvent.FromRaw(pair.Value));
			}
			
			return eventList;
		}
		
		/// <summary>
		/// Add a blacklist template to the engine to stop the matching events to be inserted.
		/// If the event was inserted successfully then TemplateAdded event is raised
		/// </summary>
		/// <param name="blacklistId">
		/// The id of the blacklist template of the type <see cref="System.String"/>
		/// </param>
		/// <param name="eventTemplate">
		/// The actual event template of type <see cref="Event"/>
		/// </param>
		/// <remarks>
		/// The event template provided is used to match the event to be inserted. The Properties 
		/// not set are treated as wildcards. Timestamp is not taken under consideration
		/// </remarks>
		public void AddTemplate(string blacklistId, Event eventTemplate)
		{
			srcInterface.AddTemplate(blacklistId, RawEvent.FromEvent(eventTemplate));
		}
		
		/// <summary>
		/// Removes the blacklist from the engine if found.
		/// If the blacklist template was found and is removed then TemplateRemoved event is raised
		/// </summary>
		/// <param name="blacklistId">
		/// The blacklist template id for the template <see cref="System.String"/>
		/// </param>
		/// <remarks>
		/// If the blacklist does not exist. No event is raised
		/// </remarks>
		public void RemoveTemplate(string blacklistId)
		{
			srcInterface.RemoveTemplate(blacklistId);
		}
		
		/// <summary>
		/// Raised when a blacklist template is added
		/// </summary>
		/// <summary>
		/// When a new blacklist template is added to the engine, then this event is raised. 
		/// The delegate <see cref="Zeitgeist.BlacklistTemplateAddedHandler"/> is used for handle the events.
		/// This handler has two argument: 
		/// 'blacklistId' of type <see cref="string"/> and 
		/// 'addedTemplate' of type <see cref="Zeitgeist.Datamodel.Event"/>
		/// </summary>
		public event BlacklistTemplateAddedHandler TemplateAdded;
		
		/// <summary>
		/// Raised when a blacklist template is removed
		/// </summary>
		/// <summary>
		/// When a new blacklist template is removed to the engine, then this event is raised. 
		/// The delegate <see cref="Zeitgeist.BlacklistTemplateRemovedHandler"/> is used for handle the events.
		/// This handler has two argument: 
		/// 'blacklistId' of type <see cref="string"/> and 
		/// 'removedTemplate' of type <see cref="Zeitgeist.Datamodel.Event"/>
		/// </summary>
		public event BlacklistTemplateRemovedHandler TemplateRemoved;
		
		#region Private Fields
		
		private IBlacklist srcInterface;
		
		private static string objectPath = "/org/gnome/zeitgeist/blacklist";
		
		#endregion
	}
}

