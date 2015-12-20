namespace Tautalos.Unity.Mobius.Channels
{
	public class EmptyEventTag: IEventTag
	{
		string _name = "EMPTY";		
		static EmptyEventTag _instance = new EmptyEventTag ();
		
		public static EmptyEventTag Instance {
			get { return _instance; }
		} 
		
		public bool IsEmpty {
			get { return true; }
		}
		
		public string Name { 
			get { return _name; }
		}
	}
}



