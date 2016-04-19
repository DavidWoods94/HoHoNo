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
    class DateTimeText:GameText
    {
        internal DateTimeText(string text, double percentageX, double percentageY, double fontSize, Color color)
            : base(text,percentageX,percentageY,fontSize,color)
        {

        }

        DateTime d = new DateTime();


        internal override void update()
        {
            d=DateTime.Now;
            Text = d.ToLongDateString() + "\n" + d.ToLongTimeString();
            base.update();
        }

    }
}
