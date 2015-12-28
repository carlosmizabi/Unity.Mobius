using NUnit.Framework;
using Tautalos.Unity.Mobius.Signals;
using Tautalos.Unity.Mobius.Channels;

namespace Tautalos.Unity.Mobius.Tests
{
	[TestFixture()]
	internal class EmptySignalTest
	{
		
		[Test,
		 Category("Given the EmptySignal"),
		 Description("When getting the Instance property, Then it should return a signal")]
		 
		public void ShouldReturnaSignal ()
		{
			Assert.IsTrue (EmptySignal.Instance is ISignal);
		}
		
		[Test,
		 Category("Given the EmptySignal"),
		 Description("When checking if it empty, Then it should e positive")]
		 
		public void ShouldBePositiveWhenAskedIfItIsEmpty ()
		{
			Assert.IsTrue (EmptySignal.Instance.IsEmpty);
		}
		
		[Test,
		 Category("Given the EmptySignal"),
		 Description("When getting the EventTag, Then it should give us the EmptyEventTag")]
		
		public void ShouldReturnTheEmptyEventTag ()
		{
			Assert.AreSame (EmptySignal.Instance.EventTag, EmptyEventTag.Instance);
		}
		
		[Test,
		 Category("Given the EmptySignal"),
		 Description("When getting the Message, Then it should give us the EmptyMessage")]
		
		public void ShouldReturnTheEmptyMessage ()
		{
			Assert.AreSame (EmptySignal.Instance.Message, EmptyMessage.Instance);
		}
		
		[Test,
		 Category("Given the EmptySignal"),
		 Description("When getting the Signaller, Then it should give us the EmptySignaller")]
		
		public void ShouldReturnTheEmptySignaller ()
		{
			Assert.AreSame (EmptySignal.Instance.Signaller, EmptySignaller.Instance);
		}
		
		[Test,
		 Category("Given the EmptySignal"),
		 Description("When checking if it has a message, Then it should be negative")]
		
		public void ShouldRespondNegativeIfItHasMessage ()
		{
			Assert.IsFalse (EmptySignal.Instance.HasMessage ());
		}
	}
}

