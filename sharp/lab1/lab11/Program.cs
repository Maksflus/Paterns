using System;

// Підсистема бронювання столиків
public class ReservationSystem
{
    public void BookTable(string name)
    {
        Console.WriteLine($"Столик заброньовано на ім'я: {name}");
    }
}

// Підсистема меню
public class MenuSystem
{
    public void OrderFood(string foodItem)
    {
        Console.WriteLine($"Страва {foodItem} замовлена");
    }
}

// Підсистема виставлення рахунків
public class BillingSystem
{
    public void GenerateBill(decimal amount)
    {
        Console.WriteLine($"Виставлено рахунок на суму: {amount} грн");
    }
}

// Фасад
public class RestaurantFacade
{
    private ReservationSystem _reservationSystem;
    private MenuSystem _menuSystem;
    private BillingSystem _billingSystem;

    public RestaurantFacade()
    {
        _reservationSystem = new ReservationSystem();
        _menuSystem = new MenuSystem();
        _billingSystem = new BillingSystem();
    }

    public void DineOut(string name, string foodItem, decimal amount)
    {
        _reservationSystem.BookTable(name);
        _menuSystem.OrderFood(foodItem);
        _billingSystem.GenerateBill(amount);
    }
}

// Демонстрація
class Program
{
    static void Main(string[] args)
    {
        RestaurantFacade facade = new RestaurantFacade();
        facade.DineOut("Максим", "Піца", 250);
    }
}
