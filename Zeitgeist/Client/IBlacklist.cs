using System;
using Zeitgeist.Datamodel;
using Zeitgeist;

namespace Zeitgeist.Client
{
	[NDesk.DBus.Interface ("org.gnome.zeitgeist.Blacklist")]
	public interface IBlacklist
	{
		RawEvent[] GetBlacklist();
		void SetBlacklist(RawEvent[] event_templates);
	}
}

