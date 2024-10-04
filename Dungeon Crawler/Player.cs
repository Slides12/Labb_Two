
using System;
using System.Numerics;
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
                    return (elements[i] as Enemy);
                }
            }
        }
        return null;
    }


    public void TakeDamage(int damageTaken)
    {
        this.Health -= damageTaken;
    }

    



    public void DisplayCombatLog(int nextX, int nextY, List<LevelElement> elements)
    {
        Enemy enemy = GetEnemy(nextX, nextY, elements);

        int playerATK = attackDice.Throw();
        int playerDEF = defencekDice.Throw();
        int enemyATK = enemy.AttackDice.Throw();
        int enemyDEF = enemy.DefencekDice.Throw();

        
        

    
        string playerDidDamage = GetPlayerAttackText(playerATK, enemyDEF, enemy, elements);
        Console.SetCursorPosition(0, 1);
        Console.WriteLine($"{Name} (ATK: {attackDice} => {playerATK}) attacked the {enemy?.Name} (DEF: {enemy?.DefencekDice} => {enemyDEF}), {playerDidDamage})");

       
        if (enemy?.Health > 0)
        {
            if (enemyATK > playerDEF)
            {
                TakeDamage(enemyATK - playerDEF);
            }
            string enemyDidDamage = GetEnemyAttackText(enemyATK, playerDEF, enemy, elements);
            Console.SetCursorPosition(0, 2);
            Console.WriteLine($"The {enemy?.Name} (ATK: {enemy?.AttackDice} => {enemyATK}) attacked the (DEF: {defencekDice} => {playerDEF}), {enemyDidDamage})");
        }
        else if(enemy?.Health <= 0)
        {
            Console.SetCursorPosition(0, 2);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"The dead can't retalliate.");
        }
    }

    public void ResetCombatLog()
    {
        Console.SetCursorPosition(0, 1);
        Console.Write(new String(' ', Console.BufferWidth));
        Console.SetCursorPosition(0, 2);
        Console.Write(new String(' ', Console.BufferWidth));
    }

    public string GetPlayerAttackText(int playerATK, int enemyDEF, Enemy enemy, List<LevelElement> elements)
    {
        string playerDidDamage = "";
        Console.SetCursorPosition(55, 1);

        if (playerATK - enemyDEF >= enemy?.Health)
        {
            enemy?.TakeDamage(playerATK - enemyDEF, elements);
            Console.ForegroundColor = ConsoleColor.Green;
            playerDidDamage = $"You killed it.";
        }
        else if (playerATK > enemyDEF)
        {
            enemy?.TakeDamage(playerATK - enemyDEF, elements);
            Console.ForegroundColor = ConsoleColor.Yellow;
            playerDidDamage = $"Wow, you scratched it.{enemy?.Name}:{enemy?.Health} HP ";
        }
        else if (playerATK <= enemyDEF)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            playerDidDamage = $"You literally did 0 damage. {enemy?.Name}:{enemy?.Health} HP ";
        }

        return playerDidDamage;
    }

    public string GetEnemyAttackText(int enemyATK, int playerDEF, Enemy enemy, List<LevelElement> elements)
    {
        string enemyDidDamage = "";

        if (enemyATK > playerDEF)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            enemyDidDamage = "He f-ed you up. ";
        }
        else if (enemyATK <= playerDEF)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            enemyDidDamage = $"{enemy?.Name} did 0 damage. ";
        }

        return enemyDidDamage;
    }


    public void FogOfWar(List<LevelElement> elements)
    {
        foreach (LevelElement element in elements)
        {
            if(Position.DistanceTo(element.Position) < 4 && element.elementChar != '@')
            {
                element.Draw();
            }
            else
            {
                element.ResetLastPos();
            }
        }
    }
}
