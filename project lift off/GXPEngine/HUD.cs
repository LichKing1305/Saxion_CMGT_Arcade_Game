using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GXPEngine;

public class HUD : Canvas 
{
    private Claw _claw;
    string SNES= "SnesItalic-1G9Be.ttf";
    public HUD (Claw claw) : base(128,64) 
    {
        _claw = claw;
    }

    void Update () 
    { 
        graphics.Clear(Color.Empty);
        graphics.DrawString("Time:" + _claw.GetScore(), SystemFonts.DefaultFont, Brushes.White, 100, 0);
        Console.WriteLine(_claw.GetScore());
    }
}

