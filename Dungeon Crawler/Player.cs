//Slutligen har vi klasserna “Rat” och “Snake” som initialiserar sina nedärvda
//properties med de unika egenskaper som respektive fiende har,
//samt även implementerar Update-metoden på sina egna unika sätt.


//Player: HP = 100, Attack = 2d6 + 2, Defence = 2d6 + 0

//Rat: HP = 10, Attack = 1d6 + 3, Defence = 1d6 + 1


//Snake: HP = 25, Attack = 3d4 + 2, Defence = 1d8 + 5


using System.Xml.Linq;

class Player : LevelElement
{
    public string Name { get; set; }
    public int Health { get; set; }

    public Dice attackDice;
    public Dice defencekDice;

    public ConsoleKeyInfo cki;
    public int moveCount;



    public Player()
    {
        this.Name = "Player";
        this.Health = 100;
        this.attackDice = new Dice(2, 6, 2);
        this.defencekDice = new Dice(2, 6, 0);
        this.elementChar = '@';
        this.color = ConsoleColor.Blue;

    }


    public void UpdateMovement(ConsoleKeyInfo cki, List<LevelElement> elements)
    {

        int nextX = this.xPos;
        int nextY = this.yPos;

        if (cki.Key == ConsoleKey.LeftArrow || cki.Key == ConsoleKey.A)
        {
            nextX -= 1; 
        }
        else if (cki.Key == ConsoleKey.RightArrow || cki.Key == ConsoleKey.D)
        {
            nextX += 1; 
        }
        else if (cki.Key == ConsoleKey.DownArrow || cki.Key == ConsoleKey.S)
        {
            nextY += 1; 
        }
        else if (cki.Key == ConsoleKey.UpArrow || cki.Key == ConsoleKey.W)
        {
            nextY -= 1; 
        }

        if (!IsAWall(nextX, nextY, elements))
        {
            this.xPos = nextX;
            this.yPos = nextY;
        }

        this.moveCount++;
        base.Draw();
    }




    public bool IsAWall(int nextX, int nextY, List<LevelElement> elements)
    {
        for (int i = 0; i < elements.Count; i++)
        {
            if (elements[i].elementChar == '#')
            {
                if (elements[i].xPos == nextX && elements[i].yPos == nextY)
                {
                    return true;
                }
            }
        }
        return false;

    }




}