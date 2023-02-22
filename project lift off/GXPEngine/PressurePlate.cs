using System;
using GXPEngine;

public class PressurePlate : Sprite
{
    //private Bear _bear;
    private Bear2 _bear2;
    private string _map;
    private bool _isActivated;
    string menu = "menu.tmx";
    public PressurePlate(/*Bear bear,*/Bear2 bear2, int x, int y, string map) : base("colors.png")
    {
        //_bear = bear;
        _bear2 = bear2;
        _map = map;
        SetXY(x, y);
        _isActivated = false;
    }

    void Update()
    {
        if (/*_bear != null &&*/ _bear2 != null /*&& _bear.HitTest(this)*/ && _bear2.HitTest(this))
        {
            Console.WriteLine("switching levels");
            Console.WriteLine(_bear2);
            Activate();
        }
        else
        {
            Deactivate();
        }
    }

    void Activate()
    {
        Console.WriteLine("Level switch");
        if (!_isActivated)
        {
            Level level = new Level(_map);
            _isActivated = true;
            level.LoadLevel();
        }
    }

    void Deactivate()
    {
        if (_isActivated)
        {
            _isActivated = false;
        }
    }
}
