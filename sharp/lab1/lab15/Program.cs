using System;

// Інтерфейс команди
public interface ICommand
{
    void Execute();
}

// Отримувач, який виконує операції
public class ReservationReceiver
{
    public void BookTable()
    {
        Console.WriteLine("Столик заброньовано.");
    }

    public void OrderDish()
    {
        Console.WriteLine("Страва замовлена.");
    }

    public void ProcessPayment()
    {
        Console.WriteLine("Платіж оброблено.");
    }
}

// Конкретна команда для бронювання столика
public class BookTableCommand : ICommand
{
    private readonly ReservationReceiver _receiver;

    public BookTableCommand(ReservationReceiver receiver)
    {
        _receiver = receiver;
    }

    public void Execute()
    {
        _receiver.BookTable();
    }
}

// Конкретна команда для замовлення страви
public class OrderDishCommand : ICommand
{
    private readonly ReservationReceiver _receiver;

    public OrderDishCommand(ReservationReceiver receiver)
    {
        _receiver = receiver;
    }

    public void Execute()
    {
        _receiver.OrderDish();
    }
}

// Конкретна команда для обробки платежу
public class ProcessPaymentCommand : ICommand
{
    private readonly ReservationReceiver _receiver;

    public ProcessPaymentCommand(ReservationReceiver receiver)
    {
        _receiver = receiver;
    }

    public void Execute()
    {
        _receiver.ProcessPayment();
    }
}

// Клас, що викликає команди
public class CommandInvoker
{
    private ICommand _command;

    public void SetCommand(ICommand command)
    {
        _command = command;
    }

    public void ExecuteCommand()
    {
        _command.Execute();
    }
}

// Клієнт
class Program
{
    static void Main(string[] args)
    {
        // Створення отримувача
        var receiver = new ReservationReceiver();

        // Створення конкретних команд
        var bookTableCommand = new BookTableCommand(receiver);
        var orderDishCommand = new OrderDishCommand(receiver);
        var processPaymentCommand = new ProcessPaymentCommand(receiver);

        // Створення інвокера
        var invoker = new CommandInvoker();

        // Виконання команд через інвокера
        invoker.SetCommand(bookTableCommand);
        invoker.ExecuteCommand();

        invoker.SetCommand(orderDishCommand);
        invoker.ExecuteCommand();

        invoker.SetCommand(processPaymentCommand);
        invoker.ExecuteCommand();
    }
}
