using GXPEngine;
using System;
class PickupCoin : AnimationSprite
{
    public bool HasPickedUp = false;
    const int coolDown = 10000;
    int timeFollower = 0;

    public PickupCoin() : base("coin.jpg", 1, 1)
    {
        // SpawnCoin();
        x = Utils.Random(64, game.width - 64);
        y = Utils.Random(400, game.height - 64);
    }

    void Update()
    {
        Console.WriteLine(Time.time+":time"+timeFollower+":timeFollower");
        SpawnCoin();
    }

    void SpawnCoin()
    {
        if (Time.time > timeFollower + coolDown)
        {
            Console.WriteLine("spawn");
            x = Utils.Random(64, game.width-64);
            y = Utils.Random(400, game.height - 64);
            timeFollower = Time.time;
         
        }
        else if (HasPickedUp)
        {
            //Remove();
            timeFollower = Time.time;
            HasPickedUp = false;
            x = -100;
            y = -100;
        }
    }
    public void PickedUp()
    {
        
    }






}

