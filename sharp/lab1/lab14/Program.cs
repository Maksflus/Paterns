using System;

// Абстрактний обробник
public abstract class ReservationHandler
{
    protected ReservationHandler _nextHandler;

    public void SetNextHandler(ReservationHandler nextHandler)
    {
        _nextHandler = nextHandler;
    }

    public abstract void HandleRequest(string request);
}

// Конкретний обробник для перевірки вільних місць
public class AvailableSeatsHandler : ReservationHandler
{
    public override void HandleRequest(string request)
    {
        if (request == "check seats")
        {
            Console.WriteLine("Перевірка наявності вільних місць...");
            // Якщо місця є, обробляє запит
        }
        else if (_nextHandler != null)
        {
            _nextHandler.HandleRequest(request);  // Передача запиту наступному обробнику
        }
    }
}

// Конкретний обробник для оплати
public class PaymentHandler : ReservationHandler
{
    public override void HandleRequest(string request)
    {
        if (request == "payment")
        {
            Console.WriteLine("Обробка платежу...");
            // Якщо платіж пройшов успішно, передає запит наступному обробнику
        }
        else if (_nextHandler != null)
        {
            _nextHandler.HandleRequest(request);  // Передача запиту наступному обробнику
        }
    }
}

// Конкретний обробник для замовлення страв
public class OrderDishHandler : ReservationHandler
{
    public override void HandleRequest(string request)
    {
        if (request == "order dish")
        {
            Console.WriteLine("Замовлення страви...");
            // Обробка замовлення страви
        }
        else if (_nextHandler != null)
        {
            _nextHandler.HandleRequest(request);  // Передача запиту наступному обробнику
        }
    }
}

// Клієнт, який створює ланцюг обробників і ініціює запит
class Program
{
    static void Main(string[] args)
    {
        // Створення обробників
        ReservationHandler availableSeats = new AvailableSeatsHandler();
        ReservationHandler payment = new PaymentHandler();
        ReservationHandler orderDish = new OrderDishHandler();

        // Формування ланцюга обробників
        availableSeats.SetNextHandler(payment);
        payment.SetNextHandler(orderDish);

        // Ініціалізація запиту
        availableSeats.HandleRequest("check seats");  // Початок з перевірки місць
        availableSeats.HandleRequest("payment");      // Перевірка оплати
        availableSeats.HandleRequest("order dish");   // Замовлення страви
    }
}
