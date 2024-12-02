import copy

class MenuPrototype:
    def clone(self):
        raise NotImplementedError("Метод clone() має бути реалізований у підкласі.")

class Dish(MenuPrototype):
    def __init__(self, name, price):
        self.name = name
        self.price = price

    def clone(self):
        print(f"Копіювання страви: {self.name}")
        return copy.deepcopy(self)

    def display_info(self):
        print(f"Страва: {self.name}, Ціна: {self.price} грн")

# Демонстрація
if __name__ == "__main__":
    # Оригінальна страва
    original_dish = Dish("Паста Болоньєзе", 250)
    original_dish.display_info()

    # Клонування
    cloned_dish = original_dish.clone()
    cloned_dish.price = 200  # Зміна ціни у клона
    cloned_dish.display_info()
