from abc import ABC, abstractmethod

class ReservationImplementation(ABC):
    @abstractmethod
    def reserve(self, details):
        pass

class OnlineReservation(ReservationImplementation):
    def reserve(self, details):
        print(f"Бронювання онлайн: {details}")

class PhoneReservation(ReservationImplementation):
    def reserve(self, details):
        print(f"Бронювання за телефоном: {details}")

class Reservation(ABC):
    def __init__(self, implementation):
        self.implementation = implementation

    @abstractmethod
    def make_reservation(self, details):
        pass

class TableReservation(Reservation):
    def make_reservation(self, details):
        print("Резервація столика:")
        self.implementation.reserve(details)

class MenuReservation(Reservation):
    def make_reservation(self, details):
        print("Резервація страв меню:")
        self.implementation.reserve(details)

# Демонстрація
if __name__ == "__main__":
    online = OnlineReservation()
    phone = PhoneReservation()

    table_reservation = TableReservation(online)
    menu_reservation = MenuReservation(phone)

    table_reservation.make_reservation("Столик #5 на 19:00")
    menu_reservation.make_reservation("Піца та салат на завтра")
