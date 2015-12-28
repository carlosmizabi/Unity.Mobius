
using Tautalos.Unity.Mobius.Channels;
using UniRx;
using Tautalos.Unity.Mobius.Signals;
using System;

namespace Tautalos.Unity.Mobius.Broadcasters
{
	public interface IBroadcaster: IObserver<ISignal>
	{
		string Name { get; }
		
		IChannel Channel { get; }
		
		bool IsEmpty { get; }
		
		IEventTag[] GetEventTags ();
		
		bool HasEventTag (IEventTag eventTag);
		
		IDisposable Subscribe (IObserver<ISignal> observer);
		
		IDisposable SubscribeWhere (IObserver<ISignal> observer, Func<ISignal, bool> perdicate);

	}
}

