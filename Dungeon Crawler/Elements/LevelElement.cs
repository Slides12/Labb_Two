//Det ska finns en abstrakt basklass som jag valt att kalla “LevelElement”. 
//Eftersom den är abstrakt så kan man inte ha instanser av denna, 
//utan den används för att definiera basfunktionalitet som andra klasser sedan kan ärva. 

//LevelElement ska ha properties för (X, Y)-position, en char som lagrar vilket tecken en klass ritas ut med (t.ex. kommer “Wall” använda #-tecknet), 

//samt en ConsoleColor som lagrar vilken färg tecknet ska ritas med. Den ska dessutom ha en publik Draw-metod (utan parametrar), 

//som vi kan anropa för att rita ut ett LevelElement med rätt färg och tecken på rätt plats.

abstract class LevelElement
{
    public int yPos; 
    public int xPos;
    public char elementChar;
    public ConsoleColor color;




    public void Draw()
    {

    }

}
