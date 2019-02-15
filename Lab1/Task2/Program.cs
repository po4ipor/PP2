using System;

namespace Task2
{
        class Program
        {
            static void Main(string[] args)
            {
                Student Zaur = new Student("Zaur", "18BD110400");//добавление нового студента
                Zaur.year = 1;// ввод данных в переменную year
                Zaur.Info();
            }
        }
        class Student // конструктор
        {
            public string name;
            public string id;
            public int year;
            public Student(string n, string i)
            {
                name = n;
                id = i;
            }

            public void Info()// вывод данных о студенте
            {
                Console.WriteLine($"{name} || {id} || {year}");
                Console.ReadKey();
            }
        }
    
}
