using NUnit.Framework;
using Tautalos.Unity.Mobius.Broadcasters;
using Tautalos.Unity.Mobius.Signals;
using System;

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
	}
}

