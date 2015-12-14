using Tautalos.Unity.Mobius.Broadcaster;

namespace Tautalos.Unity.Mobius.Channel
{
	public interface IEventEntry
	{
		IEventType EventType { get; }
		IBroadcaster Broadcaster { get; }
	}
}

