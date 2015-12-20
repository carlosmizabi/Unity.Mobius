
using Tautalos.Unity.Mobius.Signals;

namespace Tautalos.Unity.Mobius.Channels
{
	public interface ISignaller
	{
		object Owner { get; }
		IChannel Channel { get; }
		bool IsEmpty { get; }
		
		bool IsEmptySignaller ();
		
		ISignal CreateSignal (IEventTag eventTag, IMessage message);
		
		void emit (ISignal signal);
		
		void emit (ISignal[] signals);
		
	}
}

