using System;
using GXPEngine;

public class PressurePlate : Sprite 
{
    Bear2 _bear2;
    Bear _bear;
    Level _nextlevel;
    bool _isActivated;

    public PressurePlate(Bear bear, Bear2 bear2, Level filename) : base("colors.png")
    {
        _bear2 = bear2;
        _bear = bear;
        _isActivated = false;
        _nextLevel = filename;
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
            _isActivated = true;
            _nextLevel.LoadLevel();
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
