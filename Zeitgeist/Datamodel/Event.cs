using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Zeitgeist.Datamodel
{
	public class Event
	{ 
		public UInt64 Id;
		public UInt64 Timestamp;
		public string Actor;
		public string Interpretation;
		public string Manifestation;
		public List<Subject> Subjects;
		public byte[] Payload;
		
		public Event(){}
		public static Event FromRaw(RawEvent raw)
		{
			Event e = new Event();
			
			#region Metadata
			
			UInt64.TryParse(raw.metadata[(int)EventMetadataPosition.Id], out e.Id);			
			UInt64.TryParse(raw.metadata[(int)EventMetadataPosition.Timestamp], out e.Timestamp);			
			e.Actor = raw.metadata[(int)EventMetadataPosition.Actor];
			e.Interpretation = raw.metadata[(int)EventMetadataPosition.Interpretation];
			e.Manifestation = raw.metadata[(int)EventMetadataPosition.Manifestation];
			
			#endregion
			
			#region Subjects
			
			e.Subjects= new List<Subject>();
			
			for(int i = 0; i < raw.subjects.Length; i ++)
			{
				Subject sub = new Subject();
				string[] subjArr = raw.subjects[i];
				
				sub.Uri = subjArr[(int)EventSubjectPosition.Uri];
				sub.Origin = subjArr[(int)EventSubjectPosition.Origin];
				sub.MimeType = subjArr[(int)EventSubjectPosition.Mimetype];
				sub.Text = subjArr[(int)EventSubjectPosition.Text];
				sub.Storage = subjArr[(int)EventSubjectPosition.Storage];
				sub.Interpretation = subjArr[(int)EventSubjectPosition.Interpretation];
				sub.Manifestation = subjArr[(int)EventSubjectPosition.Manifestation];
				
				e.Subjects.Add(sub);
			}
			
			#endregion
			
			#region Payload
			
			e.Payload = raw.payload;
			
			#endregion
			
			return e;
		}
		public RawEvent GetRawEvent()
		{
			return RawEvent.FromEvent(this);
		}
	}
	
	public struct RawEvent 
	{
		public string[] metadata;
		public string[][] subjects;
		public byte[] payload;
		
		public RawEvent(string[] metadata, string[][] subjects, byte[] payload)
		{
			this.metadata = metadata;
			this.subjects = subjects;
			this.payload = payload;
		}
		
		public static RawEvent FromEvent(Event ev)
		{
			RawEvent raw = new RawEvent();
			
			#region MetaData
			
			int metaDataLength = Enum.GetNames(typeof(EventMetadataPosition)).Length;
			List<string> metaDataList = new List<string>(metaDataLength);
			
			for(int i=0; i< metaDataList.Capacity; i++)
				metaDataList.Add(null);
			
			metaDataList[(int)EventMetadataPosition.Id] = ev.Id.ToString();
			metaDataList[(int)EventMetadataPosition.Timestamp] = ev.Timestamp.ToString();
			metaDataList[(int)EventMetadataPosition.Actor] = ev.Actor;
			metaDataList[(int)EventMetadataPosition.Interpretation] = ev.Interpretation;
			metaDataList[(int)EventMetadataPosition.Manifestation] = ev.Manifestation;
			
			raw.metadata = metaDataList.ToArray();
			
			#endregion
			
			#region Subject
			
			List<string[]> subList= new List<string[]>();
			foreach(Subject sub in ev.Subjects)
			{
				#region Individual Subject
				
				int subLength = Enum.GetNames(typeof(EventSubjectPosition)).Length;
				List<string> subCont = new List<string>(subLength);
				
				for(int i=0; i< subCont.Capacity; i++)
					subCont.Add(null);
				
				subCont[(int)EventSubjectPosition.Uri] = sub.Uri;
				subCont[(int)EventSubjectPosition.Origin] = sub.Origin;
				subCont[(int)EventSubjectPosition.Mimetype] = sub.MimeType;
				subCont[(int)EventSubjectPosition.Text] = sub.Text;
				subCont[(int)EventSubjectPosition.Storage] = sub.Storage;
				subCont[(int)EventSubjectPosition.Interpretation] = sub.Interpretation;
				subCont[(int)EventSubjectPosition.Manifestation] = sub.Manifestation;
				
				subList.Add(subCont.ToArray());
				
				#endregion
			}
			
			raw.subjects = subList.ToArray();
			
			#endregion
			
			#region Payload
			
			raw.payload = ev.Payload;
			
			#endregion
			
			return raw;
		}
	}
	
	enum EventMetadataPosition
	{
		Id = 0,
		Timestamp = 1,
		Interpretation = 2,
		Manifestation = 3,
		Actor = 4
	}
	
	enum EventSubjectPosition
	{
		Uri = 0,
		Interpretation = 1, 
		Manifestation = 2, 
		Origin = 3, 
		Mimetype = 4,
		Text = 5,
		Storage = 6
	}
		                            
}

