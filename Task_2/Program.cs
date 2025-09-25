using ClassLibrary;
namespace Task_2
{
    public class Program
    {
        static void Print(List<Car> cars)
        {
            foreach(Car car in cars)
            {
                Console.Write(car.Name); Console.Write(" ");
                Console.Write(car.MaxSpeed); Console.Write("км/ч ");
                Console.Write(car.ProductionYear); Console.Write("г ");
                Console.WriteLine(Environment.NewLine);
            }
        }
        static void Main()
        {
            Car Mercedes = new Car("Mercedes", 2003, 290);
            Car Porsche = new Car("Porsche", 1996, 312);
            Car Toyota = new Car("Toyota", 2001, 283);
            Car Volvo = new Car("Volvo", 1976, 253);
            List<Car> cars = new List<Car>() { Volvo, Porsche, Mercedes, Toyota };
            Print(cars);
            cars.Sort(new CarComparer("Дата"));
            Console.WriteLine("Сортировка по дате выпуска");
            Print(cars);
            cars.Sort(new CarComparer("Скорость"));
            Console.WriteLine("Сортировка по максимальной скорости");
            Print(cars);
            cars.Sort(new CarComparer("Название"));
            Console.WriteLine("Сортировка по названию");
            Print(cars);
        }
    }

}
