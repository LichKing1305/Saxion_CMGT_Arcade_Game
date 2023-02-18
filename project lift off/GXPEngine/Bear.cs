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
    float initialMovementXSpeed;
    float movementXSpeedDecrease = 0.5f;
    float dropSpeed;

    /*---------int---------*/
    int health = 1;
    int _score;
    const int cooldown = 2000;
    int zero;
    /*-------bool----*/
    bool frozeMovement = false;
    /*-------------------------------------CONSTRUCTER------------------------------------------------------------*/
    public Bear(string filename, int cols, int rows, TiledObject obj = null) : base(filename, cols, rows)
    {
        y = game.height - height;
        _score = 0;
        initialMovementXSpeed = movementXSpeed;
        if (obj != null)
        {
            timer = new Timer(TimerCallback, null, 0, 1500);
            dropSpeed = obj.GetFloatProperty("dropSpeed", 0.2f);
            jumpSpeed = obj.GetFloatProperty("jumpSpeed", 10f);
            movementXSpeed = obj.GetFloatProperty("movementXSpeed", 2.5f);
            health = obj.GetIntProperty("health", 1);
        }
    }
    public Bear() : base("square.png", 1, 1)
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
        Death();
        Shot();
        RecovorMovement();
    }
    /*-------------------------------MOVEMENT CODE FOR X DIRECTIONS---------------------------------------------------------*/
    void XMovement()
    {
        if (Input.GetKey(Key.D)) { this.Mirror(false, false); this.MoveUntilCollision(movementXSpeed, 0); }
        else if (Input.GetKey(Key.A)) { this.Mirror(true, false); MoveUntilCollision(-movementXSpeed, 0); }
    }
    /*-------------------------------MOVEMENT CODE FOR Y DIRECTIONS-------------------------------------------------------*/
    void YMovement()
    {
        float oldy = y;
        initialDropSpeed += dropSpeed;
        y += initialDropSpeed;
        GameObject[] colied = GetCollisions();
        for (int i = 0; i < colied.Length; i++)
        {
            if (colied[i] is Solid || colied[i] is Bear2)
            {
                initialDropSpeed = 0;
                y = oldy;
                if (Input.GetKey(Key.W))
                {
                    this.Move(0, initialDropSpeed -= jumpSpeed);
                }
            }
        }
    }
    /*------------------------- CODE FOR SHOTING PROJECTILE(S)--------------------------------------*/
    void Shot()
    {
        if (Input.GetKeyDown(Key.F))
        {
            Screw screw = new Screw(_mirrorX ? -1 : 1);
            screw.SetXY(x + (_mirrorX ? -3 : 1) * (width / 2), y - (height / 2));
            parent.AddChild(screw);
        }


    }
    /*------------------------ CODE FOR DEATH ---------------------------------------------------*/
    void Death()
    {
        if (health < 1) { Destroy(); }
    }
    /*------------------------ CODE FOR COLLIDING WITH COLLISIONS --------------------*/
    void OnCollision(GameObject OtherThanBear)
    {
        if (OtherThanBear is Claw) { health--; }
        if (OtherThanBear is Screw)
        {
            frozeMovement = true;
        }
    }
    void RecovorMovement()
    {
        Console.WriteLine(initialMovementXSpeed);
        if (frozeMovement == true)
        {
            Console.WriteLine("got hit");
            movementXSpeed = movementXSpeedDecrease;
            if (Time.time > zero + cooldown)
            {
                Console.WriteLine("ready---------------------------------------------------------------------------------------");
                movementXSpeed = 2.5f;
                //  zero = Time.time;
                frozeMovement = false;
            }
        }
        else { zero = Time.time; }
    }
    private void TimerCallback(Object o)
    {
        if (health > 0)
        {
            _score = _score + 1;
        }
    }
}

