using GXPEngine;
using System;
using TiledMapParser;

public class Bear : AnimationSprite
{
    Sound bearwalk;
   
    /*----------floats---------*/
    float initialDropSpeed = 0;
    float jumpSpeed= 10f;
    float movementXSpeed= 3.5f;
    float initialMovementXSpeed;
    float movementXSpeedDecrease = 0.5f;
    float dropSpeed = 0.2f;
    /*---------int---------*/
    public int health = 1;
    const int cooldown = 2000;
    int zero;
    int coinAmount;
    /*-------bool----*/
    bool frozeMovement = false;
    //bool death = true;
    bool isDead = false;
    bool isIdle = true;
    bool isShooting = false;
    bool isJumping = false;
    bool isWalking = false;

    //Level level;


    /*-------------------------------------CONSTRUCTER------------------------------------------------------------*/
    public Bear() : base("bear_sprite_retry_retry.png", 8, 5)
    {
        // level = new Level(map);
        //filename = level._filename;
        //cols = _cols;
        //rows = _rows;
        
        width = 124;
        height = 128;
        x = 1000;
        y = game.height - height - 200;
        initialMovementXSpeed = movementXSpeed;
        bearwalk = new Sound("bear_walk_sound.wav", true, false);
        //pickup = new PickupCoin();
      /*  if (obj != null)
        {
            dropSpeed = obj.GetFloatProperty("dropSpeed", 0.2f);
            jumpSpeed = obj.GetFloatProperty("jumpSpeed", 10f);
            movementXSpeed = obj.GetFloatProperty("movementXSpeed", 3.5f);
            //health = obj.GetIntProperty("health", 1);
        }*/
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

        // Musics();
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
            isWalking = false;
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
        float oldx = x;
        if (Input.GetKey(Key.D)) { this.Mirror(false, false); this.Move(movementXSpeed, 0); isWalking = true; }
        else if (Input.GetKey(Key.A)) { this.Mirror(true, false); Move(-movementXSpeed, 0); isWalking = true; }
        else { isIdle = true; isWalking = false; }
        GameObject[] colied = GetCollisions();
        for (int i = 0; i < colied.Length; i++)
        {
            if (colied[i] is Solid)
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
                if (Input.GetKeyDown(Key.W) && !isDead)
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
        if (Input.GetKeyDown(Key.F) && coinAmount >= 1)
        {
            isShooting = true;
            Screw screw = new Screw(_mirrorX ? -25 : 25);
            screw.SetXY(x + (_mirrorX ? -3 : 2) * (width / 2), y - (height / 2));
            parent.AddChild(screw);
            coinAmount--;
            Console.WriteLine("shoting");
            SetCycle(28, 5); Animate(0.5f);
        }


    }
    /*------------------------ CODE FOR DEATH ---------------------------------------------------*/
    void Death()
    {

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
        if(OtherThanBear is PressurePlate) 
        {
            ((PressurePlate)OtherThanBear).Activate();
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

