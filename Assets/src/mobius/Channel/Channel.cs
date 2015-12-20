using UnityEngine;
using System.Collections;
using Tautalos.Unity.Mobius.Broadcasters;
using System.Collections.Generic;
using Tautalos.Unity.Mobius.Signals;
using System;

namespace Tautalos.Unity.Mobius.Channels
{
	public class Channel: IChannel
	{
		public Channel ()
		{
			_defaultBroadcaster = new Broadcaster ("default-broadcaster");
			_registry = new Dictionary<IEventTag, IBroadcaster> ();
		}
		
		public string Name {
			get {
				throw new NotImplementedException ();
			}
		}
		
		public IBroadcaster DefaultBroadcaster {
			get { return _defaultBroadcaster; }
		}
		
		public IDictionary<IEventTag, IBroadcaster> Registry {
			get { return _registry; }
		}
		
		public   bool IsEmpty { 
			get { return ChannelHelper.IsEmptyChannel (this); } 
		}

		public void Silence ()
		{
			throw new NotImplementedException ();
		}
		
		public void AddEventEntry (IEventEntry entry)
		{
			if (_CanAddEntry (entry)) {
				Registry.Add (entry.EventTag, entry.Broadcaster);
			}
		}
		
		public void AddEvent (IEventTag eventTag)
		{
			var entry = new EventEntry (eventTag, DefaultBroadcaster);
			AddEventEntry (entry);
		}	
		
		public bool HasEventTag (IEventTag eventTag)
		{
			return Registry.ContainsKey (eventTag);
		}
		
		public bool HasEventTag (string tagName)
		{
			bool result = false;
			foreach (IEventTag key in Registry.Keys) {
				if (key.Name.Contains (tagName)) {
					result = true;
				}
			}		
			return result;
		}
		
		public bool HasNamedBroadcaster (string name)
		{
			throw new System.NotImplementedException ();
		}
		
		public IEventTag GetEventTag (string tagName)
		{
			IEventTag eventTag = EmptyEventTag.Instance;
			foreach (IEventTag key in Registry.Keys) {
				if (key.Name.Contains (tagName)) {
					eventTag = key;
					break;
				}
			}		
			return eventTag;
		}
		
		public ICollection<IEventTag> GetAllEventTags ()
		{
			return Registry.Keys as ICollection<IEventTag>;
		}
		
		public ICollection<IEventTag> GetEventTags (IBroadcaster broadcaster)
		{
			var list = new List<IEventTag> ();
			foreach (IEventTag tag in Registry.Keys) {
				IBroadcaster b = Registry [tag];
				if (b == broadcaster) {
					list.Add (tag);
				}
			}
			return list;
		}
		
		public IBroadcaster GetBroadcasterNamed (string broadcasterName)
		{
			IBroadcaster broadcaster = EmptyBroadcaster.Instance;
			foreach (IBroadcaster b in Registry.Values) {
				if (b.Name == broadcasterName) {
					broadcaster = b;
					break;
				}
			}
			return broadcaster;
		}
		
		public IBroadcaster GetBroadcasterFor (string eventTagName)
		{
			IBroadcaster broadcaster = EmptyBroadcaster.Instance;
			var eventTag = GetEventTag (eventTagName);
			if (eventTag != EmptyEventTag.Instance) {
				broadcaster = Registry [eventTag];
			}
			return broadcaster;
		}
		
		public IBroadcaster GetBroadcasterFor (IEventTag eventTag)
		{
			IBroadcaster broadcaster = EmptyBroadcaster.Instance;
			if (eventTag != EmptyEventTag.Instance) {
				IBroadcaster result;
				Registry.TryGetValue (eventTag, out result);
				broadcaster = result is Broadcaster ? result : broadcaster;
			}
			return broadcaster;
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
		
		/********************************************************************
		
			Private
		
		*********************************************************************/
		
		IBroadcaster _defaultBroadcaster;
		IDictionary<IEventTag, IBroadcaster> _registry;
		
		bool _CanAddEntry (IEventEntry entry)
		{
			return (
				entry != null && 
				!entry.IsEmpty && 
				!entry.EventTag.IsEmpty &&
				!HasEventTag (entry.EventTag.Name)
			);
		}
	}
}

