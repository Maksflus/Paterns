# Ітератор
from abc import ABC, abstractmethod

class Iterator(ABC):
    @abstractmethod
    def has_next(self):
        pass

    @abstractmethod
    def next(self):
        pass

# Конкретний ітератор
class MenuIterator(Iterator):
    def __init__(self, menu_items):
        self._menu_items = menu_items
        self._position = 0

    def has_next(self):
        return self._position < len(self._menu_items)

    def next(self):
        if self.has_next():
            item = self._menu_items[self._position]
            self._position += 1
            return item
        return None

# Колекція
class Menu(ABC):
    @abstractmethod
    def create_iterator(self):
        pass

# Конкретна колекція
class RestaurantMenu(Menu):
    def __init__(self):
        self._menu_items = []

    def add_item(self, item):
        self._menu_items.append(item)

    def create_iterator(self):
        return MenuIterator(self._menu_items)

# Клієнт
if __name__ == "__main__":
    # Створення меню
    menu = RestaurantMenu()
    menu.add_item("Піца")
    menu.add_item("Паста")
    menu.add_item("Салат")

    # Отримання ітератора
    iterator = menu.create_iterator()

    # Перебір елементів меню
    while iterator.has_next():
        print(iterator.next())
