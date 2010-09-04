using System;
namespace Zeitgeist.ZeitgeistSharp.Datamodel
{
	public struct Subject
	{
		public string Uri { get; set; }
		public string Origin { get; set; }
		public string MimeType { get; set; }
		public string Text { get; set; }
		public string Storage { get; set; }
	}
}

