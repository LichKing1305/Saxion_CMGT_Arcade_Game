using GXPEngine;
using System;
using TiledMapParser;

 class Screw : AnimationSprite
{
    public float throwingSpeed;
  
    public Screw(float vx) : base("coin.jpg", 1, 1) 
    {
        throwingSpeed = vx;
        width=width/2;
        height = height / 2;
    
    }
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
        if (notBullet is Bear2 || notBullet is Bear || notBullet is Solid) { this.LateDestroy(); /*bullet.Play(); }*/Console.WriteLine("im hitting collision"); }  

    }


}













