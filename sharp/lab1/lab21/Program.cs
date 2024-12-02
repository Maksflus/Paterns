using System;

// Стратегія
public interface IPaymentStrategy
{
    void Pay(int amount);
}

// Контекст
public class OrderContext
{
    private IPaymentStrategy _paymentStrategy;

    public OrderContext(IPaymentStrategy paymentStrategy)
    {
        _paymentStrategy = paymentStrategy;
    }

    public void SetPaymentStrategy(IPaymentStrategy paymentStrategy)
    {
        _paymentStrategy = paymentStrategy;
    }

    public void ProcessPayment(int amount)
    {
        _paymentStrategy.Pay(amount);
    }
}

// Конкретна стратегія: Оплата кредитною карткою
public class CreditCardPayment : IPaymentStrategy
{
    public void Pay(int amount)
    {
        Console.WriteLine($"Оплата {amount} через кредитну картку.");
    }
}

// Конкретна стратегія: Оплата через PayPal
public class PayPalPayment : IPaymentStrategy
{
    public void Pay(int amount)
    {
        Console.WriteLine($"Оплата {amount} через PayPal.");
    }
}

// Конкретна стратегія: Оплата готівкою
public class CashPayment : IPaymentStrategy
{
    public void Pay(int amount)
    {
        Console.WriteLine($"Оплата {amount} готівкою.");
    }
}

// Клієнт
class Program
{
    static void Main(string[] args)
    {
        OrderContext order = new OrderContext(new CreditCardPayment());
        order.ProcessPayment(100);

        order.SetPaymentStrategy(new PayPalPayment());
        order.ProcessPayment(200);

        order.SetPaymentStrategy(new CashPayment());
        order.ProcessPayment(150);
    }
}
