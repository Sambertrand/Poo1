
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Director superclass and subclass of employee
/// </summary>
public class Directeur : Employee
{

    private double baseSalary = 150000;

    public Directeur(string firstname, string lastname) : base(firstname, lastname)
    {
    }

    public double GetSalary
    {
        get { return baseSalary; }
    }

}
