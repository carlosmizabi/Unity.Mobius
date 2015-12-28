using NUnit.Framework;
using Tautalos.Unity.Mobius.Broadcasters;
using Tautalos.Unity.Mobius.Signals;
using System;
using Tautalos.Unity.Mobius.Channels;
using System.Collections.Generic;

namespace Tautalos.Unity.Mobius.Tests
{
	[TestFixture()]
	public class WatcherTest
	{
		Watcher watcher;
		
		[SetUp]
		public void Setup ()
		{
			watcher = new Watcher ();
		}
		
		[TearDown]
		public void TearDown ()
		{
			watcher = null;
		}
		
		[Test,
		 Category("Given a Watcher"),
		 Description("When asked if empty, Then it should answer negative")]
		public void ShouldBeEmpty ()
		{
			Assert.IsFalse (watcher.IsEmpty);
		}
		
		[Test,
		 Category("Given a Watcher"),
		 Description("When instantiated with onSignal handler, Then it call the handler on OnNext observation")]
		public void ShouldCallTheProvidedOnSignalHandler ()
		{
			var result = false;
			var watcher = new Watcher (onSignal: (signal) => {
				result = true;
			});
			watcher.OnNext (EmptySignal.Instance);
			Assert.IsTrue (result);
		}
		
		[Test,
		 Category("Given a Watcher"),
		 Description("When instantiated with onError handler, Then it call the handler on OnError observation")]
		public void ShouldCallProvidedOnErrorHandler ()
		{
			var exception = new Exception ();
			Exception result = null;
			var watcher = new Watcher (onError: (error) => {
				result = error;
			});
			watcher.OnError (exception);
			Assert.IsNotNull (result);
			Assert.AreSame (exception, result);
		}
		
		[Test,
		 Category("Given a Watcher"),
		 Description("When instantiated with onDone handler, Then it call the handler on OnCompleted observation")]
		public void ShouldCallProvidedOnDoneHandler ()
		{
			var result = false;
			var watcher = new Watcher (onDone: () => {
				result = true;
			});
			watcher.OnCompleted ();
			Assert.IsTrue (result);
		}
		
		[Test,
		 Category("Given a Watcher"),
		 Description("When told to ignore a EventTag, Then it should not call the OnSignal handler for that EventTag")]
		public void ShouldNotCallHandlerOnSignalWithIgnoredEventTag ()
		{
			var result = "unchanged";
			var watcher = new Watcher (onSignal: (signal) => {
				result = "called";
			});
			watcher.Ignore (EmptyEventTag.Instance);
			watcher.OnNext (EmptySignal.Instance);
			Assert.AreEqual ("unchanged", result);
		}
		
		[Test,
		 Category("Given a Watcher"),
		 Description("When told to ignore a EventTag and stop ignoring, Then it should call the OnSignal handler for that EventTag")]
		public void ShouldCallOnSignalHandlerIfIgnoreIsLongerIgnored ()
		{
			var result = 0;
			var watcher = new Watcher (onSignal: (signal) => {
				result++;
			});
			watcher.Ignore (EmptyEventTag.Instance);
			watcher.OnNext (EmptySignal.Instance);
			watcher.DontIgnore (EmptyEventTag.Instance);
			watcher.OnNext (EmptySignal.Instance);
			Assert.AreEqual (1, result);
		}
		
		[Test,
		 Category("Given a Watcher"),
		 Description("When if it is ignoring a EventTag, Then it should answer accuretely")]
		public void ShouldTellUsIfAnEventTagIsBeingIgnored ()
		{
			Assert.IsTrue (watcher.IsIgnoring (null));
			watcher.Ignore (EmptyEventTag.Instance);
			Assert.IsTrue (watcher.IsIgnoring (EmptyEventTag.Instance));
			watcher.DontIgnore (EmptyEventTag.Instance);
			Assert.IsFalse (watcher.IsIgnoring (EmptyEventTag.Instance));
		}
		
		[Test,
		 Category("Given a Watcher"),
		 Description("When observing a Broadcaster, Then it should process all signal from it")]
		public void ShouldProcessAllSignalsFromBroadcaster ()
		{
			var eventTag_1 = new EventTag ("event-one");
			var eventTag_2 = new EventTag ("event-two");
			var eventTags = new EventTag[]{ eventTag_1, eventTag_2};
			var channel = new Channel ();
			var broadcaster = new Broadcaster (channel, eventTags, "the-broadcaster");
			var signaller = new Signaller (channel: channel, owner: this);
			var signal_1 = new Signal (signaller, eventTag_1, null);
			var signal_2 = new Signal (signaller, eventTag_2, null);
			 
			var observedSignals = new List<ISignal> ();
			var watcher = new Watcher (onSignal: (signal) => {
				observedSignals.Add (signal);
			});
			watcher.WatchAll (broadcaster);
			channel.Emit (signal_1);
			channel.Emit (signal_2);
			
			Assert.AreEqual (2, observedSignals.Count);
			Assert.Contains (signal_1, observedSignals);
			Assert.Contains (signal_2, observedSignals);
		}
		
		[Test,
		 Category("Given a Watcher"),
		 Description("When observing an EventTag from a Broadcaster, Then it should process only those broadcasts")]
		public void ShouldProcessOnlyGivenEventTags ()
		{
			var eventTag_1 = new EventTag ("event-one");
			var eventTag_2 = new EventTag ("event-two");
			var eventTags = new EventTag[]{ eventTag_1, eventTag_2};
			var channel = new Channel ();
			var broadcaster = new Broadcaster (channel, eventTags, "the-broadcaster");
			var signaller = new Signaller (channel: channel, owner: this);
			var signal_1 = new Signal (signaller, eventTag_1, null);
			var signal_2 = new Signal (signaller, eventTag_2, null);
			
			var observedSignals = new List<ISignal> ();
			var watcher = new Watcher (onSignal: (signal) => {
				observedSignals.Add (signal);
			});
			watcher.Watch (eventTag_1, broadcaster);
			channel.Emit (signal_1);
			channel.Emit (signal_2);
			
			Assert.AreEqual (1, observedSignals.Count);
			Assert.Contains (signal_1, observedSignals);
		}
	}
}

