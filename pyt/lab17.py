from abc import ABC, abstractmethod

# Посередник
class BookingMediator(ABC):
    @abstractmethod
    def notify(self, sender, event):
        pass

# Конкретний посередник
class ConcreteBookingMediator(BookingMediator):
    def __init__(self):
        self.booking_systems = []
        self.order_systems = []

    def add_booking_system(self, booking_system):
        self.booking_systems.append(booking_system)

    def add_order_system(self, order_system):
        self.order_systems.append(order_system)

    def notify(self, sender, event):
        if event == "TableBooked":
            for order_system in self.order_systems:
                order_system.handle_order(sender)

# Колега: Система бронювання столиків
class BookingSystem:
    def __init__(self, mediator):
        self.mediator = mediator

    def book_table(self, customer):
        print(f"{customer} забронював столик.")
        self.mediator.notify(self, "TableBooked")

# Колега: Система замовлення страв
class OrderSystem:
    def __init__(self, mediator):
        self.mediator = mediator

    def handle_order(self, sender):
        print("Система замовлення страв отримала повідомлення про бронювання столика.")

# Клієнт
if __name__ == "__main__":
    mediator = ConcreteBookingMediator()

    booking_system = BookingSystem(mediator)
    order_system = OrderSystem(mediator)

    mediator.add_booking_system(booking_system)
    mediator.add_order_system(order_system)

    booking_system.book_table("Іван")
