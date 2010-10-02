using System;
using org.freedesktop;
using org.freedesktop.DBus;
using System.Collections.Generic;

namespace Zeitgeist.Datamodel
{
	/// <summary>
	/// The type which holds a pair of values. The pair is Name and Uri
	/// </summary>
	public class NameUri
	{
		public NameUri()
		{
			Name = string.Empty;
			Uri = string.Empty;
		}
			
		public NameUri(string name, string uri)
		{
			Name = name;
			Uri = uri;
		}
		
		/// <summary>
		/// The name associated with this container type
		/// </summary>
		public string Name { get; set;}
		
		/// <summary>
		/// The Uri associated with this container type
		/// </summary>
		public string Uri { get; set;}
	}
}

