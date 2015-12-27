
using Tautalos.Unity.Mobius.Channels;
using UniRx;
using Tautalos.Unity.Mobius.Signals;

namespace Tautalos.Unity.Mobius.Broadcasters
{
	public interface IBroadcaster: IObserver<ISignal>
	{
		string Name { get; }
		
		IChannel Channel { get; }
		
		bool IsEmpty { get; }
		
		IEventTag[] GetEventTags ();
		
		bool HasEventTag (IEventTag eventTag);
		
		void Silence ();
		
	}

}

