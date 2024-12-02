using System;
using System.Collections.Generic;

// Flyweight для страв
public class MenuItem
{
    public string Name { get; private set; }
    public decimal Price { get; private set; }

    public MenuItem(string name, decimal price)
    {
        Name = name;
        Price = price;
    }
}

// Flyweight для столиків
public class Table
{
    public int Seats { get; private set; }

    public Table(int seats)
    {
        Seats = seats;
    }
}

// Замовлення
public class Order
{
    public MenuItem MenuItem { get; private set; }
    public Table Table { get; private set; }
    public int Quantity { get; private set; }

    public Order(MenuItem menuItem, Table table, int quantity)
    {
        MenuItem = menuItem;
        Table = table;
        Quantity = quantity;
    }

    public void ShowOrderDetails()
    {
        Console.WriteLine($"Замовлення: {Quantity} x {MenuItem.Name} на столик з {Table.Seats} місцями");
    }
}

// Фабрика Flyweight
public class Restaurant
{
    private Dictionary<string, MenuItem> _menuItems = new Dictionary<string, MenuItem>();
    private Dictionary<int, Table> _tables = new Dictionary<int, Table>();

    public MenuItem GetMenuItem(string name, decimal price)
    {
        if (!_menuItems.ContainsKey(name))
        {
            _menuItems[name] = new MenuItem(name, price);
        }
        return _menuItems[name];
    }

    public Table GetTable(int seats)
    {
        if (!_tables.ContainsKey(seats))
        {
            _tables[seats] = new Table(seats);
        }
        return _tables[seats];
    }

    public void CreateOrder(string menuItemName, decimal price, int seats, int quantity)
    {
        MenuItem menuItem = GetMenuItem(menuItemName, price);
        Table table = GetTable(seats);
        Order order = new Order(menuItem, table, quantity);
        order.ShowOrderDetails();
    }
}

// Демонстрація
class Program
{
    static void Main(string[] args)
    {
        Restaurant restaurant = new Restaurant();
        restaurant.CreateOrder("Піца", 250, 4, 2);
        restaurant.CreateOrder("Піца", 250, 4, 3);
        restaurant.CreateOrder("Бургер", 150, 2, 1);
    }
}
