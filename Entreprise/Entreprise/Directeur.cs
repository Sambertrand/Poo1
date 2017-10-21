
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Directeur : Employee
{

    private double baseSalary = 150000;

    public Directeur(string name) : base(name)
    {
    }

    public double GetSalary
    {
        get { return baseSalary; }
    }

}