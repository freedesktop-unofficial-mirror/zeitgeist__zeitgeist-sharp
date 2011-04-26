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
	/// Optimized and convenient data structure representing a datasource.
	/// </summary>
	public class DataSource 
	{
		/// <summary>
		/// The Id of the DataSource
		/// </summary>
		public string UniqueId
		{
			get;set;
		}
		
		/// <summary>
		/// The Name of the DataSource
		/// </summary>
		public string Name
		{
			get;set;
		}
		
		/// <summary>
		/// The Description of the DataSource
		/// </summary>
		public string Description
		{
			get;set;
		}
		
		/// <summary>
		/// The list of Events associated with this DataSource
		/// </summary>
		public List<Event> Events
		{
			get;set;
		}
		
		/// <summary>
		/// Is the datasouce running : TODO
		/// </summary>
		public bool Running
		{
			get;set;
		}
		
		/// <summary>
		/// Last time the DataSource did something
		/// </summary>
		public long LastSeen
		{
			get;set;
		}
		
		/// <summary>
		/// Is the DataSource Enabled : TODO
		/// </summary>
		public bool Enabled
		{
			get;set;
		}
		
		
	}
	
	/// <summary>
	/// A raw DBus  based representation of Event
	/// </summary>
	internal struct RawDataSource
	{
		/// <summary>
		/// The Id of the RawDataSource
		/// </summary>
		public string UniqueId
		{
			get
			{
				return _uniqueId;
			}
			set
			{
				_uniqueId = value;
			}
		}
		
		/// <summary>
		/// The Name of the RawDataSource
		/// </summary>
		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
			}
		}
		
		/// <summary>
		/// The Description of the RawDataSource
		/// </summary>
		public string Description
		{
			get
			{
				return _description;
			}
			set
			{
				_description = value;
			}
		}
		
		/// <summary>
		/// The list of RawEvents associated with this RawDataSource
		/// </summary>
		public RawEvent[] RawEvents
		{
			get
			{
				return _rawEvents;
			}
			set
			{
				_rawEvents = value;
			}
		}
		
		/// <summary>
		/// Is the datasouce running : TODO
		/// </summary>
		public bool Running
		{
			get
			{
				return _running;
			}
			set
			{
				_running = value;
			}
		}
		
		/// <summary>
		/// Last time the RawDataSource did something
		/// </summary>
		public UInt64 LastSeen
		{
			get
			{
				return _lastSeen;
			}
			set
			{
				_lastSeen = value;
			}
		}
		
		/// <summary>
		/// Is the DataSource Enabled : TODO
		/// </summary>
		public bool Enabled
		{
			get
			{
				return _enabled;
			}
			set
			{
				_enabled = value;
			}
		}
		
		/// <summary>
		/// A constructor for creating a RawDataSource. Even though the functiionality is provided,
		/// still please create an instance of DartaSource and then use DataSource.ToRaw()
		/// </summary>
		/// <param name="uid">
		/// The RawDataSource id <see cref="System.String"/>
		/// </param>
		/// <param name="name">
		/// The name of the Source <see cref="System.String"/>
		/// </param>
		/// <param name="desc">
		/// The description of the Source  <see cref="System.String"/>
		/// </param>
		/// <param name="events">
		/// The RawEvents associated with this RawDataSource <see cref="RawEvent[]"/>
		/// </param>
		/// <param name="running">
		/// is the RawDataSource running <see cref="System.Boolean"/>
		/// </param>
		/// <param name="Lastseen">
		/// When was the last time RawDataSource was seen <see cref="UInt64"/>
		/// </param>
		/// <param name="enabled">
		/// Is the RawDataSource enabled <see cref="System.Boolean"/>
		/// </param>
		public RawDataSource(string uid, string name, string desc, RawEvent[] events, bool running, UInt64 Lastseen, bool enabled) : this()
		{
			this.UniqueId = uid;
			this.Name = name;
			this.Description = desc;
			this.RawEvents = events;
			this.Running = running;
			this.LastSeen = Lastseen;
			this.Enabled = enabled;
		}
		
		/// <summary>
		/// Convert an object of type RawDataSource to DataSource
		/// </summary>
		/// <param name="raw">
		/// An instance of RawDataSource <see cref="RawDataSource"/>
		/// </param>
		/// <returns>
		/// An instance of DataSource <see cref="DataSource"/>
		/// </returns>
		public static DataSource FromRaw(RawDataSource  raw)
		{
			DataSource src = new DataSource();
			
			src.UniqueId = raw.UniqueId;
			src.Name = raw.Name;
			src.Description = raw.Description;
			src.Running = raw.Running;
			src.LastSeen = long.Parse(raw.LastSeen.ToString());
			src.Enabled = raw.Enabled;
			
			if(raw.RawEvents != null)
			{
				src.Events = new List<Event>();
				foreach(RawEvent evn in raw.RawEvents)
				{
					Event ev = RawEvent.FromRaw(evn);
					src.Events.Add(ev);
				}
			}
			
			return src;
		}
		
		/// <summary>
		/// Convert an object of type DataSource to RawDataSource
		/// </summary>
		/// <param name="src">
		/// An instance of DataSource <see cref="Zeitgeist.Datamodel.DataSource"/>
		/// </param>
		/// <returns>
		/// An instance of RawDataSource <see cref="Zeitgeist.Datamodel.RawDataSource"/>
		/// </returns>
		public static RawDataSource ToRaw(DataSource src)
		{
			RawDataSource raw = new RawDataSource();
			
			raw.UniqueId = src.UniqueId;
			raw.Name = src.Name;
			raw.Description = src.Description;
			raw.Running = src.Running;
			raw.LastSeen = UInt64.Parse(src.LastSeen.ToString());
			raw.Enabled = src.Enabled;
			
			if(raw.RawEvents != null)
			{
				List<RawEvent> events = new List<RawEvent>();
				foreach(Event evn in src.Events)
				{
					RawEvent ev = evn.GetRawEvent();
					events.Add(ev);
				}
			}
			
			return raw;
		}
		
		#region Private Fields
		
		private string _uniqueId;
		private string _name;
		private string _description;
		private RawEvent[] _rawEvents;
		private bool _running;
		private UInt64 _lastSeen;
		private bool _enabled;
		
		#endregion
	}
}

