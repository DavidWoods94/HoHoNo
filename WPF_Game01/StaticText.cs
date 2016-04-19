
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
    class StaticText : GameText
    {
        internal StaticText(string text, double percentageX, double percentageY, double fontSize, Color color)
            : base()
        {
            FontFamily = "Arial Black";
            Height = 100.0;
            Width = 1200.0;
            TextAlignment = TextAlignment.Center;
            FontSize = fontSize;

            Text = text;

            Y = G.gameHeight * percentageY;
            X = G.gameWidth * percentageX;

            dX = 0.0;
            dY = 0.0;

            Scale = 0.75;

            ((TextBlock)(element)).Foreground = new SolidColorBrush(color);

            AddToGame();
        }


        internal override void update()
        {
        }

    }
}
