using NUnit.Framework;
using Tautalos.Unity.Mobius.Broadcasters;
using Tautalos.Unity.Mobius.Channels;
using System;

namespace Tautalos.Unity.Mobius.Tests
{
	[TestFixture()]
	internal class BroadcasterTest
	{
		[Test,
		 Category("Given a Broadcaster"),
		 Description("When creating one, Then it should have the properties matching the parameters")]
		public void ShouldBeProperlyInstantiated ()
		{
			var name = "some-name";
			var channel = new Channel ("some-channel");
			var b = new Broadcaster (name: name, eventTags: null, channel: channel);
			Assert.AreEqual (name, b.Name);
			Assert.AreEqual (channel, b.Channel);
		}
		
		[Test,
		 Category("Given a Broadcaster"),
		 Description("When creating one with a null channel,"+
		             "Then it should have the EmptyChannel as its Channel")]
		public void ShouldBeInstantiatedWithTheEmptyChannel ()
		{
			var name = "some-name";
			var b = new Broadcaster (name: name, eventTags: null, channel: null);
			Assert.AreEqual (name, b.Name);
			Assert.AreEqual (EmptyChannel.Instance, b.Channel);
		}
		
		[Test,
		 Category("Given a Broadcaster"),
		 Description("When creating one with bunch of Event Tags and asking for the EventTags,"+
		            "Then we should get a collection with all the EventTags")]
		public void ShouldGiveACollectionWithItsEventTags ()
		{
			var eventTags = new EventTag[]{ new EventTag ("event-one"), new EventTag ("event-two")};
			var name = "some-name";
			var b = new Broadcaster (
				name: name, 
				channel: null,
				eventTags: eventTags
			);
			var collection = b.GetEventTags ();
			Assert.IsNotEmpty (collection);
			Assert.Contains (eventTags [0], collection);
			Assert.Contains (eventTags [1], collection);
		}
		
		[Test,
		 Category("Given a Broadcaster"),
		 Description("When creating one with bunch of Event Tags and nulls,"+
		            "Then we should get a collection with no null in it the EventTags")]
		public void ShouldGiveACollectionWithoutNulls ()
		{
			var eventTags = new EventTag[]{ 
				null,
				new EventTag ("event-one"), 
				null,
				new EventTag ("event-two"),
				null
			};
			var name = "some-name";
			var b = new Broadcaster (
				name: name, 
				channel: null,
				eventTags: eventTags
			);
			var collection = b.GetEventTags ();
			Assert.IsTrue (collection.Length == 2);
			CollectionAssert.AllItemsAreNotNull (collection);
		}
		
		[Test,
		 Category	("Given a Broadcaster"),
		 Description("When creating one with a bunch of EventTags,"+
		             "Then it should register all EventsTags with the Channel")]
		             
		public void ShouldRegisterAllEventTagsWithChannel ()
		{
			var channel = new Channel ();
			var eventTags = new EventTag[]{ 
				new EventTag ("event-one"), 
				new EventTag ("event-two"),
			};
			var name = "Test-Broadcaster";
			var b = new Broadcaster (
				name: name, 
				channel: channel,
				eventTags: eventTags
			);
			foreach (EventTag tag in eventTags) {
				Assert.AreEqual (b, channel.GetBroadcasterFor (tag));
			}
		}
	}
}

