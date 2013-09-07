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
        Def verse, bottles, lastOne;

        [TestInitialize]
        public void Setup()
        {
            verse = new Def()
                .Match(0).With(
                    "No more bottles of beer on the wall, no more bottles of beer.\n" +
                    "Go to the store and buy some more, 99 bottles of beer on the wall.\n")
                .Match<int>().With(n => string.Format(
                    "{0} of beer on the wall, {0} of beer.\n" +
                    "Take {1} down and pass it around, {2} of beer on the wall.\n"
                    , bottles[n], lastOne[n], bottles[n - 1]));

            lastOne = new Def()
                .Match(1).With("it")
                .Match<int>().With("one");

            bottles = new Def()
                .Match(0).With("no more bottles")
                .Match(1).With("1 bottle")
                .Match<int>().With(n => string.Format("{0} bottles", n));
        }

        [TestMethod]
        public void A_verse()
        {
            var Expected =
                "8 bottles of beer on the wall, 8 bottles of beer.\n" +
                "Take one down and pass it around, 7 bottles of beer on the wall.\n";
            Assert.AreEqual(Expected, verse[8]);
        }

        [TestMethod]
        public void Verse_1()
        {
            var Expected =
                "1 bottle of beer on the wall, 1 bottle of beer.\n" +
                "Take it down and pass it around, no more bottles of beer on the wall.\n";
            Assert.AreEqual(Expected, verse[1]);
        }

        [TestMethod]
        public void Verse_2()
        {
            var Expected =
                "2 bottles of beer on the wall, 2 bottles of beer.\n" +
                "Take one down and pass it around, 1 bottle of beer on the wall.\n";
            Assert.AreEqual(Expected, verse[2]);
        }

        [TestMethod]
        public void Verse_0()
        {
            var Expected =
                "No more bottles of beer on the wall, no more bottles of beer.\n" +
                "Go to the store and buy some more, 99 bottles of beer on the wall.\n";
            Assert.AreEqual(Expected, verse[0]);
        }
    }
}
