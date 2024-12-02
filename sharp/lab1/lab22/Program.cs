using System;

// Абстрактний клас
public abstract class AbstractOrder
{
    // Шаблонний метод, що визначає загальний алгоритм
    public void ProcessOrder()
    {
        TakeOrder();
        PrepareFood();
        ServeFood();
        TakePayment();
    }

    protected abstract void TakeOrder();      // Крок 1: Прийняти замовлення
    protected abstract void PrepareFood();    // Крок 2: Приготувати їжу
    protected abstract void ServeFood();      // Крок 3: Подати їжу
    protected abstract void TakePayment();    // Крок 4: Прийняти оплату
}

// Конкретне замовлення для ресторану
public class DineInOrder : AbstractOrder
{
    protected override void TakeOrder()
    {
        Console.WriteLine("Приймаємо замовлення для їди в ресторані.");
    }

    protected override void PrepareFood()
    {
        Console.WriteLine("Готуємо страви для їди в ресторані.");
    }

    protected override void ServeFood()
    {
        Console.WriteLine("Подати страви до столика.");
    }

    protected override void TakePayment()
    {
        Console.WriteLine("Приймаємо оплату після їжі.");
    }
}

// Конкретне замовлення для доставки
public class DeliveryOrder : AbstractOrder
{
    protected override void TakeOrder()
    {
        Console.WriteLine("Приймаємо замовлення для доставки.");
    }

    protected override void PrepareFood()
    {
        Console.WriteLine("Готуємо страви для доставки.");
    }

    protected override void ServeFood()
    {
        Console.WriteLine("Запаковуємо страви для доставки.");
    }

    protected override void TakePayment()
    {
        Console.WriteLine("Приймаємо оплату онлайн.");
    }
}

// Клієнт
class Program
{
    static void Main(string[] args)
    {
        // Створення замовлення для їди в ресторані
        AbstractOrder dineIn = new DineInOrder();
        dineIn.ProcessOrder();

        Console.WriteLine("\n");

        // Створення замовлення для доставки
        AbstractOrder delivery = new DeliveryOrder();
        delivery.ProcessOrder();
    }
}
