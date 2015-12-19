using UnityEngine;
using System.Collections;
using NUnit.Framework;
using Tautalos.Unity.Mobius.Channels;

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
		
		[ 	Test, 
			Category("When Getting the Registry"),
			Description("Given the registry is Empty")]
			
		public void ShouldReturnAnEmptyList ()
		{
			var registry = channel.GetRegistry ();
			Assert.IsNotNull (registry);
		}
		
		[ 	Test,
			Category("When registring events"),
			Description("Given a new event type")]
		
		public void ShouldAddEvenTypeToRegistry ()
		{
			var entry = new EmptyEventEntry ();
			channel.AddEventEntry (entry);
			var registry = channel.GetRegistry ();
			Assert.IsNotEmpty (registry);
		}
		
		
	}
}













