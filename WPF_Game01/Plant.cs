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
    class Plant : GameObject
    {

        internal static List<Plant> list = new List<Plant>();

        double maxScale;

        static BitmapImage bMap = null;

        internal Plant()
        {

            UseImage("plant.png",ref bMap);

            Scale = 0.1;

            makeInactive();

            scaleTransform.CenterX = element.Width / 2.0;
            scaleTransform.CenterY = element.Height;

            maxScale = G.randD(0.4, 0.6);

            Plant.list.Add(this);
            
            AddToGame();

            if (G.chance(0.2)) Plant.StartPlant(G.randD(0.1,maxScale));


        }

        internal static Plant getNextAvailable()
        {
            foreach(Plant b in list )
            {
                if(!b.isActive)
                {
                    return b;
                }
            }
            return null;
        }

        internal void initializeSpeed()
        {
            dY= -10.0;
            dX = 0.0;
        }

        internal static double energy = 30.0;
        
        internal int frameCount = 0;


        double t = G.randD(0.0, Math.PI * 2.0);
        double dt = G.randD(0.01, 0.04);
        double amplitude = G.randD(0.04,1.0);

        internal override void update()
        {
            if (isActive)
            {
                if (Scale < maxScale) Scale += 0.005;
            }
            t += dt;
            dY = Math.Sin(t) * amplitude;
            Y += dY;
        }

        static internal bool existsGardenOfEden = false;
        internal static void StartPlant(double startScale = 0.1)
        {
            Plant p = Plant.getNextAvailable();
            if (p != null)
            {
                p.Scale = startScale;
                if (G.chance(0.5) || (!existsGardenOfEden))
                {
                    p.X = G.randD(G.gameWidth);
                    p.Y = G.randD(G.gameHeight);
                }
                else
                {
                    //Garden of Eden
                    double goeSize = 50.0;
                    double cx = G.gameWidth * 0.66666;
                    double cy = G.gameHeight * 0.5;
                    double r = G.randD(goeSize);
                    double a = G.randD(Math.PI * 2.0);
                    p.X = (Math.Cos(a) * r) + cx;
                    p.Y = (Math.Sin(a) * r) + cy;
                }
            }
        }

    }
}
