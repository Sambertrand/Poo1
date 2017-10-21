
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Employee
{

    private string name;

    public Employee(string name)
    {
        this.name = name;
    }

    public string WriteName()
    {
        return name;
    }

}