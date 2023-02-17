using GXPEngine;
using System;

public class Bear2 : AnimationSprite
{
    float initialDropSpeed;
    float dropSpeed = 0.2f;
   float movementXSpeed=1.5f;
    float jumpSpeed = 10f;
   // float moveSpeed = 1.5f;
    float knockBack = 5f;
    int health = 1;
    public bool Player2Switch;
    public Bear2() : base("square2.png", 1, 1)
    {
        y = 300 - height;
        x = 300;
    }
    void Update()
    {
        XMovement();
        YMovement();
        Health();
        //  Console.WriteLine(health);
        // PlayerDestroyed();

    }
    void XMovement()
    {

        if (Input.GetKey(Key.L)) { Move(movementXSpeed, 0); }
        else if (Input.GetKey(Key.J)) { Move(-movementXSpeed, 0); }

    }

    void YMovement()
    {
        float oldy = y;
        initialDropSpeed += dropSpeed;
        y += initialDropSpeed;
        GameObject[] colied = GetCollisions();
        for (int i = 0; i < colied.Length; i++)
        {
            if (colied[i] is Solid)
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
    void Health()
    {
        if (health < 1) { Destroy(); Player2Switch = false; }

    }
    void OnCollision(GameObject OtherThanBear2)
    {

        if (OtherThanBear2 is Claw) { health--; /* Console.WriteLine("fff");*/ }
        if (OtherThanBear2 is Screw) { movementXSpeed = 0.5f;/* x += knockBack; y -= knockBack; Console.Write("speed slow down");*/ } 

    }
    void PlayerDestroyed()
    {
        if (!Player2Switch) { /*LateDestroy(); Console.WriteLine("destroyed");*/ }
    }
}

