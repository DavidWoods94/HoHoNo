
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
    class Bubble : GameObject
    {

        static BitmapImage bMap = null;


        internal static List<Bubble> list = new List<Bubble>();

        internal Bubble()
        {

            UseImage("bubble2.png",ref bMap);

            Scale = 0.1;

            makeInactive();

            Bubble.list.Add(this);

            AddToGame();

        }

        static int lastFound = -1;
        internal static Bubble getNextAvailable()
        {
            for (int i = 0; i < list.Count(); i++)
            {
                lastFound = (lastFound + 1) % list.Count();
                if (!list[lastFound].isActive)
                {
                    return list[lastFound];
                }
            }
            return null;
        }

        double gravity = -0.25;
        double friction = 0.99;

        internal int frameCount = 0;

        internal double t = G.randD(0.0, Math.PI * 2.0);
        internal double dt = G.randD(0.01, 0.04);
        internal double amplitude = G.randD(0.1, 0.2);
        internal override void update()
        {
            if (isActive)
            {
                frameCount--;

                t += dt;
                dY += Math.Sin(t) * amplitude;


                dY += gravity;
                if (Y < 0.0) makeInactive();
                else if (Y > G.gameHeight) makeInactive();
                else if (X < 0.0) makeInactive();
                else if (X > G.gameWidth) makeInactive();

                dX *= friction;
                dY *= friction;

                X += dX;
                Y += dY;
                if (frameCount <= 0)
                {
                    makeInactive();
                }
            }
        }

        static internal void LaunchBubbles(int howMany,double x,double y)
        {
            for (int i = 0; i < howMany; i++)
            {
                Bubble p = Bubble.getNextAvailable();
                if (p != null)
                {
                    const double pSpeed = 4.0;
                    p.X = x;
                    p.Y = y;
                    p.dX = G.randD(-pSpeed / 2.0, pSpeed / 2.0);
                    p.dY = G.randD(-pSpeed, 0.0);
                    p.frameCount = 200;
                    p.Scale = G.randD(0.1, 0.4);
                }
            }
        }


    }
}
