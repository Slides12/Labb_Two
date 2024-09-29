//Slutligen har vi klasserna “Rat” och “Snake” som initialiserar sina nedärvda
//properties med de unika egenskaper som respektive fiende har,
//samt även implementerar Update-metoden på sina egna unika sätt.


//Player: HP = 100, Attack = 2d6 + 2, Defence = 2d6 + 0

//Rat: HP = 10, Attack = 1d6 + 3, Defence = 1d6 + 1


//Snake: HP = 25, Attack = 3d4 + 2, Defence = 1d8 + 5


using System.Runtime.ConstrainedExecution;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

class Rat : Enemy
{

    public Rat()
    {
        this.Name = "Rat";
        this.Health = 10;
        this.AttackDice = new Dice(1,6,3);
        this.DefencekDice = new Dice(1,6,1);
        this.elementChar = 'r';
        this.color = ConsoleColor.Red;
        this.Position = new Position(this.xPos, this.yPos);


    }



    public override void Update(List<LevelElement> elements, Player player)
    {
        this.Position = new Position(this.xPos, this.yPos);
        

        Random rand = new Random();
        int direction = rand.Next(0, 4);
        int nextX = this.xPos;
        int nextY = this.yPos;
        
        if (direction == 0)
        {
            nextX -= 1;
        }
        else if (direction == 1)
        {
            nextX += 1;
        }
        else if (direction == 2)
        {
            nextY += 1;
        }
        else if (direction == 3)
        {
            nextY -= 1;
        }


        if (!IsAWall(nextX, nextY, elements))
        {
            if (IsPlayerAtPos(nextX, nextY, player))
            {
                DisplayCombatLog(nextX, nextY, player, elements);
            }
            else
            {
                this.xPos = nextX;
                this.yPos = nextY;
            }
        }

        base.Draw();

        //Rat förflyttar sig 1 steg i slumpmässig vald riktning(upp, ner, höger eller vänster) varje omgång.
    }

    public bool IsAWall(int nextX, int nextY, List<LevelElement> elements)
    {
        for (int i = 0; i < elements.Count; i++)
        {
                if (elements[i].xPos == nextX && elements[i].yPos == nextY)
                {
                    return true;
                }
        }
        return false;

    }

    public bool IsPlayerAtPos(int nextX, int nextY, Player player)
    {
        return player.xPos == nextX && player.yPos == nextY;
    }

    public override void TakeDamage(int damageTaken, List<LevelElement> elements)
    {
        this.Health -= damageTaken;
        if (this.Health <= 0)
        {
            Die(elements);
        }
    }

    public override void Die(List<LevelElement> elements)
    {
        elements.Remove(this);

    }

    

    public void DisplayCombatLog(int nextX, int nextY, Player player, List<LevelElement> elements)
    {
        int enemyATK = AttackDice.Throw();
        int enemyDEF = DefencekDice.Throw();

        int playerATK = player.attackDice.Throw();
        int playerDEF = player.defencekDice.Throw();
        string playerDidDamage = "";
        string enemyDidDamage = "";


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

            enemyDidDamage = $"{Name} did 0 damage. ";
        }

        

        Console.SetCursorPosition(0, 1);
        Console.WriteLine($"The {Name} (ATK: {AttackDice} => {enemyATK}) attacked the (DEF: {player?.defencekDice} => {playerDEF}), {enemyDidDamage})");

        if (playerATK > enemyDEF)
        {
            player?.TakeDamage(playerATK - enemyDEF);
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

        Console.SetCursorPosition(0, 2);
        Console.WriteLine($"{player?.Name} (ATK: {player?.attackDice} => {playerATK}) attacked the {Name} (DEF: {DefencekDice} => {enemyDEF}), {playerDidDamage})");


        if (enemyATK > playerDEF)
        {
            TakeDamage(enemyATK - playerDEF,elements);
        }
    }

  
}

