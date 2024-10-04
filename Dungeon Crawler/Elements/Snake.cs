

using System.Numerics;
using System.Xml.Linq;

class Snake : Enemy
{

    public Snake()
    {
        this.Name = "Snake";
        this.Health = 25;
        this.AttackDice = new Dice(3,4,2);
        this.DefencekDice = new Dice(1,6,3);
        this.elementChar = 's';
        this.color = ConsoleColor.Green;
        this.Position = new Position(this.xPos, this.yPos);


    }
    

    public override void Update(List<LevelElement> elements, Player player)
    {
        this.Position = new Position(this.xPos, this.yPos);
        
        Movement(elements,player);

    }

    public void Movement(List<LevelElement> elements, Player player)
    {
        int nextX = this.xPos;
        int nextY = this.yPos;

        if (Position.DistanceTo(player.Position) <= 2)
        {
            double angle = Position.AngleTo(player.Position);

            if (angle <= 80 && angle >= -80)
            {
                nextX -= 1;
            }
            else if (angle >= 100 || angle <= -100)
            {
                nextX += 1;
            }
            else if (angle <= -80 && angle >= -100)
            {
                nextY += 1;
            }
            else if (angle >= 81 && angle <= 100)
            {
                nextY -= 1;
            }
        }


        if (!IsAWall(nextX, nextY, elements))
        {
            this.xPos = nextX;
            this.yPos = nextY;
        }
    }

    public bool IsAWall(int nextX, int nextY, List<LevelElement> elements)
    {
        for (int i = 0; i < elements.Count; i++)
        {
            if(elements[i].elementChar != '@') { 
                if (elements[i].xPos == nextX && elements[i].yPos == nextY)
                {
                    return true;
                }
            }
        }
        return false;
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
}