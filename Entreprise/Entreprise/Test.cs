using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace Entreprise
{
    /// <summary>
    /// Test classes that wil lthat the simple methods in every other class
    /// </summary>
    [TestFixture()]
    public class TestEmployee
    {
        private Employee e;
        private Employee m;

        [SetUp()]
        public void Init()
        {
            e = new Employee("Martin", "Degeldt");
            m = new Employee("", "");
        }

        [Test()]
        public void TestwriteName()
        {
            Assert.AreEqual("Martin Degeldt", e.ToString());
            Assert.AreEqual(" ", m.ToString());
        }
    }
    [TestFixture()]
    public class TestDirecteur
    {
        private Directeur d;

        [SetUp()]
        public void Init()
        {
            d = new Directeur("xav", "VDD");
        }

        [Test()]
        public void TestGetDirectorSalary()
        {
            Assert.AreEqual(150000, d.GetSalary);
        }
    }

    [TestFixture()]
    public class TestManager
    {
        private Manager m;
        private Client s;
        private Consultant c;
        List<Consultant> l = new List<Consultant>();

        [SetUp()]
        public void Init()
        {
            m = new Manager("Seb", "CBF", "MA01");
            s = new Client("Sam", "CL00");
            c = new Consultant("Martin", "D", m, 2017, "CO1701", s);
            l.Add(c);
        }
        [Test()]
        public void TestGetSubs()
        {
            Assert.AreEqual(l, m.GetSubs);

        }

        /*[Test()]
        public void TestGetManagerYearSalary()
        {
            Assert.AreEqual(60500, m.GetYearSalary(2017));            
            Assert.AreEqual(60000, m.GetYearSalary(2016));
        }
        //à demander au proffeseur
        */

    }
    [TestFixture()]
    public class TestConsultant
    {
        private Consultant c;
        private Manager m;
        private Client s;
        private Mission p;
        private DateTime d;
        private DateTime e;

        [SetUp()]
        public void Init()
        {
            d = new DateTime(2017, 05, 17);
            e = new DateTime(2017, 12, 31);
            m = new Manager("Seb", "CBF", "MA01");
            s = new Client("Sam", "CL00");
            c = new Consultant("Martin", "D", m, 2017, "CO1701", s);
            p = new Mission(s, c, d, e);
        }

        [Test()]
        public void TestConsultantGetYearSalary()
        {
            Assert.AreEqual(33325, c.GetYearSalary(2017));
            Assert.AreEqual(0, c.GetYearSalary(2016));
        }
    }
}
