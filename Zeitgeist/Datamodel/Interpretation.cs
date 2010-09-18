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
		public KeyValuePair<string, string> Alarm
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
		public KeyValuePair<string, string> Bookmark
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
		public KeyValuePair<string, string> BookmarkFolder
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
		public KeyValuePair<string, string> Calendar
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
		public KeyValuePair<string, string> Event
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
		public KeyValuePair<string, string> Executable
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
		public KeyValuePair<string, string> Font
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
		public KeyValuePair<string, string> Freebusy
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
		public KeyValuePair<string, string> Journal
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
		public KeyValuePair<string, string> Mailbox
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
		public KeyValuePair<string, string> MimeEntity
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
		public KeyValuePair<string, string> Timezone
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
		public KeyValuePair<string, string> Todo
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
		public KeyValuePair<string, string> TVSeries
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
		public KeyValuePair<string, string> Website
		{
			get
			{
				return _website;
			}
		}
		
		public KeyValuePair<string, string> Search(string interpretation)
		{
			if(string.Equals(_alarm.Value, interpretation))
			   return _alarm;
			
			if(string.Equals(_bookmark.Value, interpretation))
			   return _bookmark;
			
			if(string.Equals(_bookmark_folder.Value, interpretation))
			   return _bookmark_folder;
			
			if(string.Equals(_calendar.Value, interpretation))
			   return _calendar;
			
			if(string.Equals(_event.Value, interpretation))
			   return _event;
			
			if(string.Equals(_executable.Value, interpretation))
			   return _executable;
			
			if(string.Equals(_font.Value, interpretation))
			   return _font;
			
			if(string.Equals(_free_busy.Value, interpretation))
			   return _free_busy;
			
			if(string.Equals(_journal.Value, interpretation))
			   return _journal;
			
			if(string.Equals(_mail_box.Value, interpretation))
			   return _mail_box;
			
			if(string.Equals(_mime_entity.Value, interpretation))
			   return _mime_entity;
			
			if(string.Equals(_timezone.Value, interpretation))
			   return _timezone;
			
			if(string.Equals(_todo.Value, interpretation))
			   return _todo;
			
			if(string.Equals(_tvseries.Value, interpretation))
			   return _tvseries;
			
			if(string.Equals(_website.Value, interpretation))
			   return _website;
			   
			KeyValuePair<string, string> datacont = _data_container.Search(interpretation);
			if(datacont.Key != null)
				return datacont;
			
			KeyValuePair<string, string> doc = _document.Search(interpretation);
			if(doc.Key != null)
				return doc;
			
			KeyValuePair<string, string> evnt_int = _event_interpretation.Search(interpretation);
			if(evnt_int.Key != null)
				return evnt_int;
			
			KeyValuePair<string, string> media = _media.Search(interpretation);
			if(media.Key != null)
				return media;
			
			KeyValuePair<string, string> media_lst = _media_list.Search(interpretation);
			if(media_lst.Key != null)
				return media_lst;
			
			KeyValuePair<string, string> msg = _message.Search(interpretation);
			if(msg.Key != null)
				return msg;
			
			KeyValuePair<string, string> sw = _software.Search(interpretation);
			if(sw.Key != null)
				return sw;
			   
			return new KeyValuePair<string, string>();
		}
		
		#region Private Fields
		
		private static Interpretation _singleton_obj = new Interpretation();
		
		private KeyValuePair<string, string> _alarm = new KeyValuePair<string, string>("Alarm", "http://www.semanticdesktop.org/ontologies/2007/04/02/ncal#Alarm");
		
		private KeyValuePair<string, string> _bookmark = new KeyValuePair<string, string>("Bookmark", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Bookmark");
		
		private KeyValuePair<string, string> _bookmark_folder = new KeyValuePair<string, string>("BookmarkFolder", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#BookmarkFolder");
		
		private KeyValuePair<string, string> _calendar = new KeyValuePair<string, string>("Calendar", "http://www.semanticdesktop.org/ontologies/2007/04/02/ncal#Calendar");
		
		private KeyValuePair<string, string> _event = new KeyValuePair<string, string>("Event", "http://www.semanticdesktop.org/ontologies/2007/04/02/ncal#Event");
		
		private KeyValuePair<string, string> _executable = new KeyValuePair<string, string>("Executable", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Executable");
		
		private KeyValuePair<string, string> _font = new KeyValuePair<string, string>("Font", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Font");
		
		private KeyValuePair<string, string> _free_busy = new KeyValuePair<string, string>("Freebusy", "http://www.semanticdesktop.org/ontologies/2007/04/02/ncal#Freebusy");
		
		private KeyValuePair<string, string> _journal = new KeyValuePair<string, string>("Journal", "http://www.semanticdesktop.org/ontologies/2007/04/02/ncal#Journal");
		
		private KeyValuePair<string, string> _mail_box = new KeyValuePair<string, string>("Mailbox", "http://www.semanticdesktop.org/ontologies/2007/03/22/nmo#Mailbox");
		
		private KeyValuePair<string, string> _mime_entity = new KeyValuePair<string, string>("MimeEntity", "http://www.semanticdesktop.org/ontologies/2007/03/22/nmo#MimeEntity");
		
		private KeyValuePair<string, string> _timezone = new KeyValuePair<string, string>("Timezone", "http://www.semanticdesktop.org/ontologies/2007/04/02/ncal#Timezone");
		
		private KeyValuePair<string, string> _todo = new KeyValuePair<string, string>("Todo", "http://www.semanticdesktop.org/ontologies/2007/04/02/ncal#Todo");
		
		private KeyValuePair<string, string> _tvseries = new KeyValuePair<string, string>("TVSeries", "http://www.semanticdesktop.org/ontologies/2009/02/19/nmm#TVSeries");
		
		private KeyValuePair<string, string> _website = new KeyValuePair<string, string>("Website", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Website");
		
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
		public KeyValuePair<string, string> DataContainer
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
		public KeyValuePair<string, string> Archive
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
		public KeyValuePair<string, string> Folder
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
		public KeyValuePair<string, string> Trash
		{
			get
			{
				return _trash;
			}
		}
		
		public KeyValuePair<string, string> Search(string interpretation)
		{
			if(string.Equals(_datacontainer.Value, interpretation))
			   return _datacontainer;
			
			if(string.Equals(_archive.Value, interpretation))
			   return _archive;
			
			if(string.Equals(_folder.Value, interpretation))
			   return _folder;
			
			if(string.Equals(_trash.Value, interpretation))
			   return _trash;
			
			KeyValuePair<string, string> fs = _filesystem.Search(interpretation);
			if(fs.Key != null)
				return fs;
			
			return new KeyValuePair<string, string>();
		}
		
		#region Private Fields
		
		private KeyValuePair<string, string> _datacontainer = new KeyValuePair<string, string>("DataContainer", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#DataContainer");
		
		private KeyValuePair<string, string> _archive = new KeyValuePair<string, string>("Archive", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Archive");
		
		private KeyValuePair<string, string> _folder = new KeyValuePair<string, string>("Folder", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Folder");
		
		private KeyValuePair<string, string> _trash = new KeyValuePair<string, string>("Trash", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Trash");
		
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
		public KeyValuePair<string, string> Filesystem
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
		public KeyValuePair<string, string> FilesystemImage
		{
			get
			{
				return _file_system_image;
			}
		}
		
		public KeyValuePair<string, string> Search(string interpretation)
		{
			if(string.Equals(_file_system_image.Value, interpretation))
			   return _file_system_image;
			
			if(string.Equals(_file_system.Value, interpretation))
			   return _file_system;
			
			return new KeyValuePair<string, string>();
		}
		
		#region Private Fields
		
		private static KeyValuePair<string, string> _file_system_image = new KeyValuePair<string, string>("FilesystemImage", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#FilesystemImage");
		
		private static KeyValuePair<string, string> _file_system = new KeyValuePair<string, string>("Filesystem", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Filesystem");
		
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
		public KeyValuePair<string, string> Document
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
		public KeyValuePair<string, string> MindMap
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
		public KeyValuePair<string, string> Presentation
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
		public KeyValuePair<string, string> Spreadsheet
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
		
		public KeyValuePair<string, string> Search(string interpretation)
		{
			if(string.Equals(_document.Value, interpretation))
			   return _document;
			
			if(string.Equals(_mind_map.Value, interpretation))
			   return _mind_map;
			
			if(string.Equals(_presentation.Value, interpretation))
			   return _presentation;
			
			if(string.Equals(_spreadsheet.Value, interpretation))
			   return _spreadsheet;
			
			KeyValuePair<string, string> textdoc = _text_document.Search(interpretation);
			if(textdoc.Key != null)
				return textdoc;
			
			return new KeyValuePair<string, string>();
		}
		
		#region Private Fields
	
		private KeyValuePair<string, string> _document = new KeyValuePair<string, string>("Document", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Document");
		
		private KeyValuePair<string, string> _mind_map = new KeyValuePair<string, string>("MindMap", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#MindMap");
		
		private KeyValuePair<string, string> _presentation = new KeyValuePair<string, string>("Presentation", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Presentation");
		
		private KeyValuePair<string, string> _spreadsheet = new KeyValuePair<string, string>("Spreadsheet", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Spreadsheet");
		
		private TextDocumentType _text_document = new TextDocumentType();
		
		#endregion
	}
	
	public class TextDocumentType
	{
		/// <summary>
		/// A file containing a text document, that is unambiguously divided into pages. Examples might include PDF, DOC, PS, DVI etc. (Display name: 'PaginatedTextDocument')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#PaginatedTextDocument
		/// </remarks>
		public KeyValuePair<string, string> PaginatedTextDocument
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
		
		public KeyValuePair<string, string> Search(string interpretation)
		{
			if(string.Equals(_paginated_text_document.Value, interpretation))
			   return _paginated_text_document;
			
			KeyValuePair<string, string> plaintext = _plain_text_document.Search(interpretation);
			if(plaintext.Key != null)
				return plaintext;
			
			return new KeyValuePair<string, string>();
		}
		
		#region Private Fields
		
		private KeyValuePair<string, string> _paginated_text_document = new KeyValuePair<string, string>("Spreadsheet", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Spreadsheet");
		
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
		public KeyValuePair<string, string> PlainTextDocument
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
		public KeyValuePair<string, string> HtmlDocument
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
		public KeyValuePair<string, string> SourceCode
		{
			get
			{
				return _source_code;
			}
		}
		
		public KeyValuePair<string, string> Search(string interpretation)
		{
			if(string.Equals(_plain_text_document.Value, interpretation))
			   return _plain_text_document;
			
			if(string.Equals(_html_document.Value, interpretation))
			   return _html_document;
			
			if(string.Equals(_source_code.Value, interpretation))
			   return _source_code;
			
			return new KeyValuePair<string, string>();
		}
		
		#region Private Fields
		
		private KeyValuePair<string, string> _plain_text_document = new KeyValuePair<string, string>("PlainTextDocument", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#PlainTextDocument");
		
		private KeyValuePair<string, string> _html_document = new KeyValuePair<string, string>("HtmlDocument", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#HtmlDocument");
		
		private KeyValuePair<string, string> _source_code = new KeyValuePair<string, string>("SourceCode", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#SourceCode");
		
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
		public KeyValuePair<string, string> EventInterpretation
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
		public KeyValuePair<string, string> AccessEvent
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
		public KeyValuePair<string, string> CreateEvent
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
		public KeyValuePair<string, string> DeleteEvent
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
		public KeyValuePair<string, string> LeaveEvent
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
		public KeyValuePair<string, string> ModifyEvent
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
		public KeyValuePair<string, string> ReceiveEvent
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
		public KeyValuePair<string, string> SendEvent
		{
			get
			{
				return _send_event;
			}
		}
		
		public KeyValuePair<string, string> Search(string interpretation)
		{
			if(string.Equals(_event_interpretation.Value, interpretation))
			   return _event_interpretation;
			
			if(string.Equals(_access_event.Value, interpretation))
			   return _access_event;
			
			if(string.Equals(_create_event.Value, interpretation))
			   return _create_event;
			
			if(string.Equals(_delete_event.Value, interpretation))
			   return _delete_event;
			
			if(string.Equals(_leave_event.Value, interpretation))
			   return _leave_event;
			
			if(string.Equals(_modify_event.Value, interpretation))
			   return _modify_event;
			
			if(string.Equals(_receive_event.Value, interpretation))
			   return _receive_event;
			
			if(string.Equals(_send_event.Value, interpretation))
			   return _send_event;
			
			
			return new KeyValuePair<string, string>();
		}
		
		#region Private Fields
		
		private KeyValuePair<string, string> _event_interpretation = new KeyValuePair<string, string>("EventInterpretation", "http://www.zeitgeist-project.com/ontologies/2010/01/27/zg#EventInterpretation");
		
		private KeyValuePair<string, string> _access_event = new KeyValuePair<string, string>("AccessEvent", "http://www.zeitgeist-project.com/ontologies/2010/01/27/zg#AccessEvent");
		
		private KeyValuePair<string, string> _create_event = new KeyValuePair<string, string>("CreateEvent", "http://www.zeitgeist-project.com/ontologies/2010/01/27/zg#CreateEvent");
		
		private KeyValuePair<string, string> _delete_event = new KeyValuePair<string, string>("DeleteEvent", "http://www.zeitgeist-project.com/ontologies/2010/01/27/zg#DeleteEvent");
		
		private KeyValuePair<string, string> _leave_event = new KeyValuePair<string, string>("LeaveEvent", "http://www.zeitgeist-project.com/ontologies/2010/01/27/zg#LeaveEvent");
		
		private KeyValuePair<string, string> _modify_event = new KeyValuePair<string, string>("ModifyEvent", "http://www.zeitgeist-project.com/ontologies/2010/01/27/zg#ModifyEvent");
		
		private KeyValuePair<string, string> _receive_event = new KeyValuePair<string, string>("ReceiveEvent", "http://www.zeitgeist-project.com/ontologies/2010/01/27/zg#ReceiveEvent");
		
		private KeyValuePair<string, string> _send_event = new KeyValuePair<string, string>("SendEvent", "http://www.zeitgeist-project.com/ontologies/2010/01/27/zg#SendEvent");
		
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
		public KeyValuePair<string, string> Media
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
		public KeyValuePair<string, string> Audio
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
		public KeyValuePair<string, string> MusicPiece
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
		
		public KeyValuePair<string, string> Search(string interpretation)
		{
			if(string.Equals(_media.Value, interpretation))
			   return _media;
			
			if(string.Equals(_audio.Value, interpretation))
			   return _audio;
			
			if(string.Equals(_music_piece.Value, interpretation))
			   return _music_piece;
			
			KeyValuePair<string, string> visual = _visual_type.Search(interpretation);
			if(visual.Key != null)
				return visual;
			
			return new KeyValuePair<string, string>();
		}
		
		#region Private Fields
		
		private KeyValuePair<string, string> _media = new KeyValuePair<string, string>("Media", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Media");
		
		private KeyValuePair<string, string> _audio = new KeyValuePair<string, string>("Audio", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Audio");
		
		private KeyValuePair<string, string> _music_piece = new KeyValuePair<string, string>("MusicPiece", "http://www.semanticdesktop.org/ontologies/2009/02/19/nmm#MusicPiece");
		
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
		public KeyValuePair<string, string> Visual
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
		
		public KeyValuePair<string, string> Search(string interpretation)
		{
			if(string.Equals(_visual.Value, interpretation))
			   return _visual;
			
			KeyValuePair<string, string> image = _image.Search(interpretation);
			if(image.Key != null)
				return image;
			
			KeyValuePair<string, string> video = _video.Search(interpretation);
			if(video.Key != null)
				return video;
			
			return new KeyValuePair<string, string>();
		}
		
		#region Private Fields
		
		private KeyValuePair<string, string> _visual = new KeyValuePair<string, string>("Visual", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Visual");
		
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
		public KeyValuePair<string, string> Image
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
		public KeyValuePair<string, string> Icon
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
		public KeyValuePair<string, string> VectorImage
		{
			get
			{
				return _vector_image;
			}
		}
		
		public KeyValuePair<string, string> Search(string interpretation)
		{
			if(string.Equals(_image.Value, interpretation))
			   return _image;
			
			if(string.Equals(_icon.Value, interpretation))
			   return _icon;
			
			KeyValuePair<string, string> rast = _raster_image.Search(interpretation);
			if(rast.Key != null)
				return rast;
			
			if(string.Equals(_vector_image.Value, interpretation))
			   return _vector_image;
			
			return new KeyValuePair<string, string>();
		}
		
		#region Private Fields
		
		private KeyValuePair<string, string> _image = new KeyValuePair<string, string>("Image", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Image");
		
		private KeyValuePair<string, string> _icon = new KeyValuePair<string, string>("Icon", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Icon");
		
		private RasterImageType _raster_image = new RasterImageType();
		
		private KeyValuePair<string, string> _vector_image = new KeyValuePair<string, string>("VectorImage", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#VectorImage");
		
		
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
		public KeyValuePair<string, string> RasterImage
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
		public KeyValuePair<string, string> Cursor
		{
			get
			{
				return _cursor;
			}
		}
		
		public KeyValuePair<string, string> Search(string interpretation)
		{
			if(string.Equals(_raster_image.Value, interpretation))
			   return _raster_image;
			
			if(string.Equals(_cursor.Value, interpretation))
			   return _cursor;
			
			return new KeyValuePair<string, string>();
		}
		
		#region Private Fields
		
		private KeyValuePair<string, string> _raster_image = new KeyValuePair<string, string>("RasterImage", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#RasterImage");
		
		private KeyValuePair<string, string> _cursor = new KeyValuePair<string, string>("Cursor", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Cursor");
		
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
		public KeyValuePair<string, string> Video
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
		public KeyValuePair<string, string> Movie
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
		public KeyValuePair<string, string> TVShow
		{
			get
			{
				return _tv_show;
			}
		}
		
		public KeyValuePair<string, string> Search(string interpretation)
		{
			if(string.Equals(_video.Value, interpretation))
			   return _video;
			
			if(string.Equals(_movie.Value, interpretation))
			   return _movie;
			
			if(string.Equals(_tv_show.Value, interpretation))
			   return _tv_show;
			
			return new KeyValuePair<string, string>();
		}
		
		#region Private Fields
		
		private KeyValuePair<string, string> _video = new KeyValuePair<string, string>("Video", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Video");
		
		private KeyValuePair<string, string> _movie = new KeyValuePair<string, string>("Movie", "http://www.semanticdesktop.org/ontologies/2009/02/19/nmm#Movie");
		
		private KeyValuePair<string, string> _tv_show = new KeyValuePair<string, string>("TVShow", "http://www.semanticdesktop.org/ontologies/2009/02/19/nmm#TVShow");
		
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
		public KeyValuePair<string, string> MediaList
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
		public KeyValuePair<string, string> MusicAlbum
		{
			get
			{
				return _music_album;
			}
		}
		
		public KeyValuePair<string, string> Search(string interpretation)
		{
			if(string.Equals(_media_list.Value, interpretation))
			   return _media_list;
			
			if(string.Equals(_music_album.Value, interpretation))
			   return _music_album;
			
			return new KeyValuePair<string, string>();
		}
				
		#region Private Fields
		
		private KeyValuePair<string, string> _media_list = new KeyValuePair<string, string>("MediaList", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#MediaList");
		
		private KeyValuePair<string, string> _music_album = new KeyValuePair<string, string>("MusicAlbum", "http://www.semanticdesktop.org/ontologies/2009/02/19/nmm#MusicAlbum");
		
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
		public KeyValuePair<string, string> Message
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
		public KeyValuePair<string, string> Email
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
		public KeyValuePair<string, string> IMMessage
		{
			get
			{
				return _im_message;
			}
		}
		
		public KeyValuePair<string, string> Search(string interpretation)
		{
			if(string.Equals(_message.Value, interpretation))
			   return _message;
			
			if(string.Equals(_email.Value, interpretation))
			   return _email;
			
			if(string.Equals(_im_message.Value, interpretation))
			   return _im_message;
			
			return new KeyValuePair<string, string>();
		}
				
		#region Private Fields
		
		private KeyValuePair<string, string> _message = new KeyValuePair<string, string>("Message", "http://www.semanticdesktop.org/ontologies/2007/03/22/nmo#Message");
		
		private KeyValuePair<string, string> _email = new KeyValuePair<string, string>("Email", "http://www.semanticdesktop.org/ontologies/2007/03/22/nmo#Email");
		
		private KeyValuePair<string, string> _im_message = new KeyValuePair<string, string>("IMMessage", "http://www.semanticdesktop.org/ontologies/2007/03/22/nmo#IMMessage");
		
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
		public KeyValuePair<string, string> Software
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
		public KeyValuePair<string, string> Application
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
		public KeyValuePair<string, string> OperatingSystem
		{
			get
			{
				return _os;
			}
		}
		
		public KeyValuePair<string, string> Search(string interpretation)
		{
			if(string.Equals(_software.Value, interpretation))
			   return _software;
			
			if(string.Equals(_application.Value, interpretation))
			   return _application;
			
			if(string.Equals(_os.Value, interpretation))
			   return _os;
			
			return new KeyValuePair<string, string>();
		}
				
		#region Private Fields
		
		private KeyValuePair<string, string> _software = new KeyValuePair<string, string>("Software", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Software");
		
		private KeyValuePair<string, string> _application = new KeyValuePair<string, string>("Application", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#Application");
		
		private KeyValuePair<string, string> _os = new KeyValuePair<string, string>("OperatingSystem", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#OperatingSystem");
		
		#endregion
	}
	
	#endregion
}

