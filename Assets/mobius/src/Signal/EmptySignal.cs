using Tautalos.Unity.Mobius.Channels;

namespace Tautalos.Unity.Mobius.Signals
{
	public class EmptySignal: ISignal
	{
		static ISignal _instance = new EmptySignal ();
		
		public static ISignal Instance {
			get { return _instance; }
		}
		
		public IEventTag EventTag { 
			get { return EmptyEventTag.Instance; } 
		}
		
		public IMessage Message { 
			get { return EmptyMessage.Instance; }
		}
		
		public ISignaller Signaller { 
			get { return EmptySignaller.Instance; }
		}
		
		public bool IsEmpty {	
			get { return true; }
		}
		
		public bool HasMessage ()
		{
			return false;
		}
	}
}

