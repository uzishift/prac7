using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prac7
{
    /// <summary>
    /// Класс представляющий триаду (тройка чисел).
    /// </summary>
    public class Triad
    {
        /// <summary>
        /// Первое число триады.
        /// </summary>
        public int First { get; set; }

        /// <summary>
        /// Второе число триады.
        /// </summary>
        public int Second { get; set; }

        /// <summary>
        /// Третье число триады.
        /// </summary>
        public int Third { get; set; }

        /// <summary>
        /// Конструктор для инициализации триады.
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="third"></param>
        public Triad(int first, int second, int third)
        {
            First = first;
            Second = second;
            Third = third;
        }

        /// <summary>
        /// Метод для сложения всех элементов триады с числом.
        /// </summary>
        /// <param name="number">Число, которое будет добавлено ко всем элементам триады.</param>
        public void AddNumber(int number)
        {
            First += number;
            Second += number;
            Third += number;
        }

        /// <summary>
        /// Перегрузка оператора сложения триады с числом.
        /// </summary>
        /// <param name="triad"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public static Triad operator +(Triad triad, int number)
        {
            return new Triad(triad.First + number, triad.Second + number, triad.Third + number);
        }

        /// <summary>
        /// Метод для умножения всех элементов триады на число.
        /// </summary>
        /// <param name="number">Число, на которое будут умножены все элементы триады.</param>
        public void MultiplyByNumber(int number)
        {
            First *= number;
            Second *= number;
            Third *= number;
        }

        /// <summary>
        /// Метод для сложения двух триад.
        /// </summary>
        /// <param name="other">Триада, которую нужно сложить с текущей.</param>
        public void AddTriad(Triad other)
        {
            if (other != null)
            {
                First += other.First;
                Second += other.Second;
                Third += other.Third;
            }
        }

        /// <summary>
        /// Перегрузка оператора сложения двух триад.
        /// </summary>
        /// <param name="triad1"></param>
        /// <param name="triad2"></param>
        /// <returns></returns>
        public static Triad operator +(Triad triad1, Triad triad2)
        {
            return new Triad(triad1.First + triad2.First, triad1.Second + triad2.Second, triad1.Third + triad2.Third);
        }

        /// <summary>
        /// Метод для проверки равенства двух триад.
        /// </summary>
        /// <param name="other"></param>
        /// <returns>True, если триады равны; иначе False.</returns>
        public bool Equals(Triad other)
        {
            if (other == null)
                return false;

            return First == other.First && Second == other.Second && Third == other.Third;
        }

        /// <summary>
        /// Переопределение метода ToString для удобного отображения триады.
        /// </summary>
        /// <returns>Строковое представление триады.</returns>
        public override string ToString()
        {
            return $"({First}, {Second}, {Third})";
        }
    }
}
