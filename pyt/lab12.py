# Flyweight для страв
class MenuItem:
    def __init__(self, name, price):
        self.name = name
        self.price = price

# Flyweight для столиків
class Table:
    def __init__(self, seats):
        self.seats = seats

# Замовлення
class Order:
    def __init__(self, menu_item, table, quantity):
        self.menu_item = menu_item
        self.table = table
        self.quantity = quantity

    def show_order_details(self):
        print(f"Замовлення: {self.quantity} x {self.menu_item.name} на столик з {self.table.seats} місцями")

# Фабрика Flyweight
class Restaurant:
    def __init__(self):
        self._menu_items = {}
        self._tables = {}

    def get_menu_item(self, name, price):
        if name not in self._menu_items:
            self._menu_items[name] = MenuItem(name, price)
        return self._menu_items[name]

    def get_table(self, seats):
        if seats not in self._tables:
            self._tables[seats] = Table(seats)
        return self._tables[seats]

    def create_order(self, menu_item_name, price, seats, quantity):
        menu_item = self.get_menu_item(menu_item_name, price)
        table = self.get_table(seats)
        order = Order(menu_item, table, quantity)
        order.show_order_details()

# Демонстрація
if __name__ == "__main__":
    restaurant = Restaurant()
    restaurant.create_order("Піца", 250, 4, 2)
    restaurant.create_order("Піца", 250, 4, 3)
    restaurant.create_order("Бургер", 150, 2, 1)
