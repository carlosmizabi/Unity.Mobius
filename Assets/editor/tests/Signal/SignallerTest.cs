using NUnit.Framework;
using Tautalos.Unity.Mobius.Signals;
using Tautalos.Unity.Mobius.Channels;

namespace Tautalos.Unity.Mobius.Tests
{
	[TestFixture()]
	internal class SignallerTest
	{
		[Test,
		 Category("Given a Signaller"),
		 Description("When created if its Channels its the EmptyChannel, "+
		             "Then if asked if it is empty it should answer positive ")]
		public void ShouldAnswerPositiveToBeingEmpty ()
		{
			var signaller = new Signaller (owner: this, channel: EmptyChannel.Instance);
			Assert.IsTrue (signaller.IsEmpty);
		}
		
		[Test,
		 Category("Given a Signaller"),
		 Description("When created with a null instead of a proper channel,"+
		             "Then its Channel should be the EmptyChannel")]
		             
		public void ShouldHaveTheEmptyChannelAsItsChannel ()
		{
			var signaller = new Signaller (owner: this, channel: null);
			Assert.AreEqual (EmptyChannel.Instance, signaller.Channel);
		}
		
		[Test,
		 Category("Given a Signaller"),
		 Description("When created without a owner, Then it should own itself")]
		 
		public void ShouldOwnItself ()
		{
			var signaller = new Signaller (owner: null, channel: EmptyChannel.Instance);
			Assert.AreSame (signaller, signaller.Owner);
		}
		
		[Test,
		 Category("Given a Signaller"),
		 Description("When asked to create a Signal, Then it should give us a Signal")]
		 
		public void ShouldReturnASignal ()
		{
			var signaller = new Signaller ();
			var signal = signaller.CreateSignal (EmptyEventTag.Instance, EmptyMessage.Instance);
			Assert.IsInstanceOf<ISignal> (signal);
		}
		
		[Test,
		 Category("Given a Signaller"),
		 Description("When asked to create a Signal with null parameters, Then it should return the EmptySignal")]
		 
		public void ShouldReturnTheEmptySignal ()
		{
			var signaller = new Signaller ();
			var signal = signaller.CreateSignal (null, null);
			Assert.AreSame (EmptySignal.Instance, signal);
		}
		
		[Test,
		 Category("Given a Signaller"),
		 Description("When asked to create a Signal and the EventTag is null, "+
		             "Then the new signal Event Tag should be the EmptyEventTag")]
		             
		public void ShouldReturnSignalWithEmptyEventTag ()
		{
			var signaller = new Signaller ();
			var signal = signaller.CreateSignal (null, null);
			Assert.AreSame (EmptyEventTag.Instance, signal.EventTag);
		}
		
		[Test,
		 Category("Given a Signaller"),
		 Description("When asked to create a Signal and the Message is null, "+
		            "Then the new signal Message should be the EmptyMessage")]
		
		public void ShouldReturnSignalWithEmptyMessage ()
		{
			var signaller = new Signaller ();
			var signal = signaller.CreateSignal (EmptyEventTag.Instance, null);
			Assert.AreSame (EmptyMessage.Instance, signal.Message);
		}
		
		[Test,
		 Category	("Given a Signaller"),
		 Description("When asked to create a Signal and all parameters supplied,"+
		             "Then the new signals properties should match the parameters supplied")]
		
		public void ShouldReturnSignalWithCorrectProperties ()
		{
			var evenTag = new EventTag ("some-event");
			var message = new Message (body: "Hello");
			var signaller = new Signaller ();
			var signal = signaller.CreateSignal (evenTag, message);
			Assert.AreSame (evenTag, signal.EventTag);
			Assert.AreSame (message, signal.Message);
		}
	}
}

