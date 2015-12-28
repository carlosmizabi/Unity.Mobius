using Tautalos.Unity.Mobius.Signals;
using Tautalos.Unity.Mobius.Channels;
using System;
using UniRx;
using System.Collections.Generic;

namespace Tautalos.Unity.Mobius.Broadcasters
{
	public class Watcher: IWatcher
	{
		Action<ISignal> _OnSignal;
		Action<Exception> _OnError;
		Action _OnDone;
		List<IEventTag> _ignoredTags = new List<IEventTag> ();
		Dictionary<IBroadcaster, IDisposable> _subscriptions = new Dictionary<IBroadcaster, IDisposable> ();
		
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
		
		public void Ignore (IEventTag eventTag)
		{
			if (eventTag != null) {
				_ignoredTags.Add (eventTag);
			}
		}
		
		public void DontIgnore (IEventTag eventTag)
		{
			if (eventTag != null) {
				_ignoredTags.Remove (eventTag);
			}
		}

		public void Stop ()
		{
			throw new System.NotImplementedException ();
		}
		
		public bool IsIgnoring (IEventTag eventTag)
		{
			var isIgnored = false;
			if (eventTag == null || _ignoredTags.Contains (eventTag)) {
				isIgnored = true;
			} 
			return isIgnored;
		}

		public bool IsWatching (IEventTag eventTag)
		{
			throw new System.NotImplementedException ();
		}

		public void Watch (IEventTag eventTag, IBroadcaster broadcaster)
		{
			IDisposable subscription;
			if (broadcaster != null && eventTag != null) {
				subscription = broadcaster.SubscribeWhere (this, (ISignal signal) => {
					return signal.EventTag == eventTag;
				});
				if (subscription != null) {
					_subscriptions.Add (broadcaster, subscription);
				}
			}
		}

		public void WatchAll (IBroadcaster broadcaster)
		{
			IDisposable subscription;
			if (broadcaster != null) {
				subscription = broadcaster.Subscribe (this);
				if (subscription != null) {
					_subscriptions.Add (broadcaster, subscription);
				}
			}
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
			if (_OnSignal != null && signal != null && !_ignoredTags.Contains (signal.EventTag)) {
				_OnSignal (signal);
			}
		}
		
		static Action<ISignal> _DefaultActionOnSignal = new Action<ISignal> ((signal) => {});
		static Action<Exception> _DefaultActionOnError = new Action<Exception> ((error) => {});
		static Action _DefaultActionOnDone = new Action (() => {});
		
	}
}

