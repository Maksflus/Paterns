using System;

// Клас, що представляє замовлення
public class MealOrder
{
    public string MainDish { get; set; }
    public string SideDish { get; set; }
    public string Drink { get; set; }
    public string Dessert { get; set; }

    public override string ToString()
    {
        return $"Основна страва: {MainDish}, Гарнір: {SideDish}, Напій: {Drink}, Десерт: {Dessert}";
    }
}

// Абстрактний будівельник
public abstract class MealBuilder
{
    protected MealOrder meal = new MealOrder();
    public abstract void BuildMainDish();
    public abstract void BuildSideDish();
    public abstract void BuildDrink();
    public abstract void BuildDessert();

    public MealOrder GetMeal()
    {
        return meal;
    }
}

// Конкретний будівельник: Італійське меню
public class ItalianMealBuilder : MealBuilder
{
    public override void BuildMainDish()
    {
        meal.MainDish = "Паста карбонара";
    }

    public override void BuildSideDish()
    {
        meal.SideDish = "Брускетта";
    }

    public override void BuildDrink()
    {
        meal.Drink = "Червоне вино";
    }

    public override void BuildDessert()
    {
        meal.Dessert = "Тірамісу";
    }
}

// Конкретний будівельник: Японське меню
public class JapaneseMealBuilder : MealBuilder
{
    public override void BuildMainDish()
    {
        meal.MainDish = "Суші";
    }

    public override void BuildSideDish()
    {
        meal.SideDish = "Місо суп";
    }

    public override void BuildDrink()
    {
        meal.Drink = "Саке";
    }

    public override void BuildDessert()
    {
        meal.Dessert = "Мочі";
    }
}

// Директор
public class MealDirector
{
    private MealBuilder builder;

    public void SetBuilder(MealBuilder builder)
    {
        this.builder = builder;
    }

    public MealOrder ConstructMeal()
    {
        builder.BuildMainDish();
        builder.BuildSideDish();
        builder.BuildDrink();
        builder.BuildDessert();
        return builder.GetMeal();
    }
}

// Демонстрація
class Program
{
    static void Main(string[] args)
    {
        MealDirector director = new MealDirector();

        // Італійське меню
        var italianBuilder = new ItalianMealBuilder();
        director.SetBuilder(italianBuilder);
        MealOrder italianMeal = director.ConstructMeal();
        Console.WriteLine("Італійське меню:");
        Console.WriteLine(italianMeal);

        // Японське меню
        var japaneseBuilder = new JapaneseMealBuilder();
        director.SetBuilder(japaneseBuilder);
        MealOrder japaneseMeal = director.ConstructMeal();
        Console.WriteLine("\nЯпонське меню:");
        Console.WriteLine(japaneseMeal);
    }
}
