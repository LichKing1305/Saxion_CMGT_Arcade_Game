using GXPEngine;
using System;
using System.Threading;
using System.IO.Ports;

public class MyGame : Game
{
    private Level _level;
    //Level level;
    //Menu menu;
    string map = "levlemap.tmx";
    //string _menu = "menu.tmx";
    //int spawnInterval;

    public MyGame() : base(800, 600, false, true, -1, -1, false)     // Create a window that's 800x600 and NOT fullscreen
    {
        /*// Draw some things on a canvas:
		EasyDraw canvas = new EasyDraw(800, 600);
		canvas.Clear(Color.MediumPurple);
		canvas.Fill(Color.Yellow);
		canvas.Ellipse(width / 2, height / 2, 200, 200);
		canvas.Fill(50);
		canvas.TextSize(32);
		canvas.TextAlign(CenterMode.Center, CenterMode.Center);
		canvas.Text("Welcome!", width / 2, height / 2);
		
		// Add the canvas to the engine to display it:
		AddChild(canvas);
		Console.WriteLine("MyGame initialized");*/
        //  LoadLevel(map);
        /*bear= new Bear("square.png", 1, 1);
		AddChild(bear);*/
        /*claw= new Claw();
		AddChild(claw);*/
        /*	hud = new HUD(bear);
        AddChild(hud);*/
        //  bear2 = new Bear2();
        /*menu = new Menu(_menu);
        AddChild(menu);*/
        //spawnInterval = 2000; // in milliseconds
        _level = new Level(map);
        AddChild(_level);
       
    }

    void KeyReleased()
    {
        Console.WriteLine("keyRelease");

    }

    void Update()
    {
        /*  //Console.WriteLine(bear2.Player2Switch);
          if (Input.GetKeyDown(Key.ENTER)) { bear2.Player2Switch = !bear2.Player2Switch; }
          if (bear2.Player2Switch == true) { AddChild(bear2); }
          else if (!bear2.Player2Switch) { this.RemoveChild(bear2); }*/
        if (Input.GetKeyDown(Key.R)) 
        { 
            ResetLevel();
        }
    }

    static void Main()                          // Main() is the first method that's called when the program is run
    {/*
        SerialPort port = new SerialPort();
        port.PortName = "COM4";
        port.BaudRate = 9600;
        port.RtsEnable = true;
        port.DtrEnable = true;
        port.Open();
        while (true)
        {
            string line = port.ReadLine(); // read separated values
                                           //string line = port.ReadExisting(); // when using characters
            if (line != "")
            {
                Console.WriteLine("Read from port: " + line);
            }
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                port.Write(key.KeyChar.ToString());  // writing a string to Arduino
            }
        }
        */

       new MyGame().Start();                   // Create a "MyGame" and start it
    }
    public void LoadLevel(string filename)
    {
        AddChild(new Menu(filename));


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

