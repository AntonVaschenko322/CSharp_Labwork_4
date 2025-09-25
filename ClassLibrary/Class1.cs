using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClassLibrary
{
    //Задание 1
    public class MyMatrix
    {
        private double[,] matrix;
        public void Matrix()
        {
            Console.WriteLine();
            int t = 0;
            foreach(double x in matrix)
            {

                if (t == matrix.GetLength(1)-1)
                {
                    t = 0;
                    Console.WriteLine(x);
                }
                else
                {
                    ++t;
                    Console.Write(x); Console.Write(" ");
                }
                 
            }
            Console.WriteLine();
        }
        private MyMatrix(int x, int y)
        {
            matrix = new double[x, y];
        }
        public MyMatrix(int x, int y, int a, int b)
        {
            Random rnd = new Random();
            matrix = new double[x, y];
            for(int i = 0; i < x; i++)
            {
                for(int j = 0; j < y; j++)
                {
                    matrix[i, j] = rnd.Next(a, b);
                    Console.Write(matrix[i, j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }


        public double this[int a, int b]
        {
            get { return matrix[a, b]; }
            set { matrix[a, b] = value; }
        }

        public static MyMatrix operator+ (MyMatrix x, MyMatrix y)
        {
            if (x.matrix.GetLength(0) != y.matrix.GetLength(0) || x.matrix.GetLength(1) != y.matrix.GetLength(1))
            {
                Console.WriteLine("Для сложения матрицы должны быть одного порядка");
                Environment.Exit(0);
            }
            int rows = x.matrix.GetLength(0);
            int columns = x.matrix.GetLength(1);
            MyMatrix z = new MyMatrix(rows, columns);
            for(int i = 0; i < rows; i++)
            {
                for(int j = 0; j < columns; j++)
                {
                    z[i, j] = x[i, j] + y[i, j];
                }
            }
            return z;
        }

        public static MyMatrix operator- (MyMatrix x, MyMatrix y)
        {
            if (x.matrix.GetLength(0) != y.matrix.GetLength(0) || x.matrix.GetLength(1) != y.matrix.GetLength(1))
            {
                Console.WriteLine("Для вычитания матрицы должны быть одного порядка");
                Environment.Exit(0);
            }
            int rows = x.matrix.GetLength(0);
            int columns = x.matrix.GetLength(1);
            MyMatrix z = new MyMatrix(rows, columns);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    z[i, j] = x[i, j] - y[i, j];
                }
            }
            return z;
        }

        public static MyMatrix operator *(MyMatrix x, MyMatrix y)
        {
            if(x.matrix.GetLength(1) != y.matrix.GetLength(0))
            {
                Console.WriteLine("Не подходящие для произведение матрицы");
                Environment.Exit(0);
            }
            MyMatrix res = new MyMatrix(x.matrix.GetLength(0), y.matrix.GetLength(1));
            for (int i = 0; i < x.matrix.GetLength(0) ; i++)
            {
                double sum = 0;
                int count = 0;
                int t = 0;
                for(int j = 0; j < x.matrix.GetLength(1); j++)
                {
                
                    sum += x[i, j] * y[j, t];
                    if(j == (x.matrix.GetLength(1) - 1) && count < (y.matrix.GetLength(1)))
                    {
                        res[i, count] = sum;
                        sum = 0;
                        ++count;
                        j = -1;
                        ++t;
                    }
                    if(count == (y.matrix.GetLength(1)))
                    {
                        break;
                    }

                }
                
            }
            return res;
        }
        public static MyMatrix operator* (MyMatrix x, int y)
        {
            for(int i = 0; i < x.matrix.GetLength(0); i++)
            {
                for(int j = 0; j < x.matrix.GetLength(1); j++)
                {
                    x[i, j] *= y; 
                }
            }
            return x;
        }

        public static MyMatrix operator/ (MyMatrix x, double y)
        {
            for (int i = 0; i < x.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < x.matrix.GetLength(1); j++)
                {
                    x[i, j] /= y;
                }
            }
            return x;
        }

    }

    // Задание 2
    public class Car
    {
        public string Name { get; set; }
        public int ProductionYear { get; set; }
        public double MaxSpeed { get; set; }

        public Car(string name, int productionYear, double maxSpeed)
        {
            Name = name;
            ProductionYear = productionYear;
            MaxSpeed = maxSpeed;
        }
    }

    public class CarComparer : IComparer<Car>
    {
        private string type;
        public CarComparer(string x)
        {
            type= x;
        }
        public int Compare(Car x, Car y)
        {
            if (type == "Дата")
            {
                return x.ProductionYear - y.ProductionYear;
            }
            else if (type == "Скорость")
            {
                return -(int)(x.MaxSpeed - y.MaxSpeed);
            }
            else if (type == "Название")
            {
                return x.Name.Length - y.Name.Length;
            }
            return 0;
        }
    }
    //Задание 3
    public class CarCatalog
    {
        Car[] Catalog;
        public CarCatalog(params Car[] cars)
        {
            Catalog = new Car[cars.Length];
            for(int i = 0; i < cars.Length; i++)
            {
                Catalog[i] = cars[i];
            }
        }

        public IEnumerator<Car> GetEnumerator()
        {
            foreach (Car car in Catalog)
            {
                yield return car;
            }
        }

        public IEnumerable<Car> reverse()
        {
            for(int i =  Catalog.Length - 1; i >= 0; i--)
            {
                yield return Catalog[i];
            }
        }

        public IEnumerable<Car> Year(int year)
        {
            foreach(Car car in Catalog)
            {
                if(car.ProductionYear == year)
                {
                    yield return car;
                }
            }
        }

        public IEnumerable<Car> Speed(int speed)
        {
            foreach (Car car in Catalog)
            {
                if (car.MaxSpeed == speed)
                {
                    yield return car;
                }
            }
        }


    }


}
