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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WPFStartupDemo
{
    class RoundText : GameText
    {

        public RoundText()
            : base()
        {
            FontFamily = "Arial Black";
            Height = 100.0;
            Width = 1000.0;
            TextAlignment = TextAlignment.Center;
            FontSize = 100;

            Y = G.gameHeight * 0.1;
            X = G.gameWidth * 0.5;

            dX = 0.0;
            dY = 0.0;

            Scale = 0.75;

            ((TextBlock)(element)).Foreground = new SolidColorBrush(G.randLightColor());

            AddToGame();
        }




        internal override void update()
        {
        }

    }
}
