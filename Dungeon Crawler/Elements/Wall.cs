// Klassen “Wall” ärver av LevelElement,
// och behöver egentligen ingen egen kod förutom att hårdkoda färgen och tecknet för vägg (en grå hashtag).


class Wall : LevelElement
{
    
    public Wall()
    {
        this.elementChar = '#';
        this.color = ConsoleColor.Gray;


    }


    public void UpdateYX(int x, int y)
    {

    }

}
