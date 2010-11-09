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

