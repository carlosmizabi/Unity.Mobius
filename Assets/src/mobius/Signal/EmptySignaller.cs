using Tautalos.Unity.Mobius.Channels;

namespace Tautalos.Unity.Mobius.Signals
{
	public class EmptySignaller: ISignaller
	{
		static ISignaller _instance = new EmptySignaller ();
		
		public static ISignaller Instance {
			get { return _instance; }
		}
		
		public bool IsEmpty {
			get { return true; }
		}

		public ISignal CreateSignal (IEventTag eventTag, IMessage message)
		{
			return EmptySignal.Instance;
		}

		public void emit (ISignal signal)
		{
			
		}

		public void emit (ISignal[] signals)
		{
			
		}

		public object Owner {
			get {
				return _instance;
			}
		}

		public IChannel Channel {
			get {
				return EmptyChannel.Instance;
			}
		}
	}
}

