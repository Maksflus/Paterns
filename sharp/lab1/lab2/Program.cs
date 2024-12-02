using System;

public abstract class MenuPrototype
{
    public abstract MenuPrototype Clone();
}

public class Dish : MenuPrototype
{
    public string Name { get; set; }
    public double Price { get; set; }

    public Dish(string name, double price)
    {
        Name = name;
        Price = price;
    }

    public override MenuPrototype Clone()
    {
        Console.WriteLine($"Копіювання страви: {Name}");
        return new Dish(Name, Price);
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Страва: {Name}, Ціна: {Price} грн");
    }
}

// Демонстрація
public class Program
{
    public static void Main(string[] args)
    {
        // Оригінальна страва
        Dish originalDish = new Dish("Паста Болоньєзе", 250);
        originalDish.DisplayInfo();

        // Клонування
        Dish clonedDish = (Dish)originalDish.Clone();
        clonedDish.Price = 200; // Зміна ціни у клона
        clonedDish.DisplayInfo();
    }
}
