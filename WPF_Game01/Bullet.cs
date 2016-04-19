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
    class Bullet : GameObject
    {

        public static MediaPlayer exploSound = null;

        public static List<Bullet> list = new List<Bullet>();

        public Bullet()
        {

            G.SetupSound(ref exploSound, "implosion3.wav");
            exploSound.Volume = 0.2;

            Ellipse baseElement = new Ellipse();
            baseElement.Fill = Brushes.LightYellow;
            baseElement.Height = 10;
            baseElement.Width = 10;


            element = baseElement;

            makeInactive();

            Bullet.list.Add(this);

            AddToGame();

        }


        public static Bullet getNextAvailable()
        {
            foreach(Bullet b in list )
            {
                if(!b.isActive)
                {
                    return b;
                }
            }
            return null;
        }

        public void initializeSpeed()
        {
            dY= -10.0;
            dX = 0.0;
        }


        double gravity = 0.0;
        double friction = 1.01;


        public int frameCount = 0;


        internal override void update()
        {
            if (isActive)
            {
                frameCount--;
                if (frameCount <= 0) makeInactive();
                dY += gravity;
                if (Y < 0.0) makeInactive();
                else if (Y > G.gameHeight) makeInactive();
                else if (X < 0.0) makeInactive();
                else if (X > G.gameWidth) makeInactive();
                dX *= friction;
                dY *= friction;
                X += dX;
                Y += dY;
                //Particle.startBulletParticles(this);
                foreach (BouncingBall bb in BouncingBall.list)
                {
                    if(G.checkCollision(this,bb))
                    {
                        exploSound.Stop();
                        exploSound.Play();
                        bb.state = "Hit";
                        this.dX = G.randD(-10.0, 10.0);
                        this.dY = G.randD(-10.0, 10.0);
                        frameCount = 15;
                    }
                }
            }
        }

    }
}
