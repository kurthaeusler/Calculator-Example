using CalcLib;
using NUnit.Framework;

namespace CalcLibTest
{
  [TestFixture]
  public class NumberBaseTests
  {
    [Test]
    public void CanConvertDecimalToBinary()
    {
      var engine = new Engine();
      Assert.AreEqual("0", engine.Display);
      engine.Digit(5);
      Assert.AreEqual("5", engine.Display);
      engine.Binary();
      Assert.AreEqual("101", engine.Display);
    }
  }
}