using GXPEngine;
using System;
using System.Threading;
using TiledMapParser;

public class Bear : AnimationSprite
{
    Timer timer;
    /*----------floats---------*/
    float initialDropSpeed = 0;
    float jumpSpeed;
    float movementXSpeed;
    float dropSpeed;

    /*---------int---------*/
    int health = 1;
    int _score;

    public Bear(string filename, int cols, int rows, TiledObject obj = null) : base(filename, cols, rows)
    {
        y = game.height - height;
        _score = 0;
        if (obj != null)
        {
            timer = new Timer(TimerCallback, null, 0, 1500);
            dropSpeed = obj.GetFloatProperty("dropSpeed", 0.2f);
            jumpSpeed = obj.GetFloatProperty("jumpSpeed", 10f);
            movementXSpeed = obj.GetFloatProperty("movementXSpeed", 2.5f);
            health = obj.GetIntProperty("health", 1);
        }
    }

    public Bear(TiledObject obj = null) : base("square.png", 1, 1)
    {

    }

    public int GetScore()
    {
        return _score;
    }

    void Update()
    {
        XMovement();
        YMovement();
        Health();
        //   Console.WriteLine(health);
        // Console.WriteLine(jumpSpeed);
        Shot();

    }

    void XMovement()
    {

        if (Input.GetKey(Key.D)) { this.Mirror(false,false); this.MoveUntilCollision(movementXSpeed, 0); }
        else if (Input.GetKey(Key.A)) {this.Mirror(true,false);MoveUntilCollision(-movementXSpeed, 0); }

    }

    void YMovement()
    {
        float oldy = y;
        //Console.WriteLine(initialDropSpeed);
        initialDropSpeed += dropSpeed;
        y += initialDropSpeed;

        GameObject[] colied = GetCollisions();
        for (int i = 0; i < colied.Length; i++)
        {

            if (colied[i] is Solid || colied[i] is Bear2)
            {
                //Console.WriteLine("solid");
                initialDropSpeed = 0;
                y = oldy;
                if (Input.GetKey(Key.W))
                {
                    this.Move(0, initialDropSpeed -= jumpSpeed);
                }
                /*  else if (Input.GetKey(Key.S))                         //-------------------needs work(bugFound)--------------------------
                  {
                      Move(0, initialDropSpeed += jumpSpeed);
                  }*/



            }

        }


    }

    void Shot()
    {
        Console.WriteLine(height);
        if (Input.GetKeyDown(Key.F))
        {
            Screw screw = new Screw(_mirrorX ? -10:10);
            screw.SetXY(x+(_mirrorX ? -3:1)*(width/2), y-(height/2));
            parent.AddChild(screw);
        }


    }



    void Health()
    {
        if (health < 1) { Destroy(); }

    }
    void OnCollision(GameObject OtherThanBear)
    {
        //  if (OtherThanBear is Solid) { MoveUntilCollision(0,0); Console.WriteLine("collde"); }
        if (OtherThanBear is Claw) { health--; /* Console.WriteLine("fff");*/ }
        if(OtherThanBear is Screw) { movementXSpeed = 0.5f;  }

    }
    private void TimerCallback(Object o)
    {
        if (health > 0)
        {
            _score = _score + 1;
        }
    }
}

