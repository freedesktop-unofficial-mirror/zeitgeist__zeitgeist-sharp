using System;
using NUnit.Framework;
using Zeitgeist.Datamodel;

namespace Zeitgeist.Testsuite
{
	[TestFixture()]
	public class TestManifestation
	{
		#region Manifestation
		
		[Test()]
		public void TestCalendarDataObject()
		{
			Assert.AreEqual(Manifestation.Instance.CalendarDataObject.Name, "CalendarDataObject");
			Assert.AreEqual(Manifestation.Instance.CalendarDataObject.Uri, "http://www.semanticdesktop.org/ontologies/2007/04/02/ncal#CalendarDataObject");
		}
		
		[Test()]
		public void TestHardDiskPartition()
		{
			Assert.AreEqual(Manifestation.Instance.HardDiskPartition.Name, "HardDiskPartition");
			Assert.AreEqual(Manifestation.Instance.HardDiskPartition.Uri, "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#HardDiskPartition");
		}
		
		[Test()]
		public void TestMailboxDataObject()
		{
			Assert.AreEqual(Manifestation.Instance.MailboxDataObject.Name, "MailboxDataObject");
			Assert.AreEqual(Manifestation.Instance.MailboxDataObject.Uri, "http://www.semanticdesktop.org/ontologies/2007/03/22/nmo#MailboxDataObject");
		}
		
		[Test()]
		public void TestMediaStream()
		{
			Assert.AreEqual(Manifestation.Instance.MediaStream.Name, "MediaStream");
			Assert.AreEqual(Manifestation.Instance.MediaStream.Uri, "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#MediaStream");
		}
		
		[Test()]
		public void TestRemotePortAddress()
		{
			Assert.AreEqual(Manifestation.Instance.RemotePortAddress.Name, "RemotePortAddress");
			Assert.AreEqual(Manifestation.Instance.RemotePortAddress.Uri, "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#RemotePortAddress");
		}
		
		[Test()]
		public void TestSoftwareItem()
		{
			Assert.AreEqual(Manifestation.Instance.SoftwareItem.Name, "SoftwareItem");
			Assert.AreEqual(Manifestation.Instance.SoftwareItem.Uri, "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#SoftwareItem");
		}
		
		[Test()]
		public void TestSoftwareService()
		{
			Assert.AreEqual(Manifestation.Instance.SoftwareService.Name, "SoftwareService");
			Assert.AreEqual(Manifestation.Instance.SoftwareService.Uri, "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#SoftwareService");
		}
		
		#endregion
		
		#region EventManifestation
		
		[Test()]
		public void TestEventManifestation()
		{
			Assert.AreEqual(Manifestation.Instance.EventManifestation.EventManifestation.Name, "EventManifestation");
			Assert.AreEqual(Manifestation.Instance.EventManifestation.EventManifestation.Uri, "http://www.zeitgeist-project.com/ontologies/2010/01/27/zg#EventManifestation");
		}
		
		[Test()]
		public void TestHeuristicActivity()
		{
			Assert.AreEqual(Manifestation.Instance.EventManifestation.HeuristicActivity.Name, "HeuristicActivity");
			Assert.AreEqual(Manifestation.Instance.EventManifestation.HeuristicActivity.Uri, "http://www.zeitgeist-project.com/ontologies/2010/01/27/zg#HeuristicActivity");
		}
		
		[Test()]
		public void TestScheduledActivity()
		{
			Assert.AreEqual(Manifestation.Instance.EventManifestation.ScheduledActivity.Name, "ScheduledActivity");
			Assert.AreEqual(Manifestation.Instance.EventManifestation.ScheduledActivity.Uri, "http://www.zeitgeist-project.com/ontologies/2010/01/27/zg#ScheduledActivity");
		}
		
		[Test()]
		public void TestSystemNotification()
		{
			Assert.AreEqual(Manifestation.Instance.EventManifestation.SystemNotification.Name, "SystemNotification");
			Assert.AreEqual(Manifestation.Instance.EventManifestation.SystemNotification.Uri, "http://www.zeitgeist-project.com/ontologies/2010/01/27/zg#SystemNotification");
		}
		
		[Test()]
		public void TestUserActivity()
		{
			Assert.AreEqual(Manifestation.Instance.EventManifestation.UserActivity.Name, "ScheduledActivity");
			Assert.AreEqual(Manifestation.Instance.EventManifestation.UserActivity.Uri, "http://www.zeitgeist-project.com/ontologies/2010/01/27/zg#UserActivity");
		}
		
		[Test()]
		public void TestWorldActivity()
		{
			Assert.AreEqual(Manifestation.Instance.EventManifestation.WorldActivity.Name, "WorldActivity");
			Assert.AreEqual(Manifestation.Instance.EventManifestation.WorldActivity.Uri, "http://www.zeitgeist-project.com/ontologies/2010/01/27/zg#WorldActivity");
		}
		
		#endregion
		
		#region FileDataObject
		
		[Test()]
		public void TestFileDataObject()
		{
			Assert.AreEqual(Manifestation.Instance.FileDataObject.FileDataObject.Name, "FileDataObject");
			Assert.AreEqual(Manifestation.Instance.FileDataObject.FileDataObject.Uri, "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#FileDataObject");
		}
		
		[Test()]
		public void TestDeletedResource()
		{
			Assert.AreEqual(Manifestation.Instance.FileDataObject.DeletedResource.Name, "DeletedResource");
			Assert.AreEqual(Manifestation.Instance.FileDataObject.DeletedResource.Uri, "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#DeletedResource");
		}
		
		[Test()]
		public void TestRemoteDataObject()
		{
			Assert.AreEqual(Manifestation.Instance.FileDataObject.RemoteDataObject.Name, "RemoteDataObject");
			Assert.AreEqual(Manifestation.Instance.FileDataObject.RemoteDataObject.Uri, "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#RemoteDataObject");
		}
		
		[Test()]
		public void TestEmbeddedFileDataObject()
		{
			Assert.AreEqual(Manifestation.Instance.FileDataObject.EmbeddedFileDataObject.EmbeddedFileDataObject.Name, "EmbeddedFileDataObject");
			Assert.AreEqual(Manifestation.Instance.FileDataObject.EmbeddedFileDataObject.EmbeddedFileDataObject.Uri, "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#EmbeddedFileDataObject");
		}
		
		[Test()]
		public void TestArchiveItem()
		{
			Assert.AreEqual(Manifestation.Instance.FileDataObject.EmbeddedFileDataObject.ArchiveItem.Name, "ArchiveItem");
			Assert.AreEqual(Manifestation.Instance.FileDataObject.EmbeddedFileDataObject.ArchiveItem.Uri, "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#ArchiveItem");
		}
		
		[Test()]
		public void TestAttachment()
		{
			Assert.AreEqual(Manifestation.Instance.FileDataObject.EmbeddedFileDataObject.Attachment.Name, "Attachment");
			Assert.AreEqual(Manifestation.Instance.FileDataObject.EmbeddedFileDataObject.Attachment.Uri, "http://www.semanticdesktop.org/ontologies/2007/04/02/ncal#Attachment");
		}
		
		#endregion
	}
}

