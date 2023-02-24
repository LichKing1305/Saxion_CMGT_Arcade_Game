using GXPEngine;
using System;
class PickupCoin : AnimationSprite
{
    public bool HasPickedUp = false;
    Sound pickupSound;
    float vy;
    float vx;
    bool isYBounce = false;
    bool isXbounce = false;
    bool secondBounceDone = false;
    public PickupCoin() : base("coin_sprite.png", 4, 1)
    {
        pickupSound = new Sound("ping.wav", false, false);
        // SpawnCoin();
        x = Utils.Random(64, game.width - 64);
        y = Utils.Random(-50, -20);
        vy = Utils.Random(3, 8);
        vx = Utils.Random(5, 8);
    }

    void Update()
    {

        //  Console.WriteLine(Time.time+":time"+timeFollower+":timeFollower");
        // SpawnCoin();
        Console.WriteLine(vy);
        // IdleCoin();
        BounceOnTheFloor();

    }
    void BounceOnTheFloor()
    {
        float oldy;
        oldy = 812;
        if (!isYBounce)
        {
            y += vy;
        }
        else
        {
            y -= vy;
            if (y <= oldy )
            {
                isYBounce = false;
                Console.WriteLine("the one with oldy");
            }
            
           

        }
    }
    void IdleCoin()
    {
        SetCycle(0, 4);
        Animate(0.125f);
    }
    void OnCollision(GameObject otherthanpickup)
    {
        if (otherthanpickup is Bear || otherthanpickup is Bear2)
        {
            pickupSound.Play();

        }
        if (otherthanpickup is Solid)
        {
            isYBounce = true;
        }
        /*  ------------------------prob will use it later---------------------
         *  if (otherthanpickup is Solid)
          {
              if (y >= 900)
              {
                  isCoinBounceBack = true;
              }
        --------------------prob will use it later------------------------------
          }*/
    }
    public void PickedUp()
    {

    }
    void Xbounce()
    {
        if (!isXbounce)
        {
            x += vx;
        }
        else { x -= vx; }
        if (x >= game.width - 64)
        {

            Console.WriteLine("shit");
            isXbounce = true;
        }
        else if (x <= 64)
        {
            isXbounce = false;
        }

    }
    void FallCoin()
    {

        if (!isYBounce)
        {
            y += vy;
        }
        else
        {
            y -= vy;
        }
        if (y <= 0 && isYBounce)
        {
            isYBounce = false;
        }
    }
}

