from abc import ABC, abstractmethod

# Абстракція: Суб'єкт
class Subject(ABC):
    @abstractmethod
    def attach(self, observer):
        pass

    @abstractmethod
    def detach(self, observer):
        pass

    @abstractmethod
    def notify(self):
        pass

# Абстракція: Спостерігач
class Observer(ABC):
    @abstractmethod
    def update(self, message):
        pass

# Конкретний Суб'єкт
class OrderSystem(Subject):
    def __init__(self):
        self._observers = []
        self._order_status = ""

    def attach(self, observer):
        self._observers.append(observer)

    def detach(self, observer):
        self._observers.remove(observer)

    def notify(self):
        for observer in self._observers:
            observer.update(self._order_status)

    def set_order_status(self, status):
        self._order_status = status
        self.notify()

# Конкретний Спостерігач
class Customer(Observer):
    def __init__(self, name):
        self._customer_name = name

    def update(self, message):
        print(f"Користувач {self._customer_name} отримав оновлення: {message}")

# Клієнт
if __name__ == "__main__":
    order_system = OrderSystem()

    customer1 = Customer("Іван")
    customer2 = Customer("Марія")

    order_system.attach(customer1)
    order_system.attach(customer2)

    order_system.set_order_status("Замовлення прийняте")

    order_system.detach(customer1)

    order_system.set_order_status("Замовлення обробляється")
