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

namespace Zeitgeist
{
	/// <summary>
	/// This signal is emitted whenever the last running instance of a data-source disconnects.
	/// </summary>
	/// <param name="datasource">
	/// The disconnected data-source of type <see cref="Zeitgeist.Datamodel.DataSource"/>
	/// </param>
	public delegate void DataSourceDisconnectedHandler(DataSource datasource);
		
	/// <summary>
	/// This signal is emitted whenever a data-source is enabled or disabled.
	/// </summary>
	/// <param name="dataSourceValue">
	/// Unique string identifier of a data-source<see cref="System.String"/>
	/// </param>
	/// <param name="dataSourceValue">
	/// true if it was enabled false if it was disabled. <see cref="System.Boolean"/>
	/// </param>
	public delegate void DataSourceEnabledHandler(string dataSourceValue, bool enabled);
	
	/// <summary>
	/// This signal is emitted whenever a data-source registers itself.
	/// </summary>
	/// <param name="datasource">
	/// The registered data-source of type <see cref="Zeitgeist.Datamodel.DataSource"/>
	/// </param>
	public delegate void DataSourceRegisteredHandler(DataSource datasource);
	
	/// <summary>
	/// This delegate handler for the event related to Blacklist Template addition
	/// </summary>
	/// <param name="blacklistId">
	/// The blacklist ID of type <see cref="string"/>
	/// </param>
	/// <param name="addedTemplate">
	/// The blacklist template added
	/// </param>
	public delegate void BlacklistTemplateAddedHandler(string blacklistId, Event addedTemplate);
	
	/// <summary>
	/// This delegate handler for the event related to Blacklist Template deletion
	/// </summary>
	/// <param name="blacklistId">
	/// The blacklist ID of type <see cref="string"/>
	/// </param>
	/// <param name="removedTemplate">
	/// The blacklist template removed
	/// </param>
	public delegate void BlacklistTemplateRemovedHandler(string blacklistId, Event removedTemplate);
}

