





public struct Position
{
    public int y;
    public int x;

    
    public Position(int x, int y)
    {
        this.x = x;

        this.y = y;
    }


    public int HorizontalDistanceTo(Position position)
    {
        return Math.Abs(position.x - this.x);
    }

    public int VerticalDistanceTo(Position position)
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

    public double AngleTo(Position position)
    {

        double absX = position.x - this.x;
        double absY = position.y - this.y;

        double angleRadians = Math.Atan2(absY, absX);
        double angleDegrees = angleRadians * (180 / Math.PI);


        return angleDegrees;
    }

}

