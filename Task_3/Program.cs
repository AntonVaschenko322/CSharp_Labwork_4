using ClassLibrary;
namespace Task_3
{
    public class Program
    {
        static void Main()
        {
            Car Mercedes = new Car("Mercedes", 2003, 290);
            Car Porsche = new Car("Porsche", 1996, 312);
            Car Toyota = new Car("Toyota", 2001, 283);
            Car Volvo = new Car("Volvo", 1976, 253);
            CarCatalog Cat = new CarCatalog(Mercedes, Porsche, Toyota, Volvo);
            foreach(Car t in Cat)
            {
                Console.WriteLine(t.Name);
            }
            Console.WriteLine();
            foreach (Car t in Cat.reverse())
            {
                Console.WriteLine(t.Name);
            }
            Console.WriteLine();
            foreach (Car t in Cat.Year(2001))
            {
                Console.WriteLine(t.Name);
            }
            Console.WriteLine();
            foreach (Car t in Cat.Speed(312))
            {
                Console.WriteLine(t.Name);
            }
        }
    }

}

