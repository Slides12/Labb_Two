





public struct Position
{
    public int y;
    public int x;

    
    public Position(int x, int y)
    {
        this.x = x;

        this.y = y;
    }


    public int VerticalDistanceTo(Position position)
    {
        return Math.Abs(position.x - this.x);
    }

    public int HorizontalDistanceTo(Position position)
    {
        return Math.Abs(position.y - this.y);
    }

    public double DistanceTo(Position position)
    {

        double absX = VerticalDistanceTo(position);
        double absY = HorizontalDistanceTo(position);

        double distanceBetween = Math.Sqrt(((absX * absX) + (absY + absY)));


        return distanceBetween;
    }

}

