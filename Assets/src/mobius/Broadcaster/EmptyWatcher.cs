using Tautalos.Unity.Mobius.Signals;
using Tautalos.Unity.Mobius.Channels;
using System;

namespace Tautalos.Unity.Mobius.Broadcasters
{
	public class EmptyWatcher: IWatcher
	{
		static IWatcher _instance = new EmptyWatcher ();
		
		public static IWatcher Instance {
			get { return _instance; }
		}
		
		public void Ignore (IEventTag eventTag)
		{
		}
		
		public void DontIgnore (IEventTag eventTag)
		{
		}

		public void Stop ()
		{
		}
		
		public bool IsIgnoring (IEventTag tag)
		{
			return false;
		}

		public bool IsWatching (IEventTag eventTag)
		{
			return false;
		}
		
		public bool IsWatchingAll (IBroadcaster broadcaster)
		{
			return false;
		}
		
		public void Watch (IBroadcaster broadcaster, IEventTag eventTag)
		{
		}
		
		public void Watch (IBroadcaster broadcaster, IEventTag[] eventTag)
		{
		}

		public void WatchAll (IBroadcaster broadcaster)
		{
		}

		public bool IsEmpty {
			get { return true; }
		}

		public void OnCompleted ()
		{
		}

		public void OnError (Exception error)
		{
		}

		public void OnNext (ISignal value)
		{
		}

	}
}

