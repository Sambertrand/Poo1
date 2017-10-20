using System;
using NUnit.framework;


[TestFixture()]
public class TestEmployee
{
    [Test()]
    public void TestWriteName()
    {
        Client Sam = new Client("Sam");
        Assert.AreEqual("Sam", Sam.writeName());
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