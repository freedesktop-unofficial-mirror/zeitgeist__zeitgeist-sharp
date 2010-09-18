using System;
using System.Collections.Generic;

namespace Zeitgeist.Datamodel
{
	/// <summary>
	/// Represents a subject of an Event
	/// </summary>
	public struct Subject
	{
		/// <summary>
		/// URI of the subject
		/// </summary>
		public string Uri
		{
			get; set;
		}
		
		/// <summary>
		/// URI of the location where the subject resides or where it can be said to originate from
		/// </summary>
		public string Origin
		{
			get; set;
		}
		
		/// <summary>
		/// Containing the mimetype of the subject (encoded as a string) if applicable
		/// Ex text/plain
		/// </summary>
		public string MimeType
		{
			get; set;
		}
		
		/// <summary>
		/// Free form textual annotation of the subject
		/// </summary>
		public string Text
		{
			get; set;
		}
		
		/// <summary>
		/// string id of the storage medium where the subject is stored. 
		/// Ex. the UUID of the disk partition or just the string ‘net’ for items requiring network interface to be available
		/// </summary>
		public string Storage 
		{
			get; set;
		}
		
		/// <summary>
		/// Interpretation of the Subject
		/// </summary>
		public KeyValuePair<string, string> Interpretation
		{
			get; set;
		}
		
		/// <summary>
		/// Manifestation of the Subject
		/// </summary>
		public KeyValuePair<string, string> Manifestation
		{
			get; set;
		}
	}
}

