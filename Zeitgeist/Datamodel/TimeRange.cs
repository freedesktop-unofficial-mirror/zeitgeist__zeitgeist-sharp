using System;

namespace Zeitgeist.Datamodel
{
	/// <summary>
	/// The type which deals with Start and End time for an event.
	/// </summary>
	public class TimeRange
	{
		public TimeRange(Int64 startTime, Int64 endTime)
		{
			_begin = ZsUtils.ToDateTime((ulong)startTime);
			_end = ZsUtils.ToDateTime((ulong)endTime);
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
	
	internal struct RawTimeRange
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
		
		private Int64 _begin;
		
		private Int64 _end;
		
		#endregion
	}
}

