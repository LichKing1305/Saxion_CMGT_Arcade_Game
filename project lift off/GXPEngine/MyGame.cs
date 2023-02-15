using System;                                 
using GXPEngine;                               
using System.Drawing;


public class MyGame : Game {
	public MyGame() : base(800, 600, false)     // Create a window that's 800x600 and NOT fullscreen
	{
		//LoadLevel(map);
		Menu menu = new Menu();
		AddChild(menu);
	}

	
	void Update() {
		
	}

	static void Main()                          // Main() is the first method that's called when the program is run
	{
		new MyGame().Start();                   // Create a "MyGame" and start it
	}
}

