
//************************************************
//
// (c) Copyright 2015 Dr. Thomas Fernandez
//
// All rights reserved.
//
//************************************************

using System;
using System.Collections.Generic;
using System.IO;
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
    class PowerUp : GameObject
    {
        static BitmapImage bMap1 = null;
        static BitmapImage bMap2 = null;

        static MediaPlayer pistolSound = null;
        static MediaPlayer bigExploSound = null;
        static public MediaPlayer gameOverSound = null;
        public static List<PowerUp> powerList = new List<PowerUp>();
        public static int activeNits = 0;
        public int hp;
        public int MAXHP = 1;
        public PowerUp()
        {
            G.SetupSound(ref pistolSound, "pistolshotSoft.wav");
            G.SetupSound(ref bigExploSound, "bell.wav");
            G.SetupSound(ref gameOverSound, "GameOver.wav");

            UseImage("present.png", ref bMap1);
            

            hp = MAXHP;

            Scale = 0.3;
            acceleration = 1;
            //X = G.randD(ScaledWidth / 2.0, G.gameWidth - ScaledWidth / 2.0);
            //SetInMiddle();
            Random rand = new Random();
            int num = rand.Next(2);

            //SetSpeed();
            if (G.chance(.5))
            {
                SetRight();
                //movingRight = false;
            }
            else
            {
                SetLeft();
                //movingRight = true;
            }

            //dX = 300;
            powerList.Add(this);
            dY = 0.0;
            //if(G.chance(.5))
            {
                makeInactive();

            }
            //else 
            {
                //activeNits++; 
            }
            AddToGame();
        }

        public static PowerUp getNextAvailable()
        {
            foreach (PowerUp b in powerList)
            {
                if (!b.isActive)
                {

                    return b;
                }
            }
            return null;
        }
        static internal void SendPowerUp()
        {
            int numBigNit = 1;
            for (int i = 0; i < numBigNit; i++)
            {
                PowerUp n = PowerUp.getNextAvailable();
                if (n != null)
                {

                    if (G.chance(.5))
                    {
                        n.SetLeft();
                        n.movingRight = true;
                        //n.SetSpeed();
                    }
                    else
                    {
                        n.SetRight();
                        n.movingRight = false;
                        //n.SetSpeed();
                    }
                }
            }
        }
        public void SetSpeed()
        {
            if (G.chance(.3))
            {
                acceleration = 2;
            }
            else if (G.chance(.3))
            {
                acceleration = 3.5;
            }
            else
            {
                acceleration = 4.5;
            }
        }

        public void SetInMiddle()
        {
            X = G.gameWidth / 2.0;
            Y = G.gameHeight - (ScaledHeight / 2.0) - 10.0;
        }

        public void SetRight()
        {
            X = G.gameWidth;
            Y = G.gameHeight / 2 + 100;
            movingRight = false;
        }

        public void SetLeft()
        {
            X = -20;
            Y = G.gameHeight/2 + 100;
            movingRight = true;
        }

        double gravity = 1.0;
        double friction = 0.0;
        double acceleration = 1.0;

        int frameCount = 0;
        public bool movingRight = false;
        public int sheildFrameCount = 0;
        public bool isSheildOn = false;

        internal override void update()
        {
            if (isActive)
            {
                X += dX;
                if (dY != 0.0) dY += gravity;
                //dY += gravity;
                Y += dY;
                dX *= friction;
                //sheildFrameCount--;
                frameCount++;

                if (Y > G.gameHeight - (ScaledHeight / 2.0) - 10.0)
                {
                    Y = G.gameHeight - (ScaledHeight / 2.0) - 10.0;
                    dY = 0.0;
                }
                else if (Math.Abs(Y - (G.gameHeight - (ScaledHeight / 2.0) - 10.0)) < 0.00000001)
                {
                }
                if (X > G.gameWidth - Width) dX = -Math.Abs(dX);
                if (X < 0) dX = Math.Abs(dX);


                foreach (Player p in Player.player)
                {
                    if (G.checkCollision(this, p))
                    {
                        bigExploSound.Stop();
                        bigExploSound.Play();
                        //Explosion explo = Explosion.getNextAvailable();

                        Bullet.poweredUp = true;
                        Bullet.powerTime = 3000;
                        makeInactive();

                        
                        //G.hiScoreText.addNewScore(G.gameEngine.score);
                    }
                }


                if (movingRight == false)
                {
                    dX -= acceleration;
                    if (X <= -20)
                    {
                        makeInactive();
                        activeNits--;
                        hp = MAXHP;
                    }
                }
                else
                {
                    dX += acceleration;
                    if (X >= G.gameWidth + 20)
                    {
                        makeInactive();
                        activeNits--;
                        hp = MAXHP;
                    }
                }

                if (hp <= 0)
                {

                    makeInactive();
                    hp = MAXHP;
                    activeNits--;
                    G.score += 10;
                }


                double maxSpeed = 20.0;

                if (dX > maxSpeed) dX = maxSpeed;
                if (dX < -maxSpeed) dX = -maxSpeed;
            }
        }
    }
}
