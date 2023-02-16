using GXPEngine;
using System;
using TiledMapParser;

public class Screw : AnimationSprite
{
    float throwingSpeed=4f;
    public Screw(string filename, int cols, int rows, TiledObject obj = null) : base(filename, cols, rows)
    {
       if (obj != null)
        {
            throwingSpeed = obj.GetFloatProperty("throwingSpeed", 4f);
        }

    }

    public Screw() : base("screw.jpg", 1, 1) { }
    void Update()
    {
        x += throwingSpeed;

        destroyOutOfScreen();
    }
    void destroyOutOfScreen()
    {
        if (x < 0 || x > game.width)
        {
            Destroy();
            Console.WriteLine("destroyed");
        }

    }
    void OnCollision(GameObject notBullet)
    {
        if (notBullet is Bear2) { this.LateDestroy(); }//bullet.Play(); }// Console.WriteLine("im hitting collision");  

    }


}













