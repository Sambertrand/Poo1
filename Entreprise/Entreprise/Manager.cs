
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entreprise
{/**
 * 
 */
    public class Manager : Employee {

        /**
         * 
         */
        public Manager() {
        }

        /**
         * 
         */
        private List<Employee> bossOf;

        /**
         * 
         */
        private double baseSalary;

        /**
         * 
         */
        private Dictionary<int, double> salaries;



        /**
         * @return
         */
        public double UpdateSalary() {
            // TODO implement here
            return 9001;
        }

        /**
         * @return
         */
        public List<Consultant> GetSubs() {
            // TODO implement here
            return new List<Consultant>();
        }

        /**
         * @return
         */
        public string GenerateReport() {
            // TODO implement here
            return "";
        }

        /**
         * @param year 
         * @return
         */
        public double GetYearSalary(int year) {
            // TODO implement here
            return 10;
        }

    }
}