using snake.player;
using snake.fruit;
using snake.position;

namespace snake.World;

public class World
{
    public int Width = 20;
    public int Height = 20;

    public string[,] TWorld;
    public Snake player;
    public Fruits fruit;
    public int score = 0;
    public int bonusChain = 0;



    public World()
    {
        player = new(1, 1, new(Width / 2, Height / 2), "+");
        fruit = new("@");
        TWorld = new string[Width, Height];
    }

    public void PlaceObject()
    {
        // Create a "Empty" world filled with .
        for (int i = 0; i < Width; i++)
        {
            for (int j = 0; j < Height; j++)
            {
                TWorld[i, j] = ".";
            }
        }

        // Place the Snake Symbol on the world
        foreach (var part in player.Body)
        {
            if (part.X >= 0 && part.X < Width && part.Y >= 0 && part.Y < Height)
            {
                TWorld[part.X, part.Y] = player.SnakeModel;
            }
        }

        // Place a fruit Symbol on the world
        if (fruit.Fruitposition.X >= 0 && fruit.Fruitposition.X < Width &&
        fruit.Fruitposition.Y >= 0 && fruit.Fruitposition.Y < Height)
        {
            TWorld[fruit.Fruitposition.X, fruit.Fruitposition.Y] = fruit.FruitModel;
        }
    }

    public void PlaceNewFruit()
    {
        do
        {
            fruit = new("@");
        }
        while (IsFruitOverSnake());
    }

    private bool IsFruitOverSnake()
    {
        foreach (var part in player.Body)
        {

            if (part == fruit.Fruitposition)
            {
                return true;
            }
        }
        return false;
    }

    public void Update()
    {
        ConsoleKeyInfo? pressedKey = null;
        if (Console.KeyAvailable)
        {
            pressedKey = Console.ReadKey(true);
        }
        player.SnakeMoveTo(pressedKey);

        if (player.GotFruit(fruit.Fruitposition))
        {
            score += 100;
            bonusChain++;
            if (bonusChain >= 5)
            {
                score += 400;
                bonusChain = 0;
            }
            player.IncreaseSize();
            PlaceNewFruit();
        }

        if (GameOver())
        {
            Console.Clear();
            Console.WriteLine($"You Died\nTotal score: {score}\nTamanho da Cobra:{player.Tamanho}");
            Console.WriteLine("Deseja jogar novamente ? (s / n)");
            string res = Console.ReadLine()!.ToUpper();
            if (res == "S" || res == "SIM")
            {
                ResetGame();
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }

    public void ShowWorld()
    {
        PlaceObject();

        for (int i = 0; i < Width; i++)
        {
            string[] temp = new string[Height];
            for (int j = 0; j < Height; j++)
            {
                temp[j] = TWorld[i, j];
            }
            Console.WriteLine(string.Join(' ', temp));
        }
    }

    public void ResetGame()
    {
        Console.Clear();
        TWorld = new string[Width, Height];
        player = new(1, 1, new(Width / 2, Height / 2), "+");
        fruit = new("@");
        score = 0;
        bonusChain = 0;
    }

    public bool GameOver()
    {
        Position head = player.Body[0];

        // verifica se colidiu com paredes o mundo
        if (head.X < 0 || head.X >= Width || head.Y < 0 || head.Y >= Height)
        {
            return true;
        }

        // Verifica se colidiu com o proprio corpo
        for (int i = 1; i < player!.Body.Count; i++)
        {
            if (head == player.Body[i]) return true;
        }
        // retorna falso se não conlidiu com nada a cima
        return false;
    }
}