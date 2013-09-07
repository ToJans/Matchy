using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Matchy.Specs
{
    [TestClass]
    public class _99BottlesOfBeer
    {
        Def verse;

        [TestInitialize]
        public void Setup()
        {
            verse = new Def()
                .Match(8).With( "8 bottles of beer on the wall, 8 bottles of beer.\n" +
                                "Take one down and pass it around, 7 bottles of beer on the wall.\n");
        }

        [TestMethod]
        public void A_verse()
        {
            var Expected = 
                "8 bottles of beer on the wall, 8 bottles of beer.\n" + 
                "Take one down and pass it around, 7 bottles of beer on the wall.\n";
            Assert.AreEqual(Expected,verse[8]);
        }
    }
}
