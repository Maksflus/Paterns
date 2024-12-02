from abc import ABC, abstractmethod

class Order(ABC):
    @abstractmethod
    def get_cost(self):
        pass

    @abstractmethod
    def get_description(self):
        pass

class BasicOrder(Order):
    def get_cost(self):
        return 100  # базова ціна

    def get_description(self):
        return "Основне замовлення"

class OrderDecorator(Order):
    def __init__(self, order):
        self._order = order

    def get_cost(self):
        return self._order.get_cost()

    def get_description(self):
        return self._order.get_description()

class DrinkDecorator(OrderDecorator):
    def get_cost(self):
        return self._order.get_cost() + 50  # ціна за напій

    def get_description(self):
        return self._order.get_description() + ", Напій"

class DessertDecorator(OrderDecorator):
    def get_cost(self):
        return self._order.get_cost() + 30  # ціна за десерт

    def get_description(self):
        return self._order.get_description() + ", Десерт"

# Демонстрація
if __name__ == "__main__":
    order = BasicOrder()
    print(f"Опис: {order.get_description()}, Вартість: {order.get_cost()} грн")

    # Декорування замовлення
    order = DrinkDecorator(order)
    print(f"Опис: {order.get_description()}, Вартість: {order.get_cost()} грн")

    order = DessertDecorator(order)
    print(f"Опис: {order.get_description()}, Вартість: {order.get_cost()} грн")
