# Клас, що представляє замовлення
class MealOrder:
    def __init__(self):
        self.main_dish = None
        self.side_dish = None
        self.drink = None
        self.dessert = None

    def __str__(self):
        return (f"Основна страва: {self.main_dish}, Гарнір: {self.side_dish}, "
                f"Напій: {self.drink}, Десерт: {self.dessert}")


# Абстрактний будівельник
class MealBuilder:
    def __init__(self):
        self.meal = MealOrder()

    def build_main_dish(self):
        pass

    def build_side_dish(self):
        pass

    def build_drink(self):
        pass

    def build_dessert(self):
        pass

    def get_meal(self):
        return self.meal


# Конкретний будівельник: Італійське меню
class ItalianMealBuilder(MealBuilder):
    def build_main_dish(self):
        self.meal.main_dish = "Паста карбонара"

    def build_side_dish(self):
        self.meal.side_dish = "Брускетта"

    def build_drink(self):
        self.meal.drink = "Червоне вино"

    def build_dessert(self):
        self.meal.dessert = "Тірамісу"


# Конкретний будівельник: Японське меню
class JapaneseMealBuilder(MealBuilder):
    def build_main_dish(self):
        self.meal.main_dish = "Суші"

    def build_side_dish(self):
        self.meal.side_dish = "Місо суп"

    def build_drink(self):
        self.meal.drink = "Саке"

    def build_dessert(self):
        self.meal.dessert = "Мочі"


# Директор
class MealDirector:
    def __init__(self):
        self.builder = None

    def set_builder(self, builder):
        self.builder = builder

    def construct_meal(self):
        self.builder.build_main_dish()
        self.builder.build_side_dish()
        self.builder.build_drink()
        self.builder.build_dessert()
        return self.builder.get_meal()


# Демонстрація
if __name__ == "__main__":
    director = MealDirector()

    # Італійське меню
    italian_builder = ItalianMealBuilder()
    director.set_builder(italian_builder)
    italian_meal = director.construct_meal()
    print("Італійське меню:")
    print(italian_meal)

    # Японське меню
    japanese_builder = JapaneseMealBuilder()
    director.set_builder(japanese_builder)
    japanese_meal = director.construct_meal()
    print("\nЯпонське меню:")
    print(japanese_meal)
