from abc import ABC, abstractmethod

# Абстрактний клас
class AbstractOrder(ABC):
    # Шаблонний метод
    def process_order(self):
        self.take_order()
        self.prepare_food()
        self.serve_food()
        self.take_payment()

    @abstractmethod
    def take_order(self):
        pass

    @abstractmethod
    def prepare_food(self):
        pass

    @abstractmethod
    def serve_food(self):
        pass

    @abstractmethod
    def take_payment(self):
        pass

# Конкретне замовлення для ресторану
class DineInOrder(AbstractOrder):
    def take_order(self):
        print("Приймаємо замовлення для їди в ресторані.")

    def prepare_food(self):
        print("Готуємо страви для їди в ресторані.")

    def serve_food(self):
        print("Подати страви до столика.")

    def take_payment(self):
        print("Приймаємо оплату після їжі.")

# Конкретне замовлення для доставки
class DeliveryOrder(AbstractOrder):
    def take_order(self):
        print("Приймаємо замовлення для доставки.")

    def prepare_food(self):
        print("Готуємо страви для доставки.")

    def serve_food(self):
        print("Запаковуємо страви для доставки.")

    def take_payment(self):
        print("Приймаємо оплату онлайн.")

# Клієнт
if __name__ == "__main__":
    # Створення замовлення для їди в ресторані
    dine_in = DineInOrder()
    dine_in.process_order()

    print("\n")

    # Створення замовлення для доставки
    delivery = DeliveryOrder()
    delivery.process_order()
