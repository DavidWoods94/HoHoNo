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
    class Melt : GameObject
    {

        static BitmapImage b = null;


        public static List<Melt> list = new List<Melt>();


        public Melt()
        {

            UseImage("meltingsnowman.png", ref b);

            makeInactive();

            Scale = 1.0;
            Melt.list.Add(this);

            AddToGame();

        }


        public static Melt getNextAvailable()
        {
            foreach (Melt obj in list)
            {
                if (!obj.isActive)
                {
                    return obj;
                }
            }
            return null;
        }

        public void initializeSpeed()
        {
            dY = 0.0;
            dX = 0.0;
        }


        //double gravity = 0.0;
        //double friction = 1.0;


        int frameCount = 0;

        public int exploLength = 15;

        internal override void update()
        {
            if (isActive)
            {
                frameCount++;
                
                //Angle = G.randAngle();
                Scale = 2;
                if (frameCount >= exploLength)
                {
                    exploLength = 8;
                    Scale = 1.0;
                    frameCount = 0;
                    makeInactive();
                }

            }
        }

    }
}
