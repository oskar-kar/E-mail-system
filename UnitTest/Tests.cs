using Microsoft.VisualStudio.TestTools.UnitTesting;
using KlasaBD;
using KlasaSerwera;

namespace UnitTest
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void TestAddUser() 
        {
            DB db = new DB();
            bool result = db.AddUser(" ", " "), expected = false;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestAuthenticateUser() 
        {
            DB db = new DB();
            bool result = db.AuthenticateUser("", ""), expected = false;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestGenerateResponse1()
        {
            LoginProtocol loginProtocol = new LoginProtocol();
            string result = loginProtocol.GenerateResponse("n"), expected = "Podaj login i haslo rozdzielajac je dwukropkiem\n";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestGenerateResponse2()
        {
            LoginProtocol loginProtocol = new LoginProtocol();
            string result = loginProtocol.GenerateResponse("n"), expected = "nieprawidlowe dane rejestracyjne\n";
            result = loginProtocol.GenerateResponse(" : ");
            Assert.AreEqual(expected, result);
        }
    }
}
