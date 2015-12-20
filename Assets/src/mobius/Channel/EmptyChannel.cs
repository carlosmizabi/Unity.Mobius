using Tautalos.Unity.Mobius.Broadcasters;
using System.Collections.Generic;
using Tautalos.Unity.Mobius.Signals;

namespace Tautalos.Unity.Mobius.Channels
{
	public class EmptyChannel: IChannel
	{		
		string _name = "EmptyChannel";
		
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
		
		public IEventTag[] GetEventTags ()
		{
			return new EventTag[0];
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
		
		public List<IEventTag> GetEventEntries (IBroadcaster broadcaster)
		{
			return new List<IEventTag> ();
		}
		
		public IBroadcaster GetBroadcaster (string eventTagName)
		{
			return EmptyBroadcaster.Instance;
		}
		
		public IBroadcaster GetBroadcaster (IEventTag eventTag)
		{
			return EmptyBroadcaster.Instance;
		}
		
		public bool WhichEventTagsExist (EventTag[] eventTag)
		{
			return false;
		}
		
		public bool WhichEventTagsExist (string[] tagNames)
		{
			return false;
		}
		
		public bool IsEmittable (ISignal signal)
		{
			return false;
		}
		
		public void Emit (ISignal signal)
		{	
		}
		
		public ISignaller CreateSignaller ()
		{
			return null;
		}
	}
}

