using GXPEngine;
using TiledMapParser;
class Map : GameObject
{
    TiledLoader loader;
    
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

    }

}

