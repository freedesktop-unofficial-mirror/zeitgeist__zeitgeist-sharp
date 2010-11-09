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

namespace Zeitgeist.Datamodel
{
	/// <summary>
	/// Represents a subject of an Event
	/// </summary>
	public class Subject
	{
		public Subject()
		{
			Uri = string.Empty;
			Origin = string.Empty;
			MimeType = string.Empty;
			Text = string.Empty;
			Storage = string.Empty;
			Interpretation = new NameUri();
			Manifestation = new NameUri();
		}
		
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
		public NameUri Interpretation
		{
			get; set;
		}
		
		/// <summary>
		/// Manifestation of the Subject
		/// </summary>
		public NameUri Manifestation
		{
			get; set;
		}
	}
}

