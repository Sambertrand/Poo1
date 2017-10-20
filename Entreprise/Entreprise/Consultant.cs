
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entreprise
{
    /**
     * 
     */
    public class Consultant : Employee {

        /**
         * 
         */
        public Consultant(string name) : base(name) {
        }

        /**
         * 
         */
        private Manager subOf;

        /**
         * 
         */
        private Double baseSalary;

        /**
         * 
         */
        private Dictionary<int,double> salaries;

        /**
         * 
         */
        public List<Mission> Missions;

        /**
         * 
         */
        public bool InMission;




        /**
         * @return
         */
        public float UpdateSalaries() {
            // TODO implement here
            return 44;
        }

        /**
         * @param year 
         * @return
         */
        public double GetYearSalary(int year) {
            // TODO implement here
            return 10;
        }

        /**
         * @return
         */
        public Mission AddMission() {
            // TODO implement here
            return new Mission();
        }

    }
}
