using System;
using System.Collections.Generic;

namespace Zeitgeist.Datamodel
{
	/// <summary>
	/// The manifestation type of an event or subject is an abstract classification of “how did this happen” or “how does this item exist”.
	/// Each manifestation type is uniquely identified by a URI. This class provides a list of hard coded URI constants for programming convenience. In addition; each interpretation instance in this class has a display_name property, which is an internationalized string meant for end user display.
	/// </summary>
	/// <remarks>
	/// The manifestation types listed here are all subclasses of str and may be used anywhere a string would be used.
	/// Manifestations form a hierarchical type tree. So that fx. ArchiveItem, Attachment, and RemoteDataObject all are sub types of FileDataObject. These types can again have their own sub types.
	/// Templates match on all sub types, so that a query on subjects with manifestation FileDataObject also match subjects of types Attachment or ArchiveItem and all other sub types of FileDataObject . (Display name: '')
	/// </remarks>
	public class Manifestation
	{
		public static Manifestation Instance
		{
			get
			{
				if(_singleton_obj == null)
					_singleton_obj = new Manifestation();
				
				return _singleton_obj;
			}
		}
		
		/// <summary>
		/// A DataObject found in a calendar. It is usually interpreted as one of the calendar entity types (e.g. Event, Journal, Todo etc.). (Display name: 'CalendarDataObject')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/04/02/ncal#CalendarDataObject
		/// </remarks>
		public NameUri CalendarDataObject
		{
			get
			{
				return _cal_data_obj;
			}
		}
		
		/// <summary>
		/// Base class for event manifestation types. Please do no instantiate directly, but use one of the sub classes. The manifestation of an event describes ‘how it happened’. Fx. ‘the user did this’ or ‘the system notified the user’. (Display name: 'EVENT_MANIFESTATION')
		/// </summary>
		/// <remarks>
		/// http://www.zeitgeist-project.com/ontologies/2010/01/27/zg#EventManifestation
		/// </remarks>
		public EventManifestationType EventManifestation
		{
			get
			{
				return _event_manifestation;
			}
		}
		
		/// <summary>
		/// A resource containing a finite sequence of bytes with arbitrary information, that is available to a computer program and is usually based on some kind of durable storage. A file is durable in the sense that it remains available for programs to use after the current program has finished. (Display name: 'File')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#FileDataObject
		/// </remarks>
		public FileDataObjectType FileDataObject
		{
			get
			{
				return _file_data_obj;
			}
		}
		
		/// <summary>
		/// A partition on a hard disk. (Display name: 'HardDiskPartition')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#HardDiskPartition
		/// </remarks>
		public NameUri HardDiskPartition
		{
			get
			{
				return _hd_partition;
			}
		}
		
		/// <summary>
		/// An entity encountered in a mailbox. Most common interpretations for such an entity include Message or Folder. (Display name: 'MailboxDataObject')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/03/22/nmo#MailboxDataObject
		/// </remarks>
		public NameUri MailboxDataObject
		{
			get
			{
				return _mailbox_data_obj;
			}
		}
		
		/// <summary>
		/// A stream of multimedia content, usually contained within a media container such as a movie (containing both audio and video) or a DVD (possibly containing many streams of audio and video). Most common interpretations for such a DataObject include Audio and Video. (Display name: 'MediaStream')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#MediaStream
		/// </remarks>
		public NameUri MediaStream
		{
			get
			{
				return _media_stream;
			}
		}
		
		/// <summary>
		/// An address specifying a remote host and port. Such an address can be interpreted in many ways (examples of such interpretations include mailboxes, websites, remote calendars or filesystems), depending on an interpretation, various kinds of data may be extracted from such an address. (Display name: 'RemotePortAddress')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#RemotePortAddress
		/// </remarks>
		public NameUri RemotePortAddress
		{
			get
			{
				return _remote_port_addr;
			}
		}
		
		/// <summary>
		/// A DataObject representing a piece of software. Examples of interpretations of a SoftwareItem include an Application and an OperatingSystem. (Display name: 'SoftwareItem')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#SoftwareItem
		/// </remarks>
		public NameUri SoftwareItem
		{
			get
			{
				return _sw_item;
			}
		}
		
		/// <summary>
		/// A service published by a piece of software, either by an operating system or an application. Examples of such services may include calendar, addresbook and mailbox managed by a PIM application. This category is introduced to distinguish between data available directly from the applications (Via some Interprocess Communication Mechanisms) and data available from files on a disk. In either case both DataObjects would receive a similar interpretation (e.g. a Mailbox) and wouldn’t differ on the content level. (Display name: 'SoftwareService')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#SoftwareService
		/// </remarks>
		public NameUri SoftwareService
		{
			get
			{
				return _sw_service;
			}
		}
		
		public NameUri Search(string manifestation)
		{
			if(string.Equals(_cal_data_obj.Uri, manifestation))
			   return _cal_data_obj;
			
			NameUri event_manifestation = _event_manifestation.Search(manifestation);
			if(event_manifestation.Name != null)
				return event_manifestation;
			
			NameUri file_data_obj = _file_data_obj.Search(manifestation);
			if(file_data_obj.Name != null)
				return file_data_obj;
			
			if(string.Equals(_hd_partition.Uri, manifestation))
			   return _hd_partition;
			
			if(string.Equals(_mailbox_data_obj.Uri, manifestation))
			   return _mailbox_data_obj;
			
			if(string.Equals(_media_stream.Uri, manifestation))
			   return _media_stream;
			
			if(string.Equals(_remote_port_addr.Uri, manifestation))
			   return _remote_port_addr;
			
			if(string.Equals(_sw_item.Uri, manifestation))
			   return _sw_item;
			
			if(string.Equals(_sw_service.Uri, manifestation))
			   return _sw_service;
			
			return new NameUri();
		}
		
		#region Private Fields
		
		private static Manifestation _singleton_obj = new Manifestation();
		
		private NameUri _cal_data_obj = new NameUri("CalendarDataObject", "http://www.semanticdesktop.org/ontologies/2007/04/02/ncal#CalendarDataObject");
		
		private EventManifestationType _event_manifestation = new EventManifestationType();
		
		private FileDataObjectType _file_data_obj = new FileDataObjectType();
		
		private NameUri _hd_partition = new NameUri("HardDiskPartition", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#HardDiskPartition");
		
		private NameUri _mailbox_data_obj = new NameUri("MailboxDataObject", "http://www.semanticdesktop.org/ontologies/2007/03/22/nmo#MailboxDataObject");
		
		private NameUri _media_stream = new NameUri("MediaStream", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#MediaStream");
		
		private NameUri _remote_port_addr = new NameUri("RemotePortAddress", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#RemotePortAddress");
		
		private NameUri _sw_item = new NameUri("SoftwareItem", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#SoftwareItem");
		
		private NameUri _sw_service = new NameUri("SoftwareService", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#SoftwareService");
		
		#endregion
	}
	
	public class EventManifestationType
	{
		/// <summary>
		/// Base class for event manifestation types. Please do no instantiate directly, but use one of the sub classes. The manifestation of an event describes ‘how it happened’. Fx. ‘the user did this’ or ‘the system notified the user’. (Display name: 'EVENT_MANIFESTATION')
		/// </summary>
		/// <remarks>
		/// http://www.zeitgeist-project.com/ontologies/2010/01/27/zg#EventManifestation
		/// </remarks>
		public NameUri EventManifestation
		{
			get
			{
				return _evnt_manifest;
			}
		}
		
		/// <summary>
		/// An event that is caused indirectly from user activity or deducted via analysis of other events. Fx. if an algorithm divides a user workflow into disjoint ‘projects’ based on temporal analysis it could insert heuristic events when the user changed project. (Display name: 'HEURISTIC_ACTIVITY')
		/// </summary>
		/// <remarks>
		/// http://www.zeitgeist-project.com/ontologies/2010/01/27/zg#HeuristicActivity
		/// </remarks>
		public NameUri HeuristicActivity
		{
			get
			{
				return _heur_activity;
			}
		}
		
		/// <summary>
		/// An event that was directly triggered by some user initiated sequence of actions. For example a music player automatically changing to the next song in a playlist. (Display name: 'SCHEDULED_ACTIVITY')
		/// </summary>
		/// <remarks>
		/// http://www.zeitgeist-project.com/ontologies/2010/01/27/zg#ScheduledActivity
		/// </remarks>
		public NameUri ScheduledActivity
		{
			get
			{
				return _schld_activity;
			}
		}
		
		/// <summary>
		/// An event send to the user by the operating system. Examples could include when the user inserts a USB stick or when the system warns that the hard disk is full. (Display name: 'SYSTEM_NOTIFICATION')
		/// </summary>
		/// <remarks>
		/// http://www.zeitgeist-project.com/ontologies/2010/01/27/zg#SystemNotification
		/// </remarks>
		public NameUri SystemNotification
		{
			get
			{
				return _sys_notification;
			}
		}
		
		/// <summary>
		/// An event that was actively performed by the user. For example saving or opening a file by clicking on it in the file manager. (Display name: 'USER_ACTIVITY')
		/// </summary>
		/// <remarks>
		/// http://www.zeitgeist-project.com/ontologies/2010/01/27/zg#UserActivity
		/// </remarks>
		public NameUri UserActivity
		{
			get
			{
				return _user_activity;
			}
		}
		
		/// <summary>
		/// An event that was performed by an entity, usually human or organization, other than the user. An example could be logging the activities of other people in a team. (Display name: 'WORLD_ACTIVITY')
		/// </summary>
		/// <remarks>
		/// http://www.zeitgeist-project.com/ontologies/2010/01/27/zg#WorldActivity
		/// </remarks>
		public NameUri WorldActivity
		{
			get
			{
				return _world_activity;
			}
		}
		
		public NameUri Search(string manifestation)
		{
			if(string.Equals(_evnt_manifest.Uri, manifestation))
			   return _evnt_manifest;
			
			if(string.Equals(_heur_activity.Uri, manifestation))
			   return _heur_activity;
			
			if(string.Equals(_schld_activity.Uri, manifestation))
			   return _schld_activity;
			
			if(string.Equals(_sys_notification.Uri, manifestation))
			   return _sys_notification;
			
			if(string.Equals(_user_activity.Uri, manifestation))
			   return _user_activity;
			
			if(string.Equals(_world_activity.Uri, manifestation))
			   return _world_activity;
			
			return new NameUri();
		}
		
		#region Private Fields
		
		private NameUri _evnt_manifest = new NameUri("EventManifestation", "http://www.zeitgeist-project.com/ontologies/2010/01/27/zg#EventManifestation");
		
		private NameUri _heur_activity = new NameUri("HeuristicActivity", "http://www.zeitgeist-project.com/ontologies/2010/01/27/zg#HeuristicActivity");
		
		private NameUri _schld_activity = new NameUri("ScheduledActivity", "http://www.zeitgeist-project.com/ontologies/2010/01/27/zg#ScheduledActivity");
		
		private NameUri _sys_notification = new NameUri("SystemNotification", "http://www.zeitgeist-project.com/ontologies/2010/01/27/zg#SystemNotification");
		
		private NameUri _user_activity = new NameUri("UserActivity", "http://www.zeitgeist-project.com/ontologies/2010/01/27/zg#UserActivity");
		
		private NameUri _world_activity = new NameUri("WorldActivity", "http://www.zeitgeist-project.com/ontologies/2010/01/27/zg#WorldActivity");
		
		#endregion
	}
	
	public class FileDataObjectType
	{
		/// <summary>
		/// A resource containing a finite sequence of bytes with arbitrary information, that is available to a computer program and is usually based on some kind of durable storage. A file is durable in the sense that it remains available for programs to use after the current program has finished. (Display name: 'File')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#FileDataObject
		/// </remarks>
		public NameUri FileDataObject
		{
			get
			{
				return _file_data_obj;
			}
		}
		
		/// <summary>
		/// A file entity that has been deleted from the original source. Usually such entities are stored within various kinds of ‘Trash’ or ‘Recycle Bin’ folders. (Display name: 'DeletedResource')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#DeletedResource
		/// </remarks>
		public NameUri DeletedResource
		{
			get
			{
				return _deleted_resc;
			}
		}
		
		/// <summary>
		/// A file embedded in another data object. There are many ways in which a file may be embedded in another one. Use this class directly only in cases if none of the subclasses gives a better description of your case. (Display name: 'EmbeddedFileDataObject')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#EmbeddedFileDataObject
		/// </remarks>
		public EmbeddedFileDataObjectType EmbeddedFileDataObject
		{
			get
			{
				return _embedded_file_data_obj;
			}
		}
		
		/// <summary>
		/// A file data object stored at a remote location. Don’t confuse this class with a RemotePortAddress. This one applies to a particular resource, RemotePortAddress applies to an address, that can have various interpretations. (Display name: 'RemoteDataObject')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#RemoteDataObject
		/// </remarks>
		public NameUri RemoteDataObject
		{
			get
			{
				return _remote_data_obj;
			}
		}
		
		public NameUri Search(string manifestation)
		{
			if(string.Equals(_file_data_obj.Uri, manifestation))
			   return _file_data_obj;
			
			if(string.Equals(_deleted_resc.Uri, manifestation))
			   return _deleted_resc;
			
			NameUri embedded_file_data_obj = _embedded_file_data_obj.Search(manifestation);
			if(embedded_file_data_obj.Name != null)
				return embedded_file_data_obj;
			
			if(string.Equals(_remote_data_obj.Uri, manifestation))
			   return _remote_data_obj;
			
			return new NameUri();
		}
		
		#region Private Fields
		
		private NameUri _file_data_obj = new NameUri("FileDataObject", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#FileDataObject");
		
		private NameUri _deleted_resc = new NameUri("DeletedResource", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#DeletedResource");
		
		private EmbeddedFileDataObjectType _embedded_file_data_obj = new EmbeddedFileDataObjectType();
		
		private NameUri _remote_data_obj = new NameUri("RemoteDataObject", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#RemoteDataObject");
		
		#endregion
	}
	
	public class EmbeddedFileDataObjectType
	{
		/// <summary>
		/// A file embedded in another data object. There are many ways in which a file may be embedded in another one. Use this class directly only in cases if none of the subclasses gives a better description of your case. (Display name: 'EmbeddedFileDataObject')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#EmbeddedFileDataObject
		/// </remarks>
		public NameUri EmbeddedFileDataObject
		{
			get
			{
				return _embedded_file_data_obj;
			}
		}
		
		/// <summary>
		/// A file entity inside an archive. (Display name: 'ArchiveItem')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#ArchiveItem
		/// </remarks>
		public NameUri ArchiveItem
		{
			get
			{
				return _archive_item;
			}
		}
		
		/// <summary>
		/// An object attached to a calendar entity. This class has been introduced to serve as a structured value of the ncal:attach property. See the documentation of ncal:attach for details. (Display name: 'Attachment')
		/// </summary>
		/// <remarks>
		/// http://www.semanticdesktop.org/ontologies/2007/04/02/ncal#Attachment
		/// </remarks>
		public NameUri Attachment
		{
			get
			{
				return _attachment;
			}
		}
		
		public NameUri Search(string manifestation)
		{
			if(string.Equals(_embedded_file_data_obj.Uri, manifestation))
			   return _embedded_file_data_obj;
			
			if(string.Equals(_archive_item.Uri, manifestation))
			   return _archive_item;
			
			if(string.Equals(_attachment.Uri, manifestation))
			   return _attachment;
			
			return new NameUri();
		}
		
		#region Private Fields
		
		private NameUri _embedded_file_data_obj = new NameUri("EmbeddedFileDataObject", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#EmbeddedFileDataObject");
		
		private NameUri _archive_item = new NameUri("ArchiveItem", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#ArchiveItem");
		
		private NameUri _attachment = new NameUri("Attachment", "http://www.semanticdesktop.org/ontologies/2007/04/02/ncal#Attachment");
		
		#endregion
	}
}

