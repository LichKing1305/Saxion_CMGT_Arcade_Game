using GXPEngine;
using System;
class PickupCoin : AnimationSprite
{
    public bool HasPickedUp = false;
    Sound pickupSound;

    public PickupCoin() : base("coin_sprite.png", 4, 1)
    {
        pickupSound = new Sound("ping.wav", false, false);
        // SpawnCoin();
       x = Utils.Random(64, (game.width - (128 + width)));
       y = Utils.Random(400, (game.height - (128 + height)));
    }

    void Update()
    {
        //  Console.WriteLine(Time.time+":time"+timeFollower+":timeFollower");
        // SpawnCoin();
        IdleCoin();
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
    }
    public void PickedUp()
    {
        
    }

}

