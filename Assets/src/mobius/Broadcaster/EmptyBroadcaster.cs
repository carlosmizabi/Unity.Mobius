
using Tautalos.Unity.Mobius.Channels;

namespace Tautalos.Unity.Mobius.Broadcasters
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

