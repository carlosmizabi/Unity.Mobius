
using Tautalos.Unity.Mobius.Broadcasters;

namespace Tautalos.Unity.Mobius.Channels
{
	public class EmptyEventEntry: IEventEntry
	{
		IEventType _eventType = EmptyEventType.Instance;
		IBroadcaster _broadcaster = EmptyBroadcaster.Instance;
		
		static EmptyEventEntry _instance = new EmptyEventEntry ();
		
		public static EmptyEventEntry Instance {
			get { return _instance; }
		}
		
		
		public IEventType EventType {
			get {
				return _eventType;
			}
		}
		
		public IBroadcaster Broadcaster {
			get {
				return _broadcaster;
			}
		}
		
		public bool IsEmpty ()
		{
			return true;
		}	
		
	}
	
}

