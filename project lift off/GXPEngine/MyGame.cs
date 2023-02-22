using GXPEngine;
using System;

public class MyGame : Game
{
    private Level _level;
    EndScreen endscreen;
    HUD hud;
    string map = "levlemap.tmx";
    string _endscreen = "endscreen.tmx";
    //string _menu = "menu.tmx";

    public MyGame() : base(1920, 1080, false, true, -1, -1, false)     // Create a window that's 800x600 and NOT fullscreen
    {
        _level = new Level(map);
        AddChild(_level);
        hud = new HUD(_level);
        AddChild(hud);
        /*  endscreen = new EndScreen(_endscreen);
          AddChild(endscreen);*/
    }

    void KeyReleased()
    {
        Console.WriteLine("keyRelease");

    }

    void Update()
    {
        if (Input.GetKeyDown(Key.R))
        {
            ResetLevel();
        }

    }
    static void Main()     // Main() is the first method that's called when the program is run
    {
        new MyGame().Start();    // Create a "MyGame" and start it
    }

    void ResetLevel()
    {
        if (_level != null)
        {
            RemoveChild(_level);
            _level = null;
        }
        _level = new Level(map);
        // AddChild(_level);
    }
}

