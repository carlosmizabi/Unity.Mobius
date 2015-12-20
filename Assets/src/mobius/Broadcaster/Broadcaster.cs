
using Tautalos.Unity.Mobius.Channels;

namespace Tautalos.Unity.Mobius.Broadcasters
{
	public class Broadcaster: IBroadcaster
	{
		string _name;
		
		public Broadcaster (string name = "anonymous-broadcaster")
		{
			_name = name;
		}
		
		public string Name {
			get { return _name; }
		}
		
		public bool IsEmpty {
			get { return false; }
		}
		
		public IEventTag[] GetEventTags ()
		{
			return null;
		}
		
		public bool HasEventTag ()
		{
			return false;
		}
		
		public void Silence ()
		{
			
		}

	}
}

