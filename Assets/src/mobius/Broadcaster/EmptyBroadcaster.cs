
using Tautalos.Unity.Mobius.Channels;

namespace Tautalos.Unity.Mobius.Broadcasters
{
	public class EmptyBroadcaster: IBroadcaster
	{
		string _name = "EMPTY";
		
		static EmptyBroadcaster _instance = new EmptyBroadcaster ();
		
		public static EmptyBroadcaster Instance {
			get { return _instance; }
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
			return true;
		}
	}
}

