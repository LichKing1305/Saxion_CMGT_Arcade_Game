using GXPEngine;
using System;
class PickupCoin : AnimationSprite
{
    public bool HasPickedUp = false;
   

    public PickupCoin() : base("coin_sprite.png", 4, 1)
    {
        // SpawnCoin();
        x = Utils.Random(64, game.width - 64);
        y = Utils.Random(400, game.height - 64);
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
    public void PickedUp()
    {
        
    }

}

