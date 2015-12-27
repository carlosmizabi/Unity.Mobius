using Tautalos.Unity.Mobius.Channels;
using UniRx;
using Tautalos.Unity.Mobius.Signals;

namespace Tautalos.Unity.Mobius.Broadcasters
{
	public interface IWatcher: IObserver<ISignal>
	{
		void Stop (IEventTag eventTag);
		
		void StopAll ();
		
		bool IsWatching (IEventTag eventTag);
		
		void Watch (IEventTag eventTag);
		
		bool IsEmpty { get; }
		
	} 
}

