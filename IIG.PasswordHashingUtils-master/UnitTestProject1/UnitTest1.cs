using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IIG.PasswordHashingUtils;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsNotNull(PasswordHasher.GetHash("test"));
        }

        [TestMethod]
        public void CompareHashSamePassword()
        {
            const string firstPass = "test";
            const string secondPass = "test";

            Assert.AreEqual(PasswordHasher.GetHash(firstPass), PasswordHasher.GetHash(secondPass));
        }

        [TestMethod]
        public void CreateHashWithSalt()
        {
            const string firstPass = "test";
            const string salt = "salt";
            Assert.IsNotNull(PasswordHasher.GetHash(firstPass, salt, 64243));
        }

        [TestMethod]
        public void GetHashForEmptyPassword()
        {
            const string pass = "";
            const string salt = "salt";
            Assert.IsNotNull(PasswordHasher.GetHash(pass, salt, 64243));
        }

        [TestMethod]
        public void GetHashForEmptyPasswordEmptySalt()
        {
            const string pass = "";
            const string salt = "";
            Assert.IsNotNull(PasswordHasher.GetHash(pass, salt, 64243));
        }

        [TestMethod]
        public void GetHashForSpecialCharacter()
        {
            const string pass = "異體字";
            Assert.IsNotNull(PasswordHasher.GetHash(pass, "", 64243));
        }

        [TestMethod]
        public void CompareHashSpecialCharacter()
        {
            const string pass = "異體字";
            const string secondPass = "異體字";
             Assert.AreEqual(PasswordHasher.GetHash(pass), PasswordHasher.GetHash(secondPass));
        }

        [TestMethod]
        public void HashSpecialCharacter()
        {
            const string pass = "異體字";
            const string salt = "異體字";
            Assert.IsNotNull(PasswordHasher.GetHash(pass, salt, 64243));
        }

    }

  
}
