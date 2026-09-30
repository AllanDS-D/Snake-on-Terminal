using snake.position;

namespace snake.fruit;
public class Fruits
{    
    private Random random = new();    
    public string FruitModel { get; set; }
    public Position Fruitposition { get; set; }


    public Fruits(string fruitModel)
    {        
        FruitModel = fruitModel;
        Fruitposition = FruitGeneratorPosition();
    }

    public Position FruitGeneratorPosition()
    {                
        return new(random.Next(0, 20), random.Next(0, 20));   
    }    


    
}