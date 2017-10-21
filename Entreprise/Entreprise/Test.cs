using System;
using NUnit.Framework;
using System.Collections.Generic;

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
        List<Consultant> l = new List<Consultant>();

        [SetUp()]
        public void Init()
        {
            m = new Manager("Seb");
            c = new Consultant("Martin", m, 2017);            
            l.Add(c);
        }

        [Test()]
        public void TestWriteName()
        {
            Assert.AreEqual("Seb", m.WriteName());

        }
        [Test()]
        public void TestGetSubs()
        {
            Assert.AreEqual(l , m.GetSubs);

        }
        [Test()]
        public void TestGetSalary()
        {
            Assert.AreEqual(60500, m.GetYearSalary(2017));
            Assert.AreEqual(60000, m.GetYearSalary(2016));

        }

    }
}   
