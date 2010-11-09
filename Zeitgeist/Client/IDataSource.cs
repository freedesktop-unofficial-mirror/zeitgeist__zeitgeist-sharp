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
	/// The Zeitgeist engine maintains a publicly available list of recognized data-sources 
	/// (components inserting information into Zeitgeist). An option to disable such data-providers is also provided.
	/// </summary>
	[NDesk.DBus.Interface ("org.gnome.zeitgeist.DataSourceRegistry")]
	internal interface IDataSource
	{
		/// <summary>
		/// Get the list of known data-sources.
		/// </summary>
		/// <returns>
		/// A list of RawDataSource <see cref="RawDataSource[]"/>
		/// </returns>
		RawDataSource[] GetDataSources();
		
		/// <summary>
		/// Register a data-source as currently running. 
		/// If the data-source was already in the database, its metadata (name, description and event_templates) are updated.
		/// </summary>
		/// <param name="unique_id">
		/// The uniqueId DataSource <see cref="System.String"/>
		/// </param>
		/// <param name="name">
		/// The name of the DataSource <see cref="System.String"/>
		/// </param>
		/// <param name="description">
		/// Description of DataSource <see cref="System.String"/>
		/// </param>
		/// <param name="events">
		/// A list of RawEvent templates <see cref="RawEvent[]"/>
		/// </param>
		/// <returns>
		/// true is successful, false otherwise <see cref="System.Boolean"/>
		/// </returns>
		bool RegisterDataSources(string unique_id, string name, string description, RawEvent[] events);
		
		/// <summary>
		/// Enables/Disables the DataSource identified by a uniqueId
		/// </summary>
		/// <param name="unique_id">
		/// The uniqueId of the DataSource <see cref="System.String"/>
		/// </param>
		/// <param name="enabled">
		/// Is the DataSource to be enabled(true) or disabled(false)  <see cref="System.Boolean"/>
		/// </param>
		void SetDataSourceEnabled(string unique_id, bool enabled);
		
		/// <summary>
		/// This signal is emitted whenever the last running instance of a data-source disconnects.
		/// </summary>
		event DataSourceDisconnectedHandler DataSourceDisconnected;
		
		/// <summary>
		/// This signal is emitted whenever a data-source is enabled or disabled.
		/// </summary>
		event DataSourceEnabledHandler DataSourceEnabled;
		
		/// <summary>
		/// This signal is emitted whenever a data-source registers itself.
		/// </summary>
		event DataSourceRegisteredHandler DataSourceRegistered;
	}
}

