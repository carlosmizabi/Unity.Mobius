using NUnit.Framework;
using Tautalos.Unity.Mobius.Broadcasters;
using Tautalos.Unity.Mobius.Channels;

namespace Tautalos.Unity.Mobius.Tests
{
	[TestFixture()]
	public class EmptyBroadcasterTest
	{
		[Test,
		 Category("Given the EmptyBroadcaster"),
		 Description("When asking if it is empty, Then it should return positive")]
		public void ShouldBePositiveToBeingEmpty ()
		{
			Assert.IsTrue (EmptyBroadcaster.Instance.IsEmpty);
		}
		
		[Test,
		 Category("Given the EmptyBroadcaster"),
		 Description("When asking for the instance, Then it should return an instance")]
		public void ShouldReturnTheEmptyBroadcasterInstance ()
		{
			Assert.IsInstanceOf<EmptyBroadcaster> (EmptyBroadcaster.Instance);
		}
		
		[Test,
		 Category("Given the EmptyBroadcaster"),
		 Description("When asking for the EventTags, Then it should return an empty collection")]
		public void ShouldReturnAnEmptyCollectionOfEventTags ()
		{
			Assert.IsEmpty (EmptyBroadcaster.Instance.GetEventTags ());
		}
		
		[Test,
		 Category("Given the EmptyBroadcaster"),
		 Description("When asking if it has an EventTag, Then it should return negative")]
		public void ShouldReturnNegativeToHavingAnyEventTag ()
		{
			Assert.IsFalse (EmptyBroadcaster.Instance.HasEventTag (null));
		}
		
		[Test,
		 Category("Given the EmptyBroadcaster"),
		 Description("When asking for its Channel, Then it should return the EmptyChannel")]
		public void ShouldReturnTheEmptyChannel ()
		{
			Assert.AreSame (EmptyChannel.Instance, EmptyBroadcaster.Instance.Channel);
		}
	}
}

