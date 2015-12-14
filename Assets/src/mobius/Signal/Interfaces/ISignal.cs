using Tautalos.Unity.Mobius.Channel;

namespace Tautalos.Unity.Mobius.Signal
{
	public interface ISignal
	{
		IEventType EventType { get; }
		IMessage Message { get; }
		ISignaller Signaller { get; }
		
		bool HasMessage ();
	}
}

