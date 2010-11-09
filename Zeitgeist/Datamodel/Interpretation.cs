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
using System.Collections.Generic;

namespace Zeitgeist.Datamodel
{
	/// <summary>
	/// In general terms the interpretation of an event or subject is an abstract description of “what happened” or “what is this”.
	/// Each interpretation type is uniquely identified by a URI. This class provides a list of hard coded URI constants for programming convenience. In addition; each interpretation instance in this class has a display_name property, which is an internationalized string meant for end user display.
	/// </summary>
	/// <remarks>
	/// The interpretation types listed here are all subclasses of str and may be used anywhere a string would be used.
	/// Interpretations form a hierarchical type tree. So that fx. Audio, Video, and Image all are sub types of Media. These types again have their own sub types, like fx. Image has children Icon, Photo, and VectorImage (among others).
	/// Templates match on all sub types, so that a query on subjects with interpretation Media also match subjects with interpretations Audio, Photo, and all other sub types of Media. . (Display name: '')
	/// </remarks>
	public class Interpretation
	{
		/// <summary>
		/// The singleton Instance of Interpretation
		/// </summary>
		public static Interpretation Instance
		{
			get
			{
				if(_singleton_obj == null)
					_singleton_obj = new Interpretation();
				
				return _singleton_obj;
			}
		}
		
		/// <summary>
		/// Provide a grouping of component properties that define an alarm. (Display name: 'Alarm')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/04/02/ncal#Alarm
		/// </remarks>
		public NameUri Alarm
		{
			get
			{
				return _alarm;
			}
		}
		
		/// <summary>
		/// A bookmark of a webbrowser. Use nie:title for the name/label, nie:contentCreated to represent the date when the user added the bookmark, and nie:contentLastModified for modifications. nfo:bookmarks to store the link. (Display name: 'Bookmark')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Bookmark
		/// </remarks>
		public NameUri Bookmark
		{
			get
			{
				return _bookmark;
			}
		}
		
		/// <summary>
		/// A folder with bookmarks of a webbrowser. Use nfo:containsBookmark to relate Bookmarks. Folders can contain subfolders, use containsBookmarkFolder to relate them. (Display name: 'Bookmark Folder')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#BookmarkFolder
		/// </remarks>
		public NameUri BookmarkFolder
		{
			get
			{
				return _bookmark_folder;
			}
		}
		
		/// <summary>
		/// A calendar. Inspirations for this class can be traced to the VCALENDAR component defined in RFC 2445 sec. 4.4, but it may just as well be used to represent any kind of Calendar. (Display name: 'Calendar')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/04/02/ncal#Calendar
		/// </remarks>
		public NameUri Calendar
		{
			get
			{
				return _calendar;
			}
		}
		
		/// <summary>
		/// A superclass for all entities, whose primary purpose is to serve as containers for other data object. They usually don’t have any “meaning” by themselves. Examples include folders, archives and optical disc images. (Display name: 'DataContainer')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#DataContainer
		/// </remarks>
		public DataContainerType DataContainer
		{
			get
			{
				return _data_container;
			}
		}
			
		/// <summary>
		/// A generic document. A common superclass for all documents on the desktop. (Display name: 'Document')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Document
		/// </remarks>
		public DocumentType Document
		{
			get
			{
				return _document;
			}
		}
		
		/// <summary>
		/// Provide a grouping of component properties that describe an event. (Display name: 'Event')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/04/02/ncal#Event
		/// </remarks>
		public NameUri Event
		{
			get
			{
				return _event;
			}
		}
		
		/// <summary>
		/// Base class for event interpretations. Please do no instantiate directly, but use one of the sub classes. The interpretation of an event describes ‘what happened’ - fx. ‘something was created’ or ‘something was accessed’. (Display name: 'EVENT_INTERPRETATION')
		/// </summary>
		/// <remarks>
		/// http://www.zeitgeist-project.com/ontologies/2010/01/27/zg#EventInterpretation
		/// </remarks>
		public EventInterpretationType EventInterpretation
		{
			get
			{
				return _event_interpretation;
			}
		}
		
		/// <summary>
		/// An executable file. (Display name: 'Executable')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Executable
		/// </remarks>
		public NameUri Executable
		{
			get
			{
				return _executable;
			}
		}
		
		/// <summary>
		/// A font. (Display name: 'Font')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Font
		/// </remarks>
		public NameUri Font
		{
			get
			{
				return _font;
			}
		}
		
		/// <summary>
		/// Provide a grouping of component properties that describe either a request for free/busy time, describe a response to a request for free/busy time or describe a published set of busy time. (Display name: 'Freebusy')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/04/02/ncal#Freebusy
		/// </remarks>
		public NameUri Freebusy
		{
			get
			{
				return _free_busy;
			}
		}
		
		/// <summary>
		/// Provide a grouping of component properties that describe a journal entry. (Display name: 'Journal')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/04/02/ncal#Journal
		/// </remarks>
		public NameUri Journal
		{
			get
			{
				return _journal;
			}
		}
		
		/// <summary>
		/// A mailbox - container for MailboxDataObjects. (Display name: 'Mailbox')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/03/22/nmo#Mailbox
		/// </remarks>
		public NameUri Mailbox
		{
			get
			{
				return _mail_box;
			}
		}
		
		/// <summary>
		/// A piece of media content. This class may be used to express complex media containers with many streams of various media content (both aural and visual). (Display name: 'Media')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Media
		/// </remarks>
		public MediaType Media
		{
			get
			{
				return _media;
			}
		}
		
		/// <summary>
		/// A file containing a list of media files.e.g. a playlist. (Display name: 'MediaList')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#MediaList
		/// </remarks>
		public MediaListType MediaList
		{
			get
			{
				return _media_list;
			}
		}
		
		/// <summary>
		/// A message. Could be an email, instant messanging message, SMS message etc. (Display name: 'Message')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/03/22/nmo#Message
		/// </remarks>
		public MessageType Message
		{
			get
			{
				return _message;
			}
		}
		
		/// <summary>
		/// A MIME entity, as defined in RFC2045, Section 2.4. (Display name: 'MimeEntity')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/03/22/nmo#MimeEntity
		/// </remarks>
		public NameUri MimeEntity
		{
			get
			{
				return _mime_entity;
			}
		}
		
		/// <summary>
		/// A piece of software. Examples may include applications and the operating system. This interpretation most commonly applies to SoftwareItems. (Display name: 'Software')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Software
		/// </remarks>
		public SoftwareType Software
		{
			get
			{
				return _software;
			}
		}
		
		/// <summary>
		/// Provide a grouping of component properties that defines a time zone. (Display name: 'Timezone')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/04/02/ncal#Timezone
		/// </remarks>
		public NameUri Timezone
		{
			get
			{
				return _timezone;
			}
		}
		
		/// <summary>
		/// Provide a grouping of calendar properties that describe a to-do. (Display name: 'Todo')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/04/02/ncal#Todo
		/// </remarks>
		public NameUri Todo
		{
			get
			{
				return _todo;
			}
		}
		
		/// <summary>
		/// A TV Series has multiple seasons and episodes. (Display name: 'tv series')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2009/02/19/nmm#TVSeries
		/// </remarks>
		public NameUri TVSeries
		{
			get
			{
				return _tvseries;
			}
		}
		
		/// <summary>
		/// A website, usually a container for remote resources, that may be interpreted as HTMLDocuments, images or other types of content. (Display name: 'Website')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Website
		/// </remarks>
		public NameUri Website
		{
			get
			{
				return _website;
			}
		}
		
		/// <summary>
		/// Search for an interpretation KeyValuePair provided the interpretation string
		/// </summary>
		/// <param name="interpretation">
		/// The Interpretation of type <see cref="System.String"/>
		/// </param>
		/// <returns>
		/// The parsed value of Interpretation <see cref="KeyValuePair<System.String, System.String>"/>
		/// </returns>
		public NameUri Search(string interpretation)
		{
			if(string.Equals(_alarm.Uri, interpretation))
			   return _alarm;
			
			if(string.Equals(_bookmark.Uri, interpretation))
			   return _bookmark;
			
			if(string.Equals(_bookmark_folder.Uri, interpretation))
			   return _bookmark_folder;
			
			if(string.Equals(_calendar.Uri, interpretation))
			   return _calendar;
			
			if(string.Equals(_event.Uri, interpretation))
			   return _event;
			
			if(string.Equals(_executable.Uri, interpretation))
			   return _executable;
			
			if(string.Equals(_font.Uri, interpretation))
			   return _font;
			
			if(string.Equals(_free_busy.Uri, interpretation))
			   return _free_busy;
			
			if(string.Equals(_journal.Uri, interpretation))
			   return _journal;
			
			if(string.Equals(_mail_box.Uri, interpretation))
			   return _mail_box;
			
			if(string.Equals(_mime_entity.Uri, interpretation))
			   return _mime_entity;
			
			if(string.Equals(_timezone.Uri, interpretation))
			   return _timezone;
			
			if(string.Equals(_todo.Uri, interpretation))
			   return _todo;
			
			if(string.Equals(_tvseries.Uri, interpretation))
			   return _tvseries;
			
			if(string.Equals(_website.Uri, interpretation))
			   return _website;
			   
			NameUri datacont = _data_container.Search(interpretation);
			if(datacont != null)
				return datacont;
			
			NameUri doc = _document.Search(interpretation);
			if(doc != null)
				return doc;
			
			NameUri evnt_int = _event_interpretation.Search(interpretation);
			if(evnt_int != null)
				return evnt_int;
			
			NameUri media = _media.Search(interpretation);
			if(media != null)
				return media;
			
			NameUri media_lst = _media_list.Search(interpretation);
			if(media_lst != null)
				return media_lst;
			
			NameUri msg = _message.Search(interpretation);
			if(msg != null)
				return msg;
			
			NameUri sw = _software.Search(interpretation);
			if(sw != null)
				return sw;
			   
			return new NameUri(ZsUtils.GetStringAnchor(interpretation), interpretation);
		}
		
		#region Private Fields
		
		private static Interpretation _singleton_obj = new Interpretation();
		
		private NameUri _alarm = new NameUri("Alarm", "http://www.semanticdesktop.org/ontologies/2007/04/02/ncal#Alarm");
		
		private NameUri _bookmark = new NameUri("Bookmark", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Bookmark");
		
		private NameUri _bookmark_folder = new NameUri("BookmarkFolder", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#BookmarkFolder");
		
		private NameUri _calendar = new NameUri("Calendar", "http://www.semanticdesktop.org/ontologies/2007/04/02/ncal#Calendar");
		
		private NameUri _event = new NameUri("Event", "http://www.semanticdesktop.org/ontologies/2007/04/02/ncal#Event");
		
		private NameUri _executable = new NameUri("Executable", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Executable");
		
		private NameUri _font = new NameUri("Font", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Font");
		
		private NameUri _free_busy = new NameUri("Freebusy", "http://www.semanticdesktop.org/ontologies/2007/04/02/ncal#Freebusy");
		
		private NameUri _journal = new NameUri("Journal", "http://www.semanticdesktop.org/ontologies/2007/04/02/ncal#Journal");
		
		private NameUri _mail_box = new NameUri("Mailbox", "http://www.semanticdesktop.org/ontologies/2007/03/22/nmo#Mailbox");
		
		private NameUri _mime_entity = new NameUri("MimeEntity", "http://www.semanticdesktop.org/ontologies/2007/03/22/nmo#MimeEntity");
		
		private NameUri _timezone = new NameUri("Timezone", "http://www.semanticdesktop.org/ontologies/2007/04/02/ncal#Timezone");
		
		private NameUri _todo = new NameUri("Todo", "http://www.semanticdesktop.org/ontologies/2007/04/02/ncal#Todo");
		
		private NameUri _tvseries = new NameUri("TVSeries", "http://www.semanticdesktop.org/ontologies/2009/02/19/nmm#TVSeries");
		
		private NameUri _website = new NameUri("Website", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Website");
		
		private DataContainerType _data_container = new DataContainerType();
		
		private DocumentType _document = new DocumentType();
		
		private EventInterpretationType _event_interpretation = new EventInterpretationType();
		
		private MediaType _media = new MediaType();
		
		private MediaListType _media_list = new MediaListType();
		
		private MessageType _message = new MessageType();
		
		private SoftwareType _software = new SoftwareType();
		
		#endregion
	}
	
	#region DataContainer Classes
	
	public class DataContainerType
	{
		/// <summary>
		/// A superclass for all entities, whose primary purpose is to serve as containers for other data object. They usually don’t have any “meaning” by themselves. Examples include folders, archives and optical disc images. (Display name: 'DataContainer')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#DataContainer
		/// </remarks>
		public NameUri DataContainer
		{
			get
			{
				return _datacontainer;
			}
		}
		
		/// <summary>
		/// A compressed file. May contain other files or folder inside. (Display name: 'Archive')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Archive
		/// </remarks>
		public NameUri Archive
		{
			get
			{
				return _archive;
			}
		}
		
		/// <summary>
		/// A filesystem. Examples of filesystems include hard disk partitions, removable media, but also images thereof stored in files. (Display name: 'Filesystem')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Filesystem
		/// </remarks>
		public FileSystemType Filesystem
		{
			get
			{
				return _filesystem;
			}
		}
		
		/// <summary>
		/// A folder/directory. Examples of folders include folders on a filesystem and message folders in a mailbox. (Display name: 'Folder')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Folder
		/// </remarks>
		public NameUri Folder
		{
			get
			{
				return _folder;
			}
		}
		
		/// <summary>
		/// Represents a container for deleted files, a feature common in modern operating systems. (Display name: 'Trash')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Trash
		/// </remarks>
		public NameUri Trash
		{
			get
			{
				return _trash;
			}
		}
		
		public NameUri Search(string interpretation)
		{
			if(string.Equals(_datacontainer.Uri, interpretation))
			   return _datacontainer;
			
			if(string.Equals(_archive.Uri, interpretation))
			   return _archive;
			
			if(string.Equals(_folder.Uri, interpretation))
			   return _folder;
			
			if(string.Equals(_trash.Uri, interpretation))
			   return _trash;
			
			NameUri fs = _filesystem.Search(interpretation);
			if(fs != null)
				return fs;
			
			return null;
		}
		
		#region Private Fields
		
		private NameUri _datacontainer = new NameUri("DataContainer", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#DataContainer");
		
		private NameUri _archive = new NameUri("Archive", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Archive");
		
		private NameUri _folder = new NameUri("Folder", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Folder");
		
		private NameUri _trash = new NameUri("Trash", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Trash");
		
		private FileSystemType _filesystem = new FileSystemType();

		#endregion
	}
	
	public class FileSystemType
	{
		/// <summary>
		/// A filesystem. Examples of filesystems include hard disk partitions, removable media, but also images thereof stored in files. (Display name: 'Filesystem')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Filesystem
		/// </remarks>
		public NameUri Filesystem
		{
			get
			{
				return _file_system;
			}
		}
		
		/// <summary>
		/// Represents a container for deleted files, a feature common in modern operating systems. (Display name: 'Trash')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Trash
		/// </remarks>
		public NameUri FilesystemImage
		{
			get
			{
				return _file_system_image;
			}
		}
		
		public NameUri Search(string interpretation)
		{
			if(string.Equals(_file_system_image.Uri, interpretation))
			   return _file_system_image;
			
			if(string.Equals(_file_system.Uri, interpretation))
			   return _file_system;
			
			return null;
		}
		
		#region Private Fields
		
		private static NameUri _file_system_image = new NameUri("FilesystemImage", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#FilesystemImage");
		
		private static NameUri _file_system = new NameUri("Filesystem", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Filesystem");
		
		#endregion
	}
	
	#endregion
	
	#region DocumentType Classes
	
	public class DocumentType
	{
		/// <summary>
		/// A generic document. A common superclass for all documents on the desktop. (Display name: 'Document')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Document
		/// </remarks>
		public NameUri Document
		{
			get
			{
				return _document;
			}
		}
		
		/// <summary>
		/// A MindMap, created by a mind-mapping utility. Examples might include FreeMind or mind mapper. (Display name: 'MindMap')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#MindMap
		/// </remarks>
		public NameUri MindMap
		{
			get
			{
				return _mind_map;
			}
		}
		
		/// <summary>
		/// A Presentation made by some presentation software (Corel Presentations, OpenOffice Impress, MS Powerpoint etc.). (Display name: 'Presentation')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Presentation
		/// </remarks>
		public NameUri Presentation
		{
			get
			{
				return _presentation;
			}
		}
		
		/// <summary>
		/// A spreadsheet, created by a spreadsheet application. Examples might include Gnumeric, OpenOffice Calc or MS Excel. (Display name: 'Spreadsheet')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Spreadsheet
		/// </remarks>
		public NameUri Spreadsheet
		{
			get
			{
				return _spreadsheet;
			}
		}
		
		/// <summary>
		/// A text document. (Display name: 'TextDocument')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#TextDocument
		/// </remarks>
		public TextDocumentType TextDocument
		{
			get
			{
				return _text_document;
			}
		}
		
		public NameUri Search(string interpretation)
		{
			if(string.Equals(_document.Uri, interpretation))
			   return _document;
			
			if(string.Equals(_mind_map.Uri, interpretation))
			   return _mind_map;
			
			if(string.Equals(_presentation.Uri, interpretation))
			   return _presentation;
			
			if(string.Equals(_spreadsheet.Uri, interpretation))
			   return _spreadsheet;
			
			NameUri textdoc = _text_document.Search(interpretation);
			if(textdoc != null)
				return textdoc;
			
			return null;
		}
		
		#region Private Fields
	
		private NameUri _document = new NameUri("Document", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Document");
		
		private NameUri _mind_map = new NameUri("MindMap", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#MindMap");
		
		private NameUri _presentation = new NameUri("Presentation", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Presentation");
		
		private NameUri _spreadsheet = new NameUri("Spreadsheet", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Spreadsheet");
		
		private TextDocumentType _text_document = new TextDocumentType();
		
		#endregion
	}
	
	public class TextDocumentType
	{
		/// <summary>
		/// A text document. (Display name: 'TextDocument')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#TextDocument
		/// </remarks>
		public NameUri TextDocument
		{
			get
			{
				return _text_document;
			}
		}
		
		/// <summary>
		/// A file containing a text document, that is unambiguously divided into pages. Examples might include PDF, DOC, PS, DVI etc. (Display name: 'PaginatedTextDocument')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#PaginatedTextDocument
		/// </remarks>
		public NameUri PaginatedTextDocument
		{
			get
			{
				return _paginated_text_document;
			}
		}
		
		
		/// <summary>
		/// A file containing a text document, that is unambiguously divided into pages. Examples might include PDF, DOC, PS, DVI etc. (Display name: 'PaginatedTextDocument')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#PaginatedTextDocument
		/// </remarks>
		public PlainTextDocumentType PlainTextDocument
		{
			get
			{
				return _plain_text_document;
			}
		}
		
		public NameUri Search(string interpretation)
		{
			if(string.Equals(_paginated_text_document.Uri, interpretation))
			   return _paginated_text_document;
			
			NameUri plaintext = _plain_text_document.Search(interpretation);
			if(plaintext != null)
				return plaintext;
			
			return null;
		}
		
		#region Private Fields
		
		private NameUri _text_document = new NameUri("TextDocument", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#TextDocument");
		
		private NameUri _paginated_text_document = new NameUri("PaginatedTextDocument", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#PaginatedTextDocument");
		
		private PlainTextDocumentType _plain_text_document = new PlainTextDocumentType();
		
		#endregion
	}
	
	public class PlainTextDocumentType
	{
		/// <summary>
		/// A file containing plain text (ASCII, Unicode or other encodings). Examples may include TXT, HTML, XML, program source code etc. (Display name: 'PlainTextDocument')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#PlainTextDocument
		/// </remarks>
		public NameUri PlainTextDocument
		{
			get
			{
				return _plain_text_document;
			}
		}
		
		/// <summary>
		/// A HTML document, may contain links to other files. (Display name: 'HtmlDocument')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#HtmlDocument
		/// </remarks>
		public NameUri HtmlDocument
		{
			get
			{
				return _html_document;
			}
		}
		
		/// <summary>
		/// Code in a compilable or interpreted programming language. (Display name: 'SourceCode')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#SourceCode
		/// </remarks>
		public NameUri SourceCode
		{
			get
			{
				return _source_code;
			}
		}
		
		public NameUri Search(string interpretation)
		{
			if(string.Equals(_plain_text_document.Uri, interpretation))
			   return _plain_text_document;
			
			if(string.Equals(_html_document.Uri, interpretation))
			   return _html_document;
			
			if(string.Equals(_source_code.Uri, interpretation))
			   return _source_code;
			
			return null;
		}
		
		#region Private Fields
		
		private NameUri _plain_text_document = new NameUri("PlainTextDocument", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#PlainTextDocument");
		
		private NameUri _html_document = new NameUri("HtmlDocument", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#HtmlDocument");
		
		private NameUri _source_code = new NameUri("SourceCode", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#SourceCode");
		
		#endregion
	}
	
	#endregion
	
	#region EventInterpretation Classes
	
	public class EventInterpretationType
	{
		/// <summary>
		/// Base class for event interpretations. Please do no instantiate directly, but use one of the sub classes. The interpretation of an event describes ‘what happened’ - fx. ‘something was created’ or ‘something was accessed’. (Display name: 'EVENT_INTERPRETATION')
		/// </summary>
		/// <remarks>
		/// http://www.zeitgeist-project.com/ontologies/2010/01/27/zg#EventInterpretation
		/// </remarks>
		public NameUri EventInterpretation
		{
			get
			{
				return _event_interpretation;
			}
		}
		
		/// <summary>
		/// Event triggered by opening, accessing, or starting a resource. Most zg:AccessEvents will have an accompanying zg:LeaveEvent, but this need not always be the case. (Display name: 'ACCESS_EVENT')
		/// </summary>
		/// <remarks>
		/// http://www.zeitgeist-project.com/ontologies/2010/01/27/zg#AccessEvent
		/// </remarks>
		public NameUri AccessEvent
		{
			get
			{
				return _access_event;
			}
		}
		
		/// <summary>
		/// Event type triggered when an item is created. (Display name: 'Created')
		/// </summary>
		/// <remarks>
		/// http://www.zeitgeist-project.com/ontologies/2010/01/27/zg#CreateEvent
		/// </remarks>
		public NameUri CreateEvent
		{
			get
			{
				return _create_event;
			}
		}
		
		/// <summary>
		/// Event triggered because a resource has been deleted or otherwise made permanently unavailable. Fx. when deleting a file. FIXME: How about when moving to trash?. (Display name: 'DELETE_EVE
		/// </summary>
		/// <remarks>
		/// http://www.zeitgeist-project.com/ontologies/2010/01/27/zg#DeleteEvent
		/// </remarks>
		public NameUri DeleteEvent
		{
			get
			{
				return _delete_event;
			}
		}
		
		/// <summary>
		/// Event triggered by closing, leaving, or stopping a resource. Most zg:LeaveEvents will be following a zg:Access event, but this need not always be the case. (Display name: 'LEAVE_EVENT')
		/// </summary>
		/// <remarks>
		/// http://www.zeitgeist-project.com/ontologies/2010/01/27/zg#LeaveEvent 
		/// </remarks>
		public NameUri LeaveEvent
		{
			get
			{
				return _leave_event;
			}
		}
		
		/// <summary>
		/// Event triggered by modifying an existing resources. Fx. when editing and saving a file on disk or correcting a typo in the name of a contact. (Display name: 'MODIFY_EVENT')
		/// </summary>
		/// <remarks>
		/// http://www.zeitgeist-project.com/ontologies/2010/01/27/zg#ModifyEvent
		/// </remarks>
		public NameUri ModifyEvent
		{
			get
			{
				return _modify_event;
			}
		}
		
		/// <summary>
		/// Event triggered when something is received from an external party. The event manifestation must be set according to the world view of the receiving party. Most often the item that is being received will be some sort of message - an email, instant message, or broadcasted media such as micro blogging. (Display name: 'RECEIVE_EVENT')
		/// </summary>
		/// <remarks>
		/// http://www.zeitgeist-project.com/ontologies/2010/01/27/zg#ReceiveEvent
		/// </remarks>
		public NameUri ReceiveEvent
		{
			get
			{
				return _receive_event;
			}
		}
		
		/// <summary>
		/// Event triggered when something is send to an external party. The event manifestation must be set according to the world view of the sending party. Most often the item that is being send will be some sort of message - an email, instant message, or broadcasted media such as micro blogging. (Display name: 'SEND_EVENT')
		/// </summary>
		/// <remarks>
		/// http://www.zeitgeist-project.com/ontologies/2010/01/27/zg#SendEvent
		/// </remarks>
		public NameUri SendEvent
		{
			get
			{
				return _send_event;
			}
		}
		
		public NameUri Search(string interpretation)
		{
			if(string.Equals(_event_interpretation.Uri, interpretation))
			   return _event_interpretation;
			
			if(string.Equals(_access_event.Uri, interpretation))
			   return _access_event;
			
			if(string.Equals(_create_event.Uri, interpretation))
			   return _create_event;
			
			if(string.Equals(_delete_event.Uri, interpretation))
			   return _delete_event;
			
			if(string.Equals(_leave_event.Uri, interpretation))
			   return _leave_event;
			
			if(string.Equals(_modify_event.Uri, interpretation))
			   return _modify_event;
			
			if(string.Equals(_receive_event.Uri, interpretation))
			   return _receive_event;
			
			if(string.Equals(_send_event.Uri, interpretation))
			   return _send_event;
			
			
			return null;
		}
		
		#region Private Fields
		
		private NameUri _event_interpretation = new NameUri("EventInterpretation", "http://www.zeitgeist-project.com/ontologies/2010/01/27/zg#EventInterpretation");
		
		private NameUri _access_event = new NameUri("AccessEvent", "http://www.zeitgeist-project.com/ontologies/2010/01/27/zg#AccessEvent");
		
		private NameUri _create_event = new NameUri("CreateEvent", "http://www.zeitgeist-project.com/ontologies/2010/01/27/zg#CreateEvent");
		
		private NameUri _delete_event = new NameUri("DeleteEvent", "http://www.zeitgeist-project.com/ontologies/2010/01/27/zg#DeleteEvent");
		
		private NameUri _leave_event = new NameUri("LeaveEvent", "http://www.zeitgeist-project.com/ontologies/2010/01/27/zg#LeaveEvent");
		
		private NameUri _modify_event = new NameUri("ModifyEvent", "http://www.zeitgeist-project.com/ontologies/2010/01/27/zg#ModifyEvent");
		
		private NameUri _receive_event = new NameUri("ReceiveEvent", "http://www.zeitgeist-project.com/ontologies/2010/01/27/zg#ReceiveEvent");
		
		private NameUri _send_event = new NameUri("SendEvent", "http://www.zeitgeist-project.com/ontologies/2010/01/27/zg#SendEvent");
		
		#endregion
	}
	
	#endregion
	
	#region Media Classes
	
	public class MediaType
	{
		/// <summary>
		/// A piece of media content. This class may be used to express complex media containers with many streams of various media content (both aural and visual). (Display name: 'Media')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Media
		/// </remarks>
		public NameUri Media
		{
			get
			{
				return _media;
			}
		}
		
		/// <summary>
		/// UsA file containing audio content. (Display name: 'Audio')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Audio
		/// </remarks>
		public NameUri Audio
		{
			get
			{
				return _audio;
			}
		}
		
		/// <summary>
		/// Used to assign music-specific properties such a BPM to video and audio. (Display name: 'music')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2009/02/19/nmm#MusicPiece
		/// </remarks>
		public NameUri MusicPiece
		{
			get
			{
				return _music_piece;
			}
		}
		
		/// <summary>
		/// File containing visual content. (Display name: 'Visual')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Visual
		/// </remarks>
		public VisualType Visual
		{
			get
			{
				return _visual_type;
			}
		}
		
		public NameUri Search(string interpretation)
		{
			if(string.Equals(_media.Uri, interpretation))
			   return _media;
			
			if(string.Equals(_audio.Uri, interpretation))
			   return _audio;
			
			if(string.Equals(_music_piece.Uri, interpretation))
			   return _music_piece;
			
			NameUri visual = _visual_type.Search(interpretation);
			if(visual != null)
				return visual;
			
			return null;
		}
		
		#region Private Fields
		
		private NameUri _media = new NameUri("Media", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Media");
		
		private NameUri _audio = new NameUri("Audio", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Audio");
		
		private NameUri _music_piece = new NameUri("MusicPiece", "http://www.semanticdesktop.org/ontologies/2009/02/19/nmm#MusicPiece");
		
		private VisualType _visual_type = new VisualType();
		
		#endregion
	}
	
	public class VisualType
	{
		/// <summary>
		/// File containing visual content. (Display name: 'Visual')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Visual
		/// </remarks>
		public NameUri Visual
		{
			get
			{
				return _visual;
			}
		}
		
		/// <summary>
		/// A file containing an image. (Display name: 'Image')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Image
		/// </remarks>
		public ImageType Image
		{
			get
			{
				return _image;
			}
		}
		
		/// <summary>
		/// A video file. (Display name: 'Video')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Video
		/// </remarks>
		public VideoType Video
		{
			get
			{
				return _video;
			}
		}
		
		public NameUri Search(string interpretation)
		{
			if(string.Equals(_visual.Uri, interpretation))
			   return _visual;
			
			NameUri image = _image.Search(interpretation);
			if(image != null)
				return image;
			
			NameUri video = _video.Search(interpretation);
			if(video != null)
				return video;
			
			return null;
		}
		
		#region Private Fields
		
		private NameUri _visual = new NameUri("Visual", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Visual");
		
		private ImageType _image = new ImageType();
		
		private VideoType _video = new VideoType();
		
		#endregion
	}
	
	public class ImageType
	{
		/// <summary>
		/// A file containing an image. (Display name: 'Image')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Image
		/// </remarks>
		public NameUri Image
		{
			get
			{
				return _image;
			}
		}
		
		/// <summary>
		/// An Icon (regardless of whether it’s a raster or a vector icon. A resource representing an icon could have two types (Icon and Raster, or Icon and Vector) if required. (Display name: 'Icon')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Icon
		/// </remarks>
		public NameUri Icon
		{
			get
			{
				return _icon;
			}
		}
		
		/// <summary>
		/// A raster image. (Display name: 'RasterImage')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#RasterImage
		/// </remarks>
		public RasterImageType RasterImage
		{
			get
			{
				return _raster_image;
			}
		}
		
		/// <summary>
		/// . (Display name: 'VectorImage')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#VectorImage
		/// </remarks>
		public NameUri VectorImage
		{
			get
			{
				return _vector_image;
			}
		}
		
		public NameUri Search(string interpretation)
		{
			if(string.Equals(_image.Uri, interpretation))
			   return _image;
			
			if(string.Equals(_icon.Uri, interpretation))
			   return _icon;
			
			NameUri rast = _raster_image.Search(interpretation);
			if(rast != null)
				return rast;
			
			if(string.Equals(_vector_image.Uri, interpretation))
			   return _vector_image;
			
			return null;
		}
		
		#region Private Fields
		
		private NameUri _image = new NameUri("Image", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Image");
		
		private NameUri _icon = new NameUri("Icon", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Icon");
		
		private RasterImageType _raster_image = new RasterImageType();
		
		private NameUri _vector_image = new NameUri("VectorImage", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#VectorImage");
		
		
		#endregion
	}
	
	public class RasterImageType
	{
		/// <summary>
		/// A raster image. (Display name: 'RasterImage')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#RasterImage
		/// </remarks>
		public NameUri RasterImage
		{
			get
			{
				return _raster_image;
			}
		}
		
		/// <summary>
		/// A Cursor. (Display name: 'Cursor')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Cursor
		/// </remarks>
		public NameUri Cursor
		{
			get
			{
				return _cursor;
			}
		}
		
		public NameUri Search(string interpretation)
		{
			if(string.Equals(_raster_image.Uri, interpretation))
			   return _raster_image;
			
			if(string.Equals(_cursor.Uri, interpretation))
			   return _cursor;
			
			return null;
		}
		
		#region Private Fields
		
		private NameUri _raster_image = new NameUri("RasterImage", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#RasterImage");
		
		private NameUri _cursor = new NameUri("Cursor", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Cursor");
		
		#endregion
	}
	
	public class VideoType
	{
		/// <summary>
		/// A video file. (Display name: 'Video')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Video
		/// </remarks>
		public NameUri Video
		{
			get
			{
				return _video;
			}
		}
		
		/// <summary>
		/// A Movie. (Display name: 'movie')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2009/02/19/nmm#Movie
		/// </remarks>
		public NameUri Movie
		{
			get
			{
				return _movie;
			}
		}
		
		/// <summary>
		/// A TV Show. (Display name: 'tv show')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2009/02/19/nmm#TVShow
		/// </remarks>
		public NameUri TVShow
		{
			get
			{
				return _tv_show;
			}
		}
		
		public NameUri Search(string interpretation)
		{
			if(string.Equals(_video.Uri, interpretation))
			   return _video;
			
			if(string.Equals(_movie.Uri, interpretation))
			   return _movie;
			
			if(string.Equals(_tv_show.Uri, interpretation))
			   return _tv_show;
			
			return null;
		}
		
		#region Private Fields
		
		private NameUri _video = new NameUri("Video", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Video");
		
		private NameUri _movie = new NameUri("Movie", "http://www.semanticdesktop.org/ontologies/2009/02/19/nmm#Movie");
		
		private NameUri _tv_show = new NameUri("TVShow", "http://www.semanticdesktop.org/ontologies/2009/02/19/nmm#TVShow");
		
		#endregion
	}
	
	#endregion
	
	#region MediaList Classes
	
	public class MediaListType
	{
		/// <summary>
		/// A file containing a list of media files.e.g. a playlist. (Display name: 'MediaList')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#MediaList
		/// </remarks>
		public NameUri MediaList
		{
			get
			{
				return _media_list;
			}
		}
		
		/// <summary>
		/// The music album as provided by the publisher. Not to be confused with media lists or collections. (Display name: 'music album')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2009/02/19/nmm#MusicAlbum
		/// </remarks>
		public NameUri MusicAlbum
		{
			get
			{
				return _music_album;
			}
		}
		
		public NameUri Search(string interpretation)
		{
			if(string.Equals(_media_list.Uri, interpretation))
			   return _media_list;
			
			if(string.Equals(_music_album.Uri, interpretation))
			   return _music_album;
			
			return null;
		}
				
		#region Private Fields
		
		private NameUri _media_list = new NameUri("MediaList", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#MediaList");
		
		private NameUri _music_album = new NameUri("MusicAlbum", "http://www.semanticdesktop.org/ontologies/2009/02/19/nmm#MusicAlbum");
		
		#endregion
	}
	
	#endregion
	
	#region Message Classes
	
	public class MessageType
	{
		/// <summary>
		/// A message. Could be an email, instant messanging message, SMS message etc. (Display name: 'Message')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/03/22/nmo#Message
		/// </remarks>
		public NameUri Message
		{
			get
			{
				return _message;
			}
		}
		
		/// <summary>
		/// An email. (Display name: 'Email')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/03/22/nmo#Email
		/// </remarks>
		public NameUri Email
		{
			get
			{
				return _email;
			}
		}
		
		/// <summary>
		/// A message sent with Instant Messaging software. (Display name: 'IMMessage')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/03/22/nmo#IMMessage
		/// </remarks>
		public NameUri IMMessage
		{
			get
			{
				return _im_message;
			}
		}
		
		public NameUri Search(string interpretation)
		{
			if(string.Equals(_message.Uri, interpretation))
			   return _message;
			
			if(string.Equals(_email.Uri, interpretation))
			   return _email;
			
			if(string.Equals(_im_message.Uri, interpretation))
			   return _im_message;
			
			return null;
		}
				
		#region Private Fields
		
		private NameUri _message = new NameUri("Message", "http://www.semanticdesktop.org/ontologies/2007/03/22/nmo#Message");
		
		private NameUri _email = new NameUri("Email", "http://www.semanticdesktop.org/ontologies/2007/03/22/nmo#Email");
		
		private NameUri _im_message = new NameUri("IMMessage", "http://www.semanticdesktop.org/ontologies/2007/03/22/nmo#IMMessage");
		
		#endregion
	}
	
	#endregion
	
	#region Software Classes
	
	public class SoftwareType
	{
		/// <summary>
		/// A piece of software. Examples may include applications and the operating system. This interpretation most commonly applies to SoftwareItems. (Display name: 'Software')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Software
		/// </remarks>
		public NameUri Software
		{
			get
			{
				return _software;
			}
		}
		
		/// <summary>
		/// An application. (Display name: 'Application')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Application
		/// </remarks>
		public NameUri Application
		{
			get
			{
				return _application;
			}
		}
		
		/// <summary>
		/// An OperatingSystem. (Display name: 'OperatingSystem')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#OperatingSystem
		/// </remarks>
		public NameUri OperatingSystem
		{
			get
			{
				return _os;
			}
		}
		
		public NameUri Search(string interpretation)
		{
			if(string.Equals(_software.Uri, interpretation))
			   return _software;
			
			if(string.Equals(_application.Uri, interpretation))
			   return _application;
			
			if(string.Equals(_os.Uri, interpretation))
			   return _os;
			
			return null;
		}
				
		#region Private Fields
		
		private NameUri _software = new NameUri("Software", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Software");
		
		private NameUri _application = new NameUri("Application", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Application");
		
		private NameUri _os = new NameUri("OperatingSystem", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#OperatingSystem");
		
		#endregion
	}
	
	#endregion
}

