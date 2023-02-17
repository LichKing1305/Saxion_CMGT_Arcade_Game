using GXPEngine;
using System;
using TiledMapParser;

 class Screw : AnimationSprite
{
    float throwingSpeed;
  
    public Screw(float vx) : base("screw.jpg", 1, 1) 
    {
        throwingSpeed = vx;
       
    
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
        if (notBullet is Bear2|| notBullet is Bear) { this.LateDestroy(); }//bullet.Play(); }// Console.WriteLine("im hitting collision");  

    }


}













