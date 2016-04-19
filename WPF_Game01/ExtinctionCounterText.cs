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
using System.Windows.Media;

namespace WPFStartupDemo
{
    class ExtinctionCounterText:FloatingText
    {
        internal ExtinctionCounterText(string text, double percentageX, double percentageY, double fontSize, Color color)
            : base(text,percentageX,percentageY,fontSize,color)
        {

        }

        internal override void update()
        {
            base.update();
        }

    }
}
