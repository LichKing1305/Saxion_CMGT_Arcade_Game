using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
public class Powerup : AnimationSprite
{

    public Powerup() : base("circle.png", 1, 1)
    {
        spawn();
    }

    void Update()
    {



    }

    void spawn()
    {
        x = Utils.Random(0, game.width - this.width);
        y = Utils.Random(500, game.height - this.height);
    }
    public void Pickup()
    {
        spawn();
    }

}