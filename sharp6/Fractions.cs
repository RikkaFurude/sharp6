using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharp6
{

    //2
    interface IFractionOperations
    {
        double GetDecimalValue(); // Получить вещественное значение
        void SetChislitel(int numerator); // Установить числитель
        void SetZnamenatel(int denominator); // Установить знаменатель
    }

    class Fraction : ICloneable, IFractionOperations
    {
        private int chislitel;
        private int znaminatel;
        private double? cachedDecimalValue;

        // Конструктор для создания дроби с числителем и знаменателем
        public Fraction(int ch, int zn)
        {
            if (zn == 0)
                throw new ArgumentException("Знаменатель не может быть равен нулю.");

            // Убедимся, что знаменатель всегда положительный
            if (zn < 0)
            {
                ch = -ch;
                zn = -zn;
            }

            chislitel = ch;
            znaminatel = zn;
            cachedDecimalValue = null;
        }

        //Вывод дроби
        public override string ToString()
        {
            return $"{chislitel}/{znaminatel}";
        }
        // Получение вещественного значения
        public double GetDecimalValue()
        {
            if (cachedDecimalValue == null)
            {
                cachedDecimalValue = (double)chislitel / znaminatel;
            }
            return cachedDecimalValue.Value;
        }

        // Установка числителя
        public void SetChislitel(int ch)
        {
            chislitel = ch;
            cachedDecimalValue = null; // Сбрасываем кэш при изменении числителя
        }

        // Установка знаменателя
        public void SetZnamenatel(int zn)
        {
            if (zn == 0)
                throw new ArgumentException("Знаменатель не может быть равен нулю.");
            znaminatel = zn;
            cachedDecimalValue = null; // Сбрасываем кэш при изменении знаменателя
        }

        // Перегрузка операторов

        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            int ch = f1.chislitel * f2.znaminatel + f2.chislitel * f1.znaminatel;
            int zn = f1.znaminatel * f2.znaminatel;
            return new Fraction(ch, zn);
        }
        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            int ch = f1.chislitel * f2.znaminatel - f2.chislitel * f1.znaminatel;
            int zn = f1.znaminatel * f2.znaminatel;
            return new Fraction(ch, zn);
        }

        public static Fraction operator *(Fraction f1, Fraction f2)
        {
            int ch = f1.chislitel * f2.chislitel;
            int zn = f1.znaminatel * f2.znaminatel;
            return new Fraction(ch, zn);
        }

        public static Fraction operator /(Fraction f1, Fraction f2)
        {
            if (f2.chislitel == 0)
                throw new DivideByZeroException("Нельзя делить на ноль.");

            int ch = f1.chislitel * f2.znaminatel;
            int zn = f1.znaminatel * f2.chislitel;
            return new Fraction(ch, zn);
        }

        public static Fraction operator +(Fraction f, int number)
        {
            int ch = f.chislitel + number * f.znaminatel;
            return new Fraction(ch, f.znaminatel);
        }

        public static Fraction operator -(Fraction f, int number)
        {
            int ch = f.chislitel - number * f.znaminatel;
            return new Fraction(ch, f.znaminatel);
        }

        public static Fraction operator *(Fraction f, int number)
        {
            int ch = f.chislitel * number;
            return new Fraction(ch, f.znaminatel);
        }

        public static Fraction operator /(Fraction f, int number)
        {
            if (number == 0)
                throw new DivideByZeroException("Нельзя делить на ноль.");

            int zn = f.znaminatel * number;
            return new Fraction(f.chislitel, zn);
        }

        // Метод для выполнения цепочки операций: sum -> div -> minus
        public Fraction Sum(Fraction other)
        {
            return this + other;
        }

        public Fraction Div(Fraction other)
        {
            return this / other;
        }

        public Fraction Minus(int number)
        {
            return this - number;
        }
        //Переопределение метода сравнения
        public override bool Equals(object obj)
        {
            if (obj is Fraction other)
            {
                return this.chislitel == other.chislitel && this.znaminatel == other.znaminatel;
            }
            return false;
        }
        public object Clone()
        {
            return new Fraction(this.chislitel, this.znaminatel);
        }
    }

}
