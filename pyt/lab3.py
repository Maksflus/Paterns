from abc import ABC, abstractmethod

# Абстрактний клас страви
class Dish(ABC):
    @abstractmethod
    def prepare(self):
        pass

# Конкретні страви
class Pizza(Dish):
    def prepare(self):
        print("Приготування піци...")

class Pasta(Dish):
    def prepare(self):
        print("Приготування пасти...")

# Фабричний метод
class DishFactory(ABC):
    @abstractmethod
    def create_dish(self):
        pass

# Конкретні фабрики
class PizzaFactory(DishFactory):
    def create_dish(self):
        return Pizza()

class PastaFactory(DishFactory):
    def create_dish(self):
        return Pasta()

# Демонстрація
if __name__ == "__main__":
    # Фабрика піци
    pizza_factory = PizzaFactory()
    pizza = pizza_factory.create_dish()
    pizza.prepare()

    # Фабрика пасти
    pasta_factory = PastaFactory()
    pasta = pasta_factory.create_dish()
    pasta.prepare()
