using System;

public interface IReservationImplementation
{
    void Reserve(string details);
}

public class OnlineReservation : IReservationImplementation
{
    public void Reserve(string details)
    {
        Console.WriteLine($"Бронювання онлайн: {details}");
    }
}

public class PhoneReservation : IReservationImplementation
{
    public void Reserve(string details)
    {
        Console.WriteLine($"Бронювання за телефоном: {details}");
    }
}

public abstract class Reservation
{
    protected IReservationImplementation implementation;

    public Reservation(IReservationImplementation implementation)
    {
        this.implementation = implementation;
    }

    public abstract void MakeReservation(string details);
}

public class TableReservation : Reservation
{
    public TableReservation(IReservationImplementation implementation) : base(implementation) { }

    public override void MakeReservation(string details)
    {
        Console.WriteLine("Резервація столика:");
        implementation.Reserve(details);
    }
}

public class MenuReservation : Reservation
{
    public MenuReservation(IReservationImplementation implementation) : base(implementation) { }

    public override void MakeReservation(string details)
    {
        Console.WriteLine("Резервація страв меню:");
        implementation.Reserve(details);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        IReservationImplementation online = new OnlineReservation();
        IReservationImplementation phone = new PhoneReservation();

        Reservation tableReservation = new TableReservation(online);
        Reservation menuReservation = new MenuReservation(phone);

        tableReservation.MakeReservation("Столик #5 на 19:00");
        menuReservation.MakeReservation("Піца та салат на завтра");
    }
}
