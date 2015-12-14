
using Tautalos.Unity.Mobius.Channel;

namespace Tautalos.Unity.Mobius.Broadcaster
{
	public class EmptyBroadcaster: IBroadcaster
	{
		public string Name {
			get { return ""; }
		}
		
		public IEventType[] GetEventTypes ()
		{
			return null;
		}
		
		public bool HasEventType ()
		{
			return false;
		}
		
		public void Silence ()
		{
			
		}
		
		public bool IsEmpty ()
		{
			return false;
		}
	}
}

