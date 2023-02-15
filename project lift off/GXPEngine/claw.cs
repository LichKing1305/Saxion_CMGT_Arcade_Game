using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GXPEngine;

    public class Claw:AnimationSprite
    {
    bool dropSwitch = false;
    public Claw() : base("triangle.png",1,1) 
    {
       /* Random random;
        random= new Random();
       */
    }

    void Update() 
    {
        XMovement();
        YMovement();
    }
    void XMovement() 
    {
        float movementSpeed=1.5f;
        if (Input.GetKey(Key.RIGHT)) { Move(movementSpeed,0); }   
        else if (Input.GetKey(Key.LEFT)){ Move(-movementSpeed,0); }
       
    }
    void YMovement()

    {
       // Console.WriteLine(y);
        float dropSpeed = 100f;
        float goUpSpeed = 3f;
        if (Input.GetKey(Key.DOWN)&&!dropSwitch) { 
        y += dropSpeed; }
        if (y>650-height) {dropSwitch = true; }
        if (y > 0 - height && dropSwitch == true) { y-=goUpSpeed; } 
        if (y <= 0 && dropSwitch==true) { dropSwitch = false; }


    }
    

    }

