using System.Collections.Generic;
using Tautalos.Unity.Mobius.Broadcasters;
using Tautalos.Unity.Mobius.Signals;

namespace Tautalos.Unity.Mobius.Channels
{
	public interface IChannel
	{
		bool IsEmpty { get; }
		
		IBroadcaster DefaultBroadcaster { get; }
		
		IDictionary<IEventTag, IBroadcaster> Registry { get; }
		
		void AddEventEntry (IEventEntry entry);
		
		void AddEvent (IEventTag eventTag);
		
		bool HasEventTag (IEventTag eventTag);
		
		bool HasEventTag (string typeName);
		
		bool HasNamedBroadcaster (string name);
		
		IEventTag GetEventTag (string typeName);
		
		ICollection<IEventTag> GetAllEventTags ();
		
		ICollection<IEventTag> GetEventTags (IBroadcaster broadcaster);
		
		IBroadcaster GetBroadcasterNamed (string broadcasterName);
		
		IBroadcaster GetBroadcasterFor (string eventTagName);
		
		IBroadcaster GetBroadcasterFor (IEventTag eventTag);
		
		bool IsEmittable (ISignal signal);	
			
		void Emit (ISignal signal);
		
		ISignaller CreateSignaller (object owner);
		
	}
}
