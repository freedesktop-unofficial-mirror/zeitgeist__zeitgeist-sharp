using System;

namespace Zeitgeist.Datamodel
{
	public class Event
	{ 
		private int Timestamp { get; set; }
		private string Actor { get; set; }
		private string Interpretation { get; set; }
		private string Manifestation { get; set; }
		private Subject[] Subjects { get; set; }
		
		public Event(){}
		public static Event FromRaw(RawEvent raw)
		{
			Event e = new Event();
			/*
			 * assign e properties here
			 */
			return e;
		}
		public RawEvent GetRawEvent()
		{
			return RawEvent.FromEvent(this);
		}
	}
	
	public struct RawEvent 
	{
		public string[] metadata { get; set; }
		public string[][] subjects { get; set; }
		public byte[] payload { get; set; } 
		
		public RawEvent(string[] metadata, string[][] subjects, byte[] payload)
		{
			this.metadata = metadata;
			this.subjects = subjects;
			this.payload = payload;
		}
		
		public static RawEvent FromEvent(Event ev)
		{
			RawEvent raw = new RawEvent();
			/*
			 * assign rae properties here
			 */
			return raw;
		}
	}           
		                            
}

