
using Tautalos.Unity.Mobius.Broadcasters;

namespace Tautalos.Unity.Mobius.Channels
{
	public class EventEntry: IEventEntry
	{
		IEventTag _eventTag;
		IBroadcaster _broadcaster;
		
		public bool IsEmpty {
			get { return false; }
		}
		
		public EventEntry (IEventTag eventTag, IBroadcaster broadcaster)
		{
			_eventTag = eventTag;
			_broadcaster = broadcaster;
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

