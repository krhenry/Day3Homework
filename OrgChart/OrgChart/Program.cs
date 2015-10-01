using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//properties up to 
//constructors follow
//methods after that
namespace OrgChart
{
    class Employee
    {
        public string Name { get; set; }
        private Employee _supervisor;
        public Employee Supervisor
        {
            get //public employee GetSupervisor()
            {
                return _supervisor;
            }
            set //public void SetSupervisor(Employee value)
            {
                _supervisor?.Minions?.Remove(this);

                _supervisor = value;
                value.Minions.Add(this);
            }
        }
        public IList<Employee> Minions { get; set; }

        public int ReportCount
        {
            get
            {
                return Minions.Count;
            }
        }

        public Employee(string name)
        {
            this.Name = name;
            Minions = new List<Employee>(); 

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var sam = new Employee("sam");
            var bill = new Employee("bill");
            var fred = new Employee("fred");
            var jane = new Employee("jane");
            var alice = new Employee("alice");

            var employees = new List<Employee>
            {
                bill,
                sam,
                jane,
                fred,
                alice
            };

            sam.Supervisor = bill;
            fred.Supervisor = bill;
            jane.Supervisor = bill;

            alice.Supervisor = fred;

            foreach (var emp in employees)
            {
                Console.WriteLine("{0} has {1} minions. \n{0} reports to {2}", emp.Name, emp.ReportCount, emp.Supervisor == null ? "nobody" : emp.Supervisor.Name);
            }

            

            Console.WriteLine("{0} has {1}", bill.Name, bill.ReportCount);
            Console.ReadLine();



        }
    }
}
