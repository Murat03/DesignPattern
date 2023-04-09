using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Worker melih = new Worker {Name = "Melih",Salary = 10000 };
            Worker dilruba = new Worker { Name = "Dilruba", Salary = 10000 };
            Worker selamet = new Worker { Name = "Selamet", Salary = 10000 };
            Manager murat = new Manager { Name = "Murat",Salary =20000};
            Manager fatima = new Manager { Name = "Fatıma",Salary =20000};
        
            murat.Subordinates.Add(fatima);
            fatima.Subordinates.Add(melih);
            fatima.Subordinates.Add(dilruba);
            fatima.Subordinates.Add(selamet);

            OrganisationalStructure organisationalStructure = new OrganisationalStructure(murat);

            PayrollVisitor payrollVisitor = new PayrollVisitor();
            PayriseVisitor payriseVisitor = new PayriseVisitor();

            organisationalStructure.Accept(payrollVisitor);
            organisationalStructure.Accept(payriseVisitor);

            Console.ReadLine();
        }
    }
    class OrganisationalStructure
    {
        public EmployeeBase Employee;
        public OrganisationalStructure(EmployeeBase firstEmployee)
        {
            Employee = firstEmployee;
        }
        public void Accept(VisitorBase visitor)
        {
            Employee.Accept(visitor);
        }
    }
    abstract class EmployeeBase
    {
        public abstract void Accept(VisitorBase visitor);
        public string Name { get; set; }
        public decimal Salary { get; set; }
    }
    class Manager : EmployeeBase
    {
        public List<EmployeeBase> Subordinates { get; set; }

        public Manager()
        {
            Subordinates = new List<EmployeeBase>();
        }

        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);
            foreach(var employee in Subordinates)
            {
                employee.Accept(visitor);
            }
        }
    }
    class Worker : EmployeeBase
    {
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);
        }
    }
    abstract class VisitorBase
    {
        public abstract void Visit(Worker worker);
        public abstract void Visit(Manager manager);
    }
    class PayrollVisitor : VisitorBase
    {
        public override void Visit(Worker worker)
        {
            Console.WriteLine(worker.Name+" paid "+worker.Salary);
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine(manager.Name + " paid " + manager.Salary);
        }
    }
    class PayriseVisitor : VisitorBase
    {
        public override void Visit(Worker worker)
        {
            Console.WriteLine(worker.Name + " salary increased to " + worker.Salary * (decimal)1.1);
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine(manager.Name + " salary increased to " + manager.Salary * (decimal)1.2);
        }
    }
}
