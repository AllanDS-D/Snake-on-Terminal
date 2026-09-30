using snake.World;
using System.Threading;


public class IMain
{
    public static void Main(string[] args)
    {
        Console.Clear();
        World teste = new();        

        Console.CursorVisible = false;
        while (true)
        {            
            Console.SetCursorPosition(0,0);
            teste.Update();
            teste.ShowWorld();            
            Thread.Sleep(100);
        }
    }
    
}
