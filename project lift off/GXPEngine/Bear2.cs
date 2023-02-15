using GXPEngine;
using System;

public class Bear2 : AnimationSprite
{
    float dropSpeed = 0f;
    int health = 1;
    public bool Player2Switch;
    public Bear2() : base("square2.png", 1, 1)
    {
        y = 600 - height;
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
        float movementXSpeed = 1.5f;
        if (Input.GetKey(Key.L)) { Move(movementXSpeed, 0); }
        else if (Input.GetKey(Key.J)) { Move(-movementXSpeed, 0); }

    }

    void YMovement()
    {

        dropSpeed += 0.2f;
        float jumpSpeed = 4f;
        y += dropSpeed;
        if (y > 600 - height)
        {
            y = 600 - height;
            dropSpeed = 0;
            if (Input.GetKey(Key.I)) { Move(0, dropSpeed -= jumpSpeed); }
        }


    }
    void Health()
    {
        if (health < 1) { Destroy(); }

    }
    void OnCollision(GameObject OtherThanBear2)
    {

        if (OtherThanBear2 is Claw) { health--; /* Console.WriteLine("fff");*/ }

    }
    void PlayerDestroyed()
    {
        if (!Player2Switch) { /*LateDestroy(); Console.WriteLine("destroyed");*/ }
    }
}

