using System;

// Абстрактний клас
public abstract class Dish
{
    public abstract void Prepare();
}

// Конкретні класи страв
public class Pizza : Dish
{
    public override void Prepare()
    {
        Console.WriteLine("Приготування піци...");
    }
}

public class Pasta : Dish
{
    public override void Prepare()
    {
        Console.WriteLine("Приготування пасти...");
    }
}

// Фабричний метод
public abstract class DishFactory
{
    public abstract Dish CreateDish();
}

// Конкретні фабрики
public class PizzaFactory : DishFactory
{
    public override Dish CreateDish()
    {
        return new Pizza();
    }
}

public class PastaFactory : DishFactory
{
    public override Dish CreateDish()
    {
        return new Pasta();
    }
}

// Демонстрація
public class Program
{
    public static void Main(string[] args)
    {
        // Фабрика піци
        DishFactory pizzaFactory = new PizzaFactory();
        Dish pizza = pizzaFactory.CreateDish();
        pizza.Prepare();

        // Фабрика пасти
        DishFactory pastaFactory = new PastaFactory();
        Dish pasta = pastaFactory.CreateDish();
        pasta.Prepare();
    }
}
