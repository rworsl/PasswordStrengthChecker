using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordStrengthChecker;
using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordStrengthChecker.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void NumberOfCharactersTest()
        {
            var Program = new Program();
            var test1 = Program.NumberOfCharacters("1234");
            var test2 = Program.NumberOfCharacters("abcde");
            Assert.AreEqual(16, test1);
            Assert.AreEqual(20, test2);
        }

        [TestMethod()]
        public void CountUppercaseLettersTest()
        {
            var Program = new Program();
            var test1 = Program.CountUppercaseLetters("123lowerUPPER");
            var test2 = Program.CountUppercaseLetters("aBcDe");
            Assert.AreEqual(16, test1);
            Assert.AreEqual(6, test2);
        }

        [TestMethod()]
        public void CountLowercaseLettersTest()
        {
            var Program = new Program();
            var test1 = Program.CountLowercaseLetters("123lowUP");
            var test2 = Program.CountLowercaseLetters("aBcDe");
            Assert.AreEqual(10, test1);
            Assert.AreEqual(4, test2);
        }

        [TestMethod()]
        public void CountNumbersTest()
        {
            var Program = new Program();
            var test1 = Program.CountNumbers("123lowUP");
            var test2 = Program.CountNumbers("aBcDe");
            var test3 = Program.CountNumbers("1aBcDe1");
            Assert.AreEqual(12, test1);
            Assert.AreEqual(0, test2);
            Assert.AreEqual(8, test3);
        }

        [TestMethod()]
        public void CountSymbolsTest()
        {
            var Program = new Program();
            var test1 = Program.CountSymbols("@12!£$3l!owUP");
            var test2 = Program.CountSymbols("aBcDe");
            var test3 = Program.CountSymbols("1a@@@B@@c####De;£$!1");
            Assert.AreEqual(30, test1);
            Assert.AreEqual(0, test2);
            Assert.AreEqual(78, test3);
        }

        [TestMethod()]
        public void CountMiddleSymbolsTest()
        {
            var Program = new Program();
            var test1 = Program.CountMiddleSymbols("@1@dgsg!£34$%%fsd@1@");
            var test2 = Program.CountMiddleSymbols("aBcDe");
            var test3 = Program.CountMiddleSymbols("!!");
            Assert.AreEqual(22, test1);
            Assert.AreEqual(0, test2);
            Assert.AreEqual(0, test3);
        }

        [TestMethod()]
        public void MeetsAllRequirementsTest()
        {
            var Program = new Program();
            var test1 = Program.MeetsAllRequirements("@1@dgSg!£34$%%fsd@1@");
            var test2 = Program.MeetsAllRequirements("aBcDe");
            var test3 = Program.MeetsAllRequirements("!!");
            Assert.AreEqual(10, test1);
            Assert.AreEqual(4, test2);
            Assert.AreEqual(2, test3);
        }

        [TestMethod()]
        public void onlyLettersTest()
        {
            var Program = new Program();
            var test1 = Program.onlyLetters("@1@dgsg!£34$%%fsd@1@");
            var test2 = Program.onlyLetters("aBcDe");
            var test3 = Program.onlyLetters("!!");
            Assert.AreEqual(0, test1);
            Assert.AreEqual(5, test2);
            Assert.AreEqual(0, test3);
        }
    }
}