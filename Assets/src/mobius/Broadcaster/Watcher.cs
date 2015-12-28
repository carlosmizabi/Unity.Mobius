using Tautalos.Unity.Mobius.Signals;
using Tautalos.Unity.Mobius.Channels;
using System;
using UniRx;
using System.Collections.Generic;

namespace Tautalos.Unity.Mobius.Broadcasters
{
	public class Watcher: IWatcher
	{		
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
		
		public bool IsEmpty {
			get { return false; }
		}

		public void Silence (bool shouldBeSilent)
		{
			if (shouldBeSilent != null) {
				_shouldBeSilent = shouldBeSilent;
			}
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
			foreach (SubscriptionInfo info in _subscriptionsInfo.Values) {
				info.Disposable.Dispose ();
			}
			_subscriptionsInfo.Clear ();
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
			var isWatching = false;
			foreach (SubscriptionInfo info in _subscriptionsInfo.Values) {
				isWatching = info.EventTags.Contains (eventTag);
				if (isWatching)
					break;
			}
			return isWatching;
		}
		
		public bool IsWatchingAll (IBroadcaster broadcaster)
		{
			var isWatchingAll = false;
			SubscriptionInfo info;
			_subscriptionsInfo.TryGetValue (broadcaster, out info);
			if (info != null) {
				isWatchingAll = true;
				foreach (IEventTag tag in broadcaster.GetEventTags()) {
					if (!info.EventTags.Contains (tag)) {
						isWatchingAll = false;
						break;
					}
				}
			}
			
			return isWatchingAll;
		}

		public void Watch (IBroadcaster broadcaster, IEventTag eventTag)
		{
			if (broadcaster != null && eventTag != null) {
				var tags = new IEventTag[]{ eventTag };
				IDisposable subscription = _MakeSubscription (broadcaster, tags);
				if (_subscriptionsInfo.ContainsKey (broadcaster)) {
					_RemoveSubscriptionFor (broadcaster);
				}
				if (subscription != null) {
					_AddSubscriptionInfo (
						broadcaster: broadcaster, 
						subscription: subscription, 
						eventTags: tags
					);
				} 
				
			}
		}
		
		public void Watch (IBroadcaster broadcaster, IEventTag[] eventTags)
		{
			if (broadcaster != null && eventTags != null && eventTags.Length > 0) {
				IDisposable subscription = _MakeSubscription (broadcaster, eventTags);
				if (_subscriptionsInfo.ContainsKey (broadcaster)) {
					_RemoveSubscriptionFor (broadcaster);
				}
				if (subscription != null) {
					_AddSubscriptionInfo (
						broadcaster: broadcaster, 
						subscription: subscription, 
						eventTags: eventTags
					);
				} 
			}
		}

		public void WatchAll (IBroadcaster broadcaster)
		{
			if (broadcaster != null) {
				IDisposable subscription;
				subscription = broadcaster.Subscribe (this);
				if (_subscriptionsInfo.ContainsKey (broadcaster)) {
					_RemoveSubscriptionFor (broadcaster);
				}
				if (subscription != null) {
					_AddSubscriptionInfo (
						broadcaster: broadcaster, 
						subscription: subscription, 
						eventTags: broadcaster.GetEventTags ()
					);
				}
			}
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
			if (_OnSignal != null && 
				signal != null && 
				!_shouldBeSilent &&
				!_ignoredTags.Contains (signal.EventTag)) {
				_OnSignal (signal);
			}
		}
		
		/********************************************************************
		
			Private
		
		*********************************************************************/
		
		static Action<ISignal> _DefaultActionOnSignal = new Action<ISignal> ((signal) => {});
		static Action<Exception> _DefaultActionOnError = new Action<Exception> ((error) => {});
		static Action _DefaultActionOnDone = new Action (() => {});
		
		bool _shouldBeSilent;
		Action<ISignal> _OnSignal;
		Action<Exception> _OnError;
		Action _OnDone;
		List<IEventTag> _ignoredTags = new List<IEventTag> ();
		Dictionary<IBroadcaster, SubscriptionInfo> _subscriptionsInfo = 
			new Dictionary<IBroadcaster, SubscriptionInfo> ();
		
		IDisposable _MakeSubscription (IBroadcaster broadcaster, IEventTag[] eventTags)
		{
			return broadcaster.SubscribeWhere (this, (ISignal signal) => {
				var found = false;
				for (int i = 0; i < eventTags.Length; i++) {
					if (eventTags [i] == signal.EventTag) {
						found = true;
						break;
					}
				}
				return found;
			});
		}
		
		void _AddSubscriptionInfo (IBroadcaster broadcaster, IDisposable subscription, IEventTag[] eventTags)
		{
			_subscriptionsInfo.Add (
				broadcaster, 
				new SubscriptionInfo (
				eventTags: eventTags,
				broadcaster: broadcaster, 
				disposable: subscription
			));
		}
		
		void _ChangeSubscription (IBroadcaster broadcaster, IDisposable subscription, IEventTag[] tags)
		{
			SubscriptionInfo bs = null;
			_subscriptionsInfo.TryGetValue (broadcaster, out bs);
			if (bs != null) {
				bs.Disposable.Dispose ();
				bs.Disposable = subscription;
				bs.EventTags.AddRange (tags);
			}
		}
		
		void _RemoveSubscriptionFor (IBroadcaster broadcaster)
		{
			SubscriptionInfo subscription;
			_subscriptionsInfo.TryGetValue (broadcaster, out subscription);
			if (subscription != null) {
				subscription.Disposable.Dispose ();
				_subscriptionsInfo.Remove (broadcaster);
			}
		}
		
		class SubscriptionInfo
		{
			public IBroadcaster Broadcaster;
			public IDisposable Disposable;
			public List<IEventTag> EventTags = new List<IEventTag> ();
			
			public SubscriptionInfo (IEventTag[] eventTags, IBroadcaster broadcaster, IDisposable disposable)
			{
				EventTags.AddRange (eventTags);
				Broadcaster = broadcaster;
				Disposable = disposable;
			}	
		}
	}
}

