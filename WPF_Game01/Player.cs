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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFStartupDemo
{
    class Player : GameObject
    {

        static BitmapImage bMap1 = null;
        static BitmapImage bMap2 = null;

        static MediaPlayer pistolSound = null;
        static MediaPlayer bigExploSound = null;
        static public MediaPlayer gameOverSound = null;
        static public List<Player> player = new List<Player>();
        public Player()
        {
            G.SetupSound(ref pistolSound, "pistolshotSoft.wav");
            G.SetupSound(ref bigExploSound, "hohoho.wav");
            G.SetupSound(ref gameOverSound, "GameOver.wav");

            UseImage("santaleft.png", ref bMap1);
            UseImage("santaright.png", ref bMap2);
            player.Add(this);


            Scale = 0.25;

            //X = G.randD(ScaledWidth / 2.0, G.gameWidth - ScaledWidth / 2.0);
            SetInMiddle();

            dX = 0.0;
            dY = 0.0;

            AddToGame();

        }

        public void SetInMiddle()
        {
            X = G.gameWidth / 2.0;
            Y = G.gameHeight - (ScaledHeight / 2.0) - 10.0;
        }


        double gravity = 1.0;
        double friction = 0.92;
        double acceleration = 0.4;

        int frameCount = 0;
        bool jumping = false;
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
                sheildFrameCount--;
                frameCount++;

                if (Y > G.gameHeight - (ScaledHeight / 2.0)-10.0)
                {
                    Y = G.gameHeight - (ScaledHeight / 2.0) -10.0;
                    dY = 0.0;
                }
                else if (Math.Abs(Y-(G.gameHeight - (ScaledHeight / 2.0)-10.0))<0.00000001)
                {
                }
                if (X > G.gameWidth) dX = -Math.Abs(dX);
                if (X < 0) dX = Math.Abs(dX);
                if (G.isKeyPressed(Key.A))
                {
                    //G.gameEngine.autoShoot = true;
                }
                if (G.isKeyPressed(Key.S))
                {
                    //G.gameEngine.autoShoot = false;
                }
                if (G.isKeyPressed(Key.Left))
                {
                    ((Image)element).Source = bMap1;
                    if (dX > 0.0) dX = 0.0;
                    dX -= acceleration;
                }
                if (G.isKeyPressed(Key.Right))
                {
                    ((Image)element).Source = bMap2;
                    if (dX < 0.0) dX = 0.0;
                    dX += acceleration;
                }
                if (G.isKeyPressed(Key.Down))
                {
                    dX = 0.0;
                }
                if (G.isKeyPressed(Key.Up) && jumping == false)
                {
                    jumping = true;
                    dY = -20;
                }
                if(dY == 0)
                {
                    jumping = false;
                }

                foreach (Nit z in Nit.listNits)
                {
                    if (G.checkCollision(this, z))
                    {
                        bigExploSound.Stop();
                        bigExploSound.Play();
                        //Explosion explo = Explosion.getNextAvailable();
                        Explosion exp = Explosion.getNextAvailable();
                        if (exp != null)
                        {
                            exp.X = z.X;
                            exp.Y = z.Y;
                        }
                        makeInactive();
                       
                        G.gameOver = true;
                        //G.hiScoreText.addNewScore(G.gameEngine.score);
                    }
                }
                foreach(BigNit b in BigNit.listBigNits)
                {
                    if (G.checkCollision(this, b))
                    {
                        bigExploSound.Stop();
                        bigExploSound.Play();
                        //Explosion explo = Explosion.getNextAvailable();

                        makeInactive();

                        G.gameOver = true;
                        //G.hiScoreText.addNewScore(G.gameEngine.score);
                    }
                }



                if ((G.isKeyPressed(Key.Space)) && (frameCount > 6))
                {
                    frameCount = 0;
                    Bullet b = Bullet.getNextAvailable();
                    if (b != null)
                    {
                        double randomness = 0.5;
                        
                        b.X = X;
                        b.Y = Y - (ScaledHeight / 2.0) +10;
                        b.initializeSpeed();
                        b.dX = dX;
                        b.dX += G.randDRange(randomness);
                        b.dY += G.randDRange(randomness);
                        b.frameCount = 1000;
                    }
                }
                double maxSpeed = 20.0;

                if (dX > maxSpeed) dX = maxSpeed;
                if (dX < -maxSpeed) dX = -maxSpeed;

               

            }
        }

    }
}
