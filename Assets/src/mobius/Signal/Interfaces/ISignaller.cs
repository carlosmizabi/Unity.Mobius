
using Tautalos.Unity.Mobius.Channels;

namespace Tautalos.Unity.Mobius.Signals
{
	public interface ISignaller
	{
		object Owner { get; }
		IChannel Channel { get; }
		bool IsEmpty { get; }
				
		ISignal CreateSignal (IEventTag eventTag, IMessage message);
		
		void Emit (ISignal signal);
		
		void Emit (ISignal[] signals);
		
	}
}

