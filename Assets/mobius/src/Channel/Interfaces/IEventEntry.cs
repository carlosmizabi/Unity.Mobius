using Tautalos.Unity.Mobius.Broadcasters;

namespace Tautalos.Unity.Mobius.Channels
{
	public interface IEventEntry
	{
		IEventTag EventTag { get; }
		IBroadcaster Broadcaster { get; }
		bool IsEmpty { get; }
	}
}

