
using Tautalos.Unity.Mobius.Channels;

namespace Tautalos.Unity.Mobius.Broadcasters
{
	public class EmptyBroadcaster: IBroadcaster
	{
		string _name = "EMPTY";
		
		public bool IsEmpty {
			get { return false; }
		}
		
		static EmptyBroadcaster _instance = new EmptyBroadcaster ();
		
		public static EmptyBroadcaster Instance {
			get { return _instance; }
		}
		
		public string Name {
			get { return _name; }
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

