using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prac7
{
    /// <summary>
    /// Класс, представляющий трехмерный вектор, производный от класса Triad.
    /// </summary>
    public class Vector3D : Triad
    {
        /// <summary>
        /// Конструктор для инициализации вектора.
        /// </summary>
        /// <param name="x">Координата X.</param>
        /// <param name="y">Координата Y.</param>
        /// <param name="z">Координата Z.</param>
        public Vector3D(int x, int y, int z) : base(x, y, z) { }

        /// <summary>
        /// Перегрузка оператора сложения векторов.
        /// </summary>
        /// <param name="vector1">Первый вектор.</param>
        /// <param name="vector2">Второй вектор.</param>
        /// <returns>Результат сложения двух векторов.</returns>
        public static Vector3D operator +(Vector3D vector1, Vector3D vector2)
        {
            return new Vector3D(vector1.First + vector2.First, vector1.Second + vector2.Second, vector1.Third + vector2.Third);
        }

        /// <summary>
        /// Метод для вычисления скалярного произведения двух векторов.
        /// </summary>
        /// <param name="other">Другой вектор.</param>
        /// <returns>Скалярное произведение или 0, если другой вектор равен null.</returns>
        public int DotProduct(Vector3D other)
        {
            if (other == null)
                return 0;

            return (First * other.First) + (Second * other.Second) + (Third * other.Third);
        }

        /// <summary>
        /// Переопределение метода ToString для удобного отображения вектора.
        /// </summary>
        /// <returns>Строковое представление вектора.</returns>
        public override string ToString()
        {
            return $"Vector3D({First}, {Second}, {Third})";
        }
    }
}