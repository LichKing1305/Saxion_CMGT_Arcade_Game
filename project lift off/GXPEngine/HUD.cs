using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GXPEngine
{

    public class HUD : Canvas
    {
        private Bear _bear;
        public HUD(Bear bear) : base(128, 64, false)
        {
            _bear = bear;
        }

        void Update()
        {
            graphics.Clear(Color.Empty);
            graphics.DrawString("Score: " + _bear.GetScore(), SystemFonts.DefaultFont, Brushes.White, 0, 0);
        }
    }
}