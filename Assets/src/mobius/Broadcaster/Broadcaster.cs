
using Tautalos.Unity.Mobius.Channels;

namespace Tautalos.Unity.Mobius.Broadcasters
{
	public class Broadcaster: IBroadcaster
	{
		string _name;
		
		public Broadcaster (string name = "ANONYMOUS")
		{
			_name = name;
		}
		
		public string Name {
			get { return _name; }
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

