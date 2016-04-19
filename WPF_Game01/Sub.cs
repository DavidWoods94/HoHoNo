
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
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFStartupDemo
{
    class Sub : GameObject
    {

        internal static List<Sub> list = new List<Sub>();


        static BitmapImage bMap = null;


        internal Sub()
        {

            UseImage("Sub.png",ref bMap);

            Scale = 1.0;

            makeInactive();

            Sub.list.Add(this);
            
            AddToGame();


        }


        internal static Sub getNextAvailable()
        {
            foreach(Sub b in list )
            {
                if(!b.isActive)
                {
                    return b;
                }
            }
            return null;
        }





        internal int frameCount = 0;


        internal override void update()
        {
            if (isActive)
            {
                if (G.chance(0.001)) launchSub();
                Bubble.LaunchBubbles(5,X,Y);
                X += dX;
                Y += dY;
                dX *= 0.9999;
                dY *= 0.995;
                if ((X >= G.gameWidth + (ScaledWidth / 2.0)) || (Y >= G.gameHeight + (ScaledHeight / 2.0)))
                {
                    Scale = 0.001;
                    makeInactive();
                }
                else
                {
                    if (Scale < 2.5) Scale *= 1.035;
                }
            }
        }

        static internal void launchSub()
        {
            int numSubs = 1;
            for (int i = 0; i < numSubs; i++)
            {
                Sub sub = Sub.getNextAvailable();
                if (sub != null)
                {
                    sub.Scale = 0.1;
                    sub.X = -sub.ScaledWidth;
                    sub.Y = G.gameHeight * G.randD(0.0, 0.3);
                    sub.dX = 20;
                    sub.dY = 6;
                }
            }
        }

    }
}
