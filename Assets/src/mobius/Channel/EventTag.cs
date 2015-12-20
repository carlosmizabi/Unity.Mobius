namespace Tautalos.Unity.Mobius.Channels
{
	public class EventTag: IEventTag
	{	
		string _name;
		string _description;
		
		public bool IsEmpty {
			get { return false; }
		}
		
		public EventTag (string name = "NO-NAME", string description = "")
		{
			_name = name;
			_description = description;
		}
		
		public string Name { 
			get { return _name; }
		}
		public string Description { 
			get { return _description; } 
		}
			
	}
}



