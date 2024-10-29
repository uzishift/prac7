using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace prac7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Объявление Триады 1.
        /// </summary>
        private Triad _triad1;
        /// <summary>
        /// Объявление Триады 2.
        /// </summary>
        private Triad _triad2;
        /// <summary>
        /// Объявление Вектора 1.
        /// </summary>
        private Vector3D _vector1;
        /// <summary>
        /// Объявление Вектора 2.
        /// </summary>
        private Vector3D _vector2;

        /// <summary>
        /// Конструктор MainWindow.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            _triad1 = new Triad(0, 0, 0);
            _triad2 = new Triad(0, 0, 0);
            _vector1 = new Vector3D(0, 0, 0);
            _vector2 = new Vector3D(0, 0, 0);
            InitializeTextBoxes();
        }

        /// <summary>
        /// Метод инициализации TextBox'ов
        /// </summary>
        private void InitializeTextBoxes()
        {
            Triad1First.Text = _triad1.First.ToString();
            Triad1Second.Text = _triad1.Second.ToString();
            Triad1Third.Text = _triad1.Third.ToString();

            Triad2First.Text = _triad2.First.ToString();
            Triad2Second.Text = _triad2.Second.ToString();
            Triad2Third.Text = _triad2.Third.ToString();

            Triad1First.Text = _vector1.First.ToString();
            Triad1Second.Text = _vector1.Second.ToString();
            Triad1Third.Text = _vector1.Third.ToString();

            Triad2First.Text = _vector2.First.ToString();
            Triad2Second.Text = _vector2.Second.ToString();
            Triad2Third.Text = _vector2.Third.ToString();
        }

        /// <summary>
        /// Кнопка выхода из программы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Кнопка информации о программе
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Разработчик: Демьяхин Роман ИСП-31 12 Вариант\nИспользовать класс Triad (тройка чисел). Разработать операцию для сложения триады с числом.\nРазработать операцию для сложения элементов одой триады с другой триадой.", "О программе");
        }

        /// <summary>
        /// Кнопка сложения Триад.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddTriads_Click(object sender, RoutedEventArgs e)
        {
            if (UpdateTriads())
            {
                _triad1 = _triad1 + _triad2;
                tbOutput.Text = $"{_triad1}";
            }
            UpdateTextBoxesForTriad1();
        }

        /// <summary>
        /// Кнопка умножения Триады 1 на число.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMultiplyTriad1_Click(object sender, RoutedEventArgs e)
        {
            if (UpdateTriad1() && int.TryParse(tbNumber.Text, out int number))
            {
                _triad1.MultiplyByNumber(number);
                tbOutput.Text = $"Умножение Триады 1 на {number}:\n{_triad1}";
                UpdateTextBoxesForTriad1();
            }
            else
            {
                MessageBox.Show("Введите корректное число для операции умножения.", "Ошибка ввода");
            }
        }

        /// <summary>
        /// Кнопка сравнения триад.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCompareTriads_Click(object sender, RoutedEventArgs e)
        {
            if (UpdateTriads())
            {
                bool isEqual = _triad1.Equals(_triad2);
                tbOutput.Text = $"Сравнение Триад:\n{_triad1} и {_triad2} равны? {isEqual}";
            }
        }

        /// <summary>
        /// Кнопка сложения триады 1 с числом
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddNumberToTriad1_Click(object sender, RoutedEventArgs e)
        {
            if (UpdateTriad1() && int.TryParse(tbNumber.Text, out int number))
            {
                _triad1 = _triad1 + number;
                tbOutput.Text = $"Сложение Триады 1 с числом {number}:\n{_triad1}";
                UpdateTextBoxesForTriad1();
            }
            else
            {
                MessageBox.Show("Введите корректное число для операции сложения.", "Ошибка ввода");
            }
        }

        /// <summary>
        /// Метод обновления триад.
        /// </summary>
        /// <returns></returns>
        private bool UpdateTriads()
        {
            bool isValid = true;

            isValid &= int.TryParse(Triad1First.Text, out int triad1First);
            isValid &= int.TryParse(Triad1Second.Text, out int triad1Second);
            isValid &= int.TryParse(Triad1Third.Text, out int triad1Third);

            isValid &= int.TryParse(Triad2First.Text, out int triad2First);
            isValid &= int.TryParse(Triad2Second.Text, out int triad2Second);
            isValid &= int.TryParse(Triad2Third.Text, out int triad2Third);

            isValid &= int.TryParse(Triad1First.Text, out int vector1First);
            isValid &= int.TryParse(Triad1Second.Text, out int vector1Second);
            isValid &= int.TryParse(Triad1Third.Text, out int vector1Third);

            isValid &= int.TryParse(Triad2First.Text, out int vector2First);
            isValid &= int.TryParse(Triad2Second.Text, out int vector2Second);
            isValid &= int.TryParse(Triad2Third.Text, out int vector2Third);

            if (!isValid)
            {
                MessageBox.Show("Введите корректные числа для обеих триад.", "Ошибка ввода");
                return false;
            }

            _triad1.First = triad1First;
            _triad1.Second = triad1Second;
            _triad1.Third = triad1Third;

            _triad2.First = triad2First;
            _triad2.Second = triad2Second;
            _triad2.Third = triad2Third;

            _vector1.First = vector1First;
            _vector1.Second = vector1Second;
            _vector1.Third = vector1Third;

            _vector2.First = vector2First;
            _vector2.Second = vector2Second;
            _vector2.Third = vector2Third;

            return true;
        }

        /// <summary>
        /// Метод обновления 1 триады.
        /// </summary>
        /// <returns></returns>
        private bool UpdateTriad1()
        {
            bool isValid = true;

            isValid &= int.TryParse(Triad1First.Text, out int triad1First);
            isValid &= int.TryParse(Triad1Second.Text, out int triad1Second);
            isValid &= int.TryParse(Triad1Third.Text, out int triad1Third);

            isValid &= int.TryParse(Triad1First.Text, out int vector1First);
            isValid &= int.TryParse(Triad1Second.Text, out int vector1Second);
            isValid &= int.TryParse(Triad1Third.Text, out int vector1Third);

            if (!isValid)
            {
                MessageBox.Show("Введите корректные числа для триады.", "Ошибка ввода");
                return false;
            }

            _triad1.First = triad1First;
            _triad1.Second = triad1Second;
            _triad1.Third = triad1Third;

            _vector1.First = vector1First;
            _vector1.Second = vector1Second;
            _vector1.Third = vector1Third;

            return true;
        }

        /// <summary>
        /// Метод обновления TextBox'ов 1 триады.
        /// </summary>
        private void UpdateTextBoxesForTriad1()
        {
            Triad1First.Text = _triad1.First.ToString();
            Triad1Second.Text = _triad1.Second.ToString();
            Triad1Third.Text = _triad1.Third.ToString();

            Triad1First.Text = _vector1.First.ToString();
            Triad1Second.Text = _vector1.Second.ToString();
            Triad1Third.Text = _vector1.Third.ToString();
        } 
        /// <summary>
        /// Кнопка сложения векторов.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddVectors_Click(object sender, RoutedEventArgs e)
        {
            if (UpdateTriads())
            {
                _vector1 = _vector1 + _vector2;
                tbOutput.Text = $"Сложение векторов:\n{_vector1}";
            }
            UpdateTextBoxesForTriad1();
        }
        /// <summary>
        /// Кнопка нахождения скалярного произведения.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDotProduct_Click(object sender, RoutedEventArgs e)
        {
            if (UpdateTriads())
            {
                int dotProduct = _vector1.DotProduct(_vector2);
                tbOutput.Text = $"Скалярное произведение векторов: {dotProduct}";
            }
            UpdateTextBoxesForTriad1();
        }
    }
}