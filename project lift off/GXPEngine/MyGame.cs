using GXPEngine;
using System;


public class MyGame : Game
{


    Level level;
    Menu menu;
    string map = "levlemap.tmx";
    string _menu = "menu.tmx";


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
        menu = new Menu(_menu);
        AddChild(menu);
        level = new Level(map);
        AddChild(level);
       
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
    }

    static void Main()                          // Main() is the first method that's called when the program is run
    {
        new MyGame().Start();                   // Create a "MyGame" and start it
    }
    public void LoadLevel(string filename)
    {
        AddChild(new Menu(filename));


    }

}

