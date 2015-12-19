
using Tautalos.Unity.Mobius.Broadcasters;

namespace Tautalos.Unity.Mobius.Channels
{
	public class EventEntryMock: IEventEntry
	{
		public EventEntryMock ()
		{
			
		}

		public IEventType EventType {
			get {
				throw new System.NotImplementedException ();
			}
		}

		public IBroadcaster Broadcaster {
			get {
				throw new System.NotImplementedException ();
			}
		}
		
		IEventType _eventType;
		IBroadcaster _broadcaster;
	}
}

