using System;
using System.Collections.Generic;

// Абстракція: Суб'єкт
public interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify();
}

// Абстракція: Спостерігач
public interface IObserver
{
    void Update(string message);
}

// Конкретний Суб'єкт
public class OrderSystem : ISubject
{
    private List<IObserver> _observers = new List<IObserver>();
    private string _orderStatus;

    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (var observer in _observers)
        {
            observer.Update(_orderStatus);
        }
    }

    public void SetOrderStatus(string status)
    {
        _orderStatus = status;
        Notify();
    }
}

// Конкретний Спостерігач
public class Customer : IObserver
{
    private string _customerName;

    public Customer(string name)
    {
        _customerName = name;
    }

    public void Update(string message)
    {
        Console.WriteLine($"Користувач {_customerName} отримав оновлення: {message}");
    }
}

// Клієнт
class Program
{
    static void Main(string[] args)
    {
        var orderSystem = new OrderSystem();

        var customer1 = new Customer("Іван");
        var customer2 = new Customer("Марія");

        orderSystem.Attach(customer1);
        orderSystem.Attach(customer2);

        orderSystem.SetOrderStatus("Замовлення прийняте");

        orderSystem.Detach(customer1);

        orderSystem.SetOrderStatus("Замовлення обробляється");
    }
}
