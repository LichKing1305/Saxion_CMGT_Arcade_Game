/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

public class Menu : GameObject
{
    public string map = "levlemap.tmx";
    Button _button;
    public Menu() : base()
    {
        Button button = new Button();
        AddChild(_button);
        _button.x = (game.width - button.width) / 2;
        _button.y = (game.height - button.height) / 2;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(_button.HitTestPoint(Input.mouseX, Input.mouseY))
            {
                LoadLevel(map);
            }
        }
    }

    void LoadLevel(string filename)
    {
        AddChild(new Map(filename));
    }
}*/