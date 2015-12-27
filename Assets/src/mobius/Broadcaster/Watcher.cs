using Tautalos.Unity.Mobius.Signals;
using Tautalos.Unity.Mobius.Channels;
using System;

namespace Tautalos.Unity.Mobius.Broadcasters
{
	public class Watcher: IWatcher
	{
		public void Stop (IEventTag eventTag)
		{
			throw new System.NotImplementedException ();
		}

		public void StopAll ()
		{
			throw new System.NotImplementedException ();
		}

		public bool IsWatching (IEventTag eventTag)
		{
			throw new System.NotImplementedException ();
		}

		public void Watch (IEventTag eventTag)
		{
			throw new System.NotImplementedException ();
		}

		public bool IsEmpty {
			get { return false; }
		}

		public void OnCompleted ()
		{
			throw new System.NotImplementedException ();
		}

		public void OnError (Exception error)
		{
			throw new System.NotImplementedException ();
		}

		public void OnNext (ISignal value)
		{
			throw new System.NotImplementedException ();
		}

	}
}

