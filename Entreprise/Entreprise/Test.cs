using System;
using NUnit.Framework;

namespace Entreprise
{
    [TestFixture()]
    public class TestEmployee
    {
        private Employee e;
        private Employee m;

        [SetUp()]
        public void Init()
        {
            e = new Employee("Martin Degeldt");
            m = new Employee("");
        }

        [Test()]
        public void TestwriteName()
        {
            Assert.AreEqual("Martin Degeldt", e.WriteName());
            Assert.AreEqual("", m.WriteName());
        }
    }

    [TestFixture()]
    public class TestDirecteur
    {
        [Test()]
        public void TestGetSalary()
        {
            Directeur VDD = new Directeur("VDD");
            Assert.AreEqual("150000", VDD.GetSalary());
        }
    }

    /*[TestFixture()]
    public class TestClient
    {
        [Test()]
        public void TestWriteName()
        {
            Client Sam = new Client("Sam");
            Assert.AreEqual("Sam", Sam.writeName());
        }
        [Test()]
        public void TestAddMission()
        {
            Client Sam = new Client("Sam");
            Consultant Martin = new Consultant( );
            Manager Seb = new Manager("Seb")
            Assert.AreEqual("Sam", Sam.AddMission(2017, new Mission(Sam, )));
        }
        */
}   
