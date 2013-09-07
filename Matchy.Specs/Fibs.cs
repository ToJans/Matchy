using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Matchy.Specs
{
    [TestClass]
    public class Fibs
    {
        IMatch fib = null;

        [TestInitialize]
        public void SetupFibs()
        {
            fib.match(0).with(0)
               .match(1).with(1)
               .match<int>().with(n => fib[n-1]*fib[n-2]);
        }

        [TestMethod]
        public void Fib_0()
        {
            fib[0].ShouldBe(0);
        }
    }
}
