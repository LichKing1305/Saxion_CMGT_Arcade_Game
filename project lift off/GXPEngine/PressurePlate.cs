using System;
using TiledMapParser;
using GXPEngine;

public class PressurePlate : Sprite
{
    private Bear _bear;
    private Bear2 _bear2;
    private string _map;
    private bool _isActivated;
    string nextLevel;
    string menu = "menu.tmx";
    public PressurePlate(/*Bear bear,Bear2 bear2, int x, int y, string map,*/ TiledObject obj =null) : base("plate.png")
    {

        
        collider.isTrigger = true;
        //_bear = bear;
        //_bear2 = bear2;
       // _map = map;
        SetXY(x, y);
        _isActivated = false;
        if(obj != null)
        {
            nextLevel = obj.GetStringProperty("nextLevel", "menu");
           // nextLevel = obj.GetStringProperty("nextLevel", null);
            Console.WriteLine();
        }

    }
    void OnCollision(GameObject OtherThanClaw)
    {
        if (OtherThanClaw is Bear || OtherThanClaw is Bear2)
        {
            //_isActivated = true;
            Activate();
        }
        else
        {
            Deactivate();
        }

    }
    void Update()
    {
        /*if (_bear != null && _bear2 != null && _bear.HitTest(this) && _bear2.HitTest(this))
        {
            Console.WriteLine("switching levels");
            Console.WriteLine(_bear2);
            Activate();
        }
        else
        {
            Deactivate();
        }*/
    }

    public void Activate()
    {
        ((MyGame)game).LoadLevel(nextLevel + ".tmx");
        Console.WriteLine("Level switch");
    }

    void Deactivate()
    {
        if (!_isActivated)
        {
            _isActivated = false;
        }
    }
}
