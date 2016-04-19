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
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFStartupDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Canvas canvas = new Canvas();

        public MainWindow()
        {
            InitializeComponent();
            this.Cursor = Cursors.None;
            this.Loaded += MainWindow_Loaded;
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Maximized;

            canvas.Background = Brushes.Aquamarine;

            mainGrid.Height = Height-40;
            mainGrid.Width = Width;
            canvas.Height = mainGrid.Height;
            canvas.Width = mainGrid.Width;

            mainGrid.Children.Add(canvas);

            this.KeyDown += MainWindow_KeyDown;

            this.KeyUp += MainWindow_KeyUp;

            this.MouseMove += MainWindow_MouseMove;
            this.MouseLeftButtonDown += MainWindow_MouseLeftButtonDown;
            this.MouseLeftButtonUp += MainWindow_MouseLeftButtonUp;

            //http://msdn.microsoft.com/en-us/library/ms750596(v=vs.110).aspx

            G.canvas = canvas;

            G.startup();

        }

        void MainWindow_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            G.MouseDown = false;
        }

        void MainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            G.MouseDown = true;
        }

        void MainWindow_MouseMove(object sender, MouseEventArgs e)
        {
            Point p = e.GetPosition(this);
            G.MouseX = p.X;
            G.MouseY = p.Y;
        }


        void MainWindow_KeyUp(object sender, KeyEventArgs e)
        {
            int keyNum = (int)e.Key;
            G.keyPressed[keyNum] = false;
        }

        void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            int keyNum=(int) e.Key;
            G.keyPressed[keyNum] = true;
        }



    }
}