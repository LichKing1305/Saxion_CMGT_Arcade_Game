using GXPEngine;
using System;
using TiledMapParser;

public class Menu : GameObject
{
    TiledLoader loader;
    Bear bear1;
    Bear2 bear2;
    public Menu(String filename)
    {
        bear1= new Bear();
        AddChild(bear1);
        bear2= new Bear2();
        AddChild(bear2);
        loader = new TiledLoader(filename);
        CreateLevel();
    }
    void CreateLevel(bool includeImageLayers = true)
    {
        loader.LoadImageLayers();
        loader.addColliders = true;
        loader.LoadTileLayers();
        loader.autoInstance = true;
        loader.LoadObjectGroups();
    }
}
