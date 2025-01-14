// Класс Car представляет автомобиль с тремя свойствами: название, год выпуска и максимальная скорость
public class Car
{
    public string Name { get; set; } // Название автомобиля
    public int ProductionYear { get; set; } // Год выпуска автомобиля
    public int MaxSpeed { get; set; } // Максимальная скорость автомобиля

    // Конструктор для инициализации свойств
    public Car(string name, int productionYear, int maxSpeed)
    {
        Name = name;
        ProductionYear = productionYear;
        MaxSpeed = maxSpeed;
    }

    // Переопределение метода ToString для удобного отображения информации об автомобиле
    public override string ToString()
    {
        return $"Name: {Name}, Year: {ProductionYear}, Max Speed: {MaxSpeed}";
    }
}

// Класс CarComparer реализует интерфейс IComparer<Car> для сортировки автомобилей
public class CarComparer : IComparer<Car> // Интерфейс, для сравнения
{
    // Перечисление, определяющее критерии сортировки
    public enum SortCriteria // Определяем три возможных критерия сортировки для автомобилей
    {
        ByName,            // Сортировка по названию
        ByProductionYear,  // Сортировка по году выпуска
        ByMaxSpeed         // Сортировка по максимальной скорости
    }

    private SortCriteria sortCriteria; // Переменная для хранения текущего критерия сортировки

    // Конструктор для установки критерия сортировки
    public CarComparer(SortCriteria criteria)
    {
        sortCriteria = criteria;
    }

    // Метод Compare для сравнения двух автомобилей в зависимости от выбранного критерия
    public int Compare(Car x, Car y)
    {
        switch (sortCriteria)
        {
            case SortCriteria.ByName:
                return x.Name.CompareTo(y.Name); // Сравнение по названию
            case SortCriteria.ByProductionYear:
                return x.ProductionYear.CompareTo(y.ProductionYear); // Сравнение по году выпуска
            case SortCriteria.ByMaxSpeed:
                return x.MaxSpeed.CompareTo(y.MaxSpeed); // Сравнение по максимальной скорости
            default:
                Console.WriteLine("!!!ERROR!!! Invalid sort criteria"); // Вывод сообщения об ошибке
                return 0; // Возвращаем 0, чтобы не прерывать сортировку
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Car[] cars = {
            new Car("Ferrari", 2015, 250),
            new Car("Skoda", 2018, 200),
            new Car("BMW", 2023, 240),
            new Car("Audi", 2020, 220)
        };

        Console.WriteLine("Original array:");
        // Выводим исходный массив
        for (int i = 0; i < cars.Length; i++)
        {
            Console.WriteLine(cars[i]);
        }

        // Сортировка по имени
        Array.Sort(cars, new CarComparer(CarComparer.SortCriteria.ByName));
        Console.WriteLine("\nSorted by Name:");
        // Выводим отсортированный массив
        for (int i = 0; i < cars.Length; i++)
        {
            Console.WriteLine(cars[i]); 
        }

        // Сортировка по году выпуска
        Array.Sort(cars, new CarComparer(CarComparer.SortCriteria.ByProductionYear));
        Console.WriteLine("\nSorted by Production Year:");
        // Выводим отсортированный массив
        for (int i = 0; i < cars.Length; i++)
        {
            Console.WriteLine(cars[i]); 
        }

        // Сортировка по максимальной скорости
        Array.Sort(cars, new CarComparer(CarComparer.SortCriteria.ByMaxSpeed));
        Console.WriteLine("\nSorted by Max Speed:");
        // Выводим отсортированный массив
        for (int i = 0; i < cars.Length; i++)
        {
            Console.WriteLine(cars[i]); 
        }
    }
}
