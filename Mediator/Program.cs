using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator // arabulucu, farklı sistemleri birbirleri ile görüştürmesi , havayolu kule iletişimi gibi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mediator mediator = new Mediator();
            Teacher teacher = new Teacher(mediator);
            teacher.Name = "Test";

            mediator.Teacher = teacher;

            Student student = new Student(mediator);
            student.Name = "Test2";


            Student student1 = new Student(mediator);
            student1.Name = "Test3";

            mediator.Students = new List<Student> { student , student1 };

            teacher.SendNewImageUrl("slide.jpg", mediator   );
            teacher.RecieveQuestion("is it true?", student1);

            Console.ReadLine();

        }
    }

    abstract class CourseMember
    {

        protected Mediator _mediator;

        protected CourseMember(Mediator mediator)
        {
            _mediator = mediator;
        }
    }

    class Teacher : CourseMember
    {
        public Teacher(Mediator mediator) : base(mediator)
        {
        }

        public string Name { get; set; }


        public void RecieveQuestion(string question, Student student)
        {
            Console.WriteLine("teacher recieved question from {0},{1}", student.Name, question);
        }
        public void SendNewImageUrl(string url, Mediator mediator)
        {
            Console.WriteLine("Teacher changed slide : {0}", url);
            mediator.UpdateImage(url);
        }

        public void AnswerQuestion(string answer, Student student)
        {
            Console.WriteLine("Teacher answered question {0},{1}", student.Name,answer);
        }
    }

    class Student : CourseMember
    {
        public Student(Mediator mediator) : base(mediator)
        {
        }

        public string Name { get; set; }
        public void RecieveImage(string url)
        {
            Console.WriteLine("Student receieved image : {0}" , url);
        }

        public void RecieveAnswer(string answer)
        {
            Console.WriteLine("Student recieved answer : {0}",answer);
        }
    }

    class Mediator
    {
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set;}

        public void UpdateImage(string url)
        {
            foreach (var student in Students)
            {
                student.RecieveImage(url);
            }
        }

        public void SendQuestion(string question, Student student)
        {
            Teacher.RecieveQuestion(question, student);
        }

        public void SendAnswer(string answer, Student student)
        {
            student.RecieveAnswer(answer);
        }
    }
}
