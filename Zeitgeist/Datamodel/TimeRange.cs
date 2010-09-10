using System;

namespace Zeitgeist.Datamodel
{
	/// <summary>
	/// The type which deals with Start and End time for an event.
	/// </summary>
	public struct TimeRange
	{
		/// <summary>
		/// The begin Timestamp of the event. Seconds elapsed since Epoch
		/// </summary>
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
		
		/// <summary>
		/// The end Timestamp of the event. Seconds elapsed since Epoch
		/// </summary>
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

