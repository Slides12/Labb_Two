//Slutligen har vi klasserna “Rat” och “Snake” som initialiserar sina nedärvda
//properties med de unika egenskaper som respektive fiende har,
//samt även implementerar Update-metoden på sina egna unika sätt.


//Player: HP = 100, Attack = 2d6 + 2, Defence = 2d6 + 0

//Rat: HP = 10, Attack = 1d6 + 3, Defence = 1d6 + 1


//Snake: HP = 25, Attack = 3d4 + 2, Defence = 1d8 + 5


using System.Runtime.ConstrainedExecution;

class Rat : Enemy
{

    public Rat()
    {
        this.Name = "Rat";
        this.Health = 10;
    }

    public override void Update()
    {
        //Rat förflyttar sig 1 steg i slumpmässig vald riktning(upp, ner, höger eller vänster) varje omgång.
    }
}