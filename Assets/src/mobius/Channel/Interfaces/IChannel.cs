using UnityEngine;
using System.Collections;
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
		
		List<IEventTag> GetEventEntries (IBroadcaster broadcaster);
		
		IBroadcaster GetBroadcaster (string eventTagName);
		
		IBroadcaster GetBroadcaster (IEventTag eventTag);
		
		bool WhichEventTagsExist (EventTag[] eventTag);
		
		bool WhichEventTagsExist (string[] tagNames);
		
		bool IsEmittable (ISignal signal);	
			
		void Emit (ISignal signal);
		
		ISignaller CreateSignaller ();
		
	}
}
