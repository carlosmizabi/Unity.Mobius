
using Tautalos.Unity.Mobius.Broadcasters;

namespace Tautalos.Unity.Mobius.Channels
{
	public class EmptyEventEntry: IEventEntry
	{
		IEventTag _eventTag = EmptyEventTag.Instance;
		IBroadcaster _broadcaster = EmptyBroadcaster.Instance;
		
		public bool IsEmpty {
			get { return true; }
		}
		
		static EmptyEventEntry _instance = new EmptyEventEntry ();
		
		public static EmptyEventEntry Instance {
			get { return _instance; }
		}
		
		
		public IEventTag EventTag {
			get {
				return _eventTag;
			}
		}
		
		public IBroadcaster Broadcaster {
			get {
				return _broadcaster;
			}
		}	
		
	}
	
}

