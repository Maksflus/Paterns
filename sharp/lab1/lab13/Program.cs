using System;

// Реальний об'єкт
public class Restaurant
{
    public void BookTable(int numberOfSeats)
    {
        Console.WriteLine($"Столик на {numberOfSeats} місць заброньовано.");
    }

    public void OrderDish(string dishName)
    {
        Console.WriteLine($"Страва {dishName} замовлена.");
    }
}

// Проксі-об'єкт
public class ReservationProxy
{
    private Restaurant _restaurant;

    public ReservationProxy()
    {
        _restaurant = new Restaurant();
    }

    public void BookTable(int numberOfSeats)
    {
        Console.WriteLine("Перевірка доступу до бронювання...");
        _restaurant.BookTable(numberOfSeats);  // делегування реальному об'єкту
    }

    public void OrderDish(string dishName)
    {
        Console.WriteLine("Перевірка доступу до замовлення страви...");
        _restaurant.OrderDish(dishName);  // делегування реальному об'єкту
    }
}

// Демонстрація
class Program
{
    static void Main(string[] args)
    {
        ReservationProxy reservationProxy = new ReservationProxy();
        reservationProxy.BookTable(4);  // виклик через проксі
        reservationProxy.OrderDish("Піца");  // виклик через проксі
    }
}
