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
    class Diver : GameObject
    {

        internal static List<Diver> list = new List<Diver>();


        static BitmapImage bMap = null;


        internal Diver()
        {
            UseImage("Diver4.png",ref bMap);
            makeInactive();
            Diver.list.Add(this);
            AddToGame();
        }


        internal static Diver getNextAvailable()
        {
            foreach(Diver b in list )
            {
                if(!b.isActive)
                {
                    return b;
                }
            }
            return null;
        }

        internal double t = G.randD(0.0, Math.PI * 2.0);
        internal double dt = G.randD(0.01, 0.04);
        internal double amplitude = G.randD(0.1, 0.5);

        internal int frameCount = 0;
        string status;

        internal override void update()
        {
            if (isActive)
            {
                t += dt;
                double moreDY = Math.Sin(t) * amplitude;

                Bubble.LaunchBubbles(1,X, Y - (ScaledHeight / 2.0));
                switch (status)
                { 
                    case"Down":
                        Y += dY+moreDY;;
                        if (Y > (G.gameHeight - ((G.gameHeight*0.33)-ScaledHeight)) ) status = "Bottom";
                        break;
                    case "Bottom":
                        if (G.chance(0.001)) launchDiver();
                        if (G.chance(0.007)) status = "Up";
                        break;
                    case "Up":
                        Y -= dY+moreDY;
                        if(Y<-ScaledHeight) makeInactive();
                        break;
                }
            }
        }
        static internal void launchDiver()
        {
            int numSubs = 1;
            for (int i = 0; i < numSubs; i++)
            {
                Diver sub = Diver.getNextAvailable();
                if (sub != null)
                {
                    sub.Scale = G.randD(0.15,0.25);
                    sub.X = G.randD(G.gameWidth * 0.25, G.gameWidth * 0.75);
                    sub.Y = -sub.ScaledHeight;
                    sub.dX = 0.0;
                    sub.dY = 4.0;
                    sub.status = "Down";
                }
            }
        }
 
    }
}
