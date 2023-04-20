using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idisposable
{
    public class Employee
    {
        // department, and salary
        public  int id;
        public int salary;
        public string name;
        public string department;

        // Get the to string method that returns 
        // id, name, department, and salary
        public override string ToString()
        {
            return id + " " + name + " " +
               salary + " " + department;
        }


    }    
}

