using UnityEngine;
using System.Collections;
using Tautalos.Unity.Mobius.Broadcasters;
using System.Collections.Generic;
using Tautalos.Unity.Mobius.Signals;

namespace Tautalos.Unity.Mobius.Channels
{
	public class Channel: IChannel
	{
		public bool IsEmpty { 
			get { return false; } 
		}
		
		IDictionary<IEventTag, IBroadcaster> registry;
		
		public Channel ()
		{
			registry = new Dictionary<IEventTag, IBroadcaster> ();
		}
		public IDictionary<IEventTag, IBroadcaster> GetRegistry ()
		{
			return registry;
		}
		
		public void AddEventEntry (IEventEntry entry)
		{
			if (entry != null && !entry.IsEmpty && !entry.EventTag.IsEmpty) {
				GetRegistry ().Add (entry.EventTag, entry.Broadcaster);
			}
		}	
		
		public bool HasEventTag (IEventTag eventTag)
		{
			throw new System.NotImplementedException ();
		}
		
		public bool HasEventTag (string tagName)
		{
			throw new System.NotImplementedException ();
		}
		
		public bool HasNamedBroadcaster (string name)
		{
			throw new System.NotImplementedException ();
		}
		
		public IEventTag GetEventTag (string tagName)
		{
			throw new System.NotImplementedException ();
		}
		
		public List<IEventTag> GetEventEntries (IBroadcaster broadcaster)
		{
			throw new System.NotImplementedException ();
		}
		
		public IBroadcaster GetBroadcaster (string eventTagName)
		{
			throw new System.NotImplementedException ();
		}
		
		public IBroadcaster getBroadcaster (IEventTag eventTag)
		{
			throw new System.NotImplementedException ();
		}
		
		public bool WhichEventTagsExist (EventTag[] eventTag)
		{
			throw new System.NotImplementedException ();
		}
		
		public bool WhichEventTagsExist (string[] tagNames)
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

