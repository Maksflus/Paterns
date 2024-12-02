using System;
using System.Collections.Generic;

// Ітератор
public interface IIterator
{
    bool HasNext();
    object Next();
}

// Конкретний ітератор
public class MenuIterator : IIterator
{
    private readonly List<string> _menuItems;
    private int _position = 0;

    public MenuIterator(List<string> menuItems)
    {
        _menuItems = menuItems;
    }

    public bool HasNext()
    {
        return _position < _menuItems.Count;
    }

    public object Next()
    {
        if (HasNext())
        {
            return _menuItems[_position++];
        }
        return null;
    }
}

// Колекція
public interface IMenu
{
    IIterator CreateIterator();
}

// Конкретна колекція
public class RestaurantMenu : IMenu
{
    private readonly List<string> _menuItems = new List<string>();

    public void AddItem(string item)
    {
        _menuItems.Add(item);
    }

    public IIterator CreateIterator()
    {
        return new MenuIterator(_menuItems);
    }
}

// Клієнт
class Program
{
    static void Main(string[] args)
    {
        // Створення меню
        var menu = new RestaurantMenu();
        menu.AddItem("Піца");
        menu.AddItem("Паста");
        menu.AddItem("Салат");

        // Отримання ітератора
        IIterator iterator = menu.CreateIterator();

        // Перебір елементів меню
        while (iterator.HasNext())
        {
            Console.WriteLine(iterator.Next());
        }
    }
}
