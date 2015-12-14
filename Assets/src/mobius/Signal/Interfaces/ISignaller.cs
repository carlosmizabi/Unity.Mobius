
using Tautalos.Unity.Mobius.Signal;

namespace Tautalos.Unity.Mobius.Channel
{
	public interface ISignaller
	{
		object Owner { get; }
		IChannel Channel { get; }
		
		bool IsEmptySignaller ();
		
		ISignal CreateSignal (IEventType type, IMessage message);
		
		void emit (ISignal signal);
		
		void emit (ISignal[] signals);
		
	}
}

