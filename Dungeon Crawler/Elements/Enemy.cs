
using System.Xml.Linq;

abstract class Enemy : LevelElement
{

    public string Name { get; set; }
    public int Health { get; set; }
    public Dice AttackDice { get; set; }
    public Dice DefencekDice { get; set; }



    public abstract void Update(List<LevelElement> elements, Player player);

    public abstract void TakeDamage(int damageTaken, List<LevelElement> elements);
    public abstract void Die(List<LevelElement> elements);



}
