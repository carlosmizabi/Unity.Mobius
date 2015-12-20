using UnityEngine;
using System.Collections;
using NUnit.Framework;
using Tautalos.Unity.Mobius.Channels;
using Tautalos.Unity.Mobius.Broadcasters;
using System.Collections.Generic;

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
		}
		
		[Test, 
		Category("When instanciated"),
		Description("Given it is not the EmptyChanel, it should return false")]
		
		public void ShouldNotBeTheEmptyChannel ()
		{
			Assert.IsFalse (channel.IsEmpty);
		}	
		
		[Test, 
		Category("When Getting the Registry"),
		Description("Given the registry is Empty, it should return an empty list")]
			
		public void ShouldReturnAnEmptyList ()
		{
			Assert.IsNotNull (registry);
		}
		
		[Test,
		Category("When registering events"),
		Description("Given a invalid event tag, it should not add an invalid event tag to the registry")]
		
		public void ShouldNotAddInvalidEvenTagToRegistry ()
		{
			var entry = new EventEntry (EmptyEventTag.Instance, EmptyBroadcaster.Instance);
			channel.AddEventEntry (entry);
			Assert.IsEmpty (registry);
		}
		
		[Test,
		 Category("When registering events"),
		 Description("Given a valid event entry, it should add event to registry")]
		
		public void ShouldAddEvenToRegistry ()
		{
			var entry = new EventEntry (new EventTag ("TagName"), EmptyBroadcaster.Instance);
			channel.AddEventEntry (entry);
			Assert.IsNotEmpty (registry);
		}
		
		
		[Test,
		 Category("When registering events"),
		 Description("Given an invalid event entry, it should not add event to registry")]
		 
		public void ShouldNotAddEvenToRegistry ()
		{
			var entry = new EmptyEventEntry ();
			channel.AddEventEntry (entry);
			Assert.IsEmpty (registry);
		}
		
		[Test,
		 Category("When registering events"),
		 Description("Given a entry with an event tag already registered,"+ 
		 			 "should not add a repeated event tag to the registry")]
		
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
		 Category("When registering events"),
		 Description("Given an EventTag without an explicit Broadcaster" + 
		 			 ",it should be paired in the registry it the channel DefaultBroadcaster")]
		
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
		 Category("When checking the registry"),
		 Description("Given Events Tags, it should inform us if they are, currently,  on the registry ")]
		
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
		 Category("When checking the registry"),
		 Description("Given EventsTags Names, it should inform us if they are, currently, on the registry ")]
		
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
		 Category("When getting all event tags"),
		 Description("Given there are not tags, it should give us an empty collection EventTags")]
		
		public void ShouldGiveUsAnEmptyCollectionOfEventTags ()
		{
			Assert.IsEmpty (channel.GetEventTags ());
		}
		
		[Test,
		 Category("When getting all event tags"),
		 Description("Given there are tags, it should give us a collection of all the EventTags")]
		
		public void ShouldGiveUsAnCollectionWithAllEventTags ()
		{
			var count = 12;
			var tags = new EventTag[count];
			for (int i = 0; i < count; i++) {
				var tag = new EventTag ("EVENT-" + i);
				channel.AddEvent (tag);
				tags [i] = tag;
			}
			var collection = channel.GetEventTags ();
			Assert.AreEqual (count, collection.Count);
		}
		
		[Test,
		 Category("When looking for event tag by name"),
		 Description("Given the tag name is not present, it should return the empty EventTag")]
		 
		public void ShouldReturnTheEmptyEventTag ()
		{
			Assert.AreSame (EmptyEventTag.Instance, channel.GetEventTag ("NotPresent"));
		}
		
		[Test,
		 Category("When looking for event tag by name"),
		 Description("Given the tag name is present, it should return the EventTag")]
		
		public void ShouldReturnTheFoundEventTag ()
		{
			var name = "SomeTag";
			var tag = new EventTag (name);
			channel.AddEvent (tag);
			Assert.AreSame (tag, channel.GetEventTag (name));
		}
	}
}













