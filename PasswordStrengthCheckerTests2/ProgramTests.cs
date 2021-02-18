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
    }
}