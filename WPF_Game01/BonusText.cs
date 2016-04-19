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
    class BonusText : GameText
    {

        public BonusText()
            : base()
        {
            FontFamily = "Arial Black";
            Height = 100.0;
            Width = 1000.0;
            TextAlignment = TextAlignment.Center;
            FontSize = 100;

            Y = 100.0;
            X = (G.gameWidth / 10)*8;

            dX = 0.0;
            dY = 0.0;

            Scale = 0.5;

            ((TextBlock)(element)).Foreground = new SolidColorBrush(G.randLightColor());

            AddToGame();
        }




        internal override void update()
        {
            Text = "Bonus X: " + G.gameEngine.bonus.ToString();
        }

    }
}
