//Klassen “Enemy” ärver också av LevelElement, 

//och lägger till funktionalitet som är specifik för fiender. Även Enemy är abstrakt, 
//då vi inte vill att man ska kunna instansiera ospecifika “fiender”. 

//Alla riktiga fiender (i labben rat & snake, 
//men om man vill och har tid får man lägga till fler typer av fiender) ärver av denna klass. 

//Enemy ska ha properties för namn (t.ex snake/rat), hälsa (HP),
//samt AttackDice och DefenceDice av typen Dice (mer om detta längre ner). 
//Den ska även ha en abstrakt Update-metod,
//som alltså inte implementeras i denna klass, men som kräver att alla som ärver av klassen implementerar den. 

//vi vill alltså kunna anropa update-metoden på alla fiender
//och sedan sköter de olika subklasserna hur de uppdateras (till exempel olika förflyttningsmönster).

using System.Xml.Linq;

abstract class Enemy : LevelElement
{

    public string Name { get; set; }
    public int Health { get; set; }
    public Dice AttackDice { get; set; }
    public Dice DefencekDice { get; set; }

    public bool IsDead { get; set; } = false;


public abstract void Update(List<LevelElement> elements, Player player);

    public abstract void TakeDamage(int damageTaken);
    public abstract void Die();



}
