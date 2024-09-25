//En game loop är en loop som körs om och om igen medan spelet är igång, och i vårat fall kommer ett varv i loopen motsvaras av en omgång i spelet. 
//För varje varv i loopen inväntar vi att användaren trycker in en knapp; sedan utför vi spelarens drag, följt av datorns drag (uppdatera alla fiender), 
//innan vi loopar igen. Möjligtvis kan man ha en knapp (Esc) för att avsluta loopen/spelet.

//När spelaren/fiender flyttar på sig behöver vi beräkna deras nya position och leta igenom alla vår LevelElements för att se om det finns något annat objekt på den platsen man försöker flytta till. 
//Om det finns en vägg eller annat objekt (fiende/spelaren) på platsen måste förflyttningen avbrytas och den tidigare positionen gälla. 
//Notera dock att om spelaren flyttar sig till en plats där det står en fiende så attackerar han denna (mer om detta längre ner). 
//Detsamma gäller om en fiende flyttar sig till platsen där spelaren står. Fiender kan dock inte attackera varandra i spelet.



//Vision range
//För att få en effekt av “utforskande” i spelet begränsar vi spelarens synfält till att bara visa objekt inom en radie av 5 tecken (men ni kan också prova med andra radier); 
//Väggarna försvinner dock aldrig när man väl sett dem, men fienderna syns inte så fort de kommer utanför radien.

//Avståndet mellan två punkter i 2D kan enkelt beräknas med hjälp av pythagoras sats.




class GameLoop
{

}
