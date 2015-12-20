using NUnit.Framework;
using Tautalos.Unity.Mobius.Channels;

namespace Tautalos.Unity.Mobius.Tests
{
	[TestFixture()]
	public class ChannelHelperTest
	{
		[Test,
		 Category("Given a channel instance"),
		 Description("When not a instance of the EmptyChannel, should return false")]
		public void ShouldAnswerNegative ()
		{
			var channel = new Channel ();
			Assert.IsFalse (ChannelHelper.IsEmptyChannel (channel));
		}
		
		[Test,
		 Category("Given a channel instance"),
		 Description("When a instance of the EmptyChannel, should return false")]
		public void ShouldAnswerPositive ()
		{
			var channel = EmptyChannel.Instance;
			Assert.IsTrue (ChannelHelper.IsEmptyChannel (channel));
		}
	}
}

