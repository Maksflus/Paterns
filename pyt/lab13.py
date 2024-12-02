# Реальний об'єкт
class Restaurant:
    def book_table(self, number_of_seats):
        print(f"Столик на {number_of_seats} місць заброньовано.")

    def order_dish(self, dish_name):
        print(f"Страва {dish_name} замовлена.")


# Проксі-об'єкт
class ReservationProxy:
    def __init__(self):
        self._restaurant = Restaurant()

    def book_table(self, number_of_seats):
        print("Перевірка доступу до бронювання...")
        self._restaurant.book_table(number_of_seats)  # делегування реальному об'єкту

    def order_dish(self, dish_name):
        print("Перевірка доступу до замовлення страви...")
        self._restaurant.order_dish(dish_name)  # делегування реальному об'єкту


# Демонстрація
if __name__ == "__main__":
    reservation_proxy = ReservationProxy()
    reservation_proxy.book_table(4)  # виклик через проксі
    reservation_proxy.order_dish("Піца")  # виклик через проксі
