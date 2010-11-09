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
	/// The type which deals with Start and End time for an event.
	/// </summary>
	public class TimeRange
	{
		public TimeRange()
		{
		}
		
		/// <summary>
		/// Create a TimeRange instance from the start and end values given as milliseconds since Epoch
		/// </summary>
		/// <param name="startTime">
		/// The start time. The millseconds since Epoch <see cref="Int64"/>
		/// </param>
		/// <param name="endTime">
		/// The end time. The millseconds since Epoch <see cref="Int64"/>
		/// </param>
		public TimeRange(Int64 startTime, Int64 endTime)
		{
			_begin = ZsUtils.ToDateTime((ulong)startTime);
			_end = ZsUtils.ToDateTime((ulong)endTime);
		}
		
		/// <summary>
		/// Create an instance of TimeRange from the values provided as per CLR DateTime instance representation
		/// </summary>
		/// <param name="startTime">
		/// The start time <see cref="DateTime"/>
		/// </param>
		/// <param name="endTime">
		/// The end time <see cref="DateTime"/>
		/// </param>
		public TimeRange(DateTime startTime, DateTime endTime)
		{
			_begin = startTime;
			_end = endTime;
		}
		
		/// <summary>
		/// The begin Timestamp of the event. Seconds elapsed since Epoch
		/// </summary>
		public DateTime Begin
		{
			get
			{
				return _begin;
			}
			set
			{
				_begin = value;
			}
		}
		
		/// <summary>
		/// The end Timestamp of the event. Seconds elapsed since Epoch
		/// </summary>
		public DateTime End
		{
			get
			{
				return _end;
			}
			set
			{
				_end = value;
			}
		}
		
		#region Private Fields
		
		private DateTime _begin;
		
		private DateTime _end;
		
		#endregion
	}
	
	internal class RawTimeRange
	{
		public Int64 Begin
		{
			get
			{
				return _begin;
			}
			set
			{
				_begin = value;
			}
		}
		
		public Int64 End
		{
			get
			{
				return _end;
			}
			set
			{
				_end = value;
			}
		}
		
		#region Private Fields
		
		public Int64 _begin;
		
		public Int64 _end;
		
		#endregion
	}
}

