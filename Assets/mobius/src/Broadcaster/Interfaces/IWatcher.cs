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
		
		bool IsWatchingAll (IBroadcaster broadcaster);
		
		bool IsIgnoring (IEventTag eventTag);
				
		void Watch (IBroadcaster broadcaster, IEventTag eventTag);
		
		void Watch (IBroadcaster broadcaster, IEventTag[] eventTag);
		
		void WatchAll (IBroadcaster broadcaster);
		
		void Silence (bool shouldBeSilent);
		
		bool IsEmpty { get; }
		
	} 
}

