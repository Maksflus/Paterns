using System;

// Абстрактний продукт: Страва
public abstract class Dish
{
    public abstract void Serve();
}

// Абстрактний продукт: Напій
public abstract class Drink
{
    public abstract void Serve();
}

// Конкретний продукт: Італійська паста
public class ItalianPasta : Dish
{
    public override void Serve()
    {
        Console.WriteLine("Сервіруємо італійську пасту.");
    }
}

// Конкретний продукт: Італійське вино
public class ItalianWine : Drink
{
    public override void Serve()
    {
        Console.WriteLine("Сервіруємо італійське вино.");
    }
}

// Конкретний продукт: Японські суші
public class JapaneseSushi : Dish
{
    public override void Serve()
    {
        Console.WriteLine("Сервіруємо японські суші.");
    }
}

// Конкретний продукт: Японське саке
public class JapaneseSake : Drink
{
    public override void Serve()
    {
        Console.WriteLine("Сервіруємо японське саке.");
    }
}

// Абстрактна фабрика
public abstract class RestaurantFactory
{
    public abstract Dish CreateDish();
    public abstract Drink CreateDrink();
}

// Конкретна фабрика: Італійський ресторан
public class ItalianRestaurantFactory : RestaurantFactory
{
    public override Dish CreateDish()
    {
        return new ItalianPasta();
    }

    public override Drink CreateDrink()
    {
        return new ItalianWine();
    }
}

// Конкретна фабрика: Японський ресторан
public class JapaneseRestaurantFactory : RestaurantFactory
{
    public override Dish CreateDish()
    {
        return new JapaneseSushi();
    }

    public override Drink CreateDrink()
    {
        return new JapaneseSake();
    }
}

// Демонстрація
public class Program
{
    public static void Main(string[] args)
    {
        // Італійський ресторан
        RestaurantFactory italianFactory = new ItalianRestaurantFactory();
        Dish italianDish = italianFactory.CreateDish();
        Drink italianDrink = italianFactory.CreateDrink();
        italianDish.Serve();
        italianDrink.Serve();

        // Японський ресторан
        RestaurantFactory japaneseFactory = new JapaneseRestaurantFactory();
        Dish japaneseDish = japaneseFactory.CreateDish();
        Drink japaneseDrink = japaneseFactory.CreateDrink();
        japaneseDish.Serve();
        japaneseDrink.Serve();
    }
}
