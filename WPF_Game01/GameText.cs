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
    internal class GameText : GameObject
    {
        internal GameText()
        {
            TextBlock baseElement = new TextBlock();
            baseElement.Height = 10;
            baseElement.Width = 10;
            element = baseElement;
        }
        internal GameText(string text, double percentageX, double percentageY, double fontSize, Color color): this()
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

        internal Color FontColor
        {
            set
            {
                ((TextBlock)(element)).Foreground = new SolidColorBrush(value);

            }
         }
        internal double FontSize
        {
            set
            {
                ((TextBlock)element).FontSize = value;
            }
            get
            {
                return ((TextBlock)element).FontSize;
            }
        }
        internal string FontFamily
        {
            set
            {
                ((TextBlock)element).FontFamily = new FontFamily(value);
            }
        }
        internal TextAlignment TextAlignment
        {
            set
            {
                ((TextBlock)element).TextAlignment = value;
            }
        }
        internal string Text
        {
            get
            {
                return ((TextBlock)element).Text;
            }
            set
            {
                ((TextBlock)element).Text = value;
            }
        }
    }
}
