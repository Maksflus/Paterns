# Підсистема бронювання столиків
class ReservationSystem:
    def book_table(self, name):
        print(f"Столик заброньовано на ім'я: {name}")

# Підсистема меню
class MenuSystem:
    def order_food(self, food_item):
        print(f"Страва {food_item} замовлена")

# Підсистема виставлення рахунків
class BillingSystem:
    def generate_bill(self, amount):
        print(f"Виставлено рахунок на суму: {amount} грн")

# Фасад
class RestaurantFacade:
    def __init__(self):
        self._reservation_system = ReservationSystem()
        self._menu_system = MenuSystem()
        self._billing_system = BillingSystem()

    def dine_out(self, name, food_item, amount):
        self._reservation_system.book_table(name)
        self._menu_system.order_food(food_item)
        self._billing_system.generate_bill(amount)

# Демонстрація
if __name__ == "__main__":
    facade = RestaurantFacade()
    facade.dine_out("Максим", "Піца", 250)
