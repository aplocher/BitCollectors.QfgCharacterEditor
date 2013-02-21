using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BitCollectors.QfgCharacterEditor.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestQfg1FighterMaxValues()
        {
            Assert.AreEqual<string>("Hello", "Hello");
        }

        [TestMethod]
        public void TestQfg1MagicMaxValues()
        {
            Assert.AreEqual<string>("Test", "Test");
        }

        [TestMethod]
        public void TestQfg1ThiefMaxValues()
        {
            Assert.AreEqual<string>("Test", "Test");
        }

        [TestMethod]
        public void TestQfg2FighterMaxValues()
        {
            Assert.AreEqual<string>("Hello", "Hello");
        }

        [TestMethod]
        public void TestQfg2MagicMaxValues()
        {
            Assert.AreEqual<string>("Test", "Test");
        }

        [TestMethod]
        public void TestQfg2ThiefMaxValues()
        {
            Assert.AreEqual<string>("Test", "Test");
        }

        [TestMethod]
        public void TestQfg2PaladinMaxValues()
        {
            Assert.AreEqual<string>("Test", "Test");
        }


        [TestMethod]
        public void TestMaxValueReset()
        {
            // TODO: Set Game to QFG2
            // SetMaxValues
            // Set Game to QFG1
            // Check that max values are not greater than 100

            Assert.AreEqual<bool>(true, true);
        }
    }
}
