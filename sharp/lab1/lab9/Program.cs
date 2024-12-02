using System;
using System.Collections.Generic;

public abstract class MenuComponent
{
    public virtual void Add(MenuComponent component)
    {
        throw new NotImplementedException();
    }

    public virtual void Remove(MenuComponent component)
    {
        throw new NotImplementedException();
    }

    public virtual void Display(int depth = 0)
    {
        throw new NotImplementedException();
    }
}

public class MenuItem : MenuComponent
{
    private string _name;
    private decimal _price;

    public MenuItem(string name, decimal price)
    {
        _name = name;
        _price = price;
    }

    public override void Display(int depth = 0)
    {
        Console.WriteLine(new string('-', depth) + $" Страва: {_name}, Ціна: {_price} грн");
    }
}

public class MenuCategory : MenuComponent
{
    private string _name;
    private List<MenuComponent> _components = new List<MenuComponent>();

    public MenuCategory(string name)
    {
        _name = name;
    }

    public override void Add(MenuComponent component)
    {
        _components.Add(component);
    }

    public override void Remove(MenuComponent component)
    {
        _components.Remove(component);
    }

    public override void Display(int depth = 0)
    {
        Console.WriteLine(new string('-', depth) + $" Категорія: {_name}");
        foreach (var component in _components)
        {
            component.Display(depth + 2);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        MenuCategory mainMenu = new MenuCategory("Головне меню");

        MenuCategory drinks = new MenuCategory("Напої");
        drinks.Add(new MenuItem("Кава", 50));
        drinks.Add(new MenuItem("Чай", 30));

        MenuCategory desserts = new MenuCategory("Десерти");
        desserts.Add(new MenuItem("Торт", 120));
        desserts.Add(new MenuItem("Морозиво", 70));

        mainMenu.Add(drinks);
        mainMenu.Add(desserts);

        mainMenu.Display();
    }
}
