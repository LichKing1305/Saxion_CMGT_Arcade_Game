using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using GXPEngine;
using TiledMapParser;

    public class Claw:AnimationSprite
    {
    bool dropSwitch = false;
    float movementSpeed = 1.5f;
    float dropSpeed = 100f;
    float goUpSpeed = 3f;
    public Claw() : base("triangle.png",1,1) 
    {
       /* Random random;
        random= new Random();
       */
    }
    public Claw(string filename, int cols, int rows, TiledObject obj = null) : base(filename, cols, rows)
    {
       
        if (obj != null)
        {
            dropSpeed = obj.GetFloatProperty("dropSpeed", 100f);
            goUpSpeed = obj.GetFloatProperty("goUpSpeed", 3f);
            movementSpeed = obj.GetFloatProperty("movementSpeed", 1.5f);
        }
    }

    void Update() 
    {
        XMovement();
        YMovement();
    }
    void XMovement() 
    {
        
        if (Input.GetKey(Key.RIGHT)) { Move(movementSpeed,0); }   
        else if (Input.GetKey(Key.LEFT)){ Move(-movementSpeed,0); }
       
    }
    void YMovement()

    {
       // Console.WriteLine(y);
        
        if (Input.GetKey(Key.DOWN)&&!dropSwitch) { 
        y += dropSpeed; }
        if (y>game.height-height) {dropSwitch = true; }
        if (y > 0 - height && dropSwitch == true) { y-=goUpSpeed; } 
        if (y <= 0 && dropSwitch==true) { dropSwitch = false; }


    }
    

    }

