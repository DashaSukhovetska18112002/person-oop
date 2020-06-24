using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace student_v1
{

    enum Education
    {
        Specialist,
        Bachelor,  
        SecondEducation
    }
    class Person
    {
        private string firstName;
        private string lastName;
        private System.DateTime date;
        internal static Person person;

        public Person()
        {
            firstName = "";
            lastName = "";
            date = System.DateTime.Now;

        }

        public Person (string fname, string lname, System.DateTime date)
        {
            firstName = fname;
            lastName = lname;
            this.date = date;

        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }

        }

        public System.DateTime Date
        {
            get { return date; }
            set { date = value;}
        }

        public int ChangeYear
        {
            get { return date.Year; }
            set { date = new DateTime(value, date.Month, date.Day); }
        }

        public override string ToString()
        {
            return $"First Name {firstName} \nLast name {LastName}\nDate {date}";
        }

        public string ToShortString()
        {
            return "First name:" + firstName + "\nLast name" +lastName;
        }

    }

    class Exam
    {
       public string name;
       public int mark;
       public System.DateTime date;
        internal static Exam exam;

        public string Name
       {
            get { return name; }
            set { name = value;}
       }

        public int Mark
        {
            get { return mark;}
            set { mark = value;}
        }

        public System.DateTime Date
        {
            get { return date;}
            set { date = value;}
        }

        public Exam()
        {
            name = "";
            mark = 0;
            Date = new DateTime ();
        }


        public Exam(string name, int mark, System.DateTime date)
        {
            this.name = name;
            this.mark = mark;
            this.date = date;
        }

        public override string ToString()
        {
            return $"Name = {name}\n Mark = {mark}\n Date = {date}";
        }

    }

    class Student
    {
        private Person person;
        private Education education;
        private int groupNum;
        private Exam exam;
        private List<int> marks = new List<int>();
        private List<Exam> ex = new List<Exam>();

        public Student()
        {
            person = new Person();
            exam = new Exam();
            groupNum = 0;
            education =  Education.Specialist;
            marks.Add(exam.Mark);
        }

        public Student (Person person, Education education, int groupNum, Exam exam)
        {
            this.person = person;
            this.exam = exam;
            this.groupNum = groupNum;
            this.education = education;
            marks.Add(exam.Mark);
        }


        public Person Person
        {
            get { return person; }
            set { person = value; }
        }

        public Education Education
        {
            get { return education; }
            set { education = value; }
        }

        public Exam Exam
        {
            get { return exam; }
            set { exam = value; }
        }

        public int GroupNum
        {
            get { return groupNum;}
            set { groupNum = value; }
        }
        
        public double MidleMark
        {
            get
            {
                int sum = 0, count = 0;
                foreach (int i in marks)
                {
                    sum += i;
                    count++;
                }
                return sum / count;
            }
        }

        


        public void AddExams(params Exam[] exam)

        {
            ex.AddRange(exam);
            foreach(Exam _ex in ex)
            {
                marks.Add(_ex.mark);
            }
        }

       /* public override string ToString()
        {
            return $"{ person.FirstName} { person.LastName} {groupNum} {this.ShowEx} {education} { this.MidleMark}";
        }*/
        public void  toString()
        {
            Console.WriteLine("{0} {1} {2} {3} {4} {5} ", person.FirstName, person.LastName, groupNum, education, this.MidleMark);
            for (int i = 0; i< ex.Count; i++)
            {
                Console.WriteLine(ex[i].name + "" );
            } 
            Console.WriteLine();
        }
         

        public virtual string ToShortString()
        {
            return $"{person.FirstName} {person.LastName} {groupNum}  {education} {this.MidleMark}";
        }

        
    }

    
    class Progam
    {
        

        static void Main (string [] args)
        {
            Person person = new Person("Petro", "Koval", new DateTime(2020, 05, 07, 6, 2, 45));
            Exam exam = new Exam("Math", 3, new DateTime(2020, 05, 07, 6, 2, 45));
            Student student = new Student(person, Education.SecondEducation, 45, exam);
            student.AddExams(new Exam("Ukr", 45, new DateTime()));
            student.AddExams(new Exam("Static", 6, new DateTime()));
            student.AddExams(new Exam("Eng", 9, new DateTime()));
            student.AddExams(new Exam("Liter", 7, new DateTime()));
            student.ToString();
            //student.MidleMark();

            Console.WriteLine(student.ToShortString());

            Console.ReadKey();
        }
    }


}
