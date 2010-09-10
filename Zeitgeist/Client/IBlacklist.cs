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
	[NDesk.DBus.Interface ("org.gnome.zeitgeist.Blacklist")]
	public interface IBlacklist
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

