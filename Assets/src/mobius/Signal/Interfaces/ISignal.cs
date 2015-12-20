using Tautalos.Unity.Mobius.Channels;

namespace Tautalos.Unity.Mobius.Signals
{
	public interface ISignal
	{
		IEventTag EventTag { get; }
		IMessage Message { get; }
		ISignaller Signaller { get; }
		bool IsEmpty { get; }
		
		bool HasMessage ();
	}
}

