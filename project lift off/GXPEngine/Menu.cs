using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;

public class Menu : GameObject
{
    Bear bear;
    Bear2 bear2;
    TiledLoader loader;
    public string menu = "menu.tmx";
   // Button _button;
    public Menu(string filename) //string filename
    {
        // Button button = new Button();
        // AddChild(_button);
        //_button.x = (game.width - button.width) / 2;
        //_button.y = (game.height - button.height) / 2;
        loader = new TiledLoader(filename);
        createlevel();
    }

    void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            if (_button.HitTestPoint(Input.mouseX, Input.mouseY))
            {
                LoadLevel(map);
            }
        }*/

    }

    void LoadLevel(string filename)
    {
        AddChild(new Level(filename));
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
         
        }
    }
}