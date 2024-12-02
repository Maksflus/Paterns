class OldReservationSystem:
    def reserve_table(self, table_id):
        print(f"Стара система: столик #{table_id} зарезервовано.")

class INewReservationSystem:
    def make_reservation(self, table_id):
        raise NotImplementedError("Цей метод має бути реалізований!")

class ReservationAdapter(INewReservationSystem):
    def __init__(self, old_system):
        self.old_system = old_system

    def make_reservation(self, table_id):
        print("Адаптер перетворює запит...")
        self.old_system.reserve_table(table_id)

class Client:
    def __init__(self, reservation_system):
        self.reservation_system = reservation_system

    def reserve_table(self, table_id):
        self.reservation_system.make_reservation(table_id)

# Демонстрація
if __name__ == "__main__":
    old_system = OldReservationSystem()
    adapter = ReservationAdapter(old_system)
    client = Client(adapter)

    print("Клієнт використовує новий інтерфейс для бронювання:")
    client.reserve_table("101")
