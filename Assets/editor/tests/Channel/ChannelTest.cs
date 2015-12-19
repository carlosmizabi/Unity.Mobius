using UnityEngine;
using System.Collections;
using NUnit.Framework;
using Tautalos.Unity.Mobius.Channels;
using Tautalos.Unity.Mobius.Broadcasters;

namespace Tautalos.Unity.Mobius.Tests
{
	[TestFixture]
	internal class ChannelTest
	{
		IChannel channel;
		
	
		[SetUp] 
		public void Init ()
		{ 
			channel = new Channel ();
		
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
			Assert.IsFalse (channel.IsEmpty ());
		}	
		
		[Test, 
		Category("When Getting the Registry"),
		Description("Given the registry is Empty, it should return an empty list")]
			
		public void ShouldReturnAnEmptyList ()
		{
			var registry = channel.GetRegistry ();
			Assert.IsNotNull (registry);
		}
		
		[Test,
		Category("When registering events"),
		Description("Given a valid event type, it should add event to registry")]
		
		public void ShouldAddEvenToRegistry ()
		{
			var entry = new EventEntry (EmptyEventType.Instance, EmptyBroadcaster.Instance);
			channel.AddEventEntry (entry);
			var registry = channel.GetRegistry ();
			Assert.IsNotEmpty (registry);
		}
		
		[Test,
		 Category("When registering events"),
		 Description("Given an invalid event entry, it should not add event to registry")]
		 
		public void ShouldNotAddEvenToRegistry ()
		{
			var entry = new EmptyEventEntry ();
			channel.AddEventEntry (entry);
			var registry = channel.GetRegistry ();
			Assert.IsEmpty (registry);
		}
		
	}
}













