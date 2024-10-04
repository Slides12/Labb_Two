
abstract class LevelElement
{
    public int yPos { get; set; }
    public int xPos { get; set; }
    public int lastXPos;
    public int lastYPos;

    public char elementChar;
    public ConsoleColor color;
    public Position Position { get; set; }
    public bool hasBeenSeen = false;




    public void Draw()
    {
        ResetLastPos();

        Console.SetCursorPosition(xPos, yPos);
        Console.ForegroundColor = this.color;
        Console.Write(this.elementChar);
        Console.ResetColor();
        lastXPos = xPos;
        lastYPos = yPos;
        Console.CursorVisible = false;
    }


    public void ResetLastPos()
    {
        if (!hasBeenSeen) { 
        Console.SetCursorPosition(lastXPos, lastYPos);
        Console.Write(" ");
        }
    }

}
