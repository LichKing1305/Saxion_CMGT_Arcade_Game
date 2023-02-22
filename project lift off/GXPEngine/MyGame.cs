using GXPEngine;
using System;

public class MyGame : Game
{
    Level level;
    private Menu _menu;
    Bear bear; 
    Bear2 bear2;
    //EndScreen endscreen;
    HUD hud;
    PressurePlate plate;
    string map = "levlemap.tmx";
    //string _endscreen = "endscreen.tmx";
    string menu = "menu.tmx";

    public MyGame() : base(1920, 1080, false, false, -1, -1, false)     // Create a window that's 800x600 and NOT fullscreen
    {
        level = new Level(menu);
        AddChild(level);
        hud = new HUD(level);
        AddChild(hud);
        bear2 = new Bear2();
        AddChild(bear2);
        plate = new PressurePlate(bear2, 100, 600, map);
        AddChild(plate);
        /*  endscreen = new EndScreen(_endscreen);
          AddChild(endscreen);*/
    }

    void KeyReleased()
    {
        Console.WriteLine("keyRelease");

    }

    void Update()
    {
        /*if (Input.GetKeyDown(Key.R))
        {
            ResetLevel();
        }*/
    }
    static void Main()     // Main() is the first method that's called when the program is run
    {
        new MyGame().Start();    // Create a "MyGame" and start it
    }

    /*void ResetLevel()
    {
        if (_level != null)
        {
            RemoveChild(_level);
            _level = null;
        }
        _level = new Level(map);
        // AddChild(_level);
    }*/
}

