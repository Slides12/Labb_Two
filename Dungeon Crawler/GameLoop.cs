using System.Xml.Linq;


class GameLoop
{
    LevelData levelData = new LevelData();
    Player player = new Player() {Name = "Daniel" };
    public ConsoleKeyInfo cki;


    public void StartGame() {

        levelData.Load(@"Levels\Level1.txt");
        
        foreach(var element in levelData.Elements)
        {
            if(element is Player)
            {
                this.player.yPos = element.yPos;
                this.player.xPos = element.xPos;

            }
        }


        StartLoop();
    }

    private void StartLoop()
    {
        while (true)
        {
            if(player.Health > 0) 
            { 
            player.UpdateMovement(cki, levelData.Elements);
            UpdateEnemyMovements(levelData.Elements, player);
            player.FogOfWar(levelData.Elements);
            UpdateHealthAndMoveCount();
            cki = Console.ReadKey();
            }
            else
            {
                DisplayGameOver();
            }
        }
    }


    private void UpdateHealthAndMoveCount()
    {
        ResetHealthAndMoveCount();

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.SetCursorPosition(0, 0);

        Console.WriteLine($"Name: {player.Name}  -  Health: {player.Health}/100  -  Turn: {player.moveCount}");
        Console.ResetColor();
    }



    public static void UpdateEnemyMovements(List<LevelElement> elements, Player player)
    {
        try
        { 
        foreach (var element in elements)
        {
            (element as Enemy)?.Update(elements, player);
            (element as Wall)?.UpdateYX();

        }
        }
        catch
        {
        }
    }



    public void ResetHealthAndMoveCount()
    {
        Console.SetCursorPosition(0, 0);
        Console.Write(new String(' ', Console.BufferWidth));
        
    }


    public void DisplayGameOver()
    {

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.SetCursorPosition(0, 25);

        Console.WriteLine($"GAME OVER, you were killed.");
        Console.ResetColor();

    }
}
