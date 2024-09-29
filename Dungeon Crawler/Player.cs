//Slutligen har vi klasserna “Rat” och “Snake” som initialiserar sina nedärvda
//properties med de unika egenskaper som respektive fiende har,
//samt även implementerar Update-metoden på sina egna unika sätt.


//Player: HP = 100, Attack = 2d6 + 2, Defence = 2d6 + 0

//Rat: HP = 10, Attack = 1d6 + 3, Defence = 1d6 + 1


//Snake: HP = 25, Attack = 3d4 + 2, Defence = 1d8 + 5


using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

class Player : LevelElement
{
    public string Name { get; set; }
    public int Health { get; set; }

    public Dice attackDice { get; set; }
    public Dice defencekDice { get; set; }

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
        this.Position = new Position(this.xPos, this.yPos);

    }


    public void UpdateMovement(ConsoleKeyInfo cki, List<LevelElement> elements)
    {
        this.Position = new Position(this.xPos, this.yPos);

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

        if (IsAEnemy(nextX, nextY, elements))
        {
            ResetCombatLog();
            DisplayCombatLog(nextX, nextY, elements);
        }
        else
        {
            ResetCombatLog();
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
            if (elements[i].elementChar != '@')
            {
                if (elements[i].xPos == nextX && elements[i].yPos == nextY)
                {
                    return true;
                }
            }
        }
        return false;

    }


    public bool IsAEnemy(int nextX, int nextY, List<LevelElement> elements)
    {
        for (int i = 0; i < elements.Count; i++)
        {
            if (elements[i].elementChar == 's' || elements[i].elementChar == 'r')
            {
                if (elements[i].xPos == nextX && elements[i].yPos == nextY)
                {
                    return true;
                }
            }
        }
        return false;

    }

    public Enemy GetEnemy(int nextX, int nextY, List<LevelElement> elements)
    {
        for (int i = 0; i < elements.Count; i++)
        {
            if (elements[i].elementChar == 's' || elements[i].elementChar == 'r')
            {
                if (elements[i].xPos == nextX && elements[i].yPos == nextY)
                {
                    return (elements[i]as Enemy);
                }
            }
        }
        return null;

    }


    public void TakeDamage(int damageTaken)
    {
        Health -= damageTaken;

        if(Health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {

    }



    public void DisplayCombatLog(int nextX, int nextY, List<LevelElement> elements)
    {
        int playerATK = attackDice.Throw();
        int playerDEF = defencekDice.Throw();

        int enemyATK = GetEnemy(nextX, nextY, elements).AttackDice.Throw();
        int enemyDEF = GetEnemy(nextX, nextY, elements).DefencekDice.Throw();
        string playerDidDamage = "";
        string enemyDidDamage = "";




        if (playerATK > enemyDEF)
        {
            GetEnemy(nextX, nextY, elements)?.TakeDamage(playerATK - enemyDEF,elements);
            Console.SetCursorPosition(55, 1);
            Console.ForegroundColor = ConsoleColor.Green;
            playerDidDamage = "Wow, you scratched it. ";
        }
        else if (playerATK <= enemyDEF)
        {
            Console.SetCursorPosition(55, 1);
            Console.ForegroundColor = ConsoleColor.Red;

            playerDidDamage = "You literally did 0 damage. ";
        }

        Console.SetCursorPosition(0, 1);
        Console.WriteLine($"{Name} (ATK: {attackDice} => {playerATK}) attacked the {GetEnemy(nextX, nextY, elements)?.Name} (DEF: {GetEnemy(nextX, nextY, elements)?.DefencekDice} => {enemyDEF}), {playerDidDamage})");

        if (playerATK < enemyDEF)
        {
            Console.SetCursorPosition(55, 1);
            Console.ForegroundColor = ConsoleColor.Red;
            enemyDidDamage = "He f-ed you up. ";
        }
        else if (playerATK >= enemyDEF)
        {
            Console.SetCursorPosition(55, 1);
            Console.ForegroundColor = ConsoleColor.Green;

            enemyDidDamage = $"{GetEnemy(nextX, nextY, elements)?.Name} did 0 damage. ";
        }

        Console.SetCursorPosition(0, 2);
        Console.WriteLine($"The {GetEnemy(nextX, nextY, elements)?.Name} (ATK: {GetEnemy(nextX, nextY, elements)?.AttackDice} => {enemyATK}) attacked the (DEF: {defencekDice} => {playerDEF}), {enemyDidDamage})");
        
        if (enemyATK > playerDEF)
        {
            TakeDamage(enemyATK - playerDEF);
        }
    }

    public void ResetCombatLog()
    {
        Console.SetCursorPosition(0, 1);
        Console.Write(new String(' ', Console.BufferWidth));
        Console.SetCursorPosition(0, 2);
        Console.Write(new String(' ', Console.BufferWidth));
    }
}
