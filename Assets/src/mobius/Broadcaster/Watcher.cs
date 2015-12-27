using Tautalos.Unity.Mobius.Signals;
using Tautalos.Unity.Mobius.Channels;
using System;
using UniRx;

namespace Tautalos.Unity.Mobius.Broadcasters
{
	public class Watcher: IWatcher
	{
		Action<ISignal> _OnSignal;
		Action<Exception> _OnError;
		Action _OnDone;
		
		public Watcher (Action<ISignal> onSignal, Action<Exception> onError, Action onDone)
		{
			_OnSignal = onSignal;
			_OnError = onError;
			_OnDone = onDone;
		}
		
		public Watcher (Action<ISignal> onSignal): 
			this(onSignal: onSignal, 
			     onError: _DefaultActionOnError,
			     onDone: _DefaultActionOnDone)
		{

		}
		
		public Watcher (Action<Exception> onError): 
			this(onSignal: _DefaultActionOnSignal, 
			     onError: onError,
			     onDone:  _DefaultActionOnDone)
		{
			
		}
		
		public Watcher (Action onDone): 
			this(onSignal: _DefaultActionOnSignal, 
			     onError: _DefaultActionOnError,
			     onDone:  onDone)
		{
			
		}
		
		public Watcher (Action<ISignal> onSignal, Action<Exception> onError): 
			this(onSignal:	onSignal, 
			     onError: 	onError,
			     onDone: 	_DefaultActionOnDone)
		{
			
		}
		
		public Watcher (Action<ISignal> onSignal, Action onDone): 
			this(onSignal:	onSignal, 
			     onError: 	_DefaultActionOnError,
			     onDone: 	onDone)
		{
			
		}
		
		public Watcher (Action<Exception> onError, Action onDone): 
			this(onSignal:	_DefaultActionOnSignal, 
			     onError: 	onError,
			     onDone: 	onDone)
		{
			
		}
		
		public Watcher (): 
			this(onSignal:	_DefaultActionOnSignal, 
			     onError: 	_DefaultActionOnError,
			     onDone: 	_DefaultActionOnDone)
		{
	
		}
		
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


		public void Watch (IEventTag eventTag, IBroadcaster broadcaster)
		{
			throw new NotImplementedException ();
		}

		public void WatchAll (IBroadcaster broadcaster)
		{
			throw new NotImplementedException ();
		}

		public bool IsEmpty {
			get { return false; }
		}

		public void OnCompleted ()
		{
			if (_OnDone != null) {
				_OnDone ();
			}
		}

		public void OnError (Exception error)
		{
			if (_OnError != null && error != null) {
				_OnError (error);
			}
		}

		public void OnNext (ISignal signal)
		{
			if (_OnSignal != null && signal != null) {
				_OnSignal (signal);
			}
		}
		
		static Action<ISignal> _DefaultActionOnSignal = new Action<ISignal> ((signal) => {});
		static Action<Exception> _DefaultActionOnError = new Action<Exception> ((error) => {});
		static Action _DefaultActionOnDone = new Action (() => {});
		
	}
}

