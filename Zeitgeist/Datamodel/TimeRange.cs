using System;

namespace Zeitgeist.Datamodel
{
	/// <summary>
	/// The type which deals with Start and End time for an event.
	/// </summary>
	public struct TimeRange
	{
		public TimeRange(DateTime startTime, DateTime endTime)
		{
			_begin = startTime;
			_end = endTime;
		}
		/// <summary>
		/// The begin Timestamp of the event. Seconds elapsed since Epoch
		/// </summary>
		public Int64 Begin
		{
			get
			{
				return (Int64)ZsUtils.ToTimestamp(_begin);
			}
			set
			{
				_begin = ZsUtils.ToDateTime((ulong)value);
			}
		}
		
		/// <summary>
		/// The end Timestamp of the event. Seconds elapsed since Epoch
		/// </summary>
		public Int64 End
		{
			get
			{
				return (Int64)ZsUtils.ToTimestamp(_end);
			}
			set
			{
				_end = ZsUtils.ToDateTime((ulong)value);
			}
		}
		
		#region Private Fields
		
		private DateTime _begin;
		
		private DateTime _end;
		
		#endregion
	}
}

