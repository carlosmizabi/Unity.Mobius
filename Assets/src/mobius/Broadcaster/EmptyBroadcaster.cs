
using Tautalos.Unity.Mobius.Channels;

namespace Tautalos.Unity.Mobius.Broadcasters
{
	public class EmptyBroadcaster: IBroadcaster
	{

		static EmptyBroadcaster _instance = new EmptyBroadcaster ();
		static IEventTag[] _eventTags = new IEventTag[0];
		
		string _name = "EMPTY";
		
		public IChannel Channel {
			get {
				return EmptyChannel.Instance;
			}
		}
		
		public bool IsEmpty {
			get { return true; }
		}
				
		public static EmptyBroadcaster Instance {
			get { return _instance; }
		}
		
		public string Name {
			get { return _name; }
		}
		
		public IEventTag[] GetEventTags ()
		{
			return _eventTags;
		}
		
		public bool HasEventTag (IEventTag eventTag)
		{
			return false;
		}
		
		public void Silence ()
		{			
		}

		public void OnCompleted ()
		{
		}
		public void OnError (System.Exception error)
		{
		}
		public void OnNext (Tautalos.Unity.Mobius.Signals.ISignal value)
		{
		}
	}
}

