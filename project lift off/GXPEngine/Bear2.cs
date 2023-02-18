using GXPEngine;
using System;
using System.Threading;

public class Bear2 : AnimationSprite
{
    /*-------flaot-------------*/
    float initialDropSpeed;
    float dropSpeed = 0.2f;
    float movementXSpeed = 1.5f;
    float jumpSpeed = 10f;
    /*-------int------------*/
    int health = 1;
    int _score;
    /*------bool-----------*/
    public bool Player2Switch;
    bool frozeMovement = false;
    public Bear2() : base("square2.png", 1, 1)
    {
        y = 300 - height;
        x = 300;
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
        if (Input.GetKey(Key.L)) { this.Mirror(false, false); this.MoveUntilCollision(movementXSpeed, 0); }
        else if (Input.GetKey(Key.J)) { this.Mirror(true, false); MoveUntilCollision(-movementXSpeed, 0); }
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
                if (Input.GetKey(Key.I))
                {
                    this.Move(0, initialDropSpeed -= jumpSpeed);
                }
            }
        }
    }
    /*------------------------- CODE FOR SHOTING PROJECTILE(S)--------------------------------------*/
    void Shot()
    {
        Console.WriteLine(x + ":" + y+":frozeMovement:"+frozeMovement);
        if (Input.GetKeyDown(Key.P))
        {
            Screw screw = new Screw(_mirrorX ? -1 : 1);
            screw.SetXY(x + (_mirrorX ? -3 : 1) * (width / 2), y - (height / 2));
            parent.AddChild(screw);
            Console.WriteLine(screw.x+":"+screw.y);
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
        if (frozeMovement == true)
        {
            Thread.Sleep(2000);
            frozeMovement = false;
        }
    }
    private void TimerCallback(Object o)
    {
        if (health > 0)
        {
            _score = _score + 1;
        }
    }
    void PlayerDestroyed()
    {
        if (!Player2Switch) { /*LateDestroy(); Console.WriteLine("destroyed");*/ }
    }
}

