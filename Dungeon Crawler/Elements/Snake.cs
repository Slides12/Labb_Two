//Slutligen har vi klasserna “Rat” och “Snake” som initialiserar sina nedärvda
//properties med de unika egenskaper som respektive fiende har,
//samt även implementerar Update-metoden på sina egna unika sätt.


//Player: HP = 100, Attack = 2d6 + 2, Defence = 2d6 + 0

//Rat: HP = 10, Attack = 1d6 + 3, Defence = 1d6 + 1


//Snake: HP = 25, Attack = 3d4 + 2, Defence = 1d8 + 5


class Snake : Enemy
{

    public Snake()
    {
        this.Name = "Snake";
        this.Health = 25;
        this.AttackDice = new Dice(3,4,2);
        this.DefencekDice = new Dice(1,8,5);
        this.elementChar = 's';
        this.color = ConsoleColor.Green;
        this.Position = new Position(this.xPos, this.yPos);


    }
    

    public override void Update(List<LevelElement> elements, Player player)
    {
        this.Position = new Position(this.xPos, this.yPos);
        //Console.SetCursorPosition(0, 1);

        //Console.Write(Position.AngleTo(player.Position));
        //Console.SetCursorPosition(0, 2);

        //Console.Write(Position.DistanceTo(player.Position));

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

        base.Draw();

        //Rat förflyttar sig 1 steg i slumpmässig vald riktning(upp, ner, höger eller vänster) varje omgång.
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