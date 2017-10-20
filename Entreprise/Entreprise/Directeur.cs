
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entreprise
{
    /**
 * 
 */
    public class Directeur : Employee
    {

        /**
         * 
         */
        public Directeur(string name) : base(name)
        {
        }

        /**
         * 
         */
        private double baseSalary;

        /**
         * @return
         */
        public double GetSalary()
        {
            // TODO implement here
            return 1000;
        }

    }
}
