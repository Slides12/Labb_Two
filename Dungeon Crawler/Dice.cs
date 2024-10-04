

class Dice
{

    private int numberOfDice;
    private int sidePerDice;
    private int modifier;
    private Random random;

    public Dice(int numberOfDice, int sidePerDice, int modifier)
    { 
        this.numberOfDice = numberOfDice;
        this.sidePerDice = sidePerDice;
        this.modifier = modifier;
        random = new Random();
    }


    public int Throw()
    {
        int sum = 0;
       for (int i = 0;i < numberOfDice; i++)
        {
            sum += random.Next(1,sidePerDice);
        } 
        return sum + modifier;
    }

    public override string ToString()
    {

        return $"{numberOfDice}d{sidePerDice}+{modifier}";
    }

}