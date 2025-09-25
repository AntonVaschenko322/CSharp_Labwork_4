using System.Security.Cryptography.X509Certificates;
using ClassLibrary;
namespace Task_1;
public class Program
{
    static void Main()
    {
        int a = 0, b = 0;
        Console.WriteLine("Введите диапазон чисел заполняющих матрицу");
        a = Convert.ToInt32(Console.ReadLine());
        b = Convert.ToInt32(Console.ReadLine());
        MyMatrix matr = new MyMatrix(2, 3, a, b);
        MyMatrix matr2 = new MyMatrix(2, 3, a, b);
        MyMatrix matr3 = new MyMatrix(3, 3, a, b);
        Console.WriteLine("Сумма двух матриц: ");
        (matr + matr2).Matrix();
        Console.WriteLine("Произведение двух матриц: ");
        (matr * matr3).Matrix();
        Console.WriteLine("Умножение матрицы на число: ");
        (matr * 3).Matrix();
        Console.WriteLine("Деление матрицы на число: ");
        (matr / 2).Matrix();

    }
}
