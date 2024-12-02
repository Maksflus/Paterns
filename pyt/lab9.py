from abc import ABC, abstractmethod

class MenuComponent(ABC):
    @abstractmethod
    def display(self, depth=0):
        pass

    def add(self, component):
        raise NotImplementedError("Метод не підтримується")

    def remove(self, component):
        raise NotImplementedError("Метод не підтримується")

class MenuItem(MenuComponent):
    def __init__(self, name, price):
        self.name = name
        self.price = price

    def display(self, depth=0):
        print(f"{'-' * depth} Страва: {self.name}, Ціна: {self.price} грн")

class MenuCategory(MenuComponent):
    def __init__(self, name):
        self.name = name
        self.components = []

    def add(self, component):
        self.components.append(component)

    def remove(self, component):
        self.components.remove(component)

    def display(self, depth=0):
        print(f"{'-' * depth} Категорія: {self.name}")
        for component in self.components:
            component.display(depth + 2)

# Демонстрація
if __name__ == "__main__":
    main_menu = MenuCategory("Головне меню")

    drinks = MenuCategory("Напої")
    drinks.add(MenuItem("Кава", 50))
    drinks.add(MenuItem("Чай", 30))

    desserts = MenuCategory("Десерти")
    desserts.add(MenuItem("Торт", 120))
    desserts.add(MenuItem("Морозиво", 70))

    main_menu.add(drinks)
    main_menu.add(desserts)

    main_menu.display()
