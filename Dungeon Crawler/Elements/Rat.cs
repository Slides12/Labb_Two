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
        int direction = rand.Next(0,4);
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
}