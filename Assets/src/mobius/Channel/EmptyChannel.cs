using Tautalos.Unity.Mobius.Broadcasters;
using System.Collections.Generic;
using Tautalos.Unity.Mobius.Signals;
using System.Collections;

namespace Tautalos.Unity.Mobius.Channels
{
	public class EmptyChannel: IChannel
	{		
		string _name = "empty-channel";
		
		static IChannel StaticEmptyChannel = new EmptyChannel ();
		public static IChannel Instance {
			get { return StaticEmptyChannel; }
		}
				
		public IBroadcaster DefaultBroadcaster {
			get { return EmptyBroadcaster.Instance; }
		}
		
		public IDictionary<IEventTag, IBroadcaster> Registry {
			get { return new Dictionary<IEventTag, IBroadcaster> (); }
		}
		
		public  bool IsEmpty { 
			get { return ChannelHelper.IsEmptyChannel (this); } 
		}
		
		
		public bool HasEventTag ()
		{
			return false;
		}
		
		public void Silence ()
		{
		}
		
		public string Name {
			get {
				return _name;
			}
		}
		
		public void AddEventEntry (IEventEntry entry)
		{
		}
		
		public void AddEvent (IEventTag eventTag)
		{
		}	
		
		public bool HasEventTag (IEventTag eventTag)
		{
			return false;
		}
		
		public bool HasEventTag (string tagName)
		{		
			return false;
		}
		
		public bool HasNamedBroadcaster (string name)
		{
			return false;
		}
		
		public IEventTag GetEventTag (string tagName)
		{
			return EmptyEventTag.Instance;
		}
		
		public ICollection<IEventTag> GetEventTags (IBroadcaster broadcaster)
		{
			return GetAllEventTags ();
		}
		
		public ICollection<IEventTag> GetAllEventTags ()
		{
			return new List<IEventTag> ();
		}
		
		public IBroadcaster GetBroadcasterNamed (string broadcasterName)
		{
			return EmptyBroadcaster.Instance;
		}
		
		public IBroadcaster GetBroadcasterFor (string eventTagName)
		{
			return EmptyBroadcaster.Instance;
		}
		
		public IBroadcaster GetBroadcasterFor (IEventTag eventTag)
		{
			return EmptyBroadcaster.Instance;
		}
		
		public bool IsEmittable (ISignal signal)
		{
			return false;
		}
		
		public void Emit (ISignal signal)
		{	
		}
		
		public ISignaller CreateSignaller (object owner)
		{
			return null;
		}
	}
}

