using GXPEngine;
using TiledMapParser;
class Level : GameObject
{
    TiledLoader loader;
    Bear bear;
    //  Claw claw;
    //HUD hud;
    Bear2 bear2;
    //  Powerup power1;
    //  public string map = "levlemap.tmx";
    public Level(string filename)
    {
        loader = new TiledLoader(filename);
        createlevel();
    }

    void createlevel()
    {
        //  loader.LoadImageLayers();
        loader.addColliders = true;
        loader.LoadTileLayers();
        loader.autoInstance = true;
        loader.LoadObjectGroups();
        {
            bear = new Bear();
            bear2 = new Bear2();
            // AddChild(bear);
            //  claw = new Claw();
            // AddChild(claw);
            //  AddChild(new HUD(bear));
            //  power1 = new Powerup();
            // AddChild(power1);
        }
    }

    void Update()
    {
        //Console.WriteLine(bear2.Player2Switch);
        if (Input.GetKeyDown(Key.ENTER)) { bear2.Player2Switch = !bear2.Player2Switch; }
        if (bear2.Player2Switch == true) { AddChild(bear2); }
        else if (!bear2.Player2Switch) { this.RemoveChild(bear2); }
        //   int bearScore = bear.GetScore();
        /* if (bearScore % 100 == 0) // Check if the score is divisible by 100
         {
             power1.Pickup(); // Replace with your actual object-spawning code
         }
         / int bearScore2 = bear2.GetScore();
         if (bearScore2 % 100 == 0) // Check if the score is divisible by 100
         {
             power1.Pickup(); // Replace with your actual object-spawning code
         }/*/
    }

}