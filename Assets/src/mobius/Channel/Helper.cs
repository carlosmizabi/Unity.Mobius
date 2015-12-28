using UnityEngine;
using System.Collections;
using Tautalos.Unity.Mobius.Broadcasters;
using System.Collections.Generic;
using Tautalos.Unity.Mobius.Signals;
using System;

namespace Tautalos.Unity.Mobius.Channels
{
	public class Helper
	{
	
		public static bool IsEmptyChannel (IChannel channel)
		{
			return channel is EmptyChannel;
		}
	}
}