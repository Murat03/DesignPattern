using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee murat = new Employee{Name = "Murat İpek"};
            Employee melih = new Employee{Name = "Melih İpek"};
            murat.AddSubordinate(melih);
            Employee dilruba = new Employee { Name = "Dilruba İpek" };
            murat.AddSubordinate(dilruba);
            Contructor contructor = new Contructor {Name = "I am not Employee" };
            dilruba.AddSubordinate(contructor);
            Employee fatima = new Employee { Name = "Fatıma İpek" };
            melih.AddSubordinate(fatima);


            Console.WriteLine(murat.Name);
            foreach(Employee manager in murat)
            {
                Console.WriteLine("  "+manager.Name);
                foreach(IPerson employee in manager)
                {
                    Console.WriteLine("    "+employee.Name);
                }
            }

            Console.ReadLine();
        }
    }
    interface IPerson
    {
        string Name { get; set; }
    }
    class Contructor : IPerson
    {
        public string Name { get; set; }
    }
    class Employee : IPerson,IEnumerable<IPerson>
    {
        List<IPerson> _subordinates = new List<IPerson>();
        public void AddSubordinate(IPerson person)
        {
            _subordinates.Add(person);
        }
        public void RemoveSubordinate(IPerson person)
        {
            _subordinates?.Remove(person);
        }
        public IPerson GetSubordinate(int index)
        {
            return _subordinates[index];
        }

        public string Name { get; set; }

        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var subordinate in _subordinates)
            {
                yield return subordinate;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
