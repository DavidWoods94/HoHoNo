
//************************************************
//
// (c) Copyright 2015 Dr. Thomas Fernandez
//
// All rights reserved.
//
//************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WPFStartupDemo
{
    class FloatingText : GameText
    {
        internal FloatingText(string text, double percentageX, double percentageY, double fontSize, Color color)
            : base(text, percentageX, percentageY, fontSize, color)
        {
        }

        // float up and down vars
        internal double t = G.randD(0.0, Math.PI * 2.0);
        internal double dt = G.randD(0.01, 0.04);
        internal double amplitude = G.randD(0.1, 0.5);

        //rock back and forth vars
        internal double t2 = G.randD(0.0, Math.PI * 2.0);
        internal double dt2 = G.randD(0.01, 0.02);
        internal double amplitude2 = G.randD(1.0, 3.0);

        internal override void update()
        {
            // float up and down
            t += dt;
            dY = Math.Sin(t) * amplitude;
            Y += dY;

            //rock back and forth
            t2 += dt2;
            Angle = Math.Sin(t2) * amplitude2;         
        }

    }
}
