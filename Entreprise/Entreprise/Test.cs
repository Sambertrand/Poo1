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
        private Directeur d;

        [SetUp()]
        public void Init()
        {
            d = new Directeur("VDD");
        }

        [Test()]
        public void TestGetSalary()
        {
            Assert.AreEqual(150000, d.GetSalary);
        }
    }

    [TestFixture()]
    public class TestManager
    {
        private Manager m;
        private Consultant c;

        [SetUp()]
        public void Init()
        {
            m = new Manager("Seb");
            c = new Consultant("Martin");
        }

        [Test()]
        public void TestWriteName()
        {
            Assert.AreEqual("Seb", m.WriteName());

        }
        /*[Test()]
        public void TestAddConsultant()
        {
            Assert.AreEqual(, m.AddConsultant(c));

        }
        */
    }
}   
