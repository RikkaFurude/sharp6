using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharp6
{
    //1

    interface IMeowable
    {
        void Meow(int n = 1);
        string GetName(); // Чтобы получить имя животного
    }

    class Cat : IMeowable
    {
        private string Name;

        public Cat(string name)
        {
            Name = name;
        }

        public string GetName()
        {
            return Name;
        }

        public override string ToString()
        {
            return $"кот: {Name}";
        }

        public void Meow(int n = 1)
        {
            if (n == 1)
            {
                Console.WriteLine($"{Name}: мяу!");
            }
            else
            {
                Console.Write(Name + ": ");
                for (int i = 0; i < n; i++)
                {
                    Console.Write("мяу");
                    if (i + 1 != n) Console.Write('-');
                }
                Console.WriteLine('!');
            }
        }
    }

    class Dog : IMeowable
    {
        private string Name;

        public Dog(string name)
        {
            Name = name;
        }

        public string GetName()
        {
            return Name;
        }

        public override string ToString()
        {
            return $"собака: {Name}";
        }

        public void Meow(int n = 1)
        {
            if (n == 1)
            {
                Console.WriteLine($"{Name}: гав!");
            }
            else
            {
                Console.Write(Name + ": ");
                for (int i = 0; i < n; i++)
                {
                    Console.Write("гав");
                    if (i + 1 != n) Console.Write('-');
                }
                Console.WriteLine('!');
            }
        }
    }

    // Декоратор, отслеживающий количество мяуканий 
    class MeowCountDecorator : IMeowable
    {
        private IMeowable _meowable;
        private int _meowCount;

        public MeowCountDecorator(IMeowable meowable)
        {
            _meowable = meowable;
            _meowCount = 0;
        }

        public void Meow(int n = 1)
        {
            _meowable.Meow(n);
            _meowCount += n; // Увеличиваем количество мяуканий
        }

        public int GetMeowCount()
        {
            return _meowCount;
        }

        public string GetName()
        {
            return _meowable.GetName();
        }
    }
}
