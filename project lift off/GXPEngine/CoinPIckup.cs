using System;
using System.Threading.Tasks;
using GXPEngine;

public class CoinPickup : AnimationSprite 
{ 
    public CoinPickup(string filename, int cols, int rows) : base(filename, cols, rows) 
    { 
    
    }

    public CoinPickup() : base("coin.jpg", 1, 1)
    {

    }
}
