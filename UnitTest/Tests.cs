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
            ProtocolResponse result = loginProtocol.GenerateResponse("n");
            string expected = "Podaj login i haslo rozdzielajac je dwukropkiem\n", resultStr = result.message;
            Assert.AreEqual(expected, resultStr);
        }

        [TestMethod]
        public void TestGenerateResponse2()
        {
            LoginProtocol loginProtocol = new LoginProtocol();
            ProtocolResponse result = loginProtocol.GenerateResponse("n");
            result = loginProtocol.GenerateResponse(" : ");
            string expected = "Nieprawidlowe dane rejestracyjne.\n", resultStr = result.message;
            Assert.AreEqual(expected, resultStr);
        }
    }
}
