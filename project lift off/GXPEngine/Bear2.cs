using GXPEngine;
using System;

public class Bear2 : AnimationSprite
{
    /*-------flaot-------------*/
    float initialDropSpeed;
    float dropSpeed = 0.2f;
    float movementXSpeed = 1.5f;
    float movementXSpeedDecrease = 0.5f;
    float jumpSpeed = 10f;
    /*-------int------------*/
    public int health = 1;
    const int cooldown = 2000;
    int zero;
    /*------bool-----------*/
    public bool Player2Switch;
    bool frozeMovement = false;
    bool isIdle = true;
    bool isShooting = false;
    bool isJumping = false;
    bool isDead = false;
    bool isWalking = false;
    public Bear2() : base("bear_sprite_retry_retry.png", 8, 5)
    {
        y = 220;
        x = 300;
        width = 128;
        height = 124;

    }
    void Update()
    {
        if (!isDead)
        {
            IdleAnimation();
            XMovement();
            Shot();
            RecovorMovement();
            ShotAnimation();
            JumpAnimation();
            WalkAnimation();

        }
        YMovement();
        Death();
    }
    void WalkAnimation()
    {
        if (isWalking)
        {
            isJumping = false;
            isIdle = false;
            SetCycle(0, 4);
            Animate(0.3f);
        }
    }
    void IdleAnimation()
    {
        if (isIdle)
        {
            SetCycle(8, 4);
            Animate(0.1f);

        }
    }
    void ShotAnimation()
    {
        if (isShooting)
        {
            isWalking = false;
            isIdle = false;
            SetCycle(27, 10);
            Animate(0.16f);
            if (currentFrame == 36) { isShooting = false; }

        }
    }
    void DeathAnimation()
    {
        SetCycle(12, 8); Animate(0.1f); //death = false;

    }
    void JumpAnimation()
    {
        if (isJumping)
        {
            isWalking= false;
            isIdle = false;
            isShooting = false;
            SetCycle(4, 5);
            Animate(0.04f);
            Console.WriteLine(currentFrame);
            if (currentFrame == 8)
            {
                isJumping = false;
            }
        }
    }
    /*-------------------------------MOVEMENT CODE FOR X DIRECTIONS---------------------------------------------------------*/
    void XMovement()
    {
        if (Input.GetKey(Key.L)) { this.Mirror(false, false); this.MoveUntilCollision(movementXSpeed, 0); isWalking = true; }
        else if (Input.GetKey(Key.J)) { this.Mirror(true, false); MoveUntilCollision(-movementXSpeed, 0); isWalking = true; }
        else { isIdle = true; isWalking = false; }
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
            if (colied[i] is Solid || colied[i] is Bear)
            {
                initialDropSpeed = 0;
                y = oldy;
                if (Input.GetKey(Key.I) && !isDead)
                {
                    this.MoveUntilCollision(0, initialDropSpeed -= jumpSpeed);
                    isJumping = true;
                }
            }
        }
    }
    /*------------------------- CODE FOR SHOTING PROJECTILE(S)--------------------------------------*/
    void Shot()
    {
        // Console.WriteLine(x + ":" + y + ":frozeMovement:" + frozeMovement);
        if (Input.GetKeyDown(Key.P))
        {
            isShooting = true;
            Screw screw = new Screw(_mirrorX ? -5 : 5);
            screw.SetXY(x + (_mirrorX ? -2 : 2) * (width / 2), y + (height / 2));
            parent.AddChild(screw);
            Console.WriteLine(screw.x + ":" + screw.y);

        }
    }
    /*------------------------ CODE FOR DEATH ---------------------------------------------------*/
    void Death()
    {
       // Console.WriteLine(isDead);
        if (health < 1)
        { //Destroy();
            isIdle = false;
            isJumping = false;
            isDead = true;
            if (currentFrame != 19)
            {
                DeathAnimation();
            }
            
        }
    }
    /*------------------------ CODE FOR COLLIDING WITH COLLISIONS --------------------*/
    void OnCollision(GameObject OtherThanBear)
    {
        if (OtherThanBear is Claw) { health--; /*Player2Switch = false;*/ }
        if (OtherThanBear is Screw)
        {
            frozeMovement = true;
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
    void PlayerDestroyed()
    {
        if (!Player2Switch) { /*LateDestroy(); Console.WriteLine("destroyed");*/ }
    }
}

