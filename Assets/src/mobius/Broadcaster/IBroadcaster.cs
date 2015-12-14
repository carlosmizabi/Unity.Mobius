
namespace Tautalos.Unity.Mobius.Broadcaster
{
	public interface IBroadcaster
	{
		string Name { get; }
		
		IEventType[] GetEventTypes ();
		
		bool HasEventType ();
		
		void Silence ();
		
		bool IsEmpty ();
	}
	
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

