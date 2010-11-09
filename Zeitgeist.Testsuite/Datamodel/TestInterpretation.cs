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
using NUnit.Framework;
using Zeitgeist.Datamodel;

namespace Zeitgeist.Testsuite
{
	[TestFixture()]
	public class TestInterpretation
	{
		#region Interpretation
		
		[Test()]
		public void TestAlarm()
		{
			Assert.AreEqual(Interpretation.Instance.Alarm.Name, "Alarm");
			Assert.AreEqual(Interpretation.Instance.Alarm.Uri, "http://www.semanticdesktop.org/ontologies/2007/04/02/ncal#Alarm");
		}
		
		[Test()]
		public void TestBookmark()
		{
			Assert.AreEqual(Interpretation.Instance.Bookmark.Name, "Bookmark");
			Assert.AreEqual(Interpretation.Instance.Bookmark.Uri, "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Bookmark");
		}
		
		[Test()]
		public void TestBookmarkFolder()
		{
			Assert.AreEqual(Interpretation.Instance.BookmarkFolder.Name, "BookmarkFolder");
			Assert.AreEqual(Interpretation.Instance.BookmarkFolder.Uri, "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#BookmarkFolder");
		}
		
		[Test()]
		public void TestCalendar()
		{
			Assert.AreEqual(Interpretation.Instance.Calendar.Name, "Calendar");
			Assert.AreEqual(Interpretation.Instance.Calendar.Uri, "http://www.semanticdesktop.org/ontologies/2007/04/02/ncal#Calendar");
		}
		
		[Test()]
		public void TestEvent()
		{
			Assert.AreEqual(Interpretation.Instance.Event.Name, "Event");
			Assert.AreEqual(Interpretation.Instance.Event.Uri, "http://www.semanticdesktop.org/ontologies/2007/04/02/ncal#Event");
		}
		
		[Test()]
		public void TestExecutable()
		{
			Assert.AreEqual(Interpretation.Instance.Executable.Name, "Executable");
			Assert.AreEqual(Interpretation.Instance.Executable.Uri, "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Executable");
		}
		
		[Test()]
		public void TestFont()
		{
			Assert.AreEqual(Interpretation.Instance.Font.Name, "Font");
			Assert.AreEqual(Interpretation.Instance.Font.Uri, "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Font");
		}
		
		[Test()]
		public void TestFreebusy()
		{
			Assert.AreEqual(Interpretation.Instance.Freebusy.Name, "Freebusy");
			Assert.AreEqual(Interpretation.Instance.Freebusy.Uri, "http://www.semanticdesktop.org/ontologies/2007/04/02/ncal#Freebusy");
		}
		
		[Test()]
		public void TestJournal()
		{
			Assert.AreEqual(Interpretation.Instance.Journal.Name, "Journal");
			Assert.AreEqual(Interpretation.Instance.Journal.Uri, "http://www.semanticdesktop.org/ontologies/2007/04/02/ncal#Journal");
		}
		
		[Test()]
		public void TestMailbox()
		{
			Assert.AreEqual(Interpretation.Instance.Mailbox.Name, "Mailbox");
			Assert.AreEqual(Interpretation.Instance.Mailbox.Uri, "http://www.semanticdesktop.org/ontologies/2007/03/22/nmo#Mailbox");
		}
		
		[Test()]
		public void TestMimeEntity()
		{
			Assert.AreEqual(Interpretation.Instance.MimeEntity.Name, "MimeEntity");
			Assert.AreEqual(Interpretation.Instance.MimeEntity.Uri, "http://www.semanticdesktop.org/ontologies/2007/03/22/nmo#MimeEntity");
		}
		
		[Test()]
		public void TestTimezone()
		{
			Assert.AreEqual(Interpretation.Instance.Timezone.Name, "Timezone");
			Assert.AreEqual(Interpretation.Instance.Timezone.Uri, "http://www.semanticdesktop.org/ontologies/2007/04/02/ncal#Timezone");
		}
		
		[Test()]
		public void TestTodo()
		{
			Assert.AreEqual(Interpretation.Instance.Todo.Name, "Todo");
			Assert.AreEqual(Interpretation.Instance.Todo.Uri, "http://www.semanticdesktop.org/ontologies/2007/04/02/ncal#Todo");
		}
		
		[Test()]
		public void TestTVSeries()
		{
			Assert.AreEqual(Interpretation.Instance.TVSeries.Name, "TVSeries");
			Assert.AreEqual(Interpretation.Instance.TVSeries.Uri, "http://www.semanticdesktop.org/ontologies/2009/02/19/nmm#TVSeries");
		}
		
		[Test()]
		public void TestWebsite()
		{
			Assert.AreEqual(Interpretation.Instance.Website.Name, "Website");
			Assert.AreEqual(Interpretation.Instance.Website.Uri, "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Website");
		}
		
		#endregion
		
		#region DataContainer
		
		[Test()]
		public void TestDataContainer()
		{
			Assert.AreEqual(Interpretation.Instance.DataContainer.DataContainer.Name, "DataContainer");
			Assert.AreEqual(Interpretation.Instance.DataContainer.DataContainer.Uri, "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#DataContainer");
		}
		
		[Test()]
		public void TestDataContainerArchive()
		{
			Assert.AreEqual(Interpretation.Instance.DataContainer.Archive.Name, "Archive");
			Assert.AreEqual(Interpretation.Instance.DataContainer.Archive.Uri, "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Archive");
		}
		
		[Test()]
		public void TestDataContainerFolder()
		{
			Assert.AreEqual(Interpretation.Instance.DataContainer.Folder.Name, "Folder");
			Assert.AreEqual(Interpretation.Instance.DataContainer.Folder.Uri, "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Folder");
		}
		
		[Test()]
		public void TestDataContainerTrash()
		{
			Assert.AreEqual(Interpretation.Instance.DataContainer.Trash.Name, "Trash");
			Assert.AreEqual(Interpretation.Instance.DataContainer.Trash.Uri, "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Trash");
		}
		
		#endregion
		
		#region FileSystem
		
		[Test()]
		public void TestDataContainerFilesystemImage()
		{
			Assert.AreEqual(Interpretation.Instance.DataContainer.Filesystem.FilesystemImage.Name, "FilesystemImage");
			Assert.AreEqual(Interpretation.Instance.DataContainer.Filesystem.FilesystemImage.Uri, "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#FilesystemImage");
		}
		
		[Test()]
		public void TestDataContainerFilesystem()
		{
			Assert.AreEqual(Interpretation.Instance.DataContainer.Filesystem.Filesystem.Name, "Filesystem");
			Assert.AreEqual(Interpretation.Instance.DataContainer.Filesystem.Filesystem.Uri, "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Filesystem");
		}
		
		#endregion
		
		#region Document
		
		[Test()]
		public void TestDocument()
		{
			Assert.AreEqual(Interpretation.Instance.Document.Document.Name, "Document");
			Assert.AreEqual(Interpretation.Instance.Document.Document.Uri, "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Document");
		}
		
		[Test()]
		public void TestDocumentMindMap()
		{
			Assert.AreEqual(Interpretation.Instance.Document.MindMap.Name, "MindMap");
			Assert.AreEqual(Interpretation.Instance.Document.MindMap.Uri, "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#MindMap");
		}
		
		[Test()]
		public void TestDocumentPresentation()
		{
			Assert.AreEqual(Interpretation.Instance.Document.Presentation.Name, "Presentation");
			Assert.AreEqual(Interpretation.Instance.Document.Presentation.Uri, "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Presentation");
		}
		
		[Test()]
		public void TestDocumentSpreadsheet()
		{
			Assert.AreEqual(Interpretation.Instance.Document.Spreadsheet.Name, "Spreadsheet");
			Assert.AreEqual(Interpretation.Instance.Document.Spreadsheet.Uri, "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Spreadsheet");
		}
		
		[Test()]
		public void TestDocumentTextDocument()
		{
			Assert.AreEqual(Interpretation.Instance.Document.TextDocument.TextDocument.Name, "TextDocument");
			Assert.AreEqual(Interpretation.Instance.Document.TextDocument.TextDocument.Uri, "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#TextDocument");
		}
		
		[Test()]
		public void TestDocumentPaginatedTextDocument()
		{
			Assert.AreEqual(Interpretation.Instance.Document.TextDocument.PaginatedTextDocument.Name, "PaginatedTextDocument");
			Assert.AreEqual(Interpretation.Instance.Document.TextDocument.PaginatedTextDocument.Uri, "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#PaginatedTextDocument");
		}
		
		[Test()]
		public void TestDocumentPlainTextDocument()
		{
			Assert.AreEqual(Interpretation.Instance.Document.TextDocument.PlainTextDocument.PlainTextDocument.Name, "PlainTextDocument");
			Assert.AreEqual(Interpretation.Instance.Document.TextDocument.PlainTextDocument.PlainTextDocument.Uri, "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#PlainTextDocument");
		}
		
		[Test()]
		public void TestDocumentHtmlDocument()
		{
			Assert.AreEqual(Interpretation.Instance.Document.TextDocument.PlainTextDocument.HtmlDocument.Name, "HtmlDocument");
			Assert.AreEqual(Interpretation.Instance.Document.TextDocument.PlainTextDocument.HtmlDocument.Uri, "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#HtmlDocument");
		}
		
		[Test()]
		public void TestDocumentSourceCode()
		{
			Assert.AreEqual(Interpretation.Instance.Document.TextDocument.PlainTextDocument.SourceCode.Name, "SourceCode");
			Assert.AreEqual(Interpretation.Instance.Document.TextDocument.PlainTextDocument.SourceCode.Uri, "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#SourceCode");
		}
		
		#endregion
		
		#region EventInterpretation
		
		[Test()]
		public void TestEventInterpretation()
		{
			Assert.AreEqual(Interpretation.Instance.EventInterpretation.EventInterpretation.Name, "EventInterpretation");
			Assert.AreEqual(Interpretation.Instance.EventInterpretation.EventInterpretation.Uri, "http://www.zeitgeist-project.com/ontologies/2010/01/27/zg#EventInterpretation");
		}
		
		[Test()]
		public void TestAccessEvent()
		{
			Assert.AreEqual(Interpretation.Instance.EventInterpretation.AccessEvent.Name, "AccessEvent");
			Assert.AreEqual(Interpretation.Instance.EventInterpretation.AccessEvent.Uri, "http://www.zeitgeist-project.com/ontologies/2010/01/27/zg#AccessEvent");
		}
		
		[Test()]
		public void TestCreateEvent()
		{
			Assert.AreEqual(Interpretation.Instance.EventInterpretation.CreateEvent.Name, "CreateEvent");
			Assert.AreEqual(Interpretation.Instance.EventInterpretation.CreateEvent.Uri, "http://www.zeitgeist-project.com/ontologies/2010/01/27/zg#CreateEvent");
		}
		
		[Test()]
		public void TestDeleteEvent()
		{
			Assert.AreEqual(Interpretation.Instance.EventInterpretation.DeleteEvent.Name, "DeleteEvent");
			Assert.AreEqual(Interpretation.Instance.EventInterpretation.DeleteEvent.Uri, "http://www.zeitgeist-project.com/ontologies/2010/01/27/zg#DeleteEvent");
		}
		
		[Test()]
		public void TestLeaveEvent()
		{
			Assert.AreEqual(Interpretation.Instance.EventInterpretation.LeaveEvent.Name, "LeaveEvent");
			Assert.AreEqual(Interpretation.Instance.EventInterpretation.LeaveEvent.Uri, "http://www.zeitgeist-project.com/ontologies/2010/01/27/zg#LeaveEvent");
		}
		
		[Test()]
		public void TestModifyEvent()
		{
			Assert.AreEqual(Interpretation.Instance.EventInterpretation.ModifyEvent.Name, "ModifyEvent");
			Assert.AreEqual(Interpretation.Instance.EventInterpretation.ModifyEvent.Uri, "http://www.zeitgeist-project.com/ontologies/2010/01/27/zg#ModifyEvent");
		}
		
		[Test()]
		public void TestReceiveEvent()
		{
			Assert.AreEqual(Interpretation.Instance.EventInterpretation.ReceiveEvent.Name, "ReceiveEvent");
			Assert.AreEqual(Interpretation.Instance.EventInterpretation.ReceiveEvent.Uri, "http://www.zeitgeist-project.com/ontologies/2010/01/27/zg#ReceiveEvent");
		}
		
		[Test()]
		public void TestSendEvent()
		{
			Assert.AreEqual(Interpretation.Instance.EventInterpretation.SendEvent.Name, "SendEvent");
			Assert.AreEqual(Interpretation.Instance.EventInterpretation.SendEvent.Uri, "http://www.zeitgeist-project.com/ontologies/2010/01/27/zg#SendEvent");
		}
		
		#endregion
		
		#region Media
		
		[Test()]
		public void TestMedia()
		{
			Assert.AreEqual(Interpretation.Instance.Media.Media.Name, "Media");
			Assert.AreEqual(Interpretation.Instance.Media.Media.Uri, "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Media");
		}
		
		[Test()]
		public void TestAudio()
		{
			Assert.AreEqual(Interpretation.Instance.Media.Audio.Name, "Audio");
			Assert.AreEqual(Interpretation.Instance.Media.Audio.Uri, "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Audio");
		}
		
		[Test()]
		public void TestMusicPiece()
		{
			Assert.AreEqual(Interpretation.Instance.Media.MusicPiece.Name, "MusicPiece");
			Assert.AreEqual(Interpretation.Instance.Media.MusicPiece.Uri, "http://www.semanticdesktop.org/ontologies/2009/02/19/nmm#MusicPiece");
		}
		
		[Test()]
		public void TestVisual()
		{
			Assert.AreEqual(Interpretation.Instance.Media.Visual.Visual.Name, "Visual");
			Assert.AreEqual(Interpretation.Instance.Media.Visual.Visual.Uri, "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Visual");
		}
		
		[Test()]
		public void TestImage()
		{
			Assert.AreEqual(Interpretation.Instance.Media.Visual.Image.Image.Name, "Image");
			Assert.AreEqual(Interpretation.Instance.Media.Visual.Image.Image.Uri, "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Image");
		}
		
		[Test()]
		public void TestIcon()
		{
			Assert.AreEqual(Interpretation.Instance.Media.Visual.Image.Icon.Name, "Icon");
			Assert.AreEqual(Interpretation.Instance.Media.Visual.Image.Icon.Uri, "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Icon");
		}
		
		[Test()]
		public void TestVectorImage()
		{
			Assert.AreEqual(Interpretation.Instance.Media.Visual.Image.VectorImage.Name, "VectorImage");
			Assert.AreEqual(Interpretation.Instance.Media.Visual.Image.VectorImage.Uri, "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#VectorImage");
		}
		
		[Test()]
		public void TestRasterImage()
		{
			Assert.AreEqual(Interpretation.Instance.Media.Visual.Image.RasterImage.RasterImage.Name, "RasterImage");
			Assert.AreEqual(Interpretation.Instance.Media.Visual.Image.RasterImage.RasterImage.Uri, "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#RasterImage");
		}
		
		[Test()]
		public void TestCursor()
		{
			Assert.AreEqual(Interpretation.Instance.Media.Visual.Image.RasterImage.Cursor.Name, "Cursor");
			Assert.AreEqual(Interpretation.Instance.Media.Visual.Image.RasterImage.Cursor.Uri, "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Cursor");
		}
		
		[Test()]
		public void TestVideo()
		{
			Assert.AreEqual(Interpretation.Instance.Media.Visual.Video.Video.Name, "Video");
			Assert.AreEqual(Interpretation.Instance.Media.Visual.Video.Video.Uri, "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Video");
		}
		
		[Test()]
		public void TestMovie()
		{
			Assert.AreEqual(Interpretation.Instance.Media.Visual.Video.Movie.Name, "Movie");
			Assert.AreEqual(Interpretation.Instance.Media.Visual.Video.Movie.Uri, "http://www.semanticdesktop.org/ontologies/2009/02/19/nmm#Movie");
		}
		
		[Test()]
		public void TestTVShow()
		{
			Assert.AreEqual(Interpretation.Instance.Media.Visual.Video.TVShow.Name, "TVShow");
			Assert.AreEqual(Interpretation.Instance.Media.Visual.Video.TVShow.Uri, "http://www.semanticdesktop.org/ontologies/2009/02/19/nmm#TVShow");
		}
		
		[Test()]
		public void TestMediaList()
		{
			Assert.AreEqual(Interpretation.Instance.MediaList.MediaList.Name, "MediaList");
			Assert.AreEqual(Interpretation.Instance.MediaList.MediaList.Uri, "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#MediaList");
		}
		
		[Test()]
		public void TestMusicAlbum()
		{
			Assert.AreEqual(Interpretation.Instance.MediaList.MusicAlbum.Name, "MusicAlbum");
			Assert.AreEqual(Interpretation.Instance.MediaList.MusicAlbum.Uri, "http://www.semanticdesktop.org/ontologies/2009/02/19/nmm#MusicAlbum");
		}
		
		#endregion
		
		#region MessageType
		
		[Test()]
		public void TestMessage()
		{
			Assert.AreEqual(Interpretation.Instance.Message.Message.Name, "Message");
			Assert.AreEqual(Interpretation.Instance.Message.Message.Uri, "http://www.semanticdesktop.org/ontologies/2007/03/22/nmo#Message");
		}
		
		[Test()]
		public void TestEmail()
		{
			Assert.AreEqual(Interpretation.Instance.Message.Email.Name, "Email");
			Assert.AreEqual(Interpretation.Instance.Message.Email.Uri, "http://www.semanticdesktop.org/ontologies/2007/03/22/nmo#Email");
		}
		
		[Test()]
		public void TestIMMessage()
		{
			Assert.AreEqual(Interpretation.Instance.Message.IMMessage.Name, "IMMessage");
			Assert.AreEqual(Interpretation.Instance.Message.IMMessage.Uri, "http://www.semanticdesktop.org/ontologies/2007/03/22/nmo#IMMessage");
		}
		
		#endregion
		
		#region SoftwareType
		
		[Test()]
		public void TestSoftware()
		{
			Assert.AreEqual(Interpretation.Instance.Software.Software.Name, "Software");
			Assert.AreEqual(Interpretation.Instance.Software.Software.Uri, "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Software");
		}
		
		[Test()]
		public void TestApplication()
		{
			Assert.AreEqual(Interpretation.Instance.Software.Application.Name, "Application");
			Assert.AreEqual(Interpretation.Instance.Software.Application.Uri, "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Application");
		}
		
		[Test()]
		public void TestOperatingSystem()
		{
			Assert.AreEqual(Interpretation.Instance.Software.OperatingSystem.Name, "OperatingSystem");
			Assert.AreEqual(Interpretation.Instance.Software.OperatingSystem.Uri, "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#OperatingSystem");
		}
		
		#endregion
	}
}

