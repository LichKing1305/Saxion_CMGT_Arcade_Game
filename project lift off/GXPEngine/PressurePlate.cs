using System;
using GXPEngine;

public class PressurePlate : Sprite 
{
    Bear2 _bear2;
    Bear _bear;
    Level _nextlevel;
    public string map = "levlemap.tmx";
    bool _isActivated;

    public PressurePlate(Bear bear, Bear2 bear2) : base("colors.png")
    {
        _bear2 = bear2;
        _bear = bear;
        _isActivated = false;
    }

    void Update()
    {
        if (_bear.HitTest(this) || _bear2.HitTest(this))
        {
            activate();
        }
        else
        {
            deactivate();
        }
    }

    void activate()
    {
        if (_isActivated == false)
        {
            Level level = new Level(map); 
            _isActivated = true;
            level.loadLevel();
        }
    }

    void deactivate()
    {
        if (_isActivated == true)
        {
            _isActivated = false;
        }
    }

}
