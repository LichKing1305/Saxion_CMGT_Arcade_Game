using GXPEngine;
using System;
using TiledMapParser;

public class Bear : AnimationSprite
{
    PickupCoin pickup;
    /*----------floats---------*/
    float initialDropSpeed = 0;
    float jumpSpeed;
    float movementXSpeed;
    float initialMovementXSpeed;
    float movementXSpeedDecrease = 0.5f;
    float dropSpeed;

    /*---------int---------*/
    public int health = 1;
    const int cooldown = 2000;
    int zero;
    int coinAmount;
    /*-------bool----*/
    bool frozeMovement = false;
    /*-------------------------------------CONSTRUCTER------------------------------------------------------------*/
    public Bear(string filename, int cols, int rows, TiledObject obj = null) : base(filename, cols, rows)
    {
        y = game.height - height;
        initialMovementXSpeed = movementXSpeed;
        //pickup = new PickupCoin();
        if (obj != null)
        {
            dropSpeed = obj.GetFloatProperty("dropSpeed", 0.2f);
            jumpSpeed = obj.GetFloatProperty("jumpSpeed", 10f);
            movementXSpeed = obj.GetFloatProperty("movementXSpeed", 2.5f);
            health = obj.GetIntProperty("health", 1);
        }
    }
    public Bear() : base("bear_sprite_all.png", 8, 5)
    {


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
        float oldx = x;
        if (Input.GetKey(Key.D)) { this.Mirror(false, false); this.Move(movementXSpeed, 0); SetCycle(0, 4); Animate(0.5f); }
        else if (Input.GetKey(Key.A)) { this.Mirror(true, false); Move(-movementXSpeed, 0); }
        GameObject[] colied = GetCollisions();
        for (int i = 0; i < colied.Length; i++)
        {
            if (colied[i] is Solid || colied[i] is Bear2)
            {
                x = oldx;
            }
        }
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
                if (Input.GetKeyDown(Key.W))
                {
                    this.MoveUntilCollision(0, initialDropSpeed -= jumpSpeed);
                }
            }
        }
    }
    /*------------------------- CODE FOR SHOTING PROJECTILE(S)--------------------------------------*/
    void Shot()
    {
        if (Input.GetKeyDown(Key.F) && coinAmount >= 1)
        {
            Screw screw = new Screw(_mirrorX ? -5 : 5);
            screw.SetXY(x + (_mirrorX ? -3 : 2) * (width / 2), y - (height / 2));
            parent.AddChild(screw);
            coinAmount--;
            Console.WriteLine("shoting");
        }


    }
    /*------------------------ CODE FOR DEATH ---------------------------------------------------*/
    void Death()
    {
        if (health < 1)
        {
            //this.Remove();
            //Destroy();
            parent = null;
            
        }
        // Console.WriteLine(health);
    }
    /*------------------------ CODE FOR COLLIDING WITH COLLISIONS --------------------*/
    void OnCollision(GameObject OtherThanBear)
    {
        if (OtherThanBear is Claw) { health--; }
        if (OtherThanBear is Screw)
        {
            frozeMovement = true;
        }
        if (OtherThanBear is PickupCoin)
        {
            PickupCoin pickup = OtherThanBear as PickupCoin;
            pickup.HasPickedUp = true;
            coinAmount++;
        }
    }
    void RecovorMovement()
    {
        //Console.WriteLine(initialMovementXSpeed);
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
}

