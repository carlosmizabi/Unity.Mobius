using NUnit.Framework;
using Tautalos.Unity.Mobius.Broadcasters;

namespace Tautalos.Unity.Mobius.Tests
{
	[TestFixture()]
	internal class EmptyWatcherTest
	{
		[Test,
		 Category("Given the EmptyWatcher"),
		 Description("When getting the static Instance, Then it should give us an EmptyWatcher")]
		public void ShouldHaveAStaticInstance ()
		{
			Assert.IsInstanceOf<EmptyWatcher> (EmptyWatcher.Instance);
		}
		
		[Test,
		 Category("Given the EmptyWatcher"),
		 Description("When asked if empty, Then it should answer positive")]
		public void ShouldBeEmpty ()
		{
			Assert.IsTrue (EmptyWatcher.Instance.IsEmpty);
		}
	}
}

