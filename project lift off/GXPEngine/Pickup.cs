using GXPEngine;
using System;
class PickupCoin : AnimationSprite
{
    public bool HasPickedUp = false;
   

    public PickupCoin() : base("coin.jpg", 1, 1)
    {
        // SpawnCoin();
        x = Utils.Random(64, game.width - 64);
        y = Utils.Random(400, game.height - 64);
    }

    void Update()
    {
      //  Console.WriteLine(Time.time+":time"+timeFollower+":timeFollower");
       // SpawnCoin();
    }

   
    public void PickedUp()
    {
        
    }

}

