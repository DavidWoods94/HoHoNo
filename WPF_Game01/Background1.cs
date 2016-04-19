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
    class Background1 : GameObject
    {

        static BitmapImage bMap = null;

        internal Background1()
        {

            UseImage("ice.jpg", ref bMap);

            X = G.gameWidth / 2.0;
            Y = G.gameHeight / 2.0;

            

 
            Scale = 2.0;
            AddToGame();

        }


        internal override void update()
        {
            X += dX;
        }

    }
}
