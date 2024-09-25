﻿//Slutligen har vi klasserna “Rat” och “Snake” som initialiserar sina nedärvda
//properties med de unika egenskaper som respektive fiende har,
//samt även implementerar Update-metoden på sina egna unika sätt.


//Player: HP = 100, Attack = 2d6 + 2, Defence = 2d6 + 0

//Rat: HP = 10, Attack = 1d6 + 3, Defence = 1d6 + 1


//Snake: HP = 25, Attack = 3d4 + 2, Defence = 1d8 + 5


class Player : Enemy
{

    public Player()
    {
        this.Name = "Player";
        this.Health = 100;
    }

    public override void Update()
    {
        //Spelaren förflyttar sig 1 steg upp, ner, höger eller vänster varje omgång,
        //alternativt står still, beroende på vilken knapp användaren tryckt på.
    }
}