using NUnit.Framework;
using Tautalos.Unity.Mobius.Signals;
using Tautalos.Unity.Mobius.Channels;

namespace Tautalos.Unity.Mobius.Tests
{
	[TestFixture()]
	public class SignalTest
	{
		
		[Test,
		 Category	("Given a Signal"),
		 Description("When its message equals the EmptyMessage," +
		 		  	 "then it should answer negative when asked if it has a message")]
		public void ShouldAnswerNegativeToIfHasMessage ()
		{
			var signal = new Signal (EmptySignaller.Instance, EmptyEventTag.Instance, EmptyMessage.Instance);
			Assert.IsFalse (signal.HasMessage ());
		}
		
		[Test,
		 Category	("Given a Signal"),
		 Description("When it was not instantiated with a message" +
		            "then it should answer negative when asked if it has a message")]
		public void ShouldAnswerNegativeIfMessageWasnotSetWhenCreated ()
		{
			var signal = new Signal (EmptySignaller.Instance, EmptyEventTag.Instance);
			Assert.IsFalse (signal.HasMessage ());
		}
		
		[Test,
		 Category	("Given a Signal"),
		 Description("When its message does not equal the EmptyMessage," +
		            "then it should answer positive when asked if it has a message")]
		public void ShouldAnswerPositiveIfItHasMessage ()
		{
			var message = new Message (header: "Some header");
			var signal = new Signal (EmptySignaller.Instance, EmptyEventTag.Instance, message);
			Assert.IsTrue (signal.HasMessage ());
		}

	}
}

