from abc import ABC, abstractmethod

# Клас для позицій меню
class MenuItem:
    def __init__(self, name, price):
        self.name = name
        self.price = price

    def accept(self, visitor):
        visitor.visit(self)

# Інтерфейс для відвідувачів
class IOrderVisitor(ABC):
    @abstractmethod
    def visit(self, item):
        pass

# Клас для замовлення
class Order:
    def __init__(self):
        self.items = []

    def add_item(self, item):
        self.items.append(item)

    def accept(self, visitor):
        for item in self.items:
            item.accept(visitor)

# Конкретний відвідувач для підрахунку вартості
class TotalPriceVisitor(IOrderVisitor):
    def __init__(self):
        self.total_price = 0

    def visit(self, item):
        self.total_price += item.price

# Клієнт
if __name__ == "__main__":
    # Створення позицій меню
    pizza = MenuItem("Піца", 200)
    pasta = MenuItem("Паста", 150)

    # Створення замовлення
    order = Order()
    order.add_item(pizza)
    order.add_item(pasta)

    # Створення відвідувача для підрахунку вартості
    total_price_visitor = TotalPriceVisitor()
    order.accept(total_price_visitor)

    print(f"Загальна вартість замовлення: {total_price_visitor.total_price}")
