namespace Tautalos.Unity.Mobius.Signals
{
	public class EmptyMessage: IMessage
	{
		static IMessage _instance = new EmptyMessage ();
		static object _empty = new object ();
		
		public static object EmptyBody {
			get { return _empty; }
		}
		
		public static object EmptyFooter {
			get { return _empty; }
		}
		
		public static IMessage Instance {
			get { return _instance; }
		}
		
		public string Header {
			get {
				return "";
			}
		}

		public object Body {
			get {
				return _empty;
			}
		}

		public object Footer {
			get {
				return _empty;
			}
		}

		public bool IsEmpty {
			get {
				return true;
			}
		}
	}
}

