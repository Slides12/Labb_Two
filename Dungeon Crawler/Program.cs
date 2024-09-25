//Attack och försvar
//När en spelare attackerar (går in i) en fiende, eller tvärtom så behöver vi simulera tärningskast för att få en poäng som avgör hur mycket skada attacken gör. Den som attackerar kastar då sina tärningar först och får en attackpoäng. 
//Sedan kastar den som försvarar sina tärningar och får en försvarspoäng. Ta sedan attackpoängen minus försvarspoängen, och om differensen är större än 0, dra motsvarande antal från förvararens HP (hälsopoäng). 
//Efter en eller flera attacker kommer HP ner till 0, varpå fienden dör (eller spelaren får game over).

//Om försvararen överlever kommer han direkt att göra en motattack, d.v.s kasta tärningar på nytt för att få en attackpoäng; varpå den som först attackerade nu försvarar genom att kasta sina tärningar. Dra bort HP enligt reglerna ovan.
// Spelaren samt alla typer av fiender har en uppsättning tärningskonfigurationer för sin attack respektive försvar, samt en hårdkodad HP som man startar med. Jag har använt följande konfigurationer, men ni får gärna prova med andra:


//Player: HP = 100, Attack = 2d6 + 2, Defence = 2d6 + 0
//Rat: HP = 10, Attack = 1d6 + 3, Defence = 1d6 + 1
//Snake: HP = 25, Attack = 3d4 + 2, Defence = 1d8 + 5



//Förflyttningsmönster
//Spelaren förflyttar sig 1 steg upp, ner, höger eller vänster varje omgång, alternativt står still, beroende på vilken knapp användaren tryckt på.
//Rat förflyttar sig 1 steg i slumpmässig vald riktning (upp, ner, höger eller vänster) varje omgång.
//Snake står still om spelaren är mer än 2 rutor bort, annars förflyttar den sig bort från spelaren.
//Varken spelare, rats eller snakes kan gå igenom väggar eller varandra.


Rat rat = new Rat();
Snake snake = new Snake();


Console.WriteLine($"Name: {rat.Name}  Stats: {rat.attackDice} DiceThrow: {rat.attackDice.Throw()}");
Console.WriteLine($"Name: {rat.Name}  Stats: {rat.defencekDice} DiceThrow: {rat.defencekDice.Throw()}");
Console.WriteLine($"Name: {snake.Name} Stats: {snake.defencekDice} DiceThrow: {snake.defencekDice.Throw()}");
Console.WriteLine($"Name: {snake.Name} Stats: {snake.attackDice} DiceThrow: {snake.attackDice.Throw()}");

