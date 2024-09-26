//Det ska finns en abstrakt basklass som jag valt att kalla “LevelElement”. x
//Eftersom den är abstrakt så kan man inte ha instanser av denna, x
//utan den används för att definiera basfunktionalitet som andra klasser sedan kan ärva. x

//LevelElement ska ha properties för (X, Y)-position, en char som lagrar vilket tecken en klass ritas ut med (t.ex. kommer “Wall” använda #-tecknet), x

//samt en ConsoleColor som lagrar vilken färg tecknet ska ritas med. Den ska dessutom ha en publik Draw-metod (utan parametrar), x

//som vi kan anropa för att rita ut ett LevelElement med rätt färg och tecken på rätt plats.

abstract class LevelElement
{
    public int yPos { get; set; }
    public int xPos { get; set; }
    private int lastXPos;
    private int lastYPos;

    public char elementChar;
    public ConsoleColor color;
    public Position Position { get; set; }




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


    private void ResetLastPos()
    {
        Console.SetCursorPosition(lastXPos, lastYPos);
        Console.Write(" ");
    }

}
