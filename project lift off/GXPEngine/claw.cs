
using GXPEngine;
using TiledMapParser;

public class Claw : AnimationSprite
{
    bool dropSwitch = false;
    float movementSpeed = 1.5f;
    float dropSpeed = 10f;
    float goUpSpeed = 3f;

    public Claw(TiledObject obj = null) : base("claw_sprite.png", 4, 1)
    {
        if (obj != null)
        {
            dropSpeed = obj.GetFloatProperty("dropSpeed", 150f);
            goUpSpeed = obj.GetFloatProperty("goUpSpeed", 3f);
            movementSpeed = obj.GetFloatProperty("movementSpeed", 1.5f);
        }
    }

    void OnCollision(GameObject OtherThanClaw)
    {
        if (OtherThanClaw is Bear || OtherThanClaw is Bear2)
        {
            PickupBearAnimation();
        }

    }
    void PickupBearAnimation()
    {
        if (currentFrame != 2)
        {
            SetCycle(0, 3);
            Animate(0.2f);
        }
    }
    void Update()
    {
        XMovement();
        YMovement();

    }

    void XMovement()
    {
        if (Input.GetKey(Key.RIGHT))
        {
            MoveUntilCollision(movementSpeed, 0);

        }
        else if (Input.GetKey(Key.LEFT))
        {
            MoveUntilCollision(-movementSpeed, 0);

        }

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
            if (colied[i] is Solid)
            {
                dropSwitch = true;
                y -= goUpSpeed;
                SetCycle(3, 1);
                Animate(0.1f);
            }
        }
    }


}


