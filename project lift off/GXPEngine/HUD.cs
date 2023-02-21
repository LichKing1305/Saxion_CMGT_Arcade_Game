using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GXPEngine
{

    public class HUD : Canvas
    {
        private Claw _claw;
        public HUD(Claw claw) : base(256, 128, false)
        {
            _claw = claw;
        }

        void Update()
        {
            graphics.Clear(Color.Empty);
            graphics.DrawString("Time: " + _claw.GetScore(), SystemFonts.DefaultFont, Brushes.White, 75, 0);
        }
    }
}