using CalcLib;
using NUnit.Framework;

namespace CalcLibTest
{
  [TestFixture]
  public class BasicTests
  {
    [Test]
    public void CanAdd()
    {
      var engine = new Engine();
      engine.Digit(1);
      Assert.AreEqual(1, engine.Value);
      engine.Plus();
      Assert.AreEqual(1, engine.Value);
      engine.Digit(2);
      Assert.AreEqual(2, engine.Value);
      engine.Equals();
      Assert.AreEqual(3, engine.Value);
    }

    [Test]
    public void CanAddAndSubtract()
    {
      var engine = new Engine();
      Assert.AreEqual(0, engine.Value);
      engine.Digit(1);
      Assert.AreEqual(1, engine.Value);
      engine.Plus();
      Assert.AreEqual(1, engine.Value);
      engine.Digit(2);
      Assert.AreEqual(2, engine.Value);
      engine.Plus();
      Assert.AreEqual(3, engine.Value);
      engine.Digit(3);
      Assert.AreEqual(3, engine.Value);
      engine.Minus();
      Assert.AreEqual(6, engine.Value);
      engine.Digit(4);
      Assert.AreEqual(4, engine.Value);
      engine.Minus();
      Assert.AreEqual(2, engine.Value);
      engine.Digit(5);
      Assert.AreEqual(5, engine.Value);
      engine.Equals();
      Assert.AreEqual(-3, engine.Value);
    }

    [Test]
    public void CanClearAll()
    {
      var engine = new Engine();
      engine.Digit(1);
      engine.Plus();
      engine.Digit(2);
      engine.ClearAll();
      Assert.AreEqual(0, engine.Value);
      engine.Equals();
      Assert.AreEqual(0, engine.Value);
    }

    [Test]
    public void CanDeleteCurrentEntry()
    {
      var engine = new Engine();
      engine.Digit(1);
      Assert.AreEqual(1, engine.Value);
      engine.ClearEntry();
      Assert.AreEqual(0, engine.Value);
    }

    [Test]
    public void CanDeleteCurrentEntryWhenOperatorIsOnStack()
    {
      var engine = new Engine();
      engine.Digit(1);
      Assert.AreEqual(1, engine.Value);
      engine.Plus();
      Assert.AreEqual(1, engine.Value);
      engine.ClearEntry();
      Assert.AreEqual(0, engine.Value);
      engine.Digit(2);
      Assert.AreEqual(2, engine.Value);
      engine.Equals();
      Assert.AreEqual(3, engine.Value);
    }

    [Test]
    public void CanDivide()
    {
      var engine = new Engine();
      engine.Digit(6);
      engine.Divide();
      engine.Digit(2);
      engine.Equals();
      Assert.AreEqual(3, engine.Value);
    }

    [Test]
    public void CanDivideWithFractionalResult()
    {
      var engine = new Engine();
      engine.Digit(3);
      engine.Divide();
      engine.Digit(2);
      engine.Equals();
      Assert.AreEqual(1.5, engine.Value);
    }

    [Test]
    public void CanEnterDecimalPoints()
    {
      var engine = new Engine();
      engine.Digit(1);
      Assert.AreEqual(1, engine.Value);
      engine.Point();
      Assert.AreEqual(1, engine.Value);
      engine.Digit(2);
      Assert.AreEqual(1.2, engine.Value);
      engine.Digit(3);
      Assert.AreEqual(1.23, engine.Value);
      engine.Plus();
      Assert.AreEqual(1.23, engine.Value);
      engine.Digit(4);
      Assert.AreEqual(4, engine.Value);
      engine.Point();
      Assert.AreEqual(4, engine.Value);
      engine.Digit(5);
      Assert.AreEqual(4.5, engine.Value);
      engine.Digit(6);
      Assert.AreEqual(4.56, engine.Value);
      engine.Equals();
      Assert.AreEqual(5.79, engine.Value);
    }

    [Test]
    public void CanEnterMultiDigitNumbers()
    {
      var engine = new Engine();
      engine.Digit(1);
      Assert.AreEqual(1, engine.Value);
      engine.Digit(2);
      Assert.AreEqual(12, engine.Value);
    }

    [Test]
    public void CanEnterNegativeDecimals()
    {
      var engine = new Engine();
      engine.Minus();
      engine.Point();
      engine.Digit(1);
      Assert.AreEqual(-0.1, engine.Value);
      engine.Digit(2);
      Assert.AreEqual(-0.12, engine.Value);
      engine.Times();
      Assert.AreEqual(-0.12, engine.Value);
      engine.Digit(3);
      engine.Equals();
      Assert.AreEqual(-0.36, engine.Value);
    }

    [Test]
    public void CanEnterNegativeMultiDigitNumbers()
    {
      var engine = new Engine();
      engine.Minus();
      Assert.AreEqual(0, engine.Value);
      engine.Digit(1);
      Assert.AreEqual(-1, engine.Value);
      engine.Digit(2);
      Assert.AreEqual(-12, engine.Value);
      engine.Digit(3);
      Assert.AreEqual(-123, engine.Value);
      engine.Plus();
      Assert.AreEqual(-123, engine.Value);
      engine.Minus();
      Assert.AreEqual(-123, engine.Value);
      engine.Digit(4);
      Assert.AreEqual(-4, engine.Value);
      engine.Digit(5);
      Assert.AreEqual(-45, engine.Value);
      engine.Digit(6);
      Assert.AreEqual(-456, engine.Value);
      engine.Equals();
      Assert.AreEqual(-579, engine.Value);
    }

    [Test]
    public void CanMultiply()
    {
      var engine = new Engine();
      engine.Digit(2);
      engine.Times();
      engine.Digit(3);
      engine.Equals();
      Assert.AreEqual(6, engine.Value);
    }

    [Test]
    public void CanNegate()
    {
      var engine = new Engine();
      engine.Minus();
      engine.Digit(1);
      Assert.AreEqual(-1, engine.Value);
    }

    [Test]
    public void CanPlusAfterNegate()
    {
      var engine = new Engine();
      engine.Minus();
      engine.Plus();
      engine.Digit(5);
      engine.Minus();
      engine.Digit(3);
      engine.Equals();
      Assert.AreEqual(2, engine.Value);
    }

    [Test]
    public void CanSubtract()
    {
      var engine = new Engine();
      engine.Digit(1);
      engine.Minus();
      engine.Digit(2);
      engine.Equals();
      Assert.AreEqual(-1, engine.Value);
    }

    [Test]
    public void PrecedenceTest1()
    {
      var engine = new Engine();
      engine.Digit(1);
      engine.Plus();
      engine.Digit(2);
      engine.Times();
      engine.Digit(3);
      engine.Plus();
      engine.Digit(4);
      engine.Equals();
      Assert.AreEqual(13, engine.Value);
    }

    [Test]
    public void PrecedenceTest2()
    {
      var engine = new Engine();
      engine.Digit(1);
      engine.Times();
      engine.Digit(2);
      engine.Plus();
      engine.Digit(3);
      engine.Times();
      engine.Digit(4);
      engine.Equals();
      Assert.AreEqual(20, engine.Value);
    }
  }
}