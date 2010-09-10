using System;
using System.Collections.Generic;
using Zeitgeist.Datamodel;
using Zeitgeist.Client;
using NDesk.DBus;

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
		/// Get the current blacklist templates.
		/// </summary>
		/// <returns>
		/// A list of <see cref="T:System.Collection.Generic.List{Zeitgeist.Datamodel.Event>"/> Blacklist Event templates 
		/// </returns>
		public static List<Event> GetBlacklist()
		{
			// Get the DBus interface for Blacklist
			IBlacklist srcInterface = ZsUtils.GetDBusObject<IBlacklist>(objectPath);
			
			RawEvent[] rawBlackLists = srcInterface.GetBlacklist();
			return ZsUtils.FromRawEventList(rawBlackLists);
		}
		
		/// <summary>
		/// Set the blacklist to event_templates. 
		/// </summary>
		/// Events matching any these templates will be blocked from insertion into the log. 
		/// It is still possible to find and look up events matching the blacklist which was inserted before the blacklist banned them.
		/// <remarks>
		/// </remarks>
		/// <param name="eventTemplates">
		/// A List of <see cref="T:System.Collection.Generic.List{Zeitgeist.Datamodel.Event>"/> Event templates 
		/// </param>
		public static void SetBlacklist(List<Event> eventTemplates)
		{
			// Get the DBus interface for Blacklist
			IBlacklist srcInterface = ZsUtils.GetDBusObject<IBlacklist>(objectPath);
			
			List<RawEvent> events = ZsUtils.ToRawEventList(eventTemplates);
			srcInterface.SetBlacklist(events.ToArray());
		}
		
		private static string objectPath = "/org/gnome/zeitgeist/blacklist";
	}
}

