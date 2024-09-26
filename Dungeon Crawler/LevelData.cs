//Skapa en klass “LevelData” som har en private field “elements” av typ List<LevelElement>. x
//Denna ska även exponeras i form av en public readonly property “Elements”. x

//Vidare har LevelData en metod, Load(string filename), x
//som läser in data från filen man anger vid anrop. x
//Load läser igenom textfilen tecken för tecken, och för varje tecken den hittar som är någon av #,x
//r, eller s, så skapar den en ny instans av den klass som motsvarar tecknet och lägger till en referens till instansen på “elements”-listan.x

//Tänk på att när instansen skapas så måste den även få en (X/Y) position; x
//d.v.s Load behöver alltså hålla reda på vilken rad och kolumn i filen som tecknet hittades på. Den behöver även spara undan startpositionen
//för spelaren när den stöter på @. x

//När filen är inläst bör det alltså finnas ett objekt i “elements” för varje tecken i filen (exkluderat space/radbyte),
//och en enkel foreach-loop som anropar .Draw() för varje element i listan bör nu rita upp hela banan på skärmen.









class LevelData
    {
        private List<LevelElement> elements = new List<LevelElement>();


    public List<LevelElement> Elements
    {

        get
        {
            return elements;
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

                //Console.Write(reader.ReadLine());

                foreach (char c in reader.ReadLine())
                {
                    if (c == '#')
                    {
                        Wall wall = new Wall() {xPos = x, yPos = y };
                        elements.Add(wall);
                        x++;
                    }
                    else if (c == 's')
                    {
                        Snake snake = new Snake() { xPos = x, yPos = y };
                        elements.Add(snake);
                        x++;

                    }
                    else if (c == 'r')
                    {
                        Rat rat = new Rat() { xPos = x, yPos = y };
                        elements.Add(rat);
                        x++;

                    }
                    else if (c == '@')
                    {
                        Player player = new Player() { xPos = x, yPos = y };
                        elements.Add(player);
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


        foreach (var element in elements)
        {
            if(element.elementChar != '@') { 
            element.Draw();
            }
        }

    }
}
