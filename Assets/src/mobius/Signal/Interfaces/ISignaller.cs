
using Tautalos.Unity.Mobius.Signals;

namespace Tautalos.Unity.Mobius.Channels
{
	public interface ISignaller
	{
		object Owner { get; }
		IChannel Channel { get; }
		
		bool IsEmptySignaller ();
		
		ISignal CreateSignal (IEventType type, IMessage message);
		
		void emit (ISignal signal);
		
		void emit (ISignal[] signals);
		
		bool IsEmpty ();
		
	}
}

