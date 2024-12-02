using System;

// Абстракція: Стан
public interface IOrderState
{
    void HandleRequest(OrderContext context);
}

// Контекст: Замовлення
public class OrderContext
{
    private IOrderState _state;

    public OrderContext(IOrderState state)
    {
        _state = state;
    }

    public void SetState(IOrderState state)
    {
        _state = state;
    }

    public void Request()
    {
        _state.HandleRequest(this);
    }
}

// Конкретний стан: Замовлення чекає на підтвердження
public class PendingState : IOrderState
{
    public void HandleRequest(OrderContext context)
    {
        Console.WriteLine("Замовлення чекає на підтвердження.");
        context.SetState(new ConfirmedState());
    }
}

// Конкретний стан: Замовлення підтверджено
public class ConfirmedState : IOrderState
{
    public void HandleRequest(OrderContext context)
    {
        Console.WriteLine("Замовлення підтверджено. Починається обробка.");
        context.SetState(new ProcessingState());
    }
}

// Конкретний стан: Замовлення обробляється
public class ProcessingState : IOrderState
{
    public void HandleRequest(OrderContext context)
    {
        Console.WriteLine("Замовлення обробляється.");
        context.SetState(new CompletedState());
    }
}

// Конкретний стан: Замовлення завершене
public class CompletedState : IOrderState
{
    public void HandleRequest(OrderContext context)
    {
        Console.WriteLine("Замовлення завершено.");
    }
}

// Клієнт
class Program
{
    static void Main(string[] args)
    {
        OrderContext order = new OrderContext(new PendingState());

        order.Request(); // Замовлення чекає на підтвердження
        order.Request(); // Замовлення підтверджено
        order.Request(); // Замовлення обробляється
        order.Request(); // Замовлення завершено
    }
}
