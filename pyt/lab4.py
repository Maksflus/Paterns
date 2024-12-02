from abc import ABC, abstractmethod

# Абстрактний продукт: Страва
class Dish(ABC):
    @abstractmethod
    def serve(self):
        pass

# Абстрактний продукт: Напій
class Drink(ABC):
    @abstractmethod
    def serve(self):
        pass

# Конкретний продукт: Італійська паста
class ItalianPasta(Dish):
    def serve(self):
        print("Сервіруємо італійську пасту.")

# Конкретний продукт: Італійське вино
class ItalianWine(Drink):
    def serve(self):
        print("Сервіруємо італійське вино.")

# Конкретний продукт: Японські суші
class JapaneseSushi(Dish):
    def serve(self):
        print("Сервіруємо японські суші.")

# Конкретний продукт: Японське саке
class JapaneseSake(Drink):
    def serve(self):
        print("Сервіруємо японське саке.")

# Абстрактна фабрика
class RestaurantFactory(ABC):
    @abstractmethod
    def create_dish(self):
        pass

    @abstractmethod
    def create_drink(self):
        pass

# Конкретна фабрика: Італійський ресторан
class ItalianRestaurantFactory(RestaurantFactory):
    def create_dish(self):
        return ItalianPasta()

    def create_drink(self):
        return ItalianWine()

# Конкретна фабрика: Японський ресторан
class JapaneseRestaurantFactory(RestaurantFactory):
    def create_dish(self):
        return JapaneseSushi()

    def create_drink(self):
        return JapaneseSake()

# Демонстрація
if __name__ == "__main__":
    # Італійський ресторан
    italian_factory = ItalianRestaurantFactory()
    italian_dish = italian_factory.create_dish()
    italian_drink = italian_factory.create_drink()
    italian_dish.serve()
    italian_drink.serve()

    # Японський ресторан
    japanese_factory = JapaneseRestaurantFactory()
    japanese_dish = japanese_factory.create_dish()
    japanese_drink = japanese_factory.create_drink()
    japanese_dish.serve()
    japanese_drink.serve()
