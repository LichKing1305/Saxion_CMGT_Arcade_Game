using GXPEngine;
using System;
using TiledMapParser;

public class EndScreen : GameObject
{
    TiledLoader loader;
    public EndScreen(String filename)
    {
        loader = new TiledLoader(filename);
        CreateLevel();
    }
    void CreateLevel(bool includeImageLayers=true)
    {
        loader.LoadImageLayers();
        loader.addColliders = true;
        loader.LoadTileLayers();
        loader.autoInstance = true;
        loader.LoadObjectGroups();
    }
}

