using NUnit.Framework;
using Tautalos.Unity.Mobius.Signals;
using Tautalos.Unity.Mobius.Channels;

namespace Tautalos.Unity.Mobius.Tests
{
	[TestFixture()]
	internal class EmptySignallerTest
	{
		[Test,
		 Category("Given the EmptySignaller"),
		 Description("When asked if the EmptySignaller, Then it should answer positive")]
		 
		public void ShouldAnswerPositiveThatIsTheEmptySignaller ()
		{
			Assert.IsTrue (EmptySignaller.Instance.IsEmpty);
		}
		
		[Test,
		 Category("Given the EmptySignaller"),
		 Description("When asked for the Owner, Then it should return itself")]
		 
		public void ShouldReturnItselfAsTheOwner ()
		{
			Assert.AreSame (EmptySignaller.Instance, EmptySignaller.Instance.Owner);
		}
		
		[Test,
		 Category("Given the EmptySignaller"),
		 Description("When asked for the Channel, Then it should return the EmptyChannel")]
		
		public void ShouldReturnTheEmptyChannelAsTheChannel ()
		{
			Assert.AreSame (EmptySignaller.Instance.Channel, EmptyChannel.Instance);
		}
	}
}

