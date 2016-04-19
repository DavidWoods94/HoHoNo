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
using System.Windows.Shapes;

namespace WPFStartupDemo
{
    class Tail : GameObject
    {
        internal static List<Tail> list = new List<Tail>();

        SolidColorBrush _bodyBrush = Brushes.Yellow;

        internal SolidColorBrush bodyBrush
        {
            get
            {
                return _bodyBrush;
            }
            set
            {
                _bodyBrush = value;
                ((Ellipse)element).Fill = _bodyBrush;
            }
        }


        internal Tail()
        {


            Ellipse baseElement = new Ellipse();

            baseElement.Stroke = Brushes.DarkGray;
            baseElement.StrokeThickness = 2.0;

            baseElement.Height = 10;
            baseElement.Width = 10;

            element = baseElement;

            bodyBrush = Brushes.Gray;

            Scale = 1.0;

            makeInactive();

            Tail.list.Add(this);

            AddToGame();

        }

        static int lastFound = -1;
        internal static Tail getNextAvailable()
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


        internal int frameCount = 0;

        internal override void update()
        {
            Scale *= 0.95;
            if (isActive)
            {
                frameCount--;
                if (frameCount <= 0)
                {
                    makeInactive();
                }
            }
        }

    }
}
