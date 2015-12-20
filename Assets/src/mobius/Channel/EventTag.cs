namespace Tautalos.Unity.Mobius.Channels
{
	public class EventTag: IEventTag
	{	
		string _name;
		
		public bool IsEmpty {
			get { return false; }
		}
		
		public EventTag (string name = "NO-NAME")
		{
			_name = name;
		}
		
		public string Name { 
			get { return _name; }
		}	
	}
}



