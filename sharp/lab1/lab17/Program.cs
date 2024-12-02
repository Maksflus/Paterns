using System;
using System.Collections.Generic;

// Посередник
public interface IBookingMediator
{
    void Notify(object sender, string ev);
}

// Конкретний посередник
public class BookingMediator : IBookingMediator
{
    private readonly List<BookingSystem> _bookingSystems;
    private readonly List<OrderSystem> _orderSystems;

    public BookingMediator()
    {
        _bookingSystems = new List<BookingSystem>();
        _orderSystems = new List<OrderSystem>();
    }

    public void AddBookingSystem(BookingSystem bookingSystem)
    {
        _bookingSystems.Add(bookingSystem);
    }

    public void AddOrderSystem(OrderSystem orderSystem)
    {
        _orderSystems.Add(orderSystem);
    }

    public void Notify(object sender, string ev)
    {
        if (ev == "TableBooked")
        {
            foreach (var orderSystem in _orderSystems)
            {
                orderSystem.HandleOrder(sender);
            }
        }
    }
}

// Колега: Система бронювання столиків
public class BookingSystem
{
    private readonly IBookingMediator _mediator;

    public BookingSystem(IBookingMediator mediator)
    {
        _mediator = mediator;
    }

    public void BookTable(string customer)
    {
        Console.WriteLine($"{customer} забронював столик.");
        _mediator.Notify(this, "TableBooked");
    }
}

// Колега: Система замовлення страв
public class OrderSystem
{
    private readonly IBookingMediator _mediator;

    public OrderSystem(IBookingMediator mediator)
    {
        _mediator = mediator;
    }

    public void HandleOrder(object sender)
    {
        Console.WriteLine("Система замовлення страв отримала повідомлення про бронювання столика.");
    }
}

// Клієнт
class Program
{
    static void Main(string[] args)
    {
        var mediator = new BookingMediator();

        var bookingSystem = new BookingSystem(mediator);
        var orderSystem = new OrderSystem(mediator);

        mediator.AddBookingSystem(bookingSystem);
        mediator.AddOrderSystem(orderSystem);

        bookingSystem.BookTable("Іван");
    }
}
