using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Tautalos.Unity.Mobius.Broadcasters;
using Tautalos.Unity.Mobius.Signals;

namespace Tautalos.Unity.Mobius.Channels
{
	public interface IChannel
	{
		IDictionary<IEventType, IBroadcaster> GetRegistry ();
		
		void AddEventEntry (IEventEntry entry);
		
		bool HasEventType (IEventType eventType);
		
		bool HasEventType (string typeName);
		
		bool HasNamedBroadcaster (string name);
		
		IEventType GetEventType (string typeName);
		
		List<IEventType> GetEventEntries (IBroadcaster broadcaster);
		
		IBroadcaster GetBroadcaster (string eventType);
		
		IBroadcaster getBroadcaster (IEventType eventType);
		
		bool WhichEventTypesExist (EventType[] eventTypes);
		
		bool WhichEventTypesExist (string[] typeNames);
		
		bool IsEmittable (ISignal signal);		
		void Emit (ISignal signal);
		
		ISignaller CreateSignaller ();
		
		bool IsEmpty ();
	}
}
