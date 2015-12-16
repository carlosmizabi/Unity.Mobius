using UnityEngine;
using System.Collections;
using NUnit.Framework;
using Tautalos.Unity.Mobius.Channels;

namespace Tautalos.Unity.Mobius.Tests
{
	[TestFixture]
	internal class ChannelTest
	{
		[ Test, Category("When Getting the Registry"),
				Description("Given the registry is Empty")]
		public void ShouldReturnAnEmptyList ()
		{
			var channel = new Channel ();
			var registry = channel.GetRegistry ();
			Assert.IsNotNull (registry);
		}
		
	}
}
