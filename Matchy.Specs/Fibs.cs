using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Matchy.Specs
{
    [TestClass]
    public class Fibs
    {
        Def fib = null;
        Predicate<int> aLargeInt = x => x > 10;

        [TestInitialize]
        public void SetupFibs()
        {
            fib = new Def()
               .Match(0).With(0)
               .Match(1).With(1)
               .Match(2).With(1)
               .Match(aLargeInt).With(x => { throw new ArgumentOutOfRangeException("N", x, "We only support numbers up to 10."); })
               .Match<int>().With(n => fib[n - 1] + fib[n - 2])
               .Match<string>().With("You found the easter egg");
        }

        [TestMethod]
        public void Fib_0()
        {
            Assert.AreEqual(0, fib[0]);
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

        [TestMethod]
        public void Fib_3()
        {
            Assert.AreEqual(2, fib[3]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Fib_11()
        {
            var x = fib[11];
        }

        [TestMethod]
        public void Fib_WTF()
        {
            Assert.AreEqual("You found the easter egg", fib["WTF"]);
        }
    }
}
