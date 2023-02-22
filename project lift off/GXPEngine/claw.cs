
using GXPEngine;
using System;
using System.Threading;
using TiledMapParser;

public class Claw : AnimationSprite
{
    bool dropSwitch = false;
    float movementSpeed = 1.5f;
    float dropSpeed = 10f;
    float goUpSpeed = 3f;
    Bear bear1 = new Bear();
    Bear2 bear2;
    bool isPickUpBear = false;
    public Claw() : base("claw_sprite.png", 1, 1)
    {
       
    }
    void PickupBearAnimation()
    {
        /* if (isPickUpBear)
         {

             Console.WriteLine(currentFrame);
             if (isPickUpBear)
             {*/
        if (currentFrame != 2)
        {
            SetCycle(0, 3);
            Animate(0.2f);
        }
         /*   }
            else if(currentFrame==2)
            {
                isPickUpBear=false;
                SetCycle(0, 1);
                Animate(0);

            }
        }*/
    }
    public Claw(string filename, int cols, int rows, TiledObject obj = null) : base(filename, cols, rows)
    {
        bear2 = new Bear2();
        if (obj != null)
        {
            dropSpeed = obj.GetFloatProperty("dropSpeed", 100f);
            goUpSpeed = obj.GetFloatProperty("goUpSpeed", 3f);
            movementSpeed = obj.GetFloatProperty("movementSpeed", 1.5f);
        }
    }
    void OnCollision(GameObject OtherThanClaw)
    {
        if (OtherThanClaw is Bear||OtherThanClaw is Bear2)
        {
            isPickUpBear=true;   
            PickupBearAnimation();
        }

    }
   
   
    void Update()
    {
      
        XMovement();
        YMovement();
        //PickupBearAnimation();
        /*if (bear1.health <= 0 && bear2.health <= 0)
        {
            _gameOver = true;
        }*/

    }
    void XMovement()
    {     
        if (Input.GetKey(Key.RIGHT)) { MoveUntilCollision(movementSpeed, 0); }
        else if (Input.GetKey(Key.LEFT)) { MoveUntilCollision(-movementSpeed, 0); }
    }
    void YMovement()
    {
        if (Input.GetKey(Key.DOWN) && !dropSwitch)
        {
            y += dropSpeed;
        }
        if (y > game.height - height)
        {
            dropSwitch = true;
        }
        if (y >= game.y - height && dropSwitch == true)
        {
            y -= goUpSpeed;
        }
        if (y <= game.y + height / 2 && dropSwitch == true)
        {
            dropSwitch = false;
        }
        GameObject[] colied = GetCollisions();
        for (int i = 0; i < colied.Length; i++)
        {
            if (colied[i] is Solid )
            {
                dropSwitch = true;
                y -= goUpSpeed;
                SetCycle(3, 1);
                Animate(0.1f);
            }
        }
    }

   
}


