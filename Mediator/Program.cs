using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mediator mediator = new Mediator();
            

            Teacher murat = new Teacher(mediator);
            murat.Name = "Murat";
            mediator.Teacher = murat;

            Student melih = new Student(mediator);
            Student dilruba = new Student(mediator);
            Student fatima = new Student(mediator);
            melih.Name = "Melih";
            dilruba.Name = "Dilruba";
            fatima.Name = "Fatıma";

            mediator.Students = new List<Student> {melih,dilruba,fatima };

            murat.SendNewImageUrl("slide.img");
            murat.ReceiveQuestion("is it true",dilruba);

            Console.ReadLine();
        }
    }
    abstract class CourseMember
    {
        protected Mediator Mediator;
        public CourseMember(Mediator mediator)
        {
            Mediator = mediator;
        }
    }
    class Teacher : CourseMember
    {
        public string Name { get; set; }

        public Teacher(Mediator mediator) : base(mediator)
        {
        }

        internal void ReceiveQuestion(string question, Student student)
        {
            Console.WriteLine("Teacher recieved a question from : {0},{1}",student.Name,question);
        }
        public void SendNewImageUrl(string url)
        {
            Console.WriteLine("Teacher changed slide : " + url);
            Mediator.UpdateImage(url);
        }
        public void AnswerQuestion(string answer, Student student)
        {
            Console.WriteLine("Teacher answered question {0},{1}", student.Name, answer);
        }
    }
    class Student : CourseMember
    {
        public Student(Mediator mediator) : base(mediator)
        {
        }

        public string Name { get; set; }

        internal void ReceiveImage(string url)
        {
            Console.WriteLine(Name + " received image : " + url);
        }

        internal void ReceiveAnswer(string answer)
        {
            Console.WriteLine("Student received answer : " + answer);
        }
    }
    class Mediator
    {
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }

        public void UpdateImage(string url)
        {
            foreach(var student in Students)
            {
                student.ReceiveImage(url);
            }
        }
        public void SendQuestion(string question, Student student)
        {
            Teacher.ReceiveQuestion(question, student);
        }
        public void SendAnswer(string answer, Student student)
        {
            student.ReceiveAnswer(answer);
        }
    }
}
