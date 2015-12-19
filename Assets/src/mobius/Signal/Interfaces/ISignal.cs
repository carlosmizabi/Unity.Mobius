using Tautalos.Unity.Mobius.Channels;

namespace Tautalos.Unity.Mobius.Signals
{
	public interface ISignal
	{
		IEventType EventType { get; }
		IMessage Message { get; }
		ISignaller Signaller { get; }
		
		bool HasMessage ();
		
		bool IsEmpty ();
	}
}

