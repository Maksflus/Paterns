using System;
using System.Collections.Generic;

// Хранитель
public class OrderMemento
{
    public string OrderState { get; private set; }

    public OrderMemento(string state)
    {
        OrderState = state;
    }
}

// Той, хто створює Memento
public class OrderSystem
{
    public string OrderState { get; set; }

    public OrderSystem(string initialState)
    {
        OrderState = initialState;
    }

    public OrderMemento CreateMemento()
    {
        return new OrderMemento(OrderState);
    }

    public void RestoreMemento(OrderMemento memento)
    {
        OrderState = memento.OrderState;
    }

    public void PrintState()
    {
        Console.WriteLine("Стан замовлення: " + OrderState);
    }
}

// Доглядач
public class Caretaker
{
    private List<OrderMemento> _orderHistory = new List<OrderMemento>();

    public void Save(OrderMemento memento)
    {
        _orderHistory.Add(memento);
    }

    public OrderMemento Get(int index)
    {
        return _orderHistory[index];
    }
}

// Клієнт
class Program
{
    static void Main(string[] args)
    {
        var orderSystem = new OrderSystem("Замовлення обробляється");
        var caretaker = new Caretaker();

        orderSystem.PrintState();

        // Зберігаємо стан
        caretaker.Save(orderSystem.CreateMemento());

        orderSystem.OrderState = "Замовлення завершено";
        orderSystem.PrintState();

        // Відновлюємо стан
        orderSystem.RestoreMemento(caretaker.Get(0));
        orderSystem.PrintState();
    }
}
