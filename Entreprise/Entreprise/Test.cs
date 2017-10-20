using System;
using NUnit.Framework;

namespace Entreprise
{
    [TestFixture()]
    public class TestEmployee
    {
        [Test()]
        public void TestwriteName()
        {
            Employee Martin = new Employee("Martin");
            Assert.AreEqual("Martin", Martin.writeName());
        }
    }
    [TestFixture()]
    public class TestClient
    {
        [Test()]
        public void TestWriteName()
        {
            Client Sam = new Client("Sam");
            Assert.AreEqual("Sam", Sam.writeName());
        }
        /*[Test()]
        public void TestAddMission()
        {
            Client Sam = new Client("Sam");
            Consultant Martin = new Consultant( );
            Manager Seb = new Manager("Seb")
            Assert.AreEqual("Sam", Sam.AddMission(2017, new Mission(Sam, )));
        }
        */
}   
}
