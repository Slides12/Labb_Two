

class LevelData
    {
        private List<LevelElement> _elements = new List<LevelElement>();


    public List<LevelElement> Elements
    {

        get
        {
            return _elements;
        }
    }


    public void Load(string fileName)
    {
        int y = 3;
        int x = 0;
        using (StreamReader reader = new StreamReader(fileName))
        {


            while (!reader.EndOfStream)
            {


                foreach (char c in reader.ReadLine())
                {
                    if (c == '#')
                    {
                        Wall wall = new Wall() { xPos = x, yPos = y };
                        _elements.Add(wall);
                        x++;
                    }
                    else if (c == 's')
                    {
                        Snake snake = new Snake() { xPos = x, yPos = y };
                        _elements.Add(snake);
                        x++;

                    }
                    else if (c == 'r')
                    {
                        Rat rat = new Rat() { xPos = x, yPos = y };
                        _elements.Add(rat);
                        x++;

                    }
                    else if (c == '@')
                    {
                        Player player = new Player() { xPos = x, yPos = y };
                        _elements.Add(player);
                        x++;

                    }
                    else
                    {
                        x++;
                    }


                }
                y++;
                x = 0;

            }

        }

    }
}
