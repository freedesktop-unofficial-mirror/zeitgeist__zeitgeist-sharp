using System;
namespace Zeitgeist.ZeitgeistSharp.Datamodel
{
	public struct Event
	{
		public string[] MetaData { get; set; }
		public string[][] Subjects { get; set; }
		public byte[] Payload { get; set; }
	}
}

