using Tautalos.Unity.Mobius.Signals;
using Tautalos.Unity.Mobius.Channels;
using System;

namespace Tautalos.Unity.Mobius.Broadcasters
{
	public class EmptyWatcher: IWatcher
	{
		static IWatcher _instance = new Watcher ();
		
		public static IWatcher Instance {
			get { return _instance; }
		}
		
		public void Stop (IEventTag eventTag)
		{
		}

		public void StopAll ()
		{
		}

		public bool IsWatching (IEventTag eventTag)
		{
			return false;
		}

		public void Watch (IEventTag eventTag)
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

