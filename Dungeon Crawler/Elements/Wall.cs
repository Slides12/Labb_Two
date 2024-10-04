

class Wall : LevelElement
{
    public Wall()
    {
        this.elementChar = '#';
        this.color = ConsoleColor.Gray;
        this.Position = new Position(this.xPos, this.yPos);


    }


    public void UpdateYX()
    {
        base.hasBeenSeen = true;

        this.Position = new Position(this.xPos, this.yPos);
    }

}
