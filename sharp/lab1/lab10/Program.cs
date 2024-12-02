using System;

public abstract class Order
{
    public abstract decimal GetCost();
    public abstract string GetDescription();
}

public class BasicOrder : Order
{
    public override decimal GetCost()
    {
        return 100; // базова ціна
    }

    public override string GetDescription()
    {
        return "Основне замовлення";
    }
}

public abstract class OrderDecorator : Order
{
    protected Order _order;

    public OrderDecorator(Order order)
    {
        _order = order;
    }

    public override decimal GetCost()
    {
        return _order.GetCost();
    }

    public override string GetDescription()
    {
        return _order.GetDescription();
    }
}

public class DrinkDecorator : OrderDecorator
{
    public DrinkDecorator(Order order) : base(order) { }

    public override decimal GetCost()
    {
        return _order.GetCost() + 50; // ціна за напій
    }

    public override string GetDescription()
    {
        return _order.GetDescription() + ", Напій";
    }
}

public class DessertDecorator : OrderDecorator
{
    public DessertDecorator(Order order) : base(order) { }

    public override decimal GetCost()
    {
        return _order.GetCost() + 30; // ціна за десерт
    }

    public override string GetDescription()
    {
        return _order.GetDescription() + ", Десерт";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Order order = new BasicOrder();
        Console.WriteLine($"Опис: {order.GetDescription()}, Вартість: {order.GetCost()} грн");

        // Декорування замовлення
        order = new DrinkDecorator(order);
        Console.WriteLine($"Опис: {order.GetDescription()}, Вартість: {order.GetCost()} грн");

        order = new DessertDecorator(order);
        Console.WriteLine($"Опис: {order.GetDescription()}, Вартість: {order.GetCost()} грн");
    }
}
