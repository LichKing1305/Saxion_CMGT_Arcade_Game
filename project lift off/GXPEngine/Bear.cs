using GXPEngine;
using System;
using System.Threading;
using TiledMapParser;

public class Bear : AnimationSprite
{
    Timer timer;
    /*----------floats---------*/
    float initialDropSpeed = 0f;
    float jumpSpeed = 4f;
    float movementXSpeed = 1.5f;
    float dropSpeed = 0.2f;

    /*---------int---------*/
    int health = 1;
    int _score;

   /* public Bear(string filename,int cols, int rows,TiledObject obj=null) : base("square.png", 1, 1)
    {
        y = 600 - height;
        _score = 0;
        if (obj !=null)
        {
            timer = new Timer(TimerCallback, null, 0, 1500);
            dropSpeed = obj.GetFloatProperty("dropSpeed", 0.2f);
            jumpSpeed = obj.GetFloatProperty("jumpSpeed", 4f);
            movementXSpeed = obj.GetFloatProperty("movementXSpeed", 1.5f);
            health = obj.GetIntProperty("health", 1);
        }
    }*/

    public Bear(TiledObject obj = null) : base("square.png", 1, 1)
    {
        _score = 0;
        timer = new Timer(TimerCallback, null, 0, 250);
    }
    
    void Update()
    {
        XMovement();
        YMovement();
        Health();
      //Console.WriteLine(health);

    }

    void XMovement()
    {
       
        if (Input.GetKey(Key.D)) { Move(movementXSpeed, 0); }
        else if (Input.GetKey(Key.A)) { Move(-movementXSpeed, 0); }

    }

    void YMovement()
    {

        initialDropSpeed += dropSpeed;
       
        y += initialDropSpeed;
        if (y > 600 - height)
        {
            y = 600 - height;
            initialDropSpeed = 0;
          
            if (Input.GetKey(Key.W)) { Move(0, initialDropSpeed -= jumpSpeed);/* Console.WriteLine(y);*/ }

        }


    }
    void Health()
    {
        if (health < 1) { Destroy(); }

    }
    void OnCollision(GameObject OtherThanBear)
    {

        if (OtherThanBear is Claw) { health--; /* Console.WriteLine("fff");*/ }
        if (OtherThanBear is Powerup)
        {
            Powerup power = OtherThanBear as Powerup;
            power.Pickup();
        }
    }
    public int GetScore()
    {
        return _score;
    }
    private void TimerCallback(Object o)
    {
        if (health > 0)
        {
            _score = _score + 1;
            //Console.WriteLine(_score);
        }
    }
    void SpawnNewPickup()
    {
        Powerup power = new Powerup();
        int bearScore = GetScore();
        if (bearScore % 100 == 0) // Check if the score is divisible by 100
        {
            power.Pickup(); // Replace with your actual object-spawning code
        }

    }
}

