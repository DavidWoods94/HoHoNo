﻿
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
    class MousePlayer : GameObject
    {

        static BitmapImage bMap1 = null;
        static BitmapImage bMap2 = null;

        static MediaPlayer pistolSound = null;
        static MediaPlayer bigExploSound = null;
        static public MediaPlayer gameOverSound = null;

        public MousePlayer()
        {
            G.SetupSound(ref pistolSound, "pistolshotSoft.wav");
            G.SetupSound(ref bigExploSound, "implosion2.wav");
            G.SetupSound(ref gameOverSound, "GameOver.wav");

            UseImage("shooter.png", ref bMap1);
            UseImage("SmithsonSkull002.png", ref bMap2);



            Scale = 0.75;

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


        int frameCount = 0;

        public int sheildFrameCount = 0;
        public bool isSheildOn = false;

        internal override void update()
        {
            if (isActive)
            {
                X = G.MouseX;
                Y = G.MouseY;
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
                if (X > G.gameWidth - Width) dX = -Math.Abs(dX);
                if (X < 0) dX = Math.Abs(dX);
                if (G.isKeyPressed(Key.A))
                {
                    //G.gameEngine.autoShoot = true;
                }
                if (G.isKeyPressed(Key.S))
                {
                    //G.gameEngine.autoShoot = false;
                }
                if (G.MouseDown)
                {
                    ((Image)element).Source = bMap1;
                }
                else
                {
                    ((Image)element).Source = bMap2;
                }
                if (G.isKeyPressed(Key.Down))
                {
                    dX = 0.0;
                }
                if (G.isKeyPressed(Key.Up))
                {
                    dY = -10.1;
                }
                //if ((G.isKeyPressed(Key.Space) || G.gameEngine.autoShoot) && (frameCount > 6))
                //{
                //    frameCount = 0;
                //    Bullet b = Bullet.getNextAvailable();
                //    if (b != null)
                //    {
                //        double randomness = 0.5;
                //        if (!G.gameEngine.autoShoot)
                //        {
                //            pistolSound.Stop();
                //            pistolSound.Play();
                //        }
                //        b.X = X;
                //        b.Y = Y - (ScaledHeight / 2.0);
                //        b.initializeSpeed();
                //        b.dX = dX;
                //        b.dX += G.randDRange(randomness);
                //        b.dY += G.randDRange(randomness);
                //        b.frameCount = 1000;
                //    }
                //}
                double maxSpeed = 20.0;

                if (dX > maxSpeed) dX = maxSpeed;
                if (dX < -maxSpeed) dX = -maxSpeed;

                if (sheildFrameCount <= 0)
                {
                    isSheildOn = false;
                    Scale = 0.75;
                }

                if (!isSheildOn)
                {
                    sheildFrameCount = 0;
                    //foreach (BouncingBall bb in BouncingBall.list)
                    //{
                    //    if (G.checkCollision(this, bb))
                    //    {
                    //        bigExploSound.Stop();
                    //        bigExploSound.Play();
                    //        Explosion explo = Explosion.getNextAvailable();
                    //        if (explo != null)
                    //        {
                    //            explo.Scale = 1.0;
                    //            explo.exploLength = 30;
                    //            explo.X = X;
                    //            explo.Y = Y;
                    //        }
                    //        makeInactive();
                    //        GameEngine.bigGameText.Text = "Game Over!\nEsc to play again";
                    //        G.gameEngine.gameNotOver = false;
                    //        GameEngine.hiScoreText.addNewScore(G.gameEngine.score);
                    //    }
                    //}
                }
                else
                {
                    //Bubble.startBulletParticles(this);
                }

            }
        }

    }
}
