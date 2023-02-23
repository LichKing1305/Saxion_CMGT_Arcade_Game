using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GXPEngine
{
    

    public class HUD : Canvas
    {
        Font myFont = Utils.LoadFont("DS-DIGI.TTF", 12.0f, FontStyle.Regular);
        private Level level;
        public HUD(Level _level) : base(256, 128, false)
        {
            level = _level;
        }

        void Update()
        {
            graphics.Clear(Color.Empty);
            graphics.DrawString("Time: " + level.GetScore(), myFont, Brushes.Red, 75, 0);
        }
    }
}