
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Employee
{

    private string firstname;
    private string lastname;

    public Employee(string firstname, string lastname)
    {
        this.firstname = firstname;
        this.lastname = lastname;
    }

    public override string ToString()
    {
        return firstname + " "+ lastname;
    }

}
