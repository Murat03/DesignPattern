﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.CreditCalculatorBase = new Before2010CreditCalculator();
            customerManager.SaveCredit();
            Console.ReadLine();
        }
    }
    abstract class CreditCalculatorBase
    {
        public abstract void Calculate();
    }
    class Before2010CreditCalculator : CreditCalculatorBase
    {
        public override void Calculate()
        {
            Console.WriteLine("Credit calculated using before 2010");
        }
    }
    class After2010CreditCalculator : CreditCalculatorBase
    {
        public override void Calculate()
        {
            Console.WriteLine("Credit calculated using after 2010");
        }
    }
    class CustomerManager
    {
        public CreditCalculatorBase CreditCalculatorBase { get; set; }
        public void SaveCredit()
        {
            Console.WriteLine("Customer manager business");
            CreditCalculatorBase.Calculate();
        }
    }
}
