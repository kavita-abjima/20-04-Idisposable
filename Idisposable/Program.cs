using Idisposable;
using System;

namespace Idisposable
{
    
    public class File
    {
        public string Name
        {
            get;
            set;
        }

        public File(string name) { this.Name = name; }
    }

    public class FileHandler : IDisposable
    {
        // unmanaged object
        private File fileObject = null;

        // managed object
        private static int TotalFiles = 0;

        private bool disposedValue;

        // Constructor
        public FileHandler(string fileName)
        {
            if (fileObject == null)
            {
                TotalFiles++;
                fileObject = new File(fileName);
            }
        }
       
        // resource cleaning happens here
        protected virtual void Dispose(bool disposing)
        {
            // check if already disposed
            if (!disposedValue)
            {
                if (disposing)
                {
                    // free managed objects here
                    TotalFiles = 0;
                }

                // free unmanaged objects here
                Console.WriteLine("The {0} has been disposed",
                                  fileObject.Name);
                fileObject = null;

                // set the bool value to true
                disposedValue = true;
            }
        }

        
        public void Dispose()
        {
            
            Dispose(disposing: true);

            
            GC.SuppressFinalize(this);
        }        
        public void GetFileDetails()
        {
            Console.WriteLine(
                "{0} file has been successfully created.",
                fileObject.Name);
        }      
        ~FileHandler() { Dispose(disposing: false); }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
                "Explicit calling of dispose method - ");
            Console.WriteLine("");

            FileHandler filehandler = new FileHandler("GFG-1");
            filehandler.GetFileDetails();
            // manual calling
            filehandler.Dispose();

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine(
                "Implicit calling using 'Using' keyword - ");
            Console.WriteLine("");
            using (FileHandler fileHandler2
                  = new FileHandler("GFG-2"))
            {
                fileHandler2.GetFileDetails();
                
            }

            //IEnumarator
            // Declare a list variable 
            List<Employee> emp = new List<Employee>()
            {
          
        // Create 5 Employee details
             new Employee{ id = 201, name = "Druva",
                      salary = 12000, department = "HR" },
             new Employee{ id = 202, name = "Deepu",
                      salary = 15000, department = "Development" },
             new Employee{ id = 203, name = "Manoja",
                      salary = 13000, department = "HR" },
            new Employee{ id = 204, name = "Sathwik",
                      salary = 12000, department = "Designing" },
            new Employee{ id = 205, name = "Suraj",
                      salary = 15000, department = "Development" }
            };

            IEnumerable<Employee> result = emp.Where(x => x.name[0] == 'D');

            // Display employee details
            Console.WriteLine("ID  Name  Salary  Department");
            Console.WriteLine("++++++++++++++++++++++++++++");
            foreach (Employee e in result)
            {

                // Call the to string method
                Console.WriteLine(e.ToString());
            }
        }
    }
}
    

