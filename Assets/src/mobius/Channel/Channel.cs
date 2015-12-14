using UnityEngine;
using System.Collections;
using Tautalos.Unity.Mobius.Broadcaster;
using System.Collections.Generic;
using Tautalos.Unity.Mobius.Signal;

namespace Tautalos.Unity.Mobius.Channel
{
	public class Channel: IChannel
	{
		public List<IBroadcaster> GetRegistry ()
		{
			throw new System.NotImplementedException ();
		}
		
		public void AddEventEntry (IEventEntry entry)
		{
			throw new System.NotImplementedException ();
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

