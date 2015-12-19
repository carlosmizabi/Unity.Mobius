
using Tautalos.Unity.Mobius.Broadcasters;

namespace Tautalos.Unity.Mobius.Channels
{
	public class EventEntry: IEventEntry
	{
		IEventType _eventType;
		IBroadcaster _broadcaster;
		
		public EventEntry (IEventType eventType, IBroadcaster broadcaster)
		{
			_eventType = eventType;
			_broadcaster = broadcaster;
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
			return false;
		}	
		
	}
	 
}

