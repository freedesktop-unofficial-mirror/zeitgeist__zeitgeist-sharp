using System;

namespace Zeitgeist.Datamodel
{
	/// <summary>
	/// Enumeration class defining the possible values for the storage state of an event subject.
	/// The StorageState enumeration can be used to control whether or not matched events must have their subjects available to the user. 
	/// Ex. not including deleted files, files on unplugged USB drives, files available only when a network is available etc.
	/// </summary>
	public enum StorageState
	{
		/// <summary>
		/// The storage medium of the events subjects must not be available to the user. (Integer value: 0)
		/// </summary>
		NotAvailable = 0,
		
		/// <summary>
		/// The storage medium of all event subjects must be immediately available to the user. (Integer value: 1)
		/// </summary>
		Available = 1,
		
		/// <summary>
		/// The event subjects may or may not be available. (Integer value: 2)
		/// </summary>
		Any = 2
	}
}

