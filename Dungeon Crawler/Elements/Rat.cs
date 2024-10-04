
using System.Numerics;
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

        Movement(elements,player);
    }

    public void Movement(List<LevelElement> elements, Player player)
    {
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
                ResetCombatLog();
                DisplayCombatLog(nextX, nextY, player, elements);
            }
            else
            {

                this.xPos = nextX;
                this.yPos = nextY;
            }
        }
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
        base.ResetLastPos();
        elements.Remove(this);
    }



    public void DisplayCombatLog(int nextX, int nextY, Player player, List<LevelElement> elements)
    {
        int enemyATK = AttackDice.Throw();
        int enemyDEF = DefencekDice.Throw();

        int playerATK = player.attackDice.Throw();
        int playerDEF = player.defencekDice.Throw();
        


        if (playerATK > enemyDEF)
        {
            TakeDamage(playerATK - enemyDEF, elements);
        }

        string enemyDidDamage = GetEnemyAttackText(enemyATK, playerDEF, player);
        Console.SetCursorPosition(0, 1);
        Console.WriteLine($"The {Name} (ATK: {AttackDice} => {enemyATK}) attacked the (DEF: {player?.defencekDice} => {playerDEF}), {enemyDidDamage})");



        string playerDidDamage = GetPlayerAttackText(playerATK, enemyDEF);
        Console.SetCursorPosition(0, 2);
        Console.WriteLine($"{player?.Name} (ATK: {player?.attackDice} => {playerATK}) attacked the {Name} (DEF: {DefencekDice} => {enemyDEF}), {playerDidDamage})");
       
    }


    public void ResetCombatLog()
    {
        Console.SetCursorPosition(0, 1);
        Console.Write(new String(' ', Console.BufferWidth));
        Console.SetCursorPosition(0, 2);
        Console.Write(new String(' ', Console.BufferWidth));
    }

    public string GetEnemyAttackText(int enemyATK, int playerDEF, Player player)
    {
        string enemyDidDamage = "";

        if (enemyATK > playerDEF)
        {
            player?.TakeDamage(enemyATK - playerDEF);
            Console.ForegroundColor = ConsoleColor.Yellow;
            enemyDidDamage = "He f-ed you up. ";
        }
        else if (enemyATK <= playerDEF)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            enemyDidDamage = $"{Name} did 0 damage. ";
        }

        return enemyDidDamage;
    }


    public string GetPlayerAttackText(int playerATK, int enemyDEF)
    {
        string playerDidDamage = "";
        
        if (Health <= 0)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            playerDidDamage = $"You killed it!";
        }
        else if (playerATK > enemyDEF)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            playerDidDamage = $"Wow, you scratched it. {Name}:{Health} HP";
        }
        else if (playerATK <= enemyDEF)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            playerDidDamage = $"You literally did 0 damage. {Name}:{Health} HP";
        }

        return playerDidDamage;
    }

}

