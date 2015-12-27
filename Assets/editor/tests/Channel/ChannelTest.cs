using UnityEngine;
using System.Collections;
using NUnit.Framework;
using Tautalos.Unity.Mobius.Channels;
using Tautalos.Unity.Mobius.Broadcasters;
using System.Collections.Generic;
using Tautalos.Unity.Mobius.Signals;
using System;

namespace Tautalos.Unity.Mobius.Tests
{
	[TestFixture]
	internal class ChannelTest
	{
		IChannel channel;
		IDictionary<IEventTag, IBroadcaster> registry;
		
	
		[SetUp] 
		public void Init ()
		{ 
			channel = new Channel ();
			registry = channel.Registry;
		}
		
		[TearDown] 
		public void Cleanup ()
		{
			channel = null;
			registry = null;
		}
		
		[Test, 
		Category("Given instanciation"),
		Description("When it is not the EmptyChanel, Then it should return false")]
		
		public void ShouldNotBeTheEmptyChannel ()
		{
			Assert.IsFalse (channel.IsEmpty);
		}	
		
		[Test, 
		Category("Given we are Getting the Registry"),
		Description("When the registry is Empty, Then it should return an empty list")]
			
		public void ShouldReturnAnEmptyList ()
		{
			Assert.IsNotNull (registry);
		}
		
		[Test,
		Category("Given we are a registering events"),
		Description("When it has an invalid event tag, Thenit should not add an invalid event tag to the registry")]
		
		public void ShouldNotAddInvalidEvenTagToRegistry ()
		{
			var entry = new EventEntry (EmptyEventTag.Instance, EmptyBroadcaster.Instance);
			channel.AddEventEntry (entry);
			Assert.IsEmpty (registry);
		}
		
		[Test,
		 Category("Given we are a registering events"),
		 Description("When there is a valid event entry, Then it should add event to registry")]
		
		public void ShouldAddEvenToRegistry ()
		{
			var entry = new EventEntry (new EventTag ("TagName"), EmptyBroadcaster.Instance);
			channel.AddEventEntry (entry);
			Assert.IsNotEmpty (registry);
		}
		
		
		[Test,
		 Category("Given we are a registering event"),
		 Description("When it is an invalid event entry, Then it should not add event to registry")]
		 
		public void ShouldNotAddEvenToRegistry ()
		{
			var entry = new EmptyEventEntry ();
			channel.AddEventEntry (entry);
			Assert.IsEmpty (registry);
		}
		
		[Test,
		 Category("Given we are a registering event"),
		 Description("When a entry with an event tag already registered,"+ 
		 			 "Then it should not add a repeated event tag to the registry")]
		
		public void ShouldNotAddRepeatedEvenTagToRegistry ()
		{
			var entry1 = new EventEntry (new EventTag ("TagName"), EmptyBroadcaster.Instance);
			var entry2 = new EventEntry (new EventTag ("TagName"), EmptyBroadcaster.Instance);
			channel.AddEventEntry (entry1);
			channel.AddEventEntry (entry2);
			Assert.AreEqual (1, registry.Count);
			Assert.IsTrue (registry.ContainsKey (entry1.EventTag));
			Assert.IsFalse (registry.ContainsKey (entry2.EventTag));
		}
		
		[Test,
		 Category("Given we are a registering event"),
		 Description("When an EventTag without an explicit Broadcaster" + 
		 			 "Then it should be paired in the registry it the channel DefaultBroadcaster")]
		
		public void ShouldPairEventTagsToChannelDefaultBroadcaster ()
		{
			var eventTag = new EventTag ("PAIRED_TO_CHANNEL_DEFAUL_BROADCASTER");
			channel.AddEvent (eventTag);
			Assert.IsNotEmpty (registry);
			Assert.IsTrue (channel.HasEventTag (eventTag));
			IBroadcaster broadcaster = null;
			channel.Registry.TryGetValue (eventTag, out broadcaster);
			Assert.IsNotNull (broadcaster);
			Assert.AreSame (channel.DefaultBroadcaster, broadcaster);
		}
		
		[Test,
		 Category("Given we are checking the registry"),
		 Description("When there are Events Tags, Then it should inform us if they are, currently,  on the registry ")]
		
		public void ShouldInformUsIfAnEventTagIsRegistered ()
		{
			var count = 12;
			var tags = new EventTag[count];
			for (int i = 0; i < count; i++) {
				var tag = new EventTag ("EVENT-" + i);
				channel.AddEvent (tag);
				tags [i] = tag;
			}
			Assert.AreEqual (count, channel.Registry.Count);
			foreach (IEventTag tag in tags) {
				Assert.IsTrue (channel.HasEventTag (tag));
			}
		}
		
		[Test,
		 Category("Given we are checking the registry"),
		 Description("When we provide EventsTags Names, Then it should inform us if they are, currently, on the registry ")]
		
		public void ShouldInformUsIfAnNamedEventTagIsRegistered ()
		{
			var count = 12;
			var tags = new EventTag[count];
			for (int i = 0; i < count; i++) {
				var tag = new EventTag ("EVENT-" + i);
				channel.AddEvent (tag);
				tags [i] = tag;
			}
			Assert.AreEqual (count, channel.Registry.Count);
			foreach (IEventTag tag in tags) {
				Assert.IsTrue (channel.HasEventTag (tag.Name));
			}
		}
		
		[Test,
		 Category("Given we are getting all event tags"),
		 Description("When there are not tags, Then it should give us an empty collection EventTags")]
		
		public void ShouldGiveUsAnEmptyCollectionOfEventTags ()
		{
			Assert.IsEmpty (channel.GetAllEventTags ());
		}
		
		[Test,
		 Category("Given we are getting all event tags"),
		 Description("When there are tags, Then it should give us a collection of all the EventTags")]
		
		public void ShouldGiveUsAnCollectionWithAllEventTags ()
		{
			var count = 12;
			var tags = new EventTag[count];
			for (int i = 0; i < count; i++) {
				var tag = new EventTag ("EVENT-" + i);
				channel.AddEvent (tag);
				tags [i] = tag;
			}
			var collection = channel.GetAllEventTags ();
			Assert.AreEqual (count, collection.Count);
		}
		
		[Test,
		 Category("Given we are looking for event tag by name"),
		 Description("When the tag name is not present, Then it should return the empty EventTag")]
		 
		public void ShouldReturnTheEmptyEventTag ()
		{
			Assert.AreSame (EmptyEventTag.Instance, channel.GetEventTag ("NotPresent"));
		}
		
		[Test,
		 Category("Given we are looking for event tag by name"),
		 Description("When the tag name is present, Then it should return the EventTag")]
		
		public void ShouldReturnTheFoundEventTag ()
		{
			var name = "SomeTag";
			var tag = new EventTag (name);
			channel.AddEvent (tag);
			Assert.AreSame (tag, channel.GetEventTag (name));
		}
		
		[Test,
		 Category("When looking for all event tags of registered to a Broadcaster"),
		 Description("Given the Broadcaster is not registered, it should return an empty Collection")]
		
		public void ShouldReturnAnEmptyCollectionOfEventTags ()
		{
			Assert.IsEmpty (channel.GetEventTags (EmptyBroadcaster.Instance));
		}
		
		[Test,
		 Category("Given we are looking for all event tags of registered to a Broadcaster"),
		 Description("When the Broadcaster is not registered, Then it should return an empty Collection")]
		
		public void ShouldReturnAnCollectionWithAllTheEventTags ()
		{
			var count = 12;
			var tags = new EventTag[count];
			
			for (int i = 0; i < count; i++) {
				var tag0 = new EventTag ("0_EVENT-" + i);
				channel.AddEventEntry (new EventEntry (tag0, EmptyBroadcaster.Instance));
				tags [i] = tag0;
				
				if (i % 2 == 0) {
					var tag1 = new EventTag ("1_EVENT-" + i);
					channel.AddEvent (tag1);
					tags [i] = tag1;
				}
			}
			Assert.AreEqual (count, channel.GetEventTags (EmptyBroadcaster.Instance).Count);
			Assert.AreEqual (count / 2, channel.GetEventTags (channel.DefaultBroadcaster).Count);
		}
		
		[Test,
		 Category("Given we are looking for the Broadcaster assigned to an EventTag"),
		 Description("When the EventTag is not assigned to any Broadcaster, Then it should return the EmptyBroadcaster")]
		
		public void ShouldReturnTheEmptyBroadcaster ()
		{
			Assert.AreSame (EmptyBroadcaster.Instance, channel.GetBroadcasterFor (EmptyEventTag.Instance));
		}
		
		[Test,
		 Category("Given we are looking for the Broadcaster assigned to an EventTag"),
		 Description("When the EventTag is assigned to a Broadcaster, Then it should return the broadcaster")]
		
		public void ShouldReturnTheMatchingBroadcasterForEventTag ()
		{
			var eventTag = new EventTag ("AnEvent");
			channel.AddEvent (eventTag);
			Assert.AreSame (channel.DefaultBroadcaster, channel.GetBroadcasterFor (eventTag));
		}
		
		[Test,
		 Category("Given we are looking for the Broadcaster assigned to an named EventTag"),
		 Description("When there is not Broadcaster assigned to that EventTag name, then it should return the EmptyBroadcaster")]
		
		public void ShouldReturnTheEmptyBroadcasterWhenNoEventTagIsFoundWithName ()
		{
			Assert.AreSame (EmptyBroadcaster.Instance, channel.GetBroadcasterFor (EmptyEventTag.Instance.Name));
		}
		
		[Test,
		 Category("Given we are looking for the Broadcaster assigned to an named EventTag"),
		 Description("When the Broadcaster is a assigned to a EventTag with that " + 
		  			 "matching name, Then it should return the Broadcaster")]
		
		public void ShouldReturnTheBroadcasterForTheEventTagMatchingTheName ()
		{
			var eventTag = new EventTag ("AnEvent");
			channel.AddEvent (eventTag);
			Assert.AreSame (channel.DefaultBroadcaster, channel.GetBroadcasterFor (eventTag.Name));
		}
		
		[Test,
		 Category("Given we looking for a Broadcaster by name"),
		 Description("When there is no Broadcaster registered with that name, Then it should return the EmptyBroadcaster")]
		 
		public void ShouldReturnTheEmptyBroadcasterWhenNoneMatchesTheName ()
		{
			Assert.AreSame (EmptyBroadcaster.Instance, channel.GetBroadcasterNamed (""));
		}
		
		[Test,
		 Category("Given we are looking for a Broadcaster by name"),
		 Description("When there is no Broadcaster registered with that name, Then it should return the EmptyBroadcaster")]
		
		public void ShouldTheBroadcasterWhenWithTheMatchingName ()
		{
			var eventTag = new EventTag ("event-name");
			channel.AddEvent (eventTag);
			Assert.AreSame (channel.DefaultBroadcaster, channel.GetBroadcasterNamed ("default-broadcaster"));
		}
	
		[Test,
		 Category("Given we are checking is broadcaster with a given name exist"),
		 Description("When provided it names, Then it should return the truthfullness of the existence of matching broadcasters ")]
		
		public void ShouldReturnTheTruthfullnessOfGivenNamedBroadcasterInRegistry ()
		{
			Assert.IsFalse (channel.HasNamedBroadcaster ("default-broadcaster"));
			var eventTag = new EventTag ("event-name");
			channel.AddEvent (eventTag);
			Assert.IsTrue (channel.HasNamedBroadcaster ("default-broadcaster"));
		}
		
		[Test,
		 Category("Given we are verifying if a Signal is emmitable"),
		 Description("When the signal has an Event Tag not registered, Then it should be give a negative answer")]
		 
		public void ShouldAnwerNegativeToASignalWithANonRegisteredEventTag ()
		{
			var signal = EmptySignal.Instance;
			Assert.IsFalse (channel.IsEmittable (signal));
		}
		
		[Test,
		 Category("Given we are verifying if a Signal is emmitable"),
		 Description("When the Signal has an Event Tag registered, Then it should be give a positive answer")]
		
		public void ShouldAnwerPositiveToASignalWithARegisteredEventTag ()
		{
			var tag = new EventTag ("some-event");
			var signaller = new Signaller (owner: this, channel: channel);
			channel.AddEvent (tag);
			var signal = signaller.CreateSignal (
				eventTag: tag,
				message: EmptyMessage.Instance
			);
			Assert.IsTrue (channel.IsEmittable (signal));
		}
		
		[Test,
		 Category("Given the Channel"),
		 Description("When we ask for a signaller, Then it should return a signaller with itself as its channel")]
		 
		public void ShouldReturnASignallerWithItselfAsTheChannel ()
		{
			var signaller = channel.CreateSignaller (owner: this);
			Assert.AreSame (channel, signaller.Channel);
		}
		
		[Test,
		 Category("Given the Channel"),
		 Description("When we ask for a signaller with a null owner, Then it should return the EmptySignaller")]
		
		public void ShouldReturnTheEmptySignaller ()
		{
			var signaller = channel.CreateSignaller (owner: null);
			Assert.AreSame (EmptySignaller.Instance, signaller);
		}
		
		[Test,
		 Category("Given a Channel"),
		 Description("When we subscribe a Broadcaster, Then it should register all its EventTags")]
		 
		public void ShouldRegisterBroadcasterEventTagsOnSubscription ()
		{
			var eventTags = new EventTag[]{ 
				new EventTag ("event-one"), 
				new EventTag ("event-two"),
			};
			var bc = new Broadcaster (channel: channel, eventTags: eventTags);
			foreach (IEventTag tag in eventTags) {
				Assert.IsTrue (channel.HasEventTag (tag));
			}
		}
		
		[Test,
		 Category("Given a Channel"),
		 Description("When we subscribe a Broadcaster, Then it should return a disposable subscription")]
		
		public void ShouldReturnADisposableSubscription ()
		{
			var tags = new IEventTag[]{ new EventTag ("some-event") };
			var bc = new Broadcaster (channel, tags);
			Assert.IsInstanceOf<IDisposable> (channel.Subscribe (bc));
		}
		
		[Test,
		 Category("Given a Channel"),
		 Description("When emit a Signal on the Channel, Then it should be passed to the appropriate Broadcaster")]
		 
		public void ShouldRelaySignalToAppropriateBroadcaster ()
		{
			var tag = new EventTag ("test-event");
			channel.AddEvent (tag);
			var signal = new Signal (eventTag: tag, signaller: EmptySignaller.Instance, message: null);
//			channel.Emit (signal);
		}
		
	}
}













