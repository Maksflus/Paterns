using System;
using System.Collections.Generic;

// Клас для позицій меню
public class MenuItem
{
    public string Name { get; set; }
    public double Price { get; set; }

    public MenuItem(string name, double price)
    {
        Name = name;
        Price = price;
    }

    public void Accept(IOrderVisitor visitor)
    {
        visitor.Visit(this);
    }
}

// Інтерфейс для відвідувачів
public interface IOrderVisitor
{
    void Visit(MenuItem item);
}

// Клас для замовлення
public class Order
{
    public List<MenuItem> Items { get; private set; }

    public Order()
    {
        Items = new List<MenuItem>();
    }

    public void AddItem(MenuItem item)
    {
        Items.Add(item);
    }

    public void Accept(IOrderVisitor visitor)
    {
        foreach (var item in Items)
        {
            item.Accept(visitor);
        }
    }
}

// Конкретний відвідувач для підрахунку вартості
public class TotalPriceVisitor : IOrderVisitor
{
    public double TotalPrice { get; private set; }

    public void Visit(MenuItem item)
    {
        TotalPrice += item.Price;
    }
}

// Клієнт
public class Program
{
    public static void Main(string[] args)
    {
        // Створення позицій меню
        MenuItem pizza = new MenuItem("Піца", 200);
        MenuItem pasta = new MenuItem("Паста", 150);

        // Створення замовлення
        Order order = new Order();
        order.AddItem(pizza);
        order.AddItem(pasta);

        // Створення відвідувача для підрахунку вартості
        TotalPriceVisitor totalPriceVisitor = new TotalPriceVisitor();
        order.Accept(totalPriceVisitor);

        Console.WriteLine("Загальна вартість замовлення: " + totalPriceVisitor.TotalPrice);
    }
}
