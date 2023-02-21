using GXPEngine;
using System;
using System.Threading;
using System.IO.Ports;

public class MyGame : Game
{
    private Level _level;
    string map = "levlemap.tmx";
    //string _menu = "menu.tmx";

    public MyGame() : base(800, 600, false, true, -1, -1, false)     // Create a window that's 800x600 and NOT fullscreen
    {
        _level = new Level(map);
        AddChild(_level);
       
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
        AddChild(_level);
    }
}

