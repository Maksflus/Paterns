using System;

public class ReservationSystem
{
    private static ReservationSystem _instance; // Єдиний екземпляр класу
    private static readonly object _lock = new object(); // Блокування для потокобезпечності

    // Приватний конструктор
    private ReservationSystem()
    {
        Console.WriteLine("Ініціалізація системи бронювання...");
    }

    // Метод для отримання єдиного екземпляра
    public static ReservationSystem GetInstance()
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new ReservationSystem();
                }
            }
        }
        return _instance;
    }

    // Метод для бронювання столика
    public void BookTable(int tableNumber)
    {
        Console.WriteLine($"Столик №{tableNumber} заброньовано.");
    }
}

// Демонстрація
public class Program
{
    public static void Main(string[] args)
    {
        ReservationSystem system1 = ReservationSystem.GetInstance();
        system1.BookTable(5);

        ReservationSystem system2 = ReservationSystem.GetInstance();
        system2.BookTable(3);

        Console.WriteLine(system1 == system2); // true
    }
}
