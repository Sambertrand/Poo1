using System;
using NUnit.framework;

namespace Model
{
    [TestFixture()]
    public class TestClient
    {
        [testc()]
        public void TestWriteName()
        {
            Assert.AreEqual("", Client.writeName(""));
        }
    }
}