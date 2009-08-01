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
            engine.Number(1);
            engine.Plus();
            engine.Number(2);
            engine.Equals();
            Assert.AreEqual(3, engine.Value);
        }

        [Test]
        public void CanAddAndSubtract()
        {
            var engine = new Engine();
            engine.Number(1);
            engine.Plus();
            engine.Number(2);
            engine.Plus();
            Assert.AreEqual(3, engine.Value);
            engine.Number(3);
            engine.Minus();
            Assert.AreEqual(6, engine.Value);
            engine.Number(4);
            engine.Minus();
            Assert.AreEqual(2, engine.Value);
            engine.Number(5);
            engine.Equals();
            Assert.AreEqual(-3, engine.Value);
        }

        [Test]
        public void CanEnterMultiDigitNumbers()
        {
            var engine = new Engine();
            engine.Number(1);
            engine.Number(2);
            Assert.AreEqual(12, engine.Value);
        }

        [Test]
        public void CanEnterNegativeMultiDigitNumbers()
        {
            var engine = new Engine();
            engine.Minus();
            engine.Number(1);
            Assert.AreEqual(-1, engine.Value);
            engine.Number(2);
            Assert.AreEqual(-12, engine.Value);
            engine.Number(3);
            Assert.AreEqual(-123, engine.Value);
            engine.Plus();
            Assert.AreEqual(-123, engine.Value);
            engine.Minus();
            Assert.AreEqual(-123, engine.Value);
            engine.Number(4);
            Assert.AreEqual(-4, engine.Value);
            engine.Number(5);
            Assert.AreEqual(-45, engine.Value);
            engine.Number(6);
            Assert.AreEqual(-456, engine.Value);
            engine.Equals();
            Assert.AreEqual(-579, engine.Value);
        }

        [Test]
        public void CanNegate()
        {
            var engine = new Engine();
            engine.Minus();
            engine.Number(1);
            Assert.AreEqual(-1, engine.Value);
        }

        [Test]
        public void CanSubtract()
        {
            var engine = new Engine();
            engine.Number(1);
            engine.Minus();
            engine.Number(2);
            engine.Equals();
            Assert.AreEqual(-1, engine.Value);
        }
    }
}