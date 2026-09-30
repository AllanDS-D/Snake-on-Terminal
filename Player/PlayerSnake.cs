using snake.fruit;
using snake.position;

namespace snake.player;

public class Snake
{
    //public string Tag = "snake"; Se for Criar uma Tag crie uma CLASSE
    // public int Life { get; private set; } Não precisa de VIDA 
    public int Speed { get; private set; } // Velocidade da cobra
    public int Tamanho { get; private set; } // Tamanho do corpo da Cobra
    public string SnakeModel { get; private set; } // Sprite
    public List<Position> Body { get; set; } // Corpo Real da Cobra
    public ConsoleKey CurrentDirection { get; set; } = ConsoleKey.RightArrow;    

    public Snake(int speed, int tamanho, Position position, string snakeModel)
    {        
        Speed = speed;
        Tamanho = tamanho;
        SnakeModel = snakeModel;
        Body = [];
        Body.Add(position);
    }

    public void IncreaseSize()
    {
        Tamanho++;
    }

    public void SnakeMoveTo(ConsoleKeyInfo? button)
    {

        if (button.HasValue)
        {
            ConsoleKey key = button.Value.Key;

            if ((key == ConsoleKey.LeftArrow && CurrentDirection != ConsoleKey.RightArrow) ||
            (key == ConsoleKey.RightArrow && CurrentDirection != ConsoleKey.LeftArrow) ||
            (key == ConsoleKey.UpArrow && CurrentDirection != ConsoleKey.DownArrow) ||
            (key == ConsoleKey.DownArrow && CurrentDirection != ConsoleKey.UpArrow))
            {
                CurrentDirection = key;
            }
        }




        Position head = Body[0];
        Position newHead = null;

        if (CurrentDirection == ConsoleKey.LeftArrow)
            newHead = new Position(head.X, head.Y - Speed);
        else if (CurrentDirection == ConsoleKey.RightArrow)
            newHead = new Position(head.X, head.Y + Speed);
        else if (CurrentDirection == ConsoleKey.DownArrow)
            newHead = new Position(head.X + Speed, head.Y);
        else if (CurrentDirection == ConsoleKey.UpArrow)
            newHead = new Position(head.X - Speed, head.Y);

        if (newHead != null)
        {
            Body.Insert(0, newHead);

            if (Body.Count > Tamanho) Body.RemoveAt(Body.Count - 1);
        }
    }

    public bool GotFruit(Position fruitPosition)
    {
        Position head = Body[0];
        return head.X == fruitPosition.X && head.Y == fruitPosition.Y;
    }    
}