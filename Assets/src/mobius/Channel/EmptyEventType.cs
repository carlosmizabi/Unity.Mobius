namespace Tautalos.Unity.Mobius.Channels
{
	public class EmptyEventType: IEventType
	{
		
		static EmptyEventType _instance = new EmptyEventType ();
		
		public static EmptyEventType Instance {
			get { return _instance; }
		} 
		
		string _name = "EMPTY";
		string _description = "";
		string[] _tags = new string[0];
		
		public string Name { 
			get { return _name; }
		}
		
		public string Description { 
			get { return _description; } 
		}
		
		public string[] Tags { 
			get { 
				return _tags;
			} 
		}
		
		public bool IsEmpty ()
		{
			return true;
		}
		
	}
}



