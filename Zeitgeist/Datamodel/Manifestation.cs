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
		public KeyValuePair<string, string> CalendarDataObject
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
		public KeyValuePair<string, string> HardDiskPartition
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
		public KeyValuePair<string, string> MailboxDataObject
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
		public KeyValuePair<string, string> MediaStream
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
		public KeyValuePair<string, string> RemotePortAddress
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
		public KeyValuePair<string, string> SoftwareItem
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
		public KeyValuePair<string, string> SoftwareService
		{
			get
			{
				return _sw_service;
			}
		}
		
		public KeyValuePair<string, string> Search(string manifestation)
		{
			if(string.Equals(_cal_data_obj.Value, manifestation))
			   return _cal_data_obj;
			
			KeyValuePair<string, string> event_manifestation = _event_manifestation.Search(manifestation);
			if(event_manifestation.Key != null)
				return event_manifestation;
			
			KeyValuePair<string, string> file_data_obj = _file_data_obj.Search(manifestation);
			if(file_data_obj.Key != null)
				return file_data_obj;
			
			if(string.Equals(_hd_partition.Value, manifestation))
			   return _hd_partition;
			
			if(string.Equals(_mailbox_data_obj.Value, manifestation))
			   return _mailbox_data_obj;
			
			if(string.Equals(_media_stream.Value, manifestation))
			   return _media_stream;
			
			if(string.Equals(_remote_port_addr.Value, manifestation))
			   return _remote_port_addr;
			
			if(string.Equals(_sw_item.Value, manifestation))
			   return _sw_item;
			
			if(string.Equals(_sw_service.Value, manifestation))
			   return _sw_service;
			
			return new KeyValuePair<string, string>();
		}
		
		#region Private Fields
		
		private static Manifestation _singleton_obj = new Manifestation();
		
		private KeyValuePair<string, string> _cal_data_obj = new KeyValuePair<string, string>("CalendarDataObject", "http://www.semanticdesktop.org/ontologies/2007/04/02/ncal#CalendarDataObject");
		
		private EventManifestationType _event_manifestation = new EventManifestationType();
		
		private FileDataObjectType _file_data_obj = new FileDataObjectType();
		
		private KeyValuePair<string, string> _hd_partition = new KeyValuePair<string, string>("HardDiskPartition", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#HardDiskPartition");
		
		private KeyValuePair<string, string> _mailbox_data_obj = new KeyValuePair<string, string>("MailboxDataObject", "http://www.semanticdesktop.org/ontologies/2007/03/22/nmo#MailboxDataObject");
		
		private KeyValuePair<string, string> _media_stream = new KeyValuePair<string, string>("MediaStream", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#MediaStream");
		
		private KeyValuePair<string, string> _remote_port_addr = new KeyValuePair<string, string>("RemotePortAddress", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#RemotePortAddress");
		
		private KeyValuePair<string, string> _sw_item = new KeyValuePair<string, string>("SoftwareItem", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#SoftwareItem");
		
		private KeyValuePair<string, string> _sw_service = new KeyValuePair<string, string>("SoftwareService", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#SoftwareService");
		
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
		public KeyValuePair<string, string> EventManifestation
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
		public KeyValuePair<string, string> HeuristicActivity
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
		public KeyValuePair<string, string> ScheduledActivity
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
		public KeyValuePair<string, string> SystemNotification
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
		public KeyValuePair<string, string> UserActivity
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
		public KeyValuePair<string, string> WorldActivity
		{
			get
			{
				return _world_activity;
			}
		}
		
		public KeyValuePair<string, string> Search(string manifestation)
		{
			if(string.Equals(_evnt_manifest.Value, manifestation))
			   return _evnt_manifest;
			
			if(string.Equals(_heur_activity.Value, manifestation))
			   return _heur_activity;
			
			if(string.Equals(_schld_activity.Value, manifestation))
			   return _schld_activity;
			
			if(string.Equals(_sys_notification.Value, manifestation))
			   return _sys_notification;
			
			if(string.Equals(_user_activity.Value, manifestation))
			   return _user_activity;
			
			if(string.Equals(_world_activity.Value, manifestation))
			   return _world_activity;
			
			return new KeyValuePair<string, string>();
		}
		
		#region Private Fields
		
		private KeyValuePair<string, string> _evnt_manifest = new KeyValuePair<string, string>("EventManifestation", "http://www.zeitgeist-project.com/ontologies/2010/01/27/zg#EventManifestation");
		
		private KeyValuePair<string, string> _heur_activity = new KeyValuePair<string, string>("HeuristicActivity", "http://www.zeitgeist-project.com/ontologies/2010/01/27/zg#HeuristicActivity");
		
		private KeyValuePair<string, string> _schld_activity = new KeyValuePair<string, string>("ScheduledActivity", "http://www.zeitgeist-project.com/ontologies/2010/01/27/zg#ScheduledActivity");
		
		private KeyValuePair<string, string> _sys_notification = new KeyValuePair<string, string>("SystemNotification", "http://www.zeitgeist-project.com/ontologies/2010/01/27/zg#SystemNotification");
		
		private KeyValuePair<string, string> _user_activity = new KeyValuePair<string, string>("UserActivity", "http://www.zeitgeist-project.com/ontologies/2010/01/27/zg#UserActivity");
		
		private KeyValuePair<string, string> _world_activity = new KeyValuePair<string, string>("WorldActivity", "http://www.zeitgeist-project.com/ontologies/2010/01/27/zg#WorldActivity");
		
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
		public KeyValuePair<string, string> FileDataObject
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
		public KeyValuePair<string, string> DeletedResource
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
		public KeyValuePair<string, string> RemoteDataObject
		{
			get
			{
				return _remote_data_obj;
			}
		}
		
		public KeyValuePair<string, string> Search(string manifestation)
		{
			if(string.Equals(_file_data_obj.Value, manifestation))
			   return _file_data_obj;
			
			if(string.Equals(_deleted_resc.Value, manifestation))
			   return _deleted_resc;
			
			KeyValuePair<string, string> embedded_file_data_obj = _embedded_file_data_obj.Search(manifestation);
			if(embedded_file_data_obj.Key != null)
				return embedded_file_data_obj;
			
			if(string.Equals(_remote_data_obj.Value, manifestation))
			   return _remote_data_obj;
			
			return new KeyValuePair<string, string>();
		}
		
		#region Private Fields
		
		private KeyValuePair<string, string> _file_data_obj = new KeyValuePair<string, string>("FileDataObject", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#FileDataObject");
		
		private KeyValuePair<string, string> _deleted_resc = new KeyValuePair<string, string>("DeletedResource", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#DeletedResource");
		
		private EmbeddedFileDataObjectType _embedded_file_data_obj = new EmbeddedFileDataObjectType();
		
		private KeyValuePair<string, string> _remote_data_obj = new KeyValuePair<string, string>("RemoteDataObject", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#RemoteDataObject");
		
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
		public KeyValuePair<string, string> EmbeddedFileDataObject
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
		public KeyValuePair<string, string> ArchiveItem
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
		public KeyValuePair<string, string> Attachment
		{
			get
			{
				return _attachment;
			}
		}
		
		public KeyValuePair<string, string> Search(string manifestation)
		{
			if(string.Equals(_embedded_file_data_obj.Value, manifestation))
			   return _embedded_file_data_obj;
			
			if(string.Equals(_archive_item.Value, manifestation))
			   return _archive_item;
			
			if(string.Equals(_attachment.Value, manifestation))
			   return _attachment;
			
			return new KeyValuePair<string, string>();
		}
		
		#region Private Fields
		
		private KeyValuePair<string, string> _embedded_file_data_obj = new KeyValuePair<string, string>("EmbeddedFileDataObject", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#EmbeddedFileDataObject");
		
		private KeyValuePair<string, string> _archive_item = new KeyValuePair<string, string>("ArchiveItem", "http://www.semanticdesktop.org/ontologies/2007/03/22/nfo#ArchiveItem");
		
		private KeyValuePair<string, string> _attachment = new KeyValuePair<string, string>("Attachment", "http://www.semanticdesktop.org/ontologies/2007/04/02/ncal#Attachment");
		
		#endregion
	}
}

