using GXPEngine;
using TiledMapParser;
class Map : GameObject
{
    TiledLoader loader;
    Bear bear;
    Claw claw;
    HUD hud;
    Bear2 bear2;
    Powerup power1;

    public Map(string filename)
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
            AddChild(bear);
            claw = new Claw();
            AddChild(claw);
            hud = new HUD(bear);
            AddChild(hud);
            power1 = new Powerup();
            AddChild(power1);
        }
    }

}

