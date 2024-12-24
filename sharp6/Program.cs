using System;
using System.Collections.Generic;
namespace sharp6
{

    class Program
    {


        static void Main(string[] args)
        {

            Console.Write("Введите задание:");
            int n = Convert.ToInt32(Console.ReadLine());
            switch (n)
            {
                case 1:
                    // Метод для вызова мяуканья всех животных
                    static void MakeThemMeow(IEnumerable<IMeowable> meowables)
                    {
                        foreach (var meowable in meowables)
                        {
                            meowable.Meow(3); 
                        }
                    }
                    //1

                    // Создаём котов и собак
                    Cat barsik = new Cat("Барсик");
                    Cat murzik = new Cat("Мурзик");
                    Dog sharik = new Dog("Шарик");
                    Dog rex = new Dog("Рекс");

                    // Оборачиваем котов и собак в декораторы
                    MeowCountDecorator decoratedBarsik = new MeowCountDecorator(barsik);
                    MeowCountDecorator decoratedMurzik = new MeowCountDecorator(murzik);
                    MeowCountDecorator decoratedSharik = new MeowCountDecorator(sharik);
                    MeowCountDecorator decoratedRex = new MeowCountDecorator(rex);

                    // Добавляем животных в список
                    var pets = new List<IMeowable> { decoratedBarsik, decoratedMurzik, decoratedSharik, decoratedRex };

                    // Вызываем метод MakeThemMeow
                    MakeThemMeow(pets);

                    decoratedMurzik.Meow(5);
                    decoratedBarsik.Meow();
                    decoratedRex.Meow();

                    // Выводим количество мяуканий (или гавканий) для каждого животного
                    Console.WriteLine($"{decoratedBarsik.GetName()} мяукал {decoratedBarsik.GetMeowCount()} раз(а).");
                    Console.WriteLine($"{decoratedMurzik.GetName()} мяукал {decoratedMurzik.GetMeowCount()} раз(а).");
                    Console.WriteLine($"{decoratedSharik.GetName()} гавкал {decoratedSharik.GetMeowCount()} раз(а).");
                    Console.WriteLine($"{decoratedRex.GetName()} гавкал {decoratedRex.GetMeowCount()} раз(а).");
                    Console.WriteLine();
                    break;




                case 2:

                    //1
                    Fraction f1 = new Fraction(1, 4);
                    Console.WriteLine($"f1 = {f1}");
                    Fraction f2 = new Fraction(2, 4);
                    Console.WriteLine($"f2 = {f2}");
                    Fraction f3 = new Fraction(5, 4);
                    Console.WriteLine($"f3 = {f3}");



                    // Сложение
                    Fraction sumResult = f1 + f2;
                    Console.WriteLine($"{f1} + {f2} = {sumResult}");

                    // Вычитание
                    Fraction subtractResult = f1 - f2;
                    Console.WriteLine($"{f1} - {f2} = {subtractResult}");

                    // Умножение
                    Fraction multiplyResult = f1 * f2;
                    Console.WriteLine($"{f1} * {f2} = {multiplyResult}");

                    // Деление
                    Fraction divideResult = f1 / f2;
                    Console.WriteLine($"{f1} / {f2} = {divideResult}");


                    Fraction chainedResult = f1.Sum(f2).Div(f3).Minus(5);
                    Console.WriteLine($"f1.sum(f2).div(f3).minus(5) = {chainedResult}");
                    //3
                    Fraction f4 = (Fraction)f1.Clone();
                    Console.WriteLine($"Клонированная дробь f4: {f4}");
                    //2
                    Console.WriteLine($"f1.Equals(f2): {f1.Equals(f2)}"); // True
                    Console.WriteLine($"f1.Equals(f4): {f1.Equals(f4)}"); // False
                                                                          //4
                    Console.WriteLine($"Вещественное значение {f1}: {f1.GetDecimalValue()}");
                    Console.WriteLine($"Вещественное значение {f2}: {f2.GetDecimalValue()}");
                    // Устанавливаем числитель и знаменатель
                    Console.WriteLine("Изменяем дробь f1");
                    f1.SetChislitel(2);
                    f1.SetZnamenatel(16);
                    Console.WriteLine($"Измененная дробь: {f1}");
                    Console.WriteLine($"Вещественное значение измененной дроби {f1}: {f1.GetDecimalValue()}");
                    break;
            }
        }
    }


}