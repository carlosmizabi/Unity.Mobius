using Tautalos.Unity.Mobius.Channels;
using UniRx;
using Tautalos.Unity.Mobius.Signals;

namespace Tautalos.Unity.Mobius.Broadcasters
{
	public interface IWatcher: IObserver<ISignal>
	{
		void Ignore (IEventTag eventTag);
		
		void DontIgnore (IEventTag eventTag);
		
		void Stop ();
		
		bool IsWatching (IEventTag eventTag);
		
		bool IsIgnoring (IEventTag eventTag);
				
		void Watch (IEventTag eventTag, IBroadcaster broadcaster);
		
		void WatchAll (IBroadcaster broadcaster);
		
		bool IsEmpty { get; }
		
	} 
}

