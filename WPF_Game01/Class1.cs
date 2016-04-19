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
    class Bullet : GameObject
    {

        public static MediaPlayer exploSound = null;
        public static MediaPlayer exploSound2 = null;
        static BitmapImage bMap1 = null;
        static BitmapImage bMap2 = null;
        public static List<Bullet> list = new List<Bullet>();

        public Bullet()
        {

            G.SetupSound(ref exploSound2, "implosion3.wav");
            G.SetupSound(ref exploSound, "meltsound.wav");
            exploSound.Volume = 0.2;
            UseImage("candycane.png", ref bMap1);
            Scale = 0.1;
            //UseImage("SmithsonSkull002.png", ref bMap2);
            Ellipse baseElement = new Ellipse();
            //baseElement.Fill = Brushes.LightYellow;
            //baseElement.Height = 10;
            //baseElement.Width = 10;


            //element = baseElement;

            makeInactive();

            Bullet.list.Add(this);

            AddToGame();

        }


        public static Bullet getNextAvailable()
        {
            foreach (Bullet b in list)
            {
                if (!b.isActive)
                {
                    return b;
                }
            }
            return null;
        }

        public void initializeSpeed()
        {
            dY = 0;
            dX = 10;
        }

        
        double gravity = 0.0;
        double friction = 1.01;


        public int frameCount = 0;

        public static bool poweredUp = false;
        public static int powerTime = 0;
        internal override void update()
        {
            if (isActive)
            {
                if(poweredUp)
                {
                    Scale = .5;
                    powerTime--;
                    if(powerTime <= 0)
                    {
                        poweredUp = false;
                    }
                }
                else
                {
                    
                    Scale = .1;
                }
                frameCount--;
                if (frameCount <= 0) makeInactive();
                dY += gravity;
                if (Y < 0.0) makeInactive();
                else if (Y > G.gameHeight) makeInactive();
                else if (X < 0.0) makeInactive();
                else if (X > G.gameWidth) makeInactive();
                
                //dX *= friction;
                dY *= friction;
                X += dX;
                Y += dY;
                Angle +=11;
                //Particle.startBulletParticles(this);
                foreach (Nit z in Nit.listNits)
                {
                    if (G.checkCollision(this, z))
                    {
                        exploSound2.Stop();
                        exploSound2.Play();
                        
                        //z.makeInactive();
                        z.hp--;
                        this.dX = G.randD(-10.0, 10.0);
                        this.dY = G.randD(-10.0, 10.0);
                        frameCount = 15;
                        z.Kill();
                    }
                }

                foreach(BigNit b in BigNit.listBigNits)
                {
                    if(G.checkCollision(this, b))
                    {
                        exploSound.Stop();
                        exploSound.Play();
                        b.hp--;
                        this.dX = G.randD(-10.0, 10.0);
                        this.dY = G.randD(-10.0, 10.0);
                        frameCount = 15;
                    }
                }
            }
        }

    }
}
