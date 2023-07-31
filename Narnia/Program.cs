using Narnia;

Console.ForegroundColor = ConsoleColor.DarkGray;

string currentLocation = "Dom Profesora";

MainCharacter lucy = new MainCharacter("Łucja", 10, 30, 40);
MainCharacter peter = new MainCharacter("Piotr", 30, 30, 20);
MainCharacter susan = new MainCharacter("Zuzanna", 25, 25, 30);
MainCharacter edmund = new MainCharacter("Edmund", 35, 28, 17);
Enemy jadis = new Enemy(10, "Jadis");

List<MainCharacter> champions = new List<MainCharacter>();
champions.Add(lucy); 
champions.Add(peter); 
champions.Add(susan); 
champions.Add(edmund);


Graph map = new Graph();

map.AddVertex("Dom Profesora");
map.AddVertex("Las");
map.AddVertex("Zamek Czarownicy");
map.AddVertex("Tama Bobrów");
map.AddVertex("Cair Paravel");

map.AddEdge("Dom Profesora", "Las");
map.AddEdge("Las", "Zamek Czarownicy");
map.AddEdge("Las", "Tama Bobrów");
map.AddEdge("Zamek Czarownicy", "Tama Bobrów");
map.AddEdge("Las", "Cair Paravel");

ChampionSelect championSelect = new ChampionSelect(champions);
MainCharacter player = championSelect.StoryLine();
Console.WriteLine("Twoja postać to: " +  player.Name);
Forest forest = new Forest(player);
Dam dam = new Dam(player);
CairParavel cairParavel = new CairParavel(player);
Location location = new Location(currentLocation, map);
Tower tower = new Tower(player, jadis);
while (true)
{
    Console.ResetColor();
    Console.WriteLine("Zmiana lokalizacji.");
    currentLocation = location.NewLocation();
    switch (currentLocation)
    {
        case "Dom Profesora":
            Console.ForegroundColor = ConsoleColor.DarkGray;
            championSelect.Exit();
            break;
        case "Las":
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            forest.StoryLine();
            break;
        case "Tama Bobrów":
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            dam.StoryLine();
            break;
        case "Cair Paravel":
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            cairParavel.Visit();
            break;
        case "Zamek Czarownicy":
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            tower.Hello(); 
            break;
    }
}


