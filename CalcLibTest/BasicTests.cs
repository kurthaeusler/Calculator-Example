
using System;
using NUnit.Framework;
using CalcLib;

namespace CalcLibTest
{
	[TestFixture]
	public class BasicTests
	{
		[Test]
		public void CanAdd()
		{
			Engine engine = new Engine();
			engine.Number(1);
			engine.Plus();
			engine.Number(2);
			engine.Equals();
			Assert.AreEqual(3, engine.Value);
		}
		
		[Test]
		public void CanSubtract()
		{
			Engine engine = new Engine();
			engine.Number(1);
			engine.Minus();
			engine.Number(2);
			engine.Equals();
			Assert.AreEqual(-1, engine.Value);
		}
		
		[Test]
		public void CanAddAndSubtract()
		{
			Engine engine = new Engine();
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
	}
}
