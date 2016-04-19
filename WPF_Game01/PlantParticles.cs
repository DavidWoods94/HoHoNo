
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
    class PlantParticle : GameObject
    {

        static BitmapImage bMap = null;


        internal static List<PlantParticle> list = new List<PlantParticle>();

        internal PlantParticle()
        {

            UseImage("PlantParticle.png",ref bMap);

            Scale = 1.0;

            makeInactive();

            PlantParticle.list.Add(this);

            AddToGame();

        }

        static int lastFound = -1;
        internal static PlantParticle getNextAvailable()
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

        double gravity = 0.0;
        double friction = 0.99;

        internal int frameCount = 0;

        internal double t = G.randD(0.0, Math.PI * 2.0);
        internal double dt = G.randD(0.01, 0.04);
        internal double amplitude = G.randD(0.1, 0.2);

        internal double rotation;

        internal override void update()
        {
            if (isActive)
            {
                frameCount--;

                Scale *= 0.95;

                t += dt;
                dY += Math.Sin(t) * amplitude;


                dY += gravity;
                if (Y < 0.0) makeInactive();
                else if (Y > G.gameHeight) makeInactive();
                else if (X < 0.0) makeInactive();
                else if (X > G.gameWidth) makeInactive();

                dX *= friction;
                dY *= friction;

                Angle += rotation;

                X += dX;
                Y += dY;
                if (frameCount <= 0)
                {
                    makeInactive();
                }
            }
        }

        static internal void LaunchPlantParticle(int howMany,double x,double y)
        {
            for (int i = 0; i < howMany; i++)
            {
                PlantParticle p = PlantParticle.getNextAvailable();
                if (p != null)
                {
                    const double pSpeed = 2.0;
                    p.X = x;
                    p.Y = y;
                    p.dX = G.randD(-pSpeed , pSpeed );
                    p.dY = G.randD(-pSpeed, pSpeed );
                    p.frameCount = 20;
                    p.Scale = G.randD(1.0, 2.0);
                    p.Angle = G.randAngle();
                    p.rotation = G.randD(-4.0, 4.0);

                }
            }
        }


    }
}
