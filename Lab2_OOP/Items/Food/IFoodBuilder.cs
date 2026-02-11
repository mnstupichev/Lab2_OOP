namespace Lab2_OOP.Items.Food;

public interface IFoodBuilder
{
    IFoodBuilder WithName(string name);
    IFoodBuilder WithHealthRestoration(int healthRestoration);
    IFoodBuilder WithQuantity(int quantity);
    Food Build();
}
