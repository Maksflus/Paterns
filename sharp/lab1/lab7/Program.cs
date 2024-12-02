using System;

public interface INewReservationSystem
{
    void MakeReservation(string tableId);
}

public class OldReservationSystem
{
    public void ReserveTable(string id)
    {
        Console.WriteLine($"Стара система: столик #{id} зарезервовано.");
    }
}

public class ReservationAdapter : INewReservationSystem
{
    private readonly OldReservationSystem _oldSystem;

    public ReservationAdapter(OldReservationSystem oldSystem)
    {
        _oldSystem = oldSystem;
    }

    public void MakeReservation(string tableId)
    {
        Console.WriteLine("Адаптер перетворює запит...");
        _oldSystem.ReserveTable(tableId);
    }
}

public class Client
{
    private readonly INewReservationSystem _reservationSystem;

    public Client(INewReservationSystem reservationSystem)
    {
        _reservationSystem = reservationSystem;
    }

    public void ReserveTable(string tableId)
    {
        _reservationSystem.MakeReservation(tableId);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        OldReservationSystem oldSystem = new OldReservationSystem();
        INewReservationSystem adapter = new ReservationAdapter(oldSystem);
        Client client = new Client(adapter);

        Console.WriteLine("Клієнт використовує новий інтерфейс для бронювання:");
        client.ReserveTable("101");
    }
}
