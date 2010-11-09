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
	/// Enumeration class defining the possible values for the storage state of an event subject.
	/// The StorageState enumeration can be used to control whether or not matched events must have their subjects available to the user. 
	/// Ex. not including deleted files, files on unplugged USB drives, files available only when a network is available etc.
	/// </summary>
	public enum StorageState
	{
		/// <summary>
		/// The storage medium of the events subjects must not be available to the user. (Integer value: 0)
		/// </summary>
		NotAvailable = 0,
		
		/// <summary>
		/// The storage medium of all event subjects must be immediately available to the user. (Integer value: 1)
		/// </summary>
		Available = 1,
		
		/// <summary>
		/// The event subjects may or may not be available. (Integer value: 2)
		/// </summary>
		Any = 2
	}
}

