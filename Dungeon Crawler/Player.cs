//Slutligen har vi klasserna “Rat” och “Snake” som initialiserar sina nedärvda
//properties med de unika egenskaper som respektive fiende har,
//samt även implementerar Update-metoden på sina egna unika sätt.


//Player: HP = 100, Attack = 2d6 + 2, Defence = 2d6 + 0

//Rat: HP = 10, Attack = 1d6 + 3, Defence = 1d6 + 1


//Snake: HP = 25, Attack = 3d4 + 2, Defence = 1d8 + 5


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
        this.Position = new Position(this.xPos, this.yPos);
        this.elementChar = '@';
        this.color = ConsoleColor.Blue;

    }


    public void UpdateMovement(ConsoleKeyInfo cki)
    {
        //Spelaren förflyttar sig 1 steg upp, ner, höger eller vänster varje omgång,
        //alternativt står still, beroende på vilken knapp användaren tryckt på.

        if(cki.Key == ConsoleKey.LeftArrow || cki.Key == ConsoleKey.A)
        {
            this.xPos -= 1;
        }
        else if (cki.Key == ConsoleKey.RightArrow || cki.Key == ConsoleKey.D)
        {
            this.xPos += 1;
        }
        else if (cki.Key == ConsoleKey.DownArrow || cki.Key == ConsoleKey.S)
        {
            this.yPos += 1;
        }
        else if (cki.Key == ConsoleKey.UpArrow || cki.Key == ConsoleKey.W)
        {
            this.yPos -= 1;
        }
        this.moveCount++;
        base.Draw();
    }
}