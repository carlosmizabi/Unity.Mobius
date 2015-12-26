using NUnit.Framework;
using Tautalos.Unity.Mobius.Signals;
using Tautalos.Unity.Mobius.Channels;

namespace Tautalos.Unity.Mobius.Tests
{
	[TestFixture()]
	public class EmptyMessageTest
	{
		[Test,
		 Category	("Given the Empty Message"),
		 Description("When we get the instance, Then it should be of type IMessage")]
		 
		public void ShouldHaveStaticInstanceOfTypeMessage ()
		{
			Assert.IsTrue (EmptyMessage.Instance is IMessage);
		}
		
		[Test,
		 Category	("Given the Empty Message"),
		 Description("When we get if its empty, Then it should be positive")]
		
		public void ShouldAnswerPositiveIfItIsEmpty ()
		{
			Assert.IsTrue (EmptyMessage.Instance.IsEmpty);
		}
		
		[Test,
		 Category	("Given the Empty Message"),
		 Description("When we get the Header, Then it should be the empty string")]
		
		public void ShouldReturnTheEmptyString ()
		{
			Assert.IsTrue (EmptyMessage.Instance.Header == "");
		}
		
		[Test,
		 Category	("Given the Empty Message"),
		 Description("When we get the Body, Then it should be an object")]
		
		public void ShouldReturnAnObjectForBody ()
		{
			Assert.IsNotNull (EmptyMessage.Instance.Body);
			Assert.AreSame (EmptyMessage.Instance.Body, EmptyMessage.EmptyBody);
		}
		
		[Test,
		 Category	("Given the Empty Message"),
		 Description("When we get the Footer, Then it should be an object")]
		
		public void ShouldReturnAnObjectForFooter ()
		{
			Assert.IsNotNull (EmptyMessage.Instance.Footer);
			Assert.AreSame (EmptyMessage.Instance.Footer, EmptyMessage.EmptyFooter);
		}
		
	}
}

