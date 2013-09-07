using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Matchy.Specs
{
    [TestClass]
    public class Fibs
    {
        Def fib = null;

        [TestInitialize]
        public void SetupFibs()
        {
            fib = new Def()
               .match(0).with(0)
               .match(1).with(1)
               .match(2).with(1)
               .match<int>().with(n => fib[n - 1] * fib[n - 2]);
        }

        [TestMethod]
        public void Fib_0()
        {
            Assert.AreEqual(0,fib[0]);
        }

        [TestMethod]
        public void Fib_1()
        {
            Assert.AreEqual(1, fib[1]);
        }

        [TestMethod]
        public void Fib_2()
        {
            Assert.AreEqual(1, fib[2]);
        }
    }
}
