using System;
using System.Collections.Generic;

public class Table
{
    public int TableId { get; private set; }
    public bool IsReserved { get; set; }

    public Table(int id)
    {
        TableId = id;
        IsReserved = false;
    }

    public override string ToString()
    {
        return $"Столик #{TableId} (Зарезервовано: {IsReserved})";
    }
}

public class TablePool
{
    private readonly List<Table> availableTables = new List<Table>();
    private readonly List<Table> reservedTables = new List<Table>();

    public TablePool(int count)
    {
        for (int i = 1; i <= count; i++)
        {
            availableTables.Add(new Table(i));
        }
    }

    public Table GetTable()
    {
        if (availableTables.Count > 0)
        {
            var table = availableTables[0];
            availableTables.RemoveAt(0);
            reservedTables.Add(table);
            table.IsReserved = true;
            return table;
        }
        else
        {
            Console.WriteLine("Немає доступних столиків!");
            return null;
        }
    }

    public void ReleaseTable(Table table)
    {
        if (table != null && reservedTables.Remove(table))
        {
            table.IsReserved = false;
            availableTables.Add(table);
            Console.WriteLine($"Столик #{table.TableId} звільнено.");
        }
    }

    public void DisplayStatus()
    {
        Console.WriteLine("Доступні столики:");
        availableTables.ForEach(t => Console.WriteLine(t));
        Console.WriteLine("Зарезервовані столики:");
        reservedTables.ForEach(t => Console.WriteLine(t));
    }
}

class Program
{
    static void Main(string[] args)
    {
        TablePool tablePool = new TablePool(5);

        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Бронювання столиків в ресторані:");

        var table1 = tablePool.GetTable();
        var table2 = tablePool.GetTable();

        tablePool.DisplayStatus();

        tablePool.ReleaseTable(table1);

        tablePool.DisplayStatus();
    }
}
