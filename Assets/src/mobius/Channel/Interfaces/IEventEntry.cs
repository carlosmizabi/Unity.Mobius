using Tautalos.Unity.Mobius.Broadcasters;

namespace Tautalos.Unity.Mobius.Channels
{
	public interface IEventEntry
	{
		IEventType EventType { get; }
		IBroadcaster Broadcaster { get; }
		
		bool IsEmpty ();
	}
}

