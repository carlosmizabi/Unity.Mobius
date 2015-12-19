using UnityEngine;
using System.Collections;
using Tautalos.Unity.Mobius.Broadcasters;
using System.Collections.Generic;
using Tautalos.Unity.Mobius.Signals;

namespace Tautalos.Unity.Mobius.Channels
{
	public class Channel: IChannel
	{
		IDictionary<IEventType, IBroadcaster> registry;
		
		public Channel ()
		{
			registry = new Dictionary<IEventType, IBroadcaster> ();
		}
		public IDictionary<IEventType, IBroadcaster> GetRegistry ()
		{
			return registry;
		}
		
		public void AddEventEntry (IEventEntry entry)
		{
			GetRegistry ().Add (entry.EventType, entry.Broadcaster);
		}
		
		public bool HasEventType (IEventType eventType)
		{
			throw new System.NotImplementedException ();
		}
		
		public bool HasEventType (string typeName)
		{
			throw new System.NotImplementedException ();
		}
		
		public bool HasNamedBroadcaster (string name)
		{
			throw new System.NotImplementedException ();
		}
		
		public IEventType GetEventType (string typeName)
		{
			throw new System.NotImplementedException ();
		}
		
		public List<IEventType> GetEventEntries (IBroadcaster broadcaster)
		{
			throw new System.NotImplementedException ();
		}
		
		public IBroadcaster GetBroadcaster (string eventType)
		{
			throw new System.NotImplementedException ();
		}
		
		public IBroadcaster getBroadcaster (IEventType eventType)
		{
			throw new System.NotImplementedException ();
		}
		
		public bool WhichEventTypesExist (EventType[] eventTypes)
		{
			throw new System.NotImplementedException ();
		}
		
		public bool WhichEventTypesExist (string[] typeNames)
		{
			throw new System.NotImplementedException ();
		}
		
		public bool IsEmittable (ISignal signal)
		{
			throw new System.NotImplementedException ();
		}
		
		public void Emit (ISignal signal)
		{
			throw new System.NotImplementedException ();
		}
		
		public ISignaller CreateSignaller ()
		{
			throw new System.NotImplementedException ();
		}

	}
}

