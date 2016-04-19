//************************************************
//
// (c) Copyright 2015 Dr. Thomas Fernandez
//
// All rights reserved.
//
//************************************************

using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WPFStartupDemo
{
    class FrameRateText:GameText
    {
        internal FrameRateText(string text, double percentageX, double percentageY, double fontSize, Color color)
            : base(text,percentageX,percentageY,fontSize,color)
        {

        }

        TimeSpan lastTime = TimeSpan.Zero;
        int targetFrameRate = 30;
        static internal double badFrameCount = 0.0;
        static internal double totalFrameCount = 0.0;

        internal override void update()
        {
            totalFrameCount++;
            int timeMS = (CompositionTargetEx._last - lastTime).Milliseconds;
            if (timeMS == 0) timeMS = 1;
            int frameRate = (1000 / timeMS);
            if (frameRate < targetFrameRate) badFrameCount++;
            Text = frameRate.ToString() + "   " + ((Math.Truncate((100.0 * badFrameCount) / totalFrameCount))).ToString() + "%";
            lastTime = CompositionTargetEx._last;
            base.update();
        }

    }
}